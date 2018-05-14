using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using LiveSplit.UI.Components;
using LiveSplit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace LiveSplit.BM
{
    class BMComponent : LogicComponent
    {
        public override string ComponentName
        {
            get { return "BM"; }
        }

        public BMSettings Settings { get; set; }

        public bool Disposed { get; private set; }
        public bool IsLayoutComponent { get; private set; }

        private TimerModel _timer;
        private GameMemory _gameMemory;
        private LiveSplitState _state;


        public BMComponent(LiveSplitState state, bool isLayoutComponent)
        {
            _state = state;
            this.IsLayoutComponent = isLayoutComponent;

            this.Settings = new BMSettings();

            _timer = new TimerModel { CurrentState = state };
            _timer.CurrentState.OnStart += timer_OnStart;

            _gameMemory = new GameMemory(this.Settings);

            _gameMemory.OnSplitCompleted += gameMemory_OnSplitCompleted;
            _gameMemory.OnFirstLevelLoaded += _gameMemory_OnFirstLevelLoaded;
            _gameMemory.IsLoadingChanged += _gameMemory_IsLoadingChanged;

            state.OnStart += State_OnStart;
            state.OnReset += State_OnReset;
            resetSplitStates();
            _gameMemory.StartMonitoring();

        }

        private void State_OnReset(object sender, TimerPhase value)
        {
            Debug.WriteLine($"Reset");
            resetSplitStates();
        }

        private void _gameMemory_IsLoadingChanged(bool arg1, bool arg2)
        {
            if (arg2)
            {
                Debug.WriteLine($"Pausing");
                _state.IsGameTimePaused = true;
                
            }
            if (!arg2)
            {
                Debug.WriteLine($"Unpausing");
                _state.IsGameTimePaused = false;
            }
        }

        private void _gameMemory_OnFirstLevelLoaded(object sender, EventArgs e)
        {
            if (_state.CurrentPhase == TimerPhase.NotRunning)
            {
                if (this.Settings.AutoReset)
                {
                    Debug.WriteLine($"Restting");
                    _timer.Reset();
                }
            }
            if (this.Settings.AutoStart)
            {
                Debug.WriteLine($"strating timer");
                _timer.Start();
            }
        }

        private void timer_OnStart(object sender, EventArgs e)
        {
            _timer.InitializeGameTime();
        }

        public override void Dispose()
        {
            this.Disposed = true;

            _state.OnStart -= State_OnStart;
            _timer.CurrentState.OnStart -= timer_OnStart;

            if (_gameMemory != null)
            {
                _gameMemory.Stop();
            }

        }

        public Dictionary<SplitArea, bool> splitStates = new Dictionary<SplitArea, bool>();

        private void resetSplitStates()
        {
            foreach (SplitArea sa in Enum.GetValues(typeof(SplitArea)))
            {
                splitStates[sa] = false;
            }
        }

        void State_OnStart(object sender, EventArgs e)
        {
           resetSplitStates();
        }
        
        void gameMemory_OnSplitCompleted(object sender, SplitArea? split, uint frame)
        {   
            if (_state.CurrentPhase == TimerPhase.Running &&
                !splitStates[split.Value] &&
                (bool)this.Settings.SplitSettings[split.Value])
            {
                Trace.WriteLine(String.Format("[NoLoads] {0} Split - {1}", split, frame));
                _timer.Split();
                splitStates[split.Value] = true;
            }
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return this.Settings.GetSettings(document);
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return this.Settings;
        }

        public override void SetSettings(XmlNode settings)
        {
            this.Settings.SetSettings(settings);
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
        //public override void RenameComparison(string oldName, string newName) { }
    }
}
