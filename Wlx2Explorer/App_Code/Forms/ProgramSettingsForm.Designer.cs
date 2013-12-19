namespace Wlx2Explorer.App_Code.Forms
{
    partial class ProgramSettingsForm
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlPlugins = new System.Windows.Forms.Panel();
            this.gridViewPlugin = new System.Windows.Forms.DataGridView();
            this.clmPluginFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPluginExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbListerFormHotKeys = new System.Windows.Forms.GroupBox();
            this.lblListerFormPlus2 = new System.Windows.Forms.Label();
            this.lblListerFormPlus1 = new System.Windows.Forms.Label();
            this.cmbListerFormKey3 = new System.Windows.Forms.ComboBox();
            this.cmbListerFormKey2 = new System.Windows.Forms.ComboBox();
            this.cmbListerFormKey1 = new System.Windows.Forms.ComboBox();
            this.grbListerForm = new System.Windows.Forms.GroupBox();
            this.txtListerHeight = new System.Windows.Forms.TextBox();
            this.lblWindowHeight = new System.Windows.Forms.Label();
            this.txtListerWidth = new System.Windows.Forms.TextBox();
            this.lblWindowWidth = new System.Windows.Forms.Label();
            this.chbListerMaximized = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbAutoStartProgram = new System.Windows.Forms.GroupBox();
            this.chbAutoStart = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabpCommon = new System.Windows.Forms.TabPage();
            this.grbPrintDialogHotKeys = new System.Windows.Forms.GroupBox();
            this.lblPrintDialogPlus2 = new System.Windows.Forms.Label();
            this.lblPrintDialogPlus1 = new System.Windows.Forms.Label();
            this.cmbPrintDialogKey3 = new System.Windows.Forms.ComboBox();
            this.cmbPrintDialogKey2 = new System.Windows.Forms.ComboBox();
            this.cmbPrintDialogKey1 = new System.Windows.Forms.ComboBox();
            this.grbSearchDialogHotKeys = new System.Windows.Forms.GroupBox();
            this.lblSearchDialogPlus2 = new System.Windows.Forms.Label();
            this.lblSearchDialogPlus1 = new System.Windows.Forms.Label();
            this.cmbSearchDialogKey3 = new System.Windows.Forms.ComboBox();
            this.cmbSearchDialogKey2 = new System.Windows.Forms.ComboBox();
            this.cmbSearchDialogKey1 = new System.Windows.Forms.ComboBox();
            this.tabpPlugin = new System.Windows.Forms.TabPage();
            this.grbPlugins = new System.Windows.Forms.GroupBox();
            this.grbPluginDefaultSettings = new System.Windows.Forms.GroupBox();
            this.txtIniFile = new System.Windows.Forms.TextBox();
            this.lblIniFile = new System.Windows.Forms.Label();
            this.lblDot = new System.Windows.Forms.Label();
            this.txtLowVersion = new System.Windows.Forms.TextBox();
            this.txtHighVersion = new System.Windows.Forms.TextBox();
            this.lblPluginVersion = new System.Windows.Forms.Label();
            this.pnlPlugins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPlugin)).BeginInit();
            this.grbListerFormHotKeys.SuspendLayout();
            this.grbListerForm.SuspendLayout();
            this.grbAutoStartProgram.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabpCommon.SuspendLayout();
            this.grbPrintDialogHotKeys.SuspendLayout();
            this.grbSearchDialogHotKeys.SuspendLayout();
            this.tabpPlugin.SuspendLayout();
            this.grbPlugins.SuspendLayout();
            this.grbPluginDefaultSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(434, 304);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(86, 24);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.EditPluginClick);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::Wlx2Explorer.Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(207, 304);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 24);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.UpPluginClick);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::Wlx2Explorer.Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(164, 304);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(37, 24);
            this.btnDown.TabIndex = 0;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.DownPluginClick);
            // 
            // pnlPlugins
            // 
            this.pnlPlugins.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlPlugins.Controls.Add(this.gridViewPlugin);
            this.pnlPlugins.Location = new System.Drawing.Point(10, 19);
            this.pnlPlugins.Name = "pnlPlugins";
            this.pnlPlugins.Padding = new System.Windows.Forms.Padding(1);
            this.pnlPlugins.Size = new System.Drawing.Size(510, 267);
            this.pnlPlugins.TabIndex = 8;
            // 
            // gridViewPlugin
            // 
            this.gridViewPlugin.AllowUserToAddRows = false;
            this.gridViewPlugin.AllowUserToDeleteRows = false;
            this.gridViewPlugin.AllowUserToResizeColumns = false;
            this.gridViewPlugin.AllowUserToResizeRows = false;
            this.gridViewPlugin.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridViewPlugin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewPlugin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewPlugin.ColumnHeadersVisible = false;
            this.gridViewPlugin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPluginFile,
            this.clmPluginExtension});
            this.gridViewPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewPlugin.GridColor = System.Drawing.SystemColors.Control;
            this.gridViewPlugin.Location = new System.Drawing.Point(1, 1);
            this.gridViewPlugin.MultiSelect = false;
            this.gridViewPlugin.Name = "gridViewPlugin";
            this.gridViewPlugin.RowHeadersVisible = false;
            this.gridViewPlugin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridViewPlugin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewPlugin.Size = new System.Drawing.Size(508, 265);
            this.gridViewPlugin.TabIndex = 0;
            this.gridViewPlugin.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PluginListDoubleClick);
            // 
            // clmPluginFile
            // 
            this.clmPluginFile.HeaderText = "";
            this.clmPluginFile.Name = "clmPluginFile";
            this.clmPluginFile.ReadOnly = true;
            // 
            // clmPluginExtension
            // 
            this.clmPluginExtension.HeaderText = "";
            this.clmPluginExtension.Name = "clmPluginExtension";
            this.clmPluginExtension.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(342, 304);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.DeletePluginClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(250, 304);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddPluginClick);
            // 
            // grbListerFormHotKeys
            // 
            this.grbListerFormHotKeys.Controls.Add(this.lblListerFormPlus2);
            this.grbListerFormHotKeys.Controls.Add(this.lblListerFormPlus1);
            this.grbListerFormHotKeys.Controls.Add(this.cmbListerFormKey3);
            this.grbListerFormHotKeys.Controls.Add(this.cmbListerFormKey2);
            this.grbListerFormHotKeys.Controls.Add(this.cmbListerFormKey1);
            this.grbListerFormHotKeys.Location = new System.Drawing.Point(8, 228);
            this.grbListerFormHotKeys.Name = "grbListerFormHotKeys";
            this.grbListerFormHotKeys.Size = new System.Drawing.Size(531, 82);
            this.grbListerFormHotKeys.TabIndex = 2;
            this.grbListerFormHotKeys.TabStop = false;
            this.grbListerFormHotKeys.Text = "Show lister form hot keys";
            // 
            // lblListerFormPlus2
            // 
            this.lblListerFormPlus2.AutoSize = true;
            this.lblListerFormPlus2.Location = new System.Drawing.Point(283, 37);
            this.lblListerFormPlus2.Name = "lblListerFormPlus2";
            this.lblListerFormPlus2.Size = new System.Drawing.Size(13, 13);
            this.lblListerFormPlus2.TabIndex = 3;
            this.lblListerFormPlus2.Text = "+";
            // 
            // lblListerFormPlus1
            // 
            this.lblListerFormPlus1.AutoSize = true;
            this.lblListerFormPlus1.Location = new System.Drawing.Point(134, 37);
            this.lblListerFormPlus1.Name = "lblListerFormPlus1";
            this.lblListerFormPlus1.Size = new System.Drawing.Size(13, 13);
            this.lblListerFormPlus1.TabIndex = 1;
            this.lblListerFormPlus1.Text = "+";
            // 
            // cmbListerFormKey3
            // 
            this.cmbListerFormKey3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListerFormKey3.FormattingEnabled = true;
            this.cmbListerFormKey3.Location = new System.Drawing.Point(313, 34);
            this.cmbListerFormKey3.Name = "cmbListerFormKey3";
            this.cmbListerFormKey3.Size = new System.Drawing.Size(101, 21);
            this.cmbListerFormKey3.TabIndex = 4;
            // 
            // cmbListerFormKey2
            // 
            this.cmbListerFormKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListerFormKey2.FormattingEnabled = true;
            this.cmbListerFormKey2.Location = new System.Drawing.Point(164, 34);
            this.cmbListerFormKey2.Name = "cmbListerFormKey2";
            this.cmbListerFormKey2.Size = new System.Drawing.Size(101, 21);
            this.cmbListerFormKey2.TabIndex = 2;
            // 
            // cmbListerFormKey1
            // 
            this.cmbListerFormKey1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListerFormKey1.FormattingEnabled = true;
            this.cmbListerFormKey1.Location = new System.Drawing.Point(16, 34);
            this.cmbListerFormKey1.Name = "cmbListerFormKey1";
            this.cmbListerFormKey1.Size = new System.Drawing.Size(101, 21);
            this.cmbListerFormKey1.TabIndex = 0;
            // 
            // grbListerForm
            // 
            this.grbListerForm.Controls.Add(this.txtListerHeight);
            this.grbListerForm.Controls.Add(this.lblWindowHeight);
            this.grbListerForm.Controls.Add(this.txtListerWidth);
            this.grbListerForm.Controls.Add(this.lblWindowWidth);
            this.grbListerForm.Controls.Add(this.chbListerMaximized);
            this.grbListerForm.Location = new System.Drawing.Point(8, 94);
            this.grbListerForm.Name = "grbListerForm";
            this.grbListerForm.Size = new System.Drawing.Size(531, 128);
            this.grbListerForm.TabIndex = 1;
            this.grbListerForm.TabStop = false;
            this.grbListerForm.Text = "Lister form";
            // 
            // txtListerHeight
            // 
            this.txtListerHeight.Location = new System.Drawing.Point(96, 87);
            this.txtListerHeight.Name = "txtListerHeight";
            this.txtListerHeight.Size = new System.Drawing.Size(100, 20);
            this.txtListerHeight.TabIndex = 4;
            // 
            // lblWindowHeight
            // 
            this.lblWindowHeight.AutoSize = true;
            this.lblWindowHeight.Location = new System.Drawing.Point(13, 90);
            this.lblWindowHeight.Name = "lblWindowHeight";
            this.lblWindowHeight.Size = new System.Drawing.Size(81, 13);
            this.lblWindowHeight.TabIndex = 3;
            this.lblWindowHeight.Text = "Window height:";
            // 
            // txtListerWidth
            // 
            this.txtListerWidth.Location = new System.Drawing.Point(96, 61);
            this.txtListerWidth.Name = "txtListerWidth";
            this.txtListerWidth.Size = new System.Drawing.Size(100, 20);
            this.txtListerWidth.TabIndex = 2;
            // 
            // lblWindowWidth
            // 
            this.lblWindowWidth.AutoSize = true;
            this.lblWindowWidth.Location = new System.Drawing.Point(13, 64);
            this.lblWindowWidth.Name = "lblWindowWidth";
            this.lblWindowWidth.Size = new System.Drawing.Size(77, 13);
            this.lblWindowWidth.TabIndex = 1;
            this.lblWindowWidth.Text = "Window width:";
            // 
            // chbListerMaximized
            // 
            this.chbListerMaximized.AutoSize = true;
            this.chbListerMaximized.Location = new System.Drawing.Point(16, 31);
            this.chbListerMaximized.Name = "chbListerMaximized";
            this.chbListerMaximized.Size = new System.Drawing.Size(108, 17);
            this.chbListerMaximized.TabIndex = 0;
            this.chbListerMaximized.Text = "Maximize window";
            this.chbListerMaximized.UseVisualStyleBackColor = true;
            this.chbListerMaximized.CheckedChanged += new System.EventHandler(this.MaximizeWindowCheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(354, 542);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(446, 542);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // grbAutoStartProgram
            // 
            this.grbAutoStartProgram.Controls.Add(this.chbAutoStart);
            this.grbAutoStartProgram.Location = new System.Drawing.Point(8, 6);
            this.grbAutoStartProgram.Name = "grbAutoStartProgram";
            this.grbAutoStartProgram.Size = new System.Drawing.Size(531, 82);
            this.grbAutoStartProgram.TabIndex = 0;
            this.grbAutoStartProgram.TabStop = false;
            this.grbAutoStartProgram.Text = "Auto start";
            // 
            // chbAutoStart
            // 
            this.chbAutoStart.AutoSize = true;
            this.chbAutoStart.Location = new System.Drawing.Point(16, 36);
            this.chbAutoStart.Name = "chbAutoStart";
            this.chbAutoStart.Size = new System.Drawing.Size(246, 17);
            this.chbAutoStart.TabIndex = 0;
            this.chbAutoStart.Text = "Run program at Windows startup (current user)";
            this.chbAutoStart.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabpCommon);
            this.tabMain.Controls.Add(this.tabpPlugin);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(555, 523);
            this.tabMain.TabIndex = 0;
            // 
            // tabpCommon
            // 
            this.tabpCommon.Controls.Add(this.grbPrintDialogHotKeys);
            this.tabpCommon.Controls.Add(this.grbSearchDialogHotKeys);
            this.tabpCommon.Controls.Add(this.grbAutoStartProgram);
            this.tabpCommon.Controls.Add(this.grbListerFormHotKeys);
            this.tabpCommon.Controls.Add(this.grbListerForm);
            this.tabpCommon.Location = new System.Drawing.Point(4, 22);
            this.tabpCommon.Name = "tabpCommon";
            this.tabpCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabpCommon.Size = new System.Drawing.Size(547, 497);
            this.tabpCommon.TabIndex = 0;
            this.tabpCommon.Text = "Common";
            this.tabpCommon.UseVisualStyleBackColor = true;
            // 
            // grbPrintDialogHotKeys
            // 
            this.grbPrintDialogHotKeys.Controls.Add(this.lblPrintDialogPlus2);
            this.grbPrintDialogHotKeys.Controls.Add(this.lblPrintDialogPlus1);
            this.grbPrintDialogHotKeys.Controls.Add(this.cmbPrintDialogKey3);
            this.grbPrintDialogHotKeys.Controls.Add(this.cmbPrintDialogKey2);
            this.grbPrintDialogHotKeys.Controls.Add(this.cmbPrintDialogKey1);
            this.grbPrintDialogHotKeys.Location = new System.Drawing.Point(8, 404);
            this.grbPrintDialogHotKeys.Name = "grbPrintDialogHotKeys";
            this.grbPrintDialogHotKeys.Size = new System.Drawing.Size(531, 82);
            this.grbPrintDialogHotKeys.TabIndex = 4;
            this.grbPrintDialogHotKeys.TabStop = false;
            this.grbPrintDialogHotKeys.Text = "Show print dialog hot keys";
            // 
            // lblPrintDialogPlus2
            // 
            this.lblPrintDialogPlus2.AutoSize = true;
            this.lblPrintDialogPlus2.Location = new System.Drawing.Point(283, 37);
            this.lblPrintDialogPlus2.Name = "lblPrintDialogPlus2";
            this.lblPrintDialogPlus2.Size = new System.Drawing.Size(13, 13);
            this.lblPrintDialogPlus2.TabIndex = 3;
            this.lblPrintDialogPlus2.Text = "+";
            // 
            // lblPrintDialogPlus1
            // 
            this.lblPrintDialogPlus1.AutoSize = true;
            this.lblPrintDialogPlus1.Location = new System.Drawing.Point(134, 37);
            this.lblPrintDialogPlus1.Name = "lblPrintDialogPlus1";
            this.lblPrintDialogPlus1.Size = new System.Drawing.Size(13, 13);
            this.lblPrintDialogPlus1.TabIndex = 1;
            this.lblPrintDialogPlus1.Text = "+";
            // 
            // cmbPrintDialogKey3
            // 
            this.cmbPrintDialogKey3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintDialogKey3.FormattingEnabled = true;
            this.cmbPrintDialogKey3.Location = new System.Drawing.Point(313, 34);
            this.cmbPrintDialogKey3.Name = "cmbPrintDialogKey3";
            this.cmbPrintDialogKey3.Size = new System.Drawing.Size(101, 21);
            this.cmbPrintDialogKey3.TabIndex = 4;
            // 
            // cmbPrintDialogKey2
            // 
            this.cmbPrintDialogKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintDialogKey2.FormattingEnabled = true;
            this.cmbPrintDialogKey2.Location = new System.Drawing.Point(164, 34);
            this.cmbPrintDialogKey2.Name = "cmbPrintDialogKey2";
            this.cmbPrintDialogKey2.Size = new System.Drawing.Size(101, 21);
            this.cmbPrintDialogKey2.TabIndex = 2;
            // 
            // cmbPrintDialogKey1
            // 
            this.cmbPrintDialogKey1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrintDialogKey1.FormattingEnabled = true;
            this.cmbPrintDialogKey1.Location = new System.Drawing.Point(16, 34);
            this.cmbPrintDialogKey1.Name = "cmbPrintDialogKey1";
            this.cmbPrintDialogKey1.Size = new System.Drawing.Size(101, 21);
            this.cmbPrintDialogKey1.TabIndex = 0;
            // 
            // grbSearchDialogHotKeys
            // 
            this.grbSearchDialogHotKeys.Controls.Add(this.lblSearchDialogPlus2);
            this.grbSearchDialogHotKeys.Controls.Add(this.lblSearchDialogPlus1);
            this.grbSearchDialogHotKeys.Controls.Add(this.cmbSearchDialogKey3);
            this.grbSearchDialogHotKeys.Controls.Add(this.cmbSearchDialogKey2);
            this.grbSearchDialogHotKeys.Controls.Add(this.cmbSearchDialogKey1);
            this.grbSearchDialogHotKeys.Location = new System.Drawing.Point(8, 316);
            this.grbSearchDialogHotKeys.Name = "grbSearchDialogHotKeys";
            this.grbSearchDialogHotKeys.Size = new System.Drawing.Size(531, 82);
            this.grbSearchDialogHotKeys.TabIndex = 3;
            this.grbSearchDialogHotKeys.TabStop = false;
            this.grbSearchDialogHotKeys.Text = "Show search dialog hot keys";
            // 
            // lblSearchDialogPlus2
            // 
            this.lblSearchDialogPlus2.AutoSize = true;
            this.lblSearchDialogPlus2.Location = new System.Drawing.Point(283, 37);
            this.lblSearchDialogPlus2.Name = "lblSearchDialogPlus2";
            this.lblSearchDialogPlus2.Size = new System.Drawing.Size(13, 13);
            this.lblSearchDialogPlus2.TabIndex = 3;
            this.lblSearchDialogPlus2.Text = "+";
            // 
            // lblSearchDialogPlus1
            // 
            this.lblSearchDialogPlus1.AutoSize = true;
            this.lblSearchDialogPlus1.Location = new System.Drawing.Point(134, 37);
            this.lblSearchDialogPlus1.Name = "lblSearchDialogPlus1";
            this.lblSearchDialogPlus1.Size = new System.Drawing.Size(13, 13);
            this.lblSearchDialogPlus1.TabIndex = 1;
            this.lblSearchDialogPlus1.Text = "+";
            // 
            // cmbSearchDialogKey3
            // 
            this.cmbSearchDialogKey3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchDialogKey3.FormattingEnabled = true;
            this.cmbSearchDialogKey3.Location = new System.Drawing.Point(313, 34);
            this.cmbSearchDialogKey3.Name = "cmbSearchDialogKey3";
            this.cmbSearchDialogKey3.Size = new System.Drawing.Size(101, 21);
            this.cmbSearchDialogKey3.TabIndex = 4;
            // 
            // cmbSearchDialogKey2
            // 
            this.cmbSearchDialogKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchDialogKey2.FormattingEnabled = true;
            this.cmbSearchDialogKey2.Location = new System.Drawing.Point(164, 34);
            this.cmbSearchDialogKey2.Name = "cmbSearchDialogKey2";
            this.cmbSearchDialogKey2.Size = new System.Drawing.Size(101, 21);
            this.cmbSearchDialogKey2.TabIndex = 2;
            // 
            // cmbSearchDialogKey1
            // 
            this.cmbSearchDialogKey1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchDialogKey1.FormattingEnabled = true;
            this.cmbSearchDialogKey1.Location = new System.Drawing.Point(16, 34);
            this.cmbSearchDialogKey1.Name = "cmbSearchDialogKey1";
            this.cmbSearchDialogKey1.Size = new System.Drawing.Size(101, 21);
            this.cmbSearchDialogKey1.TabIndex = 0;
            // 
            // tabpPlugin
            // 
            this.tabpPlugin.Controls.Add(this.grbPlugins);
            this.tabpPlugin.Controls.Add(this.grbPluginDefaultSettings);
            this.tabpPlugin.Location = new System.Drawing.Point(4, 22);
            this.tabpPlugin.Name = "tabpPlugin";
            this.tabpPlugin.Padding = new System.Windows.Forms.Padding(3);
            this.tabpPlugin.Size = new System.Drawing.Size(547, 497);
            this.tabpPlugin.TabIndex = 1;
            this.tabpPlugin.Text = "Plugin";
            this.tabpPlugin.UseVisualStyleBackColor = true;
            // 
            // grbPlugins
            // 
            this.grbPlugins.Controls.Add(this.pnlPlugins);
            this.grbPlugins.Controls.Add(this.btnEdit);
            this.grbPlugins.Controls.Add(this.btnDelete);
            this.grbPlugins.Controls.Add(this.btnUp);
            this.grbPlugins.Controls.Add(this.btnDown);
            this.grbPlugins.Controls.Add(this.btnAdd);
            this.grbPlugins.Location = new System.Drawing.Point(8, 138);
            this.grbPlugins.Name = "grbPlugins";
            this.grbPlugins.Size = new System.Drawing.Size(531, 348);
            this.grbPlugins.TabIndex = 1;
            this.grbPlugins.TabStop = false;
            this.grbPlugins.Text = "Plugins";
            // 
            // grbPluginDefaultSettings
            // 
            this.grbPluginDefaultSettings.Controls.Add(this.txtIniFile);
            this.grbPluginDefaultSettings.Controls.Add(this.lblIniFile);
            this.grbPluginDefaultSettings.Controls.Add(this.lblDot);
            this.grbPluginDefaultSettings.Controls.Add(this.txtLowVersion);
            this.grbPluginDefaultSettings.Controls.Add(this.txtHighVersion);
            this.grbPluginDefaultSettings.Controls.Add(this.lblPluginVersion);
            this.grbPluginDefaultSettings.Location = new System.Drawing.Point(8, 6);
            this.grbPluginDefaultSettings.Name = "grbPluginDefaultSettings";
            this.grbPluginDefaultSettings.Size = new System.Drawing.Size(531, 116);
            this.grbPluginDefaultSettings.TabIndex = 0;
            this.grbPluginDefaultSettings.TabStop = false;
            this.grbPluginDefaultSettings.Text = "Plugin default settings";
            // 
            // txtIniFile
            // 
            this.txtIniFile.Location = new System.Drawing.Point(64, 75);
            this.txtIniFile.Name = "txtIniFile";
            this.txtIniFile.Size = new System.Drawing.Size(456, 20);
            this.txtIniFile.TabIndex = 5;
            // 
            // lblIniFile
            // 
            this.lblIniFile.AutoSize = true;
            this.lblIniFile.Location = new System.Drawing.Point(13, 78);
            this.lblIniFile.Name = "lblIniFile";
            this.lblIniFile.Size = new System.Drawing.Size(43, 13);
            this.lblIniFile.TabIndex = 4;
            this.lblIniFile.Text = "INI File:";
            // 
            // lblDot
            // 
            this.lblDot.AutoSize = true;
            this.lblDot.Location = new System.Drawing.Point(100, 34);
            this.lblDot.Name = "lblDot";
            this.lblDot.Size = new System.Drawing.Size(10, 13);
            this.lblDot.TabIndex = 2;
            this.lblDot.Text = ".";
            // 
            // txtLowVersion
            // 
            this.txtLowVersion.Location = new System.Drawing.Point(117, 31);
            this.txtLowVersion.MaxLength = 3;
            this.txtLowVersion.Name = "txtLowVersion";
            this.txtLowVersion.Size = new System.Drawing.Size(30, 20);
            this.txtLowVersion.TabIndex = 3;
            // 
            // txtHighVersion
            // 
            this.txtHighVersion.Location = new System.Drawing.Point(64, 31);
            this.txtHighVersion.MaxLength = 3;
            this.txtHighVersion.Name = "txtHighVersion";
            this.txtHighVersion.Size = new System.Drawing.Size(30, 20);
            this.txtHighVersion.TabIndex = 1;
            // 
            // lblPluginVersion
            // 
            this.lblPluginVersion.AutoSize = true;
            this.lblPluginVersion.Location = new System.Drawing.Point(13, 34);
            this.lblPluginVersion.Name = "lblPluginVersion";
            this.lblPluginVersion.Size = new System.Drawing.Size(45, 13);
            this.lblPluginVersion.TabIndex = 0;
            this.lblPluginVersion.Text = "Version:";
            // 
            // ProgramSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 594);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.pnlPlugins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPlugin)).EndInit();
            this.grbListerFormHotKeys.ResumeLayout(false);
            this.grbListerFormHotKeys.PerformLayout();
            this.grbListerForm.ResumeLayout(false);
            this.grbListerForm.PerformLayout();
            this.grbAutoStartProgram.ResumeLayout(false);
            this.grbAutoStartProgram.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabpCommon.ResumeLayout(false);
            this.grbPrintDialogHotKeys.ResumeLayout(false);
            this.grbPrintDialogHotKeys.PerformLayout();
            this.grbSearchDialogHotKeys.ResumeLayout(false);
            this.grbSearchDialogHotKeys.PerformLayout();
            this.tabpPlugin.ResumeLayout(false);
            this.grbPlugins.ResumeLayout(false);
            this.grbPluginDefaultSettings.ResumeLayout(false);
            this.grbPluginDefaultSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbListerFormHotKeys;
        private System.Windows.Forms.GroupBox grbListerForm;
        private System.Windows.Forms.TextBox txtListerHeight;
        private System.Windows.Forms.Label lblWindowHeight;
        private System.Windows.Forms.TextBox txtListerWidth;
        private System.Windows.Forms.Label lblWindowWidth;
        private System.Windows.Forms.CheckBox chbListerMaximized;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblListerFormPlus2;
        private System.Windows.Forms.Label lblListerFormPlus1;
        private System.Windows.Forms.ComboBox cmbListerFormKey3;
        private System.Windows.Forms.ComboBox cmbListerFormKey2;
        private System.Windows.Forms.ComboBox cmbListerFormKey1;
        private System.Windows.Forms.GroupBox grbAutoStartProgram;
        private System.Windows.Forms.CheckBox chbAutoStart;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridViewPlugin;
        private System.Windows.Forms.Panel pnlPlugins;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPluginFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPluginExtension;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabpCommon;
        private System.Windows.Forms.GroupBox grbSearchDialogHotKeys;
        private System.Windows.Forms.Label lblSearchDialogPlus2;
        private System.Windows.Forms.Label lblSearchDialogPlus1;
        private System.Windows.Forms.ComboBox cmbSearchDialogKey3;
        private System.Windows.Forms.ComboBox cmbSearchDialogKey2;
        private System.Windows.Forms.ComboBox cmbSearchDialogKey1;
        private System.Windows.Forms.TabPage tabpPlugin;
        private System.Windows.Forms.GroupBox grbPrintDialogHotKeys;
        private System.Windows.Forms.Label lblPrintDialogPlus2;
        private System.Windows.Forms.Label lblPrintDialogPlus1;
        private System.Windows.Forms.ComboBox cmbPrintDialogKey3;
        private System.Windows.Forms.ComboBox cmbPrintDialogKey2;
        private System.Windows.Forms.ComboBox cmbPrintDialogKey1;
        private System.Windows.Forms.GroupBox grbPluginDefaultSettings;
        private System.Windows.Forms.TextBox txtIniFile;
        private System.Windows.Forms.Label lblIniFile;
        private System.Windows.Forms.Label lblDot;
        private System.Windows.Forms.TextBox txtLowVersion;
        private System.Windows.Forms.TextBox txtHighVersion;
        private System.Windows.Forms.Label lblPluginVersion;
        private System.Windows.Forms.GroupBox grbPlugins;
    }
}