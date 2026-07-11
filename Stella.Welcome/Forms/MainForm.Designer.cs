namespace InfoBeforeStart.Forms
{
	sealed partial class MainForm
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
                _autoCloseTimer.Dispose();
                _timer.Dispose();
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
			components = new System.ComponentModel.Container();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			label1 = new Label();
			label2 = new Label();
			pictureBox1 = new PictureBox();
			label4 = new Label();
			label5 = new Label();
			pictureBox2 = new PictureBox();
			toolTip1 = new ToolTip(components);
			pictureBox3 = new PictureBox();
			pictureBox4 = new PictureBox();
			label6 = new Label();
			linkLabel3 = new LinkLabel();
			label3 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(label1, "label1");
			label1.BackColor = Color.Transparent;
			label1.ForeColor = Color.FromArgb(251, 211, 147);
			label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(label2, "label2");
			label2.BackColor = Color.Transparent;
			label2.ForeColor = Color.White;
			label2.Name = "label2";
			// 
			// pictureBox1
			// 
			resources.ApplyResources(pictureBox1, "pictureBox1");
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.Image = Properties.ImageResources.paimon_shock;
			pictureBox1.Name = "pictureBox1";
			pictureBox1.TabStop = false;
			// 
			// label4
			// 
			resources.ApplyResources(label4, "label4");
			label4.BackColor = Color.Transparent;
			label4.ForeColor = Color.White;
			label4.Name = "label4";
			// 
			// label5
			// 
			resources.ApplyResources(label5, "label5");
			label5.BackColor = Color.Transparent;
			label5.ForeColor = Color.White;
			label5.Name = "label5";
			// 
			// pictureBox2
			// 
			resources.ApplyResources(pictureBox2, "pictureBox2");
			pictureBox2.BackColor = Color.Transparent;
			pictureBox2.Cursor = Cursors.Hand;
			pictureBox2.Image = Properties.ImageResources.party_cat;
			pictureBox2.Name = "pictureBox2";
			pictureBox2.TabStop = false;
			pictureBox2.Click += Meow_Click;
			// 
			// pictureBox3
			// 
			resources.ApplyResources(pictureBox3, "pictureBox3");
			pictureBox3.BackColor = Color.Transparent;
			pictureBox3.Image = Properties.ImageResources.paimon_peek;
			pictureBox3.Name = "pictureBox3";
			pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			pictureBox4.BackColor = Color.Transparent;
			pictureBox4.Image = Properties.ImageResources.stella;
			resources.ApplyResources(pictureBox4, "pictureBox4");
			pictureBox4.Name = "pictureBox4";
			pictureBox4.TabStop = false;
			// 
			// label6
			// 
			resources.ApplyResources(label6, "label6");
			label6.BackColor = Color.Transparent;
			label6.ForeColor = Color.WhiteSmoke;
			label6.Name = "label6";
			// 
			// linkLabel3
			// 
			linkLabel3.ActiveLinkColor = Color.DeepSkyBlue;
			resources.ApplyResources(linkLabel3, "linkLabel3");
			linkLabel3.BackColor = Color.Transparent;
			linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
			linkLabel3.LinkColor = Color.Cyan;
			linkLabel3.Name = "linkLabel3";
			linkLabel3.TabStop = true;
			linkLabel3.LinkClicked += ViewDocs_LinkClicked;
			// 
			// label3
			// 
			resources.ApplyResources(label3, "label3");
			label3.BackColor = Color.Transparent;
			label3.ForeColor = Color.DeepSkyBlue;
			label3.Name = "label3";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			BackColor = Color.Black;
			BackgroundImage = Properties.ImageResources.bg;
			Controls.Add(label3);
			Controls.Add(linkLabel3);
			Controls.Add(label6);
			Controls.Add(pictureBox4);
			Controls.Add(pictureBox3);
			Controls.Add(pictureBox2);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(pictureBox1);
			Controls.Add(label2);
			Controls.Add(label1);
			DoubleBuffered = true;
			ForeColor = Color.White;
			FormBorderStyle = FormBorderStyle.None;
			MaximizeBox = false;
			Name = "MainForm";
			TopMost = true;
			WindowState = FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label4;
		  private Label label5;
		  private PictureBox pictureBox2;
		  private ToolTip toolTip1;
		  private PictureBox pictureBox3;
		  private PictureBox pictureBox4;
		  private Label label6;
		  private LinkLabel linkLabel3;
		private Label label3;
	}
}
