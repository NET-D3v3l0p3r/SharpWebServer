namespace SharpWebServer
{
    partial class SharpWebServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpWebServer));
            this.tab_cntrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.logInStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.login_ttp = new System.Windows.Forms.ToolStripStatusLabel();
            this.logIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clrbttn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.logLB = new System.Windows.Forms.ListBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.serverStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.runbttn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.blacklist = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.icobttn = new System.Windows.Forms.Button();
            this.icopath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.favicon = new System.Windows.Forms.PictureBox();
            this.inibttn = new System.Windows.Forms.Button();
            this.iniPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.inipair = new System.Windows.Forms.ListBox();
            this.tab_cntrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favicon)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_cntrl
            // 
            this.tab_cntrl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tab_cntrl.Controls.Add(this.tabPage1);
            this.tab_cntrl.Controls.Add(this.tabPage2);
            this.tab_cntrl.Controls.Add(this.tabPage3);
            this.tab_cntrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tab_cntrl.Location = new System.Drawing.Point(3, 3);
            this.tab_cntrl.Name = "tab_cntrl";
            this.tab_cntrl.SelectedIndex = 0;
            this.tab_cntrl.Size = new System.Drawing.Size(784, 459);
            this.tab_cntrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tab_cntrl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.logIn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbPin);
            this.tabPage1.Controls.Add(this.tbId);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(776, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInStatus,
            this.login_ttp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(776, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // logInStatus
            // 
            this.logInStatus.BackColor = System.Drawing.Color.Transparent;
            this.logInStatus.Name = "logInStatus";
            this.logInStatus.Size = new System.Drawing.Size(126, 17);
            this.logInStatus.Text = "LogIn-Server: pulling...";
            this.logInStatus.VisitedLinkColor = System.Drawing.Color.Magenta;
            // 
            // login_ttp
            // 
            this.login_ttp.BackColor = System.Drawing.Color.Transparent;
            this.login_ttp.Name = "login_ttp";
            this.login_ttp.Size = new System.Drawing.Size(96, 17);
            this.login_ttp.Text = "Log in: Waiting...";
            // 
            // logIn
            // 
            this.logIn.Enabled = false;
            this.logIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logIn.Location = new System.Drawing.Point(339, 270);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(95, 40);
            this.logIn.TabIndex = 5;
            this.logIn.Text = "Log in";
            this.logIn.UseVisualStyleBackColor = true;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID:";
            // 
            // tbPin
            // 
            this.tbPin.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPin.Enabled = false;
            this.tbPin.Location = new System.Drawing.Point(210, 223);
            this.tbPin.Multiline = true;
            this.tbPin.Name = "tbPin";
            this.tbPin.PasswordChar = '*';
            this.tbPin.Size = new System.Drawing.Size(355, 22);
            this.tbPin.TabIndex = 2;
            this.tbPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPin_KeyDown);
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(210, 171);
            this.tbId.Multiline = true;
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(355, 22);
            this.tbId.TabIndex = 1;
            this.tbId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbId_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "LogIn to continue:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.statusStrip2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Welcome";
            this.tabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage2_Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.clrbttn);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.logLB);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 399);
            this.panel2.TabIndex = 12;
            // 
            // clrbttn
            // 
            this.clrbttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrbttn.Location = new System.Drawing.Point(302, 15);
            this.clrbttn.Name = "clrbttn";
            this.clrbttn.Size = new System.Drawing.Size(50, 24);
            this.clrbttn.TabIndex = 12;
            this.clrbttn.Text = "Clear";
            this.clrbttn.UseVisualStyleBackColor = true;
            this.clrbttn.Click += new System.EventHandler(this.clrbttn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 24);
            this.label9.TabIndex = 12;
            this.label9.Text = "Log:";
            // 
            // logLB
            // 
            this.logLB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logLB.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.logLB.FormattingEnabled = true;
            this.logLB.Location = new System.Drawing.Point(3, 42);
            this.logLB.Name = "logLB";
            this.logLB.Size = new System.Drawing.Size(349, 340);
            this.logLB.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverStatus});
            this.statusStrip2.Location = new System.Drawing.Point(3, 405);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(770, 22);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // serverStatus
            // 
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.Image = ((System.Drawing.Image)(resources.GetObject("serverStatus.Image")));
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(133, 17);
            this.serverStatus.Text = "Server: Disconnected";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.runbttn);
            this.panel1.Location = new System.Drawing.Point(406, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 399);
            this.panel1.TabIndex = 0;
            // 
            // runbttn
            // 
            this.runbttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runbttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runbttn.Location = new System.Drawing.Point(19, 323);
            this.runbttn.Name = "runbttn";
            this.runbttn.Size = new System.Drawing.Size(312, 46);
            this.runbttn.TabIndex = 11;
            this.runbttn.Text = "Start";
            this.runbttn.UseVisualStyleBackColor = true;
            this.runbttn.Click += new System.EventHandler(this.runbttn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Configuration";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.blacklist);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.icobttn);
            this.panel3.Controls.Add(this.icopath);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.favicon);
            this.panel3.Controls.Add(this.inibttn);
            this.panel3.Controls.Add(this.iniPath);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.inipair);
            this.panel3.Location = new System.Drawing.Point(6, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(759, 390);
            this.panel3.TabIndex = 0;
            // 
            // blacklist
            // 
            this.blacklist.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.blacklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blacklist.FormattingEnabled = true;
            this.blacklist.Location = new System.Drawing.Point(336, 71);
            this.blacklist.Name = "blacklist";
            this.blacklist.Size = new System.Drawing.Size(121, 119);
            this.blacklist.TabIndex = 21;
            this.blacklist.DoubleClick += new System.EventHandler(this.blacklist_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(332, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "BlackList:";
            // 
            // icobttn
            // 
            this.icobttn.Location = new System.Drawing.Point(657, 9);
            this.icobttn.Name = "icobttn";
            this.icobttn.Size = new System.Drawing.Size(32, 23);
            this.icobttn.TabIndex = 19;
            this.icobttn.Text = "...";
            this.icobttn.UseVisualStyleBackColor = true;
            this.icobttn.Click += new System.EventHandler(this.icobttn_Click);
            // 
            // icopath
            // 
            this.icopath.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.icopath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.icopath.Location = new System.Drawing.Point(388, 10);
            this.icopath.Multiline = true;
            this.icopath.Name = "icopath";
            this.icopath.ReadOnly = true;
            this.icopath.Size = new System.Drawing.Size(263, 22);
            this.icopath.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(332, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Icon:";
            // 
            // favicon
            // 
            this.favicon.Location = new System.Drawing.Point(708, 5);
            this.favicon.Name = "favicon";
            this.favicon.Size = new System.Drawing.Size(32, 32);
            this.favicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.favicon.TabIndex = 16;
            this.favicon.TabStop = false;
            // 
            // inibttn
            // 
            this.inibttn.Location = new System.Drawing.Point(279, 5);
            this.inibttn.Name = "inibttn";
            this.inibttn.Size = new System.Drawing.Size(32, 23);
            this.inibttn.TabIndex = 15;
            this.inibttn.Text = "...";
            this.inibttn.UseVisualStyleBackColor = true;
            this.inibttn.Click += new System.EventHandler(this.inibttn_Click);
            // 
            // iniPath
            // 
            this.iniPath.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.iniPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.iniPath.Location = new System.Drawing.Point(115, 6);
            this.iniPath.Multiline = true;
            this.iniPath.Name = "iniPath";
            this.iniPath.ReadOnly = true;
            this.iniPath.Size = new System.Drawing.Size(163, 22);
            this.iniPath.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "Serverconf:";
            // 
            // inipair
            // 
            this.inipair.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.inipair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inipair.FormattingEnabled = true;
            this.inipair.Location = new System.Drawing.Point(3, 31);
            this.inipair.Name = "inipair";
            this.inipair.Size = new System.Drawing.Size(308, 340);
            this.inipair.TabIndex = 0;
            this.inipair.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.inipair_MouseDoubleClick);
            // 
            // SharpWebServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tab_cntrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpWebServer";
            this.Text = "SharpWebServerV1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SharpWebServer_FormClosing);
            this.Load += new System.EventHandler(this.SharpWebServer_Load);
            this.tab_cntrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favicon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_cntrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPin;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Button logIn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel logInStatus;
        private System.Windows.Forms.ToolStripStatusLabel login_ttp;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ToolStripStatusLabel serverStatus;
        public System.Windows.Forms.ListBox logLB;
        private System.Windows.Forms.Button clrbttn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button inibttn;
        private System.Windows.Forms.TextBox iniPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox inipair;
        private System.Windows.Forms.Button icobttn;
        private System.Windows.Forms.TextBox icopath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox favicon;
        private System.Windows.Forms.ListBox blacklist;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button runbttn;
    }
}

