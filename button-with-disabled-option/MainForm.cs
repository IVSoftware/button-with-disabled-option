using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace button_with_disabled_option
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonWithDisableOption.Enabled = checkBoxButtonEnabled.Checked = true;

            // Button events
            buttonWithDisableOption.Click += buttonWithDisableOption_Click;
            buttonWithDisableOption.DisabledClick += buttonWithDisableOption_DisabledClick;

            // CheckBox events
            checkBoxButtonEnabled.CheckedChanged += checkBoxButtonEnabled_CheckedChanged;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }
        private void checkBoxButtonEnabled_CheckedChanged(object sender, EventArgs e)
        {
            buttonWithDisableOption.Enabled = checkBoxButtonEnabled.Checked;
        }
        private void buttonWithDisableOption_Click(object sender, EventArgs e)
        {
            // Title bar
            Text = $"Button Click {_tstcount++} (Enabled)";  
        }
        private void buttonWithDisableOption_DisabledClick(object sender, EventArgs e)
        {
            var enabled = buttonWithDisableOption.Enabled ? "Enabled" : "Disabled";
            // Title bar
            Text = $"Button Click {_tstcount++} (Disabled)";
            MessageBox.Show("Button is unclickable");
        }
        int _tstcount = 1;
    }
    class ButtonWithDisableOption : Button
    {
        bool _enabled = false;
        public new bool Enabled
        {
            get => _enabled;
            set
            {
                if (!Equals(_enabled, value))
                {
                    _enabled = value;
                    OnEnabledChanged(EventArgs.Empty);
                }
            }
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if(Enabled)
            {
                ForeColor = SystemColors.ControlText;
                BackColor = SystemColors.Control;
            }
            else
            {
                ForeColor = Color.FromArgb(191, 191, 191);
                BackColor = Color.FromArgb(204, 204, 204);
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (Enabled)
            {
                base.OnClick(e);
            }
            else
            {
                DisabledClick?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler DisabledClick;
    }
}
