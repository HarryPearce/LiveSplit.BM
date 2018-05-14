using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.ComponentUtil;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.ComponentModel;
using System.Collections;

namespace LiveSplit.BM
{   

    public enum SplitArea : int
    {
        DeathOfAShowman = 0,
        AVintageYear = 1,
        CurtainsDown = 3,
        Flatline = 4,
        ANewLife = 5,
        TheMurderOfCrows = 6,
        YouBetterWatchOut = 2,
        DeathOnTheMississippi = 8,
        TillDeathDoUsPart = 9,
        AHousOfCards = 10,
        ADanceWithTheDevil = 11,
        AmendmentXXV = 12,
        Requiem = 13
    }

    class GameMemory
    {       
        public event EventHandler OnFirstLevelLoaded;        

        public delegate void SplitCompletedEventHandler(object sender, SplitArea? type, uint frame);
        public event SplitCompletedEventHandler OnSplitCompleted;

        private Task _thread;
        private CancellationTokenSource _cancelSource;
        private SynchronizationContext _uiThread;
        private List<int> _ignorePIDs;
        private BMSettings _settings;
       
        private DeepPointer _MenuLoadingScreenProgress;        
        private DeepPointer _IsNotLoading;
        private DeepPointer _IsSavingOrLoading;
        private DeepPointer _CurrentScene;
        private DeepPointer _Timer;
        private DeepPointer _Stats;
        
        private Dictionary<SplitArea, string> PostMissionSceneNames = new Dictionary<SplitArea, string>()

        {
            {SplitArea.DeathOfAShowman,"news"},

        };


        private bool _IsLoading = false;
        public event Action<bool,bool> IsLoadingChanged;
        public bool IsLoading
        {
            get
            {
                return _IsLoading;
            }
            set
            {
                if (value != _IsLoading)
                {
                    _IsLoading = value;
                    _uiThread.Post(d =>
                    {
                        IsLoadingChanged?.Invoke(!value,value);
                    }, null);
                   
                }
            }
        }

        public SplitArea? CurrentLevel = null;

        private enum ExpectedDllSizes
        {
            HMASteam = 36777984,
        }

       


        public GameMemory(BMSettings componentSettings)
        {
            _settings = componentSettings;           
          
            _MenuLoadingScreenProgress = new DeepPointer(0x509F38);//float, 0-1          
            _IsNotLoading = new DeepPointer(0x0041F820, 0x7BC, 0x2C4, 0x84, 0x20, 0x4C);//float, 0 if loading, >0 if not loding
            _IsSavingOrLoading = new DeepPointer(0x00E39520, 0x38); //float, 7 if saving or loading, 0 otherwise. Can be null
            _CurrentScene = new DeepPointer(0x004B3FC0, 0x20C, 2); // scenes?? 
            _Timer = new DeepPointer(0x0041F820, 0x48);
            _Stats = new DeepPointer(0x005B2538);
           
            
            _ignorePIDs = new List<int>();
        }

