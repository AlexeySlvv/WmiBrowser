namespace WmiBrowser
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuClasses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuSearchMSDN = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxClassDesc = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.contextMenuProps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxPropertyDesc = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpWin32Classes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox = new WmiBrowser.CustomListBox();
            this.listView = new WmiBrowser.CustomListView();
            this.colProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCimType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuClasses.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuProps.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(624, 417);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(238, 417);
            this.splitContainer2.SplitterDistance = 296;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Win32_classes";
            // 
            // contextMenuClasses
            // 
            this.contextMenuClasses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuUpdate,
            this.contextMenuCancel,
            this.toolStripSeparator5,
            this.contextMenuSearchMSDN,
            this.toolStripSeparator3,
            this.filterToolStripMenuItem});
            this.contextMenuClasses.Name = "contextMenuClasses";
            this.contextMenuClasses.Size = new System.Drawing.Size(209, 104);
            // 
            // contextMenuUpdate
            // 
            this.contextMenuUpdate.Image = global::WmiBrowser.Properties.Resources.update;
            this.contextMenuUpdate.Name = "contextMenuUpdate";
            this.contextMenuUpdate.Size = new System.Drawing.Size(208, 22);
            this.contextMenuUpdate.Text = "Update properties";
            this.contextMenuUpdate.Click += new System.EventHandler(this.UpdateProperties);
            // 
            // contextMenuCancel
            // 
            this.contextMenuCancel.Enabled = false;
            this.contextMenuCancel.Image = global::WmiBrowser.Properties.Resources.cancel;
            this.contextMenuCancel.Name = "contextMenuCancel";
            this.contextMenuCancel.Size = new System.Drawing.Size(208, 22);
            this.contextMenuCancel.Text = "Cancel update";
            this.contextMenuCancel.Click += new System.EventHandler(this.CancelUpdate);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(205, 6);
            // 
            // contextMenuSearchMSDN
            // 
            this.contextMenuSearchMSDN.Image = global::WmiBrowser.Properties.Resources.google_custom_search;
            this.contextMenuSearchMSDN.Name = "contextMenuSearchMSDN";
            this.contextMenuSearchMSDN.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.contextMenuSearchMSDN.Size = new System.Drawing.Size(208, 22);
            this.contextMenuSearchMSDN.Text = "Search on MSDN";
            this.contextMenuSearchMSDN.Click += new System.EventHandler(this.contextMenuSearchMSDN_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Image = global::WmiBrowser.Properties.Resources.filter;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.filterToolStripMenuItem.Text = "Set filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxClassDesc);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class description";
            // 
            // textBoxClassDesc
            // 
            this.textBoxClassDesc.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxClassDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxClassDesc.Location = new System.Drawing.Point(3, 16);
            this.textBoxClassDesc.Multiline = true;
            this.textBoxClassDesc.Name = "textBoxClassDesc";
            this.textBoxClassDesc.ReadOnly = true;
            this.textBoxClassDesc.Size = new System.Drawing.Size(232, 98);
            this.textBoxClassDesc.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer3.Size = new System.Drawing.Size(382, 417);
            this.splitContainer3.SplitterDistance = 296;
            this.splitContainer3.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 296);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Class properties";
            // 
            // contextMenuProps
            // 
            this.contextMenuProps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuSave});
            this.contextMenuProps.Name = "contextMenuProps";
            this.contextMenuProps.Size = new System.Drawing.Size(132, 26);
            // 
            // contextMenuSave
            // 
            this.contextMenuSave.Image = global::WmiBrowser.Properties.Resources.table_save;
            this.contextMenuSave.Name = "contextMenuSave";
            this.contextMenuSave.Size = new System.Drawing.Size(131, 22);
            this.contextMenuSave.Text = "Save to file";
            this.contextMenuSave.Click += new System.EventHandler(this.SavePropertiesToFile);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxPropertyDesc);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 117);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Property description";
            // 
            // textBoxPropertyDesc
            // 
            this.textBoxPropertyDesc.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPropertyDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPropertyDesc.Location = new System.Drawing.Point(3, 16);
            this.textBoxPropertyDesc.Multiline = true;
            this.textBoxPropertyDesc.Name = "textBoxPropertyDesc";
            this.textBoxPropertyDesc.ReadOnly = true;
            this.textBoxPropertyDesc.Size = new System.Drawing.Size(376, 98);
            this.textBoxPropertyDesc.TabIndex = 1;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.csv";
            this.saveFileDialog.Filter = "Csv files|*.csv";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(624, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileConnect,
            this.toolStripSeparator6,
            this.menuFileUpdate,
            this.menuFileCancel,
            this.toolStripSeparator1,
            this.menuFileSave,
            this.toolStripSeparator2,
            this.menuFileQuit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileConnect
            // 
            this.menuFileConnect.Image = global::WmiBrowser.Properties.Resources.server_connect;
            this.menuFileConnect.Name = "menuFileConnect";
            this.menuFileConnect.Size = new System.Drawing.Size(187, 22);
            this.menuFileConnect.Text = "Connect";
            this.menuFileConnect.Click += new System.EventHandler(this.menuFileConnect_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(184, 6);
            // 
            // menuFileUpdate
            // 
            this.menuFileUpdate.Image = global::WmiBrowser.Properties.Resources.update;
            this.menuFileUpdate.Name = "menuFileUpdate";
            this.menuFileUpdate.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuFileUpdate.Size = new System.Drawing.Size(187, 22);
            this.menuFileUpdate.Text = "Update properties";
            this.menuFileUpdate.Click += new System.EventHandler(this.UpdateProperties);
            // 
            // menuFileCancel
            // 
            this.menuFileCancel.Enabled = false;
            this.menuFileCancel.Image = global::WmiBrowser.Properties.Resources.cancel;
            this.menuFileCancel.Name = "menuFileCancel";
            this.menuFileCancel.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.menuFileCancel.Size = new System.Drawing.Size(187, 22);
            this.menuFileCancel.Text = "Cancel update";
            this.menuFileCancel.Click += new System.EventHandler(this.CancelUpdate);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = global::WmiBrowser.Properties.Resources.table_save;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(187, 22);
            this.menuFileSave.Text = "Save to file";
            this.menuFileSave.Click += new System.EventHandler(this.SavePropertiesToFile);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // menuFileQuit
            // 
            this.menuFileQuit.Image = global::WmiBrowser.Properties.Resources.door_out;
            this.menuFileQuit.Name = "menuFileQuit";
            this.menuFileQuit.Size = new System.Drawing.Size(187, 22);
            this.menuFileQuit.Text = "Quit";
            this.menuFileQuit.Click += new System.EventHandler(this.menuFileQuit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpWin32Classes,
            this.toolStripSeparator4,
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "Help";
            // 
            // menuHelpWin32Classes
            // 
            this.menuHelpWin32Classes.Image = global::WmiBrowser.Properties.Resources.world_link;
            this.menuHelpWin32Classes.Name = "menuHelpWin32Classes";
            this.menuHelpWin32Classes.Size = new System.Drawing.Size(148, 22);
            this.menuHelpWin32Classes.Text = "Win32 Classes";
            this.menuHelpWin32Classes.Click += new System.EventHandler(this.menuHelpWin32Classes_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Image = global::WmiBrowser.Properties.Resources.information;
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(148, 22);
            this.menuHelpAbout.Text = "About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // listBox
            // 
            this.listBox.ContextMenuStrip = this.contextMenuClasses;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(3, 16);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(232, 277);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProperty,
            this.colCimType,
            this.colValue});
            this.listView.ContextMenuStrip = this.contextMenuProps;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 16);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(376, 277);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_KeyUp);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // colProperty
            // 
            this.colProperty.Text = "Property";
            this.colProperty.Width = global::WmiBrowser.Properties.Settings.Default.PropWidth;
            // 
            // colCimType
            // 
            this.colCimType.Text = "CimType";
            this.colCimType.Width = global::WmiBrowser.Properties.Settings.Default.CimTypeWidth;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = global::WmiBrowser.Properties.Settings.Default.ValueWidth;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WmiBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuClasses.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuProps.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox groupBox1;
		private CustomListBox listBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxClassDesc;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBoxPropertyDesc;
        private CustomListView listView;
        private System.Windows.Forms.ColumnHeader colProperty;
        private System.Windows.Forms.ColumnHeader colCimType;
        private System.Windows.Forms.ColumnHeader colValue;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuFileUpdate;
		private System.Windows.Forms.ToolStripMenuItem menuFileCancel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuFileSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuFileQuit;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
		private System.Windows.Forms.ContextMenuStrip contextMenuProps;
		private System.Windows.Forms.ToolStripMenuItem contextMenuSave;
		private System.Windows.Forms.ContextMenuStrip contextMenuClasses;
		private System.Windows.Forms.ToolStripMenuItem contextMenuUpdate;
		private System.Windows.Forms.ToolStripMenuItem contextMenuCancel;
		private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuHelpWin32Classes;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem contextMenuSearchMSDN;
        private System.Windows.Forms.ToolStripMenuItem menuFileConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

