namespace StellaConfiguration.Forms
{
	sealed partial class Window
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
			linkLabel1 = new LinkLabel();
			label1 = new Label();
			checkBox4 = new CheckBox();
			checkBox5 = new CheckBox();
			checkBox6 = new CheckBox();
			label2 = new Label();
			label3 = new Label();
			checkBox7 = new CheckBox();
			label4 = new Label();
			label5 = new Label();
			SuspendLayout();
			// 
			// linkLabel1
			// 
			linkLabel1.ActiveLinkColor = Color.CornflowerBlue;
			resources.ApplyResources(linkLabel1, "linkLabel1");
			linkLabel1.BackColor = Color.Transparent;
			linkLabel1.Cursor = Cursors.Hand;
			linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
			linkLabel1.LinkColor = Color.LightSkyBlue;
			linkLabel1.Name = "linkLabel1";
			linkLabel1.TabStop = true;
			linkLabel1.LinkClicked += LetsGo_LinkClicked;
			// 
			// label1
			// 
			resources.ApplyResources(label1, "label1");
			label1.BackColor = Color.Transparent;
			label1.ForeColor = Color.FromArgb(0, 83, 167);
			label1.Name = "label1";
			// 
			// checkBox4
			// 
			resources.ApplyResources(checkBox4, "checkBox4");
			checkBox4.BackColor = Color.Transparent;
			checkBox4.Cursor = Cursors.Hand;
			checkBox4.ForeColor = Color.WhiteSmoke;
			checkBox4.Name = "checkBox4";
			checkBox4.UseVisualStyleBackColor = false;
			checkBox4.CheckedChanged += UpdateReShadeConfig_CheckedChanged;
			// 
			// checkBox5
			// 
			resources.ApplyResources(checkBox5, "checkBox5");
			checkBox5.BackColor = Color.Transparent;
			checkBox5.Cursor = Cursors.Hand;
			checkBox5.ForeColor = Color.WhiteSmoke;
			checkBox5.Name = "checkBox5";
			checkBox5.UseVisualStyleBackColor = false;
			checkBox5.CheckedChanged += UpdateFpsUnlockerConfig_CheckedChanged;
			// 
			// checkBox6
			// 
			resources.ApplyResources(checkBox6, "checkBox6");
			checkBox6.BackColor = Color.Transparent;
			checkBox6.Cursor = Cursors.Hand;
			checkBox6.ForeColor = Color.WhiteSmoke;
			checkBox6.Name = "checkBox6";
			checkBox6.UseVisualStyleBackColor = false;
			checkBox6.CheckedChanged += DeleteReShadeCache_CheckedChanged;
			// 
			// label2
			// 
			resources.ApplyResources(label2, "label2");
			label2.BackColor = Color.Transparent;
			label2.ForeColor = Color.WhiteSmoke;
			label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(label3, "label3");
			label3.BackColor = Color.Transparent;
			label3.ForeColor = Color.WhiteSmoke;
			label3.Name = "label3";
			// 
			// checkBox7
			// 
			resources.ApplyResources(checkBox7, "checkBox7");
			checkBox7.BackColor = Color.Transparent;
			checkBox7.Cursor = Cursors.Hand;
			checkBox7.ForeColor = Color.WhiteSmoke;
			checkBox7.Name = "checkBox7";
			checkBox7.UseVisualStyleBackColor = false;
			checkBox7.CheckedChanged += DownloadOrUpdateShaders;
			// 
			// label4
			// 
			resources.ApplyResources(label4, "label4");
			label4.BackColor = Color.Transparent;
			label4.ForeColor = Color.WhiteSmoke;
			label4.Name = "label4";
			// 
			// label5
			// 
			resources.ApplyResources(label5, "label5");
			label5.BackColor = Color.Transparent;
			label5.ForeColor = Color.WhiteSmoke;
			label5.Name = "label5";
			// 
			// Window
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			BackgroundImage = Properties.ImageResources.bg;
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(checkBox7);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(checkBox6);
			Controls.Add(checkBox5);
			Controls.Add(checkBox4);
			Controls.Add(label1);
			Controls.Add(linkLabel1);
			DoubleBuffered = true;
			ForeColor = Color.DodgerBlue;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "Window";
			FormClosing += Main_FormClosing;
			Load += Main_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

