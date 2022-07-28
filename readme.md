# button-with-disabled-option
Custom button with a DisabledClick event

Whenever a standard control doesn't behave in exactly the way that need it to, all we usually have to do is make our own version that _inherits_ the standard control so that we can **make it do whatever we want**. In this case, the question was "how to make a popup when the disabled button is clicked".

Here is a guideline example for a custom `Button` that:

1. Intercepts the `Enabled` property by declaring it `new`.
1. Leaves the base class button always responsive because it's always enabled.
2. Paints the control as dimmed if disabled.
3. Suppresses the firing of the `Click` event if disabled, and fires `DisabledClick` instead.

*Look in the Title Bar to see when the button is clicked.* 

![screenshot](https://github.com/IVSoftware/button-with-disabled-option/blob/master/button-with-disabled-option/ReadMe/screenshot.png)

***
**`ButtonWithDisabledOption class`**


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

***
**MainForm.Designer.cs**

Be sure to replace `Button` references with `ButtonWithDisabledOption`.


    private void InitializeComponent()
    {
        // this.buttonWithDisableOption = new System.Windows.Forms.Button();
        this.buttonWithDisableOption = new button_with_disabled_option.ButtonWithDisableOption();
        ...
    }

    // private System.Windows.Forms.Button button1;
    private button_with_disabled_option.ButtonWithDisableOption buttonWithDisableOption;

***
**TEST**

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
