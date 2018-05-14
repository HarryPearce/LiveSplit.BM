using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;


namespace LiveSplit.BM
{  
    public partial class BMSettings : UserControl
    {
        public bool AutoReset { get; set; }
        public bool AutoStart { get; set; }
        public Dictionary<SplitArea, bool> SplitSettings = new Dictionary<SplitArea, bool>();
        public Dictionary<SplitArea, CheckBox> SplitSettingsCheckboxes = new Dictionary<SplitArea, CheckBox>();

        public SplitArea? FirstLevel = null;

        public BMSettings()
        {
            InitializeComponent();

            this.chkAutoReset.DataBindings.Add("Checked", this, "AutoReset", false, DataSourceUpdateMode.OnPropertyChanged);
            this.chkAutoStart.DataBindings.Add("Checked", this, "AutoStart", false, DataSourceUpdateMode.OnPropertyChanged);

            foreach (SplitArea split in Enum.GetValues(typeof(SplitArea)))
            {
                if (SplitSettings.ContainsKey(split))
                    continue;
                var splitName = Enum.GetName(typeof(SplitArea), split);
               
                var checkBox = this.GetType().GetField($"chk{((int)split).ToString("D2")}", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this) as CheckBox;
                checkBox.CheckedChanged += (src,ea) => { SplitSettings[split] = ((CheckBox)src).Checked; RecalcFirstLevel(); };
                SplitSettings[split] = true;
                SplitSettingsCheckboxes[split] = checkBox;
            }

            // defaults
            SplitSettings[SplitArea.DeathOfAShowman] = false;
            AutoReset = true;
            AutoStart = true;
        }

        private void RecalcFirstLevel()
        {
            try
            {
                FirstLevel = SplitSettings.ToList().Where(el => (bool)el.Value).OrderBy(el => (int)el.Key).First().Key;
            }
            catch
            {
                FirstLevel = null;
            }
        }

        public XmlNode GetSettings(XmlDocument doc)
        {
            XmlElement settingsNode = doc.CreateElement("Settings");

            settingsNode.AppendChild(ToElement(doc, "Version", Assembly.GetExecutingAssembly().GetName().Version.ToString(3)));

            settingsNode.AppendChild(ToElement(doc, "AutoReset", this.AutoReset));
            settingsNode.AppendChild(ToElement(doc, "AutoStart", this.AutoStart));

            foreach(var kvp in SplitSettings.ToArray())
            {
                settingsNode.AppendChild(ToElement(doc, kvp.Key.ToString("g"), kvp.Value));
            }
                      
            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            this.AutoReset = ParseBool(settings, "AutoReset", true);
            this.AutoStart = ParseBool(settings, "AutoStart", true);

            foreach (SplitArea split in Enum.GetValues(typeof(SplitArea)))
            {            
                SplitSettings[split] = ParseBool(settings, split.ToString("g"), true);
                SplitSettingsCheckboxes[split].Checked = SplitSettings[split];
            }            
        }

        static bool ParseBool(XmlNode settings, string setting, bool default_ = false)
        {
            bool val;
            return settings[setting] != null ?
                (Boolean.TryParse(settings[setting].InnerText, out val) ? val : default_)
                : default_;
        }

        static XmlElement ToElement<T>(XmlDocument document, string name, T value)
        {
            XmlElement str = document.CreateElement(name);
            str.InnerText = value.ToString();
            return str;
        }       

        private void chkAutoReset_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chk00_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
