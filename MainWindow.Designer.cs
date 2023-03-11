namespace jsmhToolChest
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.StartBox = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.Radio_Mods = new System.Windows.Forms.RadioButton();
            this.Radio_Client = new System.Windows.Forms.RadioButton();
            this.Radio_NOAddons = new System.Windows.Forms.RadioButton();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.Settings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.MainList = new System.Windows.Forms.ImageList(this.components);
            this.is4399 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Main.SuspendLayout();
            this.Settings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBox
            // 
            this.StartBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartBox.Location = new System.Drawing.Point(638, 741);
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(254, 138);
            this.StartBox.TabIndex = 0;
            this.StartBox.Text = "启动盒子";
            this.StartBox.UseVisualStyleBackColor = true;
            this.StartBox.Click += new System.EventHandler(this.StartBox_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Main);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.MainList;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1228, 643);
            this.tabControl1.TabIndex = 1;
            // 
            // Main
            // 
            this.Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Main.Controls.Add(this.Radio_Mods);
            this.Main.Controls.Add(this.Radio_Client);
            this.Main.Controls.Add(this.Radio_NOAddons);
            this.Main.Controls.Add(this.LogBox);
            this.Main.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Main.ImageKey = "home_32px.png";
            this.Main.Location = new System.Drawing.Point(8, 71);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(1212, 564);
            this.Main.TabIndex = 0;
            this.Main.Text = "主页";
            this.Main.UseVisualStyleBackColor = true;
            // 
            // Radio_Mods
            // 
            this.Radio_Mods.AutoSize = true;
            this.Radio_Mods.Enabled = false;
            this.Radio_Mods.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Radio_Mods.Location = new System.Drawing.Point(977, 156);
            this.Radio_Mods.Name = "Radio_Mods";
            this.Radio_Mods.Size = new System.Drawing.Size(177, 45);
            this.Radio_Mods.TabIndex = 5;
            this.Radio_Mods.Text = "注入模式";
            this.Radio_Mods.UseVisualStyleBackColor = true;
            this.Radio_Mods.CheckedChanged += new System.EventHandler(this.Radio_Mods_CheckedChanged);
            // 
            // Radio_Client
            // 
            this.Radio_Client.AutoSize = true;
            this.Radio_Client.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Radio_Client.Location = new System.Drawing.Point(977, 94);
            this.Radio_Client.Name = "Radio_Client";
            this.Radio_Client.Size = new System.Drawing.Size(177, 45);
            this.Radio_Client.TabIndex = 4;
            this.Radio_Client.TabStop = true;
            this.Radio_Client.Text = "开端模式";
            this.Radio_Client.UseVisualStyleBackColor = true;
            this.Radio_Client.CheckedChanged += new System.EventHandler(this.Radio_Client_CheckedChanged);
            // 
            // Radio_NOAddons
            // 
            this.Radio_NOAddons.AutoSize = true;
            this.Radio_NOAddons.Checked = true;
            this.Radio_NOAddons.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Radio_NOAddons.Location = new System.Drawing.Point(977, 32);
            this.Radio_NOAddons.Name = "Radio_NOAddons";
            this.Radio_NOAddons.Size = new System.Drawing.Size(177, 45);
            this.Radio_NOAddons.TabIndex = 3;
            this.Radio_NOAddons.TabStop = true;
            this.Radio_NOAddons.Text = "白端模式";
            this.Radio_NOAddons.UseVisualStyleBackColor = true;
            this.Radio_NOAddons.CheckedChanged += new System.EventHandler(this.Radio_NOAddons_CheckedChanged);
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogBox.Location = new System.Drawing.Point(30, 33);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(912, 497);
            this.LogBox.TabIndex = 2;
            this.LogBox.Text = "";
            // 
            // Settings
            // 
            this.Settings.AutoScroll = true;
            this.Settings.Controls.Add(this.panel1);
            this.Settings.ImageIndex = 2;
            this.Settings.Location = new System.Drawing.Point(8, 71);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(1212, 564);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "设置";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 558);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(18, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 210);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "开端模式";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(27, 126);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(202, 45);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "CL14[DLL]";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(27, 62);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(198, 45);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "CL8[Mod]";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // MainList
            // 
            this.MainList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainList.ImageStream")));
            this.MainList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainList.Images.SetKeyName(0, "home_32px.png");
            this.MainList.Images.SetKeyName(1, "services_32px.png");
            this.MainList.Images.SetKeyName(2, "settings_32px.png");
            // 
            // is4399
            // 
            this.is4399.AutoSize = true;
            this.is4399.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.is4399.Location = new System.Drawing.Point(638, 688);
            this.is4399.Name = "is4399";
            this.is4399.Size = new System.Drawing.Size(254, 45);
            this.is4399.TabIndex = 1;
            this.is4399.Text = "使用4399盒子";
            this.is4399.UseMnemonic = false;
            this.is4399.UseVisualStyleBackColor = false;
            this.is4399.CheckedChanged += new System.EventHandler(this.is4399_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox_IP);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 688);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 191);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "游戏信息";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::jsmhToolChest.Properties.Resources.copy_32px;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(533, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 49);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::jsmhToolChest.Properties.Resources.copy_32px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(533, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 49);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_IP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_IP.Location = new System.Drawing.Point(143, 114);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(375, 43);
            this.textBox_IP.TabIndex = 3;
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_name.Location = new System.Drawing.Point(143, 53);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(375, 43);
            this.textBox_name.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 908);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.is4399);
            this.Controls.Add(this.StartBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.ImageList MainList;
        private System.Windows.Forms.CheckBox is4399;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton Radio_Mods;
        public System.Windows.Forms.RadioButton Radio_Client;
        public System.Windows.Forms.RadioButton Radio_NOAddons;
        public System.Windows.Forms.TextBox textBox_IP;
        public System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
    }
}