        public void StartMonitoring()
        {
            if (_thread != null && _thread.Status == TaskStatus.Running)
            {
                throw new InvalidOperationException();
            }
            if (!(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
            {
                throw new InvalidOperationException("SynchronizationContext.Current is not a UI thread.");
            }

            _uiThread = SynchronizationContext.Current;
            _cancelSource = new CancellationTokenSource();
            _thread = Task.Factory.StartNew(MemoryReadThread);
        }

        public void Stop()
        {
            if (_cancelSource == null || _thread == null || _thread.Status != TaskStatus.Running)
            {
                return;
            }

            _cancelSource.Cancel();
            _thread.Wait();
        }

        void MemoryReadThread()
        {
            Debug.WriteLine("[NoLoads] MemoryReadThread");

            while (!_cancelSource.IsCancellationRequested)
            {
                try
                {
                    Debug.WriteLine("[NoLoads] Waiting for HMA.exe...");
                    uint frameCounter = 0;
                    
                    Process game;
                    while ((game = GetGameProcess()) == null)
                    {
                        Thread.Sleep(250);
                        if (_cancelSource.IsCancellationRequested)
                        {
                            return;
                        }
                    }

                    Debug.WriteLine("[NoLoads] Got games process!");
                                      
                    float prevMenuLoadingScreenProgress = -1;
                    float prevIsInGameOrMenu = -1;
                    float prevIsNotLoading = -1;
                    float prevIsSavingOrLoading = -1;
                    int prevTimer = -1;


                    string prevCurrentScene = null;
                  
                    float menuLoadingScreenProgress = -1;
                    float isInGameOrMenu = -1;
                    float isNotLoading = -1;
                    float isSavingOrLoading = -1;
                    int timer = -1;

                    string currentScene = "";
                    bool finalSplitFlag = false;
                    Stats stats;

                    while (!game.HasExited && !_cancelSource.IsCancellationRequested)
                    {
                        currentScene = "";
                                              
                        bool isMenuLoadingScreenProgressValid = _MenuLoadingScreenProgress.Deref(game, out menuLoadingScreenProgress);                       
                        bool isIsNotLoadingValid = _IsNotLoading.Deref(game, out isNotLoading);
                        bool isIsSavingOrLoadingValid = _IsSavingOrLoading.Deref(game, out isSavingOrLoading);
                        bool isCurrentSceneValid = _CurrentScene.DerefString(game, 50, out currentScene);
                        bool isTimerValid = _Timer.Deref(game, out timer);
                        bool isStatsValid = _Stats.Deref<Stats>(game, out stats);
                        var scene = currentScene?.ToLower();

                        if (isCurrentSceneValid && currentScene != prevCurrentScene)
                        {
                            Debug.WriteLine($"Scene changed to {currentScene}");
                            if (scene.Contains("premission") || scene.Contains("intro"))
                            {
                                try
                                {
                                    CurrentLevel = (SplitArea)Int32.Parse(Regex.Match(scene, "m(\\d+)\\\\").Groups[1].Value);
                                    Debug.WriteLine($"Current level changed to {CurrentLevel}");
                                    if (_settings.FirstLevel.HasValue && CurrentLevel == _settings.FirstLevel)
                                    {
                                        Debug.WriteLine($"First level loaded");
                                        _uiThread.Post(d =>
                                        {
                                            OnFirstLevelLoaded?.Invoke(this,EventArgs.Empty);
                                        }, null);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    CurrentLevel = null;
                                    Debug.WriteLine(ex.ToString());
                                }
                            } else if (CurrentLevel.HasValue && ( (PostMissionSceneNames.ContainsKey(CurrentLevel.Value) && scene.Contains(PostMissionSceneNames[CurrentLevel.Value])) || scene.Contains("postmission") ) )
                            {
                                Debug.WriteLine($"Splitting {CurrentLevel.Value}");
                                Split(CurrentLevel.Value, frameCounter);
                            }
                            finalSplitFlag = false;
                        }

                        if (isStatsValid && CurrentLevel.HasValue  && CurrentLevel.Value == SplitArea.Requiem && isCurrentSceneValid && currentScene.ToLower().Contains("main") && !finalSplitFlag &&  stats.m_TargetsKilled == 13)
                        {
                            finalSplitFlag = true;
                            Split(CurrentLevel.Value, frameCounter);                           
                        }


                        if ( (isIsNotLoadingValid && isNotLoading == 0 && (scene.Contains("main") || scene.Contains("premission"))) ||
                             (isIsSavingOrLoadingValid && isSavingOrLoading != 0 && scene.Contains("saveandcontinue")) ||
                             (isMenuLoadingScreenProgressValid && menuLoadingScreenProgress != 1)
                            )
                        {
                            IsLoading = true;                         
                        } else 
                        {
                            IsLoading = false;
                        }
                       
                        prevMenuLoadingScreenProgress = isMenuLoadingScreenProgressValid ? menuLoadingScreenProgress : prevMenuLoadingScreenProgress;
                        prevIsInGameOrMenu = isMenuLoadingScreenProgressValid ? isInGameOrMenu : prevIsInGameOrMenu;
                        prevIsNotLoading = isIsNotLoadingValid ? isNotLoading : prevIsNotLoading;
                        prevIsSavingOrLoading = isIsSavingOrLoadingValid ? isSavingOrLoading : prevIsSavingOrLoading;
                        prevTimer = isTimerValid ? timer : prevTimer;
                        prevCurrentScene = isCurrentSceneValid ? currentScene : prevCurrentScene;

                        frameCounter++;

                        Thread.Sleep(15);                       
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Thread.Sleep(1000);
                }
            }
        }

        private void Split(SplitArea split, uint frame)
        {
            Debug.WriteLine(String.Format("[NoLoads] split {0} - {1}", split, frame));
            _uiThread.Post(d =>
            {
                if (this.OnSplitCompleted != null)
                {
                    this.OnSplitCompleted(this, split, frame);
                }
            }, null);
        }

        Process GetGameProcess()
        {
            Process game = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "hitmanbloodmoney" && !p.HasExited && !_ignorePIDs.Contains(p.Id));
            if (game == null)
            {
                return null;
            }
            return game;

            if (game.MainModuleWow64Safe().ModuleMemorySize != (int)ExpectedDllSizes.HMASteam)
            {
                _ignorePIDs.Add(game.Id);
                _uiThread.Send(d => MessageBox.Show("Unexpected game version. HMA Steam is required.", "LiveSplit.HMA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error), null);
                return null;
            }
            return game;

        }
    }
}
