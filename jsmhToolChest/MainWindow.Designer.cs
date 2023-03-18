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
            this.Client = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.ClientListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.About = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.Client.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Settings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.About.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.Client);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Controls.Add(this.About);
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
            this.Main.ImageIndex = 0;
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
            // Client
            // 
            this.Client.Controls.Add(this.tabControl2);
            this.Client.ImageIndex = 4;
            this.Client.Location = new System.Drawing.Point(8, 71);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(1212, 564);
            this.Client.TabIndex = 4;
            this.Client.Text = "开端";
            this.Client.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1220, 572);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl2_Selecting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.ClientListView);
            this.tabPage2.Location = new System.Drawing.Point(8, 71);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1204, 493);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "客户端选择";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.BackgroundImage = global::jsmhToolChest.Properties.Resources.folder_64px;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.Location = new System.Drawing.Point(1128, 216);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(64, 64);
            this.button11.TabIndex = 9;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::jsmhToolChest.Properties.Resources.done_64px;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button10.Location = new System.Drawing.Point(1128, 423);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(64, 64);
            this.button10.TabIndex = 8;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::jsmhToolChest.Properties.Resources.download_64px;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button9.Location = new System.Drawing.Point(1128, 146);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 64);
            this.button9.TabIndex = 7;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::jsmhToolChest.Properties.Resources.waste_64px;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.Location = new System.Drawing.Point(1128, 76);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 64);
            this.button8.TabIndex = 6;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::jsmhToolChest.Properties.Resources.add_64px;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Location = new System.Drawing.Point(1128, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(64, 64);
            this.button7.TabIndex = 5;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ClientListView
            // 
            this.ClientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.ClientListView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientListView.FullRowSelect = true;
            this.ClientListView.HideSelection = false;
            this.ClientListView.Location = new System.Drawing.Point(3, 3);
            this.ClientListView.MultiSelect = false;
            this.ClientListView.Name = "ClientListView";
            this.ClientListView.Size = new System.Drawing.Size(1119, 484);
            this.ClientListView.TabIndex = 0;
            this.ClientListView.UseCompatibleStateImageBehavior = false;
            this.ClientListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 312;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "目录";
            this.columnHeader3.Width = 751;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(8, 71);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1204, 493);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客户端设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 415);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(1176, 49);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 41);
            this.label8.TabIndex = 7;
            this.label8.Text = "版本选择";
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::jsmhToolChest.Properties.Resources.folder_64px;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(1122, 304);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 64);
            this.button6.TabIndex = 6;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::jsmhToolChest.Properties.Resources.waste_64px;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(1122, 217);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 64);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::jsmhToolChest.Properties.Resources.add_64px;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(1122, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 64);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::jsmhToolChest.Properties.Resources.reboot_64px;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(1122, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 64);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 47);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1106, 321);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "模组文件名";
            this.columnHeader1.Width = 820;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 0;
            this.columnHeader6.Text = "模组状态";
            this.columnHeader6.Width = 146;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(457, 41);
            this.label7.TabIndex = 1;
            this.label7.Text = "模组管理 单击模组可启用/禁用";
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
            // About
            // 
            this.About.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.About.Controls.Add(this.linkLabel3);
            this.About.Controls.Add(this.label6);
            this.About.Controls.Add(this.linkLabel2);
            this.About.Controls.Add(this.label5);
            this.About.Controls.Add(this.linkLabel1);
            this.About.Controls.Add(this.label4);
            this.About.Controls.Add(this.label3);
            this.About.ImageIndex = 3;
            this.About.Location = new System.Drawing.Point(8, 71);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(1212, 564);
            this.About.TabIndex = 3;
            this.About.Text = "关于";
            this.About.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(280, 265);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(864, 57);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://github.com/jsms2/jsmhToolChest";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 57);
            this.label6.TabIndex = 5;
            this.label6.Text = "Github:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(280, 186);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(659, 57);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://pd.qq.com/s/b8z1gt7f9";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 57);
            this.label5.TabIndex = 3;
            this.label5.Text = "QQGuild:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(280, 113);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(369, 57);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://jsmh.red/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 57);
            this.label4.TabIndex = 1;
            this.label4.Text = "Website:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 57);
            this.label3.TabIndex = 0;
            this.label3.Text = "jsmhToolChest";
            // 
            // MainList
            // 
            this.MainList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainList.ImageStream")));
            this.MainList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainList.Images.SetKeyName(0, "home_32px.png");
            this.MainList.Images.SetKeyName(1, "services_32px.png");
            this.MainList.Images.SetKeyName(2, "settings_32px.png");
            this.MainList.Images.SetKeyName(3, "about_32px.png");
            this.MainList.Images.SetKeyName(4, "minecraft_pickaxe_32px.png");
            this.MainList.Images.SetKeyName(5, "about_64px.png");
            this.MainList.Images.SetKeyName(6, "home_64px.png");
            this.MainList.Images.SetKeyName(7, "minecraft_pickaxe_64px.png");
            this.MainList.Images.SetKeyName(8, "settings_64px.png");
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
            this.Client.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button StartBox;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage Main;
        public System.Windows.Forms.ImageList MainList;
        public System.Windows.Forms.CheckBox is4399;
        public System.Windows.Forms.RichTextBox LogBox;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton Radio_Mods;
        public System.Windows.Forms.RadioButton Radio_Client;
        public System.Windows.Forms.RadioButton Radio_NOAddons;
        public System.Windows.Forms.TextBox textBox_IP;
        public System.Windows.Forms.TextBox textBox_name;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TabPage Settings;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.TabPage About;
        public System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.LinkLabel linkLabel2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.LinkLabel linkLabel3;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TabPage Client;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.ListView ClientListView;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button button8;
        public System.Windows.Forms.Button button9;
        public System.Windows.Forms.Button button10;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.Button button11;
    }
}

