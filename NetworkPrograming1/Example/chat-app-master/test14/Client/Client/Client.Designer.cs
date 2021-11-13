namespace Client
{
    partial class Client
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.connectButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.localaddrLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.sendLabel = new System.Windows.Forms.Label();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupChatDataGribView = new System.Windows.Forms.DataGridView();
            this.ident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameGroupChat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logGroupChat = new System.Windows.Forms.TextBox();
            this.createGroupChatButton = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.createGroupButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupChatDataGribView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(263, 45);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(116, 28);
            this.connectButton.TabIndex = 28;
            this.connectButton.TabStop = false;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(662, 53);
            this.portLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(34, 16);
            this.portLabel.TabIndex = 27;
            this.portLabel.Text = "Port:";
            // 
            // localaddrLabel
            // 
            this.localaddrLabel.AutoSize = true;
            this.localaddrLabel.Location = new System.Drawing.Point(463, 50);
            this.localaddrLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.localaddrLabel.Name = "localaddrLabel";
            this.localaddrLabel.Size = new System.Drawing.Size(61, 16);
            this.localaddrLabel.TabIndex = 26;
            this.localaddrLabel.Text = "Address:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(699, 50);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.portTextBox.MaxLength = 10;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(132, 22);
            this.portTextBox.TabIndex = 25;
            this.portTextBox.TabStop = false;
            this.portTextBox.Text = "9000";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(534, 149);
            this.logLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(30, 16);
            this.logLabel.TabIndex = 31;
            this.logLabel.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.logTextBox.Location = new System.Drawing.Point(263, 170);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(568, 301);
            this.logTextBox.TabIndex = 30;
            this.logTextBox.TabStop = false;
            // 
            // sendLabel
            // 
            this.sendLabel.AutoSize = true;
            this.sendLabel.Location = new System.Drawing.Point(260, 479);
            this.sendLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sendLabel.Name = "sendLabel";
            this.sendLabel.Size = new System.Drawing.Size(39, 16);
            this.sendLabel.TabIndex = 33;
            this.sendLabel.Text = "Send";
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(263, 500);
            this.sendTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendTextBox.Size = new System.Drawing.Size(568, 22);
            this.sendTextBox.TabIndex = 32;
            this.sendTextBox.TabStop = false;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendTextBox_KeyDown);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(715, 134);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(116, 28);
            this.clearButton.TabIndex = 34;
            this.clearButton.TabStop = false;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(453, 81);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 16);
            this.usernameLabel.TabIndex = 36;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(519, 78);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextBox.MaxLength = 50;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(132, 22);
            this.usernameTextBox.TabIndex = 35;
            this.usernameTextBox.TabStop = false;
            this.usernameTextBox.Text = "Client";
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(663, 81);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(33, 16);
            this.keyLabel.TabIndex = 38;
            this.keyLabel.Text = "Key:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(699, 78);
            this.keyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.keyTextBox.MaxLength = 200;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(132, 22);
            this.keyTextBox.TabIndex = 37;
            this.keyTextBox.TabStop = false;
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addrTextBox
            // 
            this.addrTextBox.Location = new System.Drawing.Point(518, 50);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addrTextBox.MaxLength = 200;
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addrTextBox.Size = new System.Drawing.Size(132, 22);
            this.addrTextBox.TabIndex = 39;
            this.addrTextBox.TabStop = false;
            this.addrTextBox.Text = "127.0.0.1";
            this.addrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox
            // 
            this.checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox.Location = new System.Drawing.Point(699, 106);
            this.checkBox.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(72, 20);
            this.checkBox.TabIndex = 41;
            this.checkBox.Text = "Hide key";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.AllowUserToAddRows = false;
            this.clientsDataGridView.AllowUserToDeleteRows = false;
            this.clientsDataGridView.AllowUserToResizeColumns = false;
            this.clientsDataGridView.AllowUserToResizeRows = false;
            this.clientsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.clientsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.clientsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.clientsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clientsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.clientsDataGridView.ColumnHeadersHeight = 24;
            this.clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.clientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.add});
            this.clientsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.clientsDataGridView.EnableHeadersVisualStyles = false;
            this.clientsDataGridView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.clientsDataGridView.Location = new System.Drawing.Point(843, 68);
            this.clientsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.clientsDataGridView.MultiSelect = false;
            this.clientsDataGridView.Name = "clientsDataGridView";
            this.clientsDataGridView.ReadOnly = true;
            this.clientsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.clientsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.clientsDataGridView.RowHeadersVisible = false;
            this.clientsDataGridView.RowHeadersWidth = 40;
            this.clientsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.clientsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.clientsDataGridView.RowTemplate.Height = 24;
            this.clientsDataGridView.RowTemplate.ReadOnly = true;
            this.clientsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientsDataGridView.ShowCellErrors = false;
            this.clientsDataGridView.ShowCellToolTips = false;
            this.clientsDataGridView.ShowEditingIcon = false;
            this.clientsDataGridView.ShowRowErrors = false;
            this.clientsDataGridView.Size = new System.Drawing.Size(273, 454);
            this.clientsDataGridView.TabIndex = 42;
            this.clientsDataGridView.TabStop = false;
            this.clientsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsDataGridView_CellClick);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.Frozen = true;
            this.name.HeaderText = "Name";
            this.name.MaxInputLength = 20;
            this.name.MinimumWidth = 20;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.Width = 150;
            // 
            // add
            // 
            this.add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.add.Frozen = true;
            this.add.HeaderText = "Chat";
            this.add.MinimumWidth = 6;
            this.add.Name = "add";
            this.add.ReadOnly = true;
            this.add.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.add.Text = "Chat";
            this.add.UseColumnTextForButtonValue = true;
            this.add.Width = 120;
            // 
            // groupChatDataGribView
            // 
            this.groupChatDataGribView.AllowUserToAddRows = false;
            this.groupChatDataGribView.AllowUserToDeleteRows = false;
            this.groupChatDataGribView.AllowUserToResizeColumns = false;
            this.groupChatDataGribView.AllowUserToResizeRows = false;
            this.groupChatDataGribView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.groupChatDataGribView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.groupChatDataGribView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.groupChatDataGribView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.groupChatDataGribView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.groupChatDataGribView.ColumnHeadersHeight = 24;
            this.groupChatDataGribView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.groupChatDataGribView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ident,
            this.nameGroupChat});
            this.groupChatDataGribView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.groupChatDataGribView.EnableHeadersVisualStyles = false;
            this.groupChatDataGribView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.groupChatDataGribView.Location = new System.Drawing.Point(13, 39);
            this.groupChatDataGribView.Margin = new System.Windows.Forms.Padding(4);
            this.groupChatDataGribView.MultiSelect = false;
            this.groupChatDataGribView.Name = "groupChatDataGribView";
            this.groupChatDataGribView.ReadOnly = true;
            this.groupChatDataGribView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupChatDataGribView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.groupChatDataGribView.RowHeadersVisible = false;
            this.groupChatDataGribView.RowHeadersWidth = 40;
            this.groupChatDataGribView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.groupChatDataGribView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.groupChatDataGribView.RowTemplate.Height = 24;
            this.groupChatDataGribView.RowTemplate.ReadOnly = true;
            this.groupChatDataGribView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.groupChatDataGribView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.groupChatDataGribView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.groupChatDataGribView.ShowCellErrors = false;
            this.groupChatDataGribView.ShowCellToolTips = false;
            this.groupChatDataGribView.ShowEditingIcon = false;
            this.groupChatDataGribView.ShowRowErrors = false;
            this.groupChatDataGribView.Size = new System.Drawing.Size(242, 483);
            this.groupChatDataGribView.TabIndex = 44;
            this.groupChatDataGribView.TabStop = false;
            this.groupChatDataGribView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.groupChatDataGribView_CellMouseClick);
            // 
            // ident
            // 
            this.ident.HeaderText = "ID";
            this.ident.MinimumWidth = 6;
            this.ident.Name = "ident";
            this.ident.ReadOnly = true;
            this.ident.Width = 60;
            // 
            // nameGroupChat
            // 
            this.nameGroupChat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nameGroupChat.DefaultCellStyle = dataGridViewCellStyle6;
            this.nameGroupChat.HeaderText = "Group Chat";
            this.nameGroupChat.MaxInputLength = 20;
            this.nameGroupChat.MinimumWidth = 20;
            this.nameGroupChat.Name = "nameGroupChat";
            this.nameGroupChat.ReadOnly = true;
            this.nameGroupChat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1126, 28);
            this.menuStrip1.TabIndex = 45;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.toolStripMenuItem.Text = "Log";
            this.toolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // logGroupChat
            // 
            this.logGroupChat.BackColor = System.Drawing.SystemColors.Window;
            this.logGroupChat.Location = new System.Drawing.Point(263, 170);
            this.logGroupChat.Margin = new System.Windows.Forms.Padding(4);
            this.logGroupChat.Multiline = true;
            this.logGroupChat.Name = "logGroupChat";
            this.logGroupChat.ReadOnly = true;
            this.logGroupChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logGroupChat.Size = new System.Drawing.Size(568, 301);
            this.logGroupChat.TabIndex = 46;
            this.logGroupChat.TabStop = false;
            // 
            // createGroupChatButton
            // 
            this.createGroupChatButton.Location = new System.Drawing.Point(843, 32);
            this.createGroupChatButton.Margin = new System.Windows.Forms.Padding(4);
            this.createGroupChatButton.Name = "createGroupChatButton";
            this.createGroupChatButton.Size = new System.Drawing.Size(140, 28);
            this.createGroupChatButton.TabIndex = 47;
            this.createGroupChatButton.TabStop = false;
            this.createGroupChatButton.Text = "Create Group Chat";
            this.createGroupChatButton.UseVisualStyleBackColor = true;
            this.createGroupChatButton.Click += new System.EventHandler(this.createGroupChatButton_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(843, 68);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(273, 454);
            this.checkedListBox.TabIndex = 49;
            // 
            // createGroupButton
            // 
            this.createGroupButton.Location = new System.Drawing.Point(1010, 33);
            this.createGroupButton.Name = "createGroupButton";
            this.createGroupButton.Size = new System.Drawing.Size(104, 26);
            this.createGroupButton.TabIndex = 50;
            this.createGroupButton.Text = "Create Group";
            this.createGroupButton.UseVisualStyleBackColor = true;
            this.createGroupButton.Click += new System.EventHandler(this.createGroupButton_Click);
            // 
            // Client
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1126, 529);
            this.Controls.Add(this.createGroupButton);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.createGroupChatButton);
            this.Controls.Add(this.logGroupChat);
            this.Controls.Add(this.groupChatDataGribView);
            this.Controls.Add(this.clientsDataGridView);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.addrTextBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.sendLabel);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.localaddrLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Client";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupChatDataGribView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label localaddrLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label sendLabel;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.DataGridView groupChatDataGribView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ident;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameGroupChat;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.TextBox logGroupChat;
        private System.Windows.Forms.Button createGroupChatButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewButtonColumn add;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button createGroupButton;
    }
}

