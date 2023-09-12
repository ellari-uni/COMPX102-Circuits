namespace Circuits
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOr = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEval = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClone = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCompoundStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEndCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnd,
            this.toolStripButtonOr,
            this.toolStripButtonNot,
            this.toolStripButtonInput,
            this.toolStripButtonOutput,
            this.toolStripButtonEval,
            this.toolStripButtonClone,
            this.toolStripButtonCompoundStart,
            this.toolStripButtonEndCompound});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1344, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonAnd.Text = "toolStripButton1";
            this.toolStripButtonAnd.ToolTipText = "AND Gate";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // toolStripButtonOr
            // 
            this.toolStripButtonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOr.Image = global::Circuits.Properties.Resources.OrIcon;
            this.toolStripButtonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOr.Name = "toolStripButtonOr";
            this.toolStripButtonOr.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonOr.Text = "toolStripButton1";
            this.toolStripButtonOr.ToolTipText = "OR Gate";
            this.toolStripButtonOr.Click += new System.EventHandler(this.toolStripButtonOr_Click);
            // 
            // toolStripButtonNot
            // 
            this.toolStripButtonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNot.Image = global::Circuits.Properties.Resources.NotIcon;
            this.toolStripButtonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNot.Name = "toolStripButtonNot";
            this.toolStripButtonNot.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonNot.Text = "toolStripButton1";
            this.toolStripButtonNot.ToolTipText = "NOT Gate";
            this.toolStripButtonNot.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonInput
            // 
            this.toolStripButtonInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInput.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButtonInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInput.Name = "toolStripButtonInput";
            this.toolStripButtonInput.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonInput.Text = "toolStripButton1";
            this.toolStripButtonInput.ToolTipText = "Input Source\r\nBlue is inactive, Green is active";
            this.toolStripButtonInput.Click += new System.EventHandler(this.toolStripButtonInput_Click);
            // 
            // toolStripButtonOutput
            // 
            this.toolStripButtonOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOutput.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.toolStripButtonOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutput.Name = "toolStripButtonOutput";
            this.toolStripButtonOutput.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonOutput.Text = "toolStripButton1";
            this.toolStripButtonOutput.ToolTipText = "Output Lamp\r\nBlue is inactive, Green is active";
            this.toolStripButtonOutput.Click += new System.EventHandler(this.toolStripButtonOutput_Click);
            // 
            // toolStripButtonEval
            // 
            this.toolStripButtonEval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEval.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripButtonEval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEval.Name = "toolStripButtonEval";
            this.toolStripButtonEval.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonEval.Text = "toolStripButton1";
            this.toolStripButtonEval.ToolTipText = "Evaluate Circuit";
            this.toolStripButtonEval.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButtonClone
            // 
            this.toolStripButtonClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClone.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripButtonClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClone.Name = "toolStripButtonClone";
            this.toolStripButtonClone.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonClone.Text = "toolStripButton2";
            this.toolStripButtonClone.ToolTipText = "Clone Selected";
            this.toolStripButtonClone.Click += new System.EventHandler(this.toolStripButtonClone_Click);
            // 
            // toolStripButtonCompoundStart
            // 
            this.toolStripButtonCompoundStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCompoundStart.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.toolStripButtonCompoundStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompoundStart.Name = "toolStripButtonCompoundStart";
            this.toolStripButtonCompoundStart.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonCompoundStart.Text = "toolStripButton1";
            this.toolStripButtonCompoundStart.ToolTipText = "Start Compound Group\r\nAfter checked, clicking gates adds to group.\r\nClick End Com" +
    "pound to end this process";
            this.toolStripButtonCompoundStart.Click += new System.EventHandler(this.toolStripButtonCompoundStart_Click);
            // 
            // toolStripButtonEndCompound
            // 
            this.toolStripButtonEndCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEndCompound.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.toolStripButtonEndCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEndCompound.Name = "toolStripButtonEndCompound";
            this.toolStripButtonEndCompound.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonEndCompound.Text = "toolStripButton1";
            this.toolStripButtonEndCompound.ToolTipText = "End Compound Group\r\nEnds compound group creation\r\nMust have a Compound Group in t" +
    "he process of creation";
            this.toolStripButtonEndCompound.Click += new System.EventHandler(this.toolStripButtonEndCompound_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1344, 713);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuits 2023";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonOr;
        private System.Windows.Forms.ToolStripButton toolStripButtonNot;
        private System.Windows.Forms.ToolStripButton toolStripButtonInput;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutput;
        private System.Windows.Forms.ToolStripButton toolStripButtonEval;
        private System.Windows.Forms.ToolStripButton toolStripButtonClone;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompoundStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonEndCompound;
    }
}

