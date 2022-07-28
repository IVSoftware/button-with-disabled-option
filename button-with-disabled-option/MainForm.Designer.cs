
namespace button_with_disabled_option
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // this.buttonWithDisableOption = new System.Windows.Forms.Button();
            this.buttonWithDisableOption = new button_with_disabled_option.ButtonWithDisableOption();

            this.checkBoxButtonEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonWithDisableOption
            // 
            this.buttonWithDisableOption.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWithDisableOption.Enabled = false;
            this.buttonWithDisableOption.Location = new System.Drawing.Point(27, 45);
            this.buttonWithDisableOption.Name = "buttonWithDisableOption";
            this.buttonWithDisableOption.Size = new System.Drawing.Size(250, 35);
            this.buttonWithDisableOption.TabIndex = 0;
            this.buttonWithDisableOption.Text = "Button with Disable Option";
            this.buttonWithDisableOption.UseVisualStyleBackColor = true;
            // 
            // checkBoxButtonEnabled
            // 
            this.checkBoxButtonEnabled.AutoSize = true;
            this.checkBoxButtonEnabled.Location = new System.Drawing.Point(27, 146);
            this.checkBoxButtonEnabled.Name = "checkBoxButtonEnabled";
            this.checkBoxButtonEnabled.Size = new System.Drawing.Size(159, 29);
            this.checkBoxButtonEnabled.TabIndex = 1;
            this.checkBoxButtonEnabled.Text = "Button Enabled";
            this.checkBoxButtonEnabled.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 244);
            this.Controls.Add(this.checkBoxButtonEnabled);
            this.Controls.Add(this.buttonWithDisableOption);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // private System.Windows.Forms.Button button1;
        private button_with_disabled_option.ButtonWithDisableOption buttonWithDisableOption;
        private System.Windows.Forms.CheckBox checkBoxButtonEnabled;
    }
}

