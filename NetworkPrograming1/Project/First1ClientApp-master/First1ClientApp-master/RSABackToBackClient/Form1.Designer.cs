namespace RSABackToBackClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.DirectoryNameLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.boxFileInfo = new System.Windows.Forms.GroupBox();
            this.txtStatusLabel = new System.Windows.Forms.Label();
            this.txtSizeLabel = new System.Windows.Forms.Label();
            this.txtDirectoryName = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.btnSendToServer = new System.Windows.Forms.Button();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.boxDirectoryServer = new System.Windows.Forms.GroupBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnRefreshFileList = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.StatusServerLabel = new System.Windows.Forms.Label();
            this.txtServerStatus = new System.Windows.Forms.Label();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PublicClientKeyE = new System.Windows.Forms.Label();
            this.PublicClientKeyN = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.Label();
            this.txtClientKeyE = new System.Windows.Forms.Label();
            this.txtClientKeyN = new System.Windows.Forms.Label();
            this.txtServerKeyN = new System.Windows.Forms.Label();
            this.txtServerKeyE = new System.Windows.Forms.Label();
            this.PublicServerKeyN = new System.Windows.Forms.Label();
            this.PublicServerKeyE = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.boxFileInfo.SuspendLayout();
            this.boxDirectoryServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hostPortToolStripMenuItem,
            this.myAccountToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // hostPortToolStripMenuItem
            // 
            this.hostPortToolStripMenuItem.Name = "hostPortToolStripMenuItem";
            this.hostPortToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.hostPortToolStripMenuItem.Text = "Host and Port";
            this.hostPortToolStripMenuItem.Click += new System.EventHandler(this.hostPortToolStripMenuItem_Click);
            // 
            // myAccountToolStripMenuItem
            // 
            this.myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            this.myAccountToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.myAccountToolStripMenuItem.Text = "MyAccount";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(3, 31);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(52, 13);
            this.FileNameLabel.TabIndex = 3;
            this.FileNameLabel.Text = "File name";
            // 
            // DirectoryNameLabel
            // 
            this.DirectoryNameLabel.AutoSize = true;
            this.DirectoryNameLabel.Location = new System.Drawing.Point(3, 56);
            this.DirectoryNameLabel.Name = "DirectoryNameLabel";
            this.DirectoryNameLabel.Size = new System.Drawing.Size(49, 13);
            this.DirectoryNameLabel.TabIndex = 4;
            this.DirectoryNameLabel.Text = "Directory";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(3, 80);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(27, 13);
            this.SizeLabel.TabIndex = 5;
            this.SizeLabel.Text = "Size";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 104);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Status";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 131);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // boxFileInfo
            // 
            this.boxFileInfo.Controls.Add(this.txtStatusLabel);
            this.boxFileInfo.Controls.Add(this.txtSizeLabel);
            this.boxFileInfo.Controls.Add(this.txtDirectoryName);
            this.boxFileInfo.Controls.Add(this.txtFileName);
            this.boxFileInfo.Controls.Add(this.btnSaveFile);
            this.boxFileInfo.Controls.Add(this.btnDecryptFile);
            this.boxFileInfo.Controls.Add(this.btnSendToServer);
            this.boxFileInfo.Controls.Add(this.btnEncryptFile);
            this.boxFileInfo.Controls.Add(this.FileNameLabel);
            this.boxFileInfo.Controls.Add(this.btnOpenFile);
            this.boxFileInfo.Controls.Add(this.DirectoryNameLabel);
            this.boxFileInfo.Controls.Add(this.StatusLabel);
            this.boxFileInfo.Controls.Add(this.SizeLabel);
            this.boxFileInfo.Location = new System.Drawing.Point(12, 27);
            this.boxFileInfo.Name = "boxFileInfo";
            this.boxFileInfo.Size = new System.Drawing.Size(418, 169);
            this.boxFileInfo.TabIndex = 8;
            this.boxFileInfo.TabStop = false;
            this.boxFileInfo.Text = "Information about file";
            // 
            // txtStatusLabel
            // 
            this.txtStatusLabel.AutoSize = true;
            this.txtStatusLabel.Location = new System.Drawing.Point(84, 104);
            this.txtStatusLabel.Name = "txtStatusLabel";
            this.txtStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.txtStatusLabel.TabIndex = 15;
            // 
            // txtSizeLabel
            // 
            this.txtSizeLabel.AutoSize = true;
            this.txtSizeLabel.Location = new System.Drawing.Point(84, 80);
            this.txtSizeLabel.Name = "txtSizeLabel";
            this.txtSizeLabel.Size = new System.Drawing.Size(0, 13);
            this.txtSizeLabel.TabIndex = 14;
            // 
            // txtDirectoryName
            // 
            this.txtDirectoryName.Location = new System.Drawing.Point(87, 53);
            this.txtDirectoryName.Name = "txtDirectoryName";
            this.txtDirectoryName.Size = new System.Drawing.Size(319, 20);
            this.txtDirectoryName.TabIndex = 13;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(87, 28);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(319, 20);
            this.txtFileName.TabIndex = 12;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(331, 131);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 11;
            this.btnSaveFile.Text = "Save";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.Location = new System.Drawing.Point(169, 131);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(75, 23);
            this.btnDecryptFile.TabIndex = 10;
            this.btnDecryptFile.Text = "Decrypt";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnSendToServer
            // 
            this.btnSendToServer.Location = new System.Drawing.Point(250, 131);
            this.btnSendToServer.Name = "btnSendToServer";
            this.btnSendToServer.Size = new System.Drawing.Size(75, 23);
            this.btnSendToServer.TabIndex = 9;
            this.btnSendToServer.Text = "Send";
            this.btnSendToServer.UseVisualStyleBackColor = true;
            this.btnSendToServer.Click += new System.EventHandler(this.btnSendToServer_Click);
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.Location = new System.Drawing.Point(87, 131);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(75, 23);
            this.btnEncryptFile.TabIndex = 8;
            this.btnEncryptFile.Text = "Encrypt";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // boxDirectoryServer
            // 
            this.boxDirectoryServer.Controls.Add(this.btnDeleteFile);
            this.boxDirectoryServer.Controls.Add(this.btnDownloadFile);
            this.boxDirectoryServer.Controls.Add(this.btnRefreshFileList);
            this.boxDirectoryServer.Controls.Add(this.listBox1);
            this.boxDirectoryServer.Location = new System.Drawing.Point(436, 27);
            this.boxDirectoryServer.Name = "boxDirectoryServer";
            this.boxDirectoryServer.Size = new System.Drawing.Size(340, 169);
            this.boxDirectoryServer.TabIndex = 9;
            this.boxDirectoryServer.TabStop = false;
            this.boxDirectoryServer.Text = "Server directory";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(259, 131);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 3;
            this.btnDeleteFile.Text = "Delete";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(177, 131);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadFile.TabIndex = 2;
            this.btnDownloadFile.Text = "Download";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnRefreshFileList
            // 
            this.btnRefreshFileList.Location = new System.Drawing.Point(95, 131);
            this.btnRefreshFileList.Name = "btnRefreshFileList";
            this.btnRefreshFileList.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshFileList.TabIndex = 1;
            this.btnRefreshFileList.Text = "Refresh";
            this.btnRefreshFileList.UseVisualStyleBackColor = true;
            this.btnRefreshFileList.Click += new System.EventHandler(this.btnRefreshFileList_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(328, 95);
            this.listBox1.TabIndex = 0;
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(262, 263);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(75, 23);
            this.btnConnectServer.TabIndex = 10;
            this.btnConnectServer.Text = "Connect";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // StatusServerLabel
            // 
            this.StatusServerLabel.AutoSize = true;
            this.StatusServerLabel.Location = new System.Drawing.Point(18, 216);
            this.StatusServerLabel.Name = "StatusServerLabel";
            this.StatusServerLabel.Size = new System.Drawing.Size(69, 13);
            this.StatusServerLabel.TabIndex = 11;
            this.StatusServerLabel.Text = "Server status";
            // 
            // txtServerStatus
            // 
            this.txtServerStatus.AutoSize = true;
            this.txtServerStatus.Location = new System.Drawing.Point(99, 215);
            this.txtServerStatus.Name = "txtServerStatus";
            this.txtServerStatus.Size = new System.Drawing.Size(0, 13);
            this.txtServerStatus.TabIndex = 12;
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(18, 245);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(29, 13);
            this.HostLabel.TabIndex = 13;
            this.HostLabel.Text = "Host";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(18, 269);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 14;
            this.PortLabel.Text = "Port";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(99, 242);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(157, 20);
            this.txtHost.TabIndex = 15;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(99, 266);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(157, 20);
            this.txtPort.TabIndex = 16;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(433, 215);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(58, 13);
            this.UserNameLabel.TabIndex = 17;
            this.UserNameLabel.Text = "User name";
            // 
            // PublicClientKeyE
            // 
            this.PublicClientKeyE.AutoSize = true;
            this.PublicClientKeyE.Location = new System.Drawing.Point(433, 245);
            this.PublicClientKeyE.Name = "PublicClientKeyE";
            this.PublicClientKeyE.Size = new System.Drawing.Size(96, 13);
            this.PublicClientKeyE.TabIndex = 18;
            this.PublicClientKeyE.Text = "Public Client Key E";
            // 
            // PublicClientKeyN
            // 
            this.PublicClientKeyN.AutoSize = true;
            this.PublicClientKeyN.Location = new System.Drawing.Point(433, 269);
            this.PublicClientKeyN.Name = "PublicClientKeyN";
            this.PublicClientKeyN.Size = new System.Drawing.Size(97, 13);
            this.PublicClientKeyN.TabIndex = 19;
            this.PublicClientKeyN.Text = "Public Client Key N";
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Location = new System.Drawing.Point(528, 216);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(0, 13);
            this.txtUserName.TabIndex = 20;
            // 
            // txtClientKeyE
            // 
            this.txtClientKeyE.AutoSize = true;
            this.txtClientKeyE.Location = new System.Drawing.Point(528, 245);
            this.txtClientKeyE.Name = "txtClientKeyE";
            this.txtClientKeyE.Size = new System.Drawing.Size(0, 13);
            this.txtClientKeyE.TabIndex = 21;
            // 
            // txtClientKeyN
            // 
            this.txtClientKeyN.AutoSize = true;
            this.txtClientKeyN.Location = new System.Drawing.Point(528, 268);
            this.txtClientKeyN.Name = "txtClientKeyN";
            this.txtClientKeyN.Size = new System.Drawing.Size(0, 13);
            this.txtClientKeyN.TabIndex = 22;
            // 
            // txtServerKeyN
            // 
            this.txtServerKeyN.AutoSize = true;
            this.txtServerKeyN.Location = new System.Drawing.Point(705, 268);
            this.txtServerKeyN.Name = "txtServerKeyN";
            this.txtServerKeyN.Size = new System.Drawing.Size(0, 13);
            this.txtServerKeyN.TabIndex = 26;
            // 
            // txtServerKeyE
            // 
            this.txtServerKeyE.AutoSize = true;
            this.txtServerKeyE.Location = new System.Drawing.Point(705, 245);
            this.txtServerKeyE.Name = "txtServerKeyE";
            this.txtServerKeyE.Size = new System.Drawing.Size(0, 13);
            this.txtServerKeyE.TabIndex = 25;
            // 
            // PublicServerKeyN
            // 
            this.PublicServerKeyN.AutoSize = true;
            this.PublicServerKeyN.Location = new System.Drawing.Point(597, 269);
            this.PublicServerKeyN.Name = "PublicServerKeyN";
            this.PublicServerKeyN.Size = new System.Drawing.Size(102, 13);
            this.PublicServerKeyN.TabIndex = 24;
            this.PublicServerKeyN.Text = "Public Server Key N";
            // 
            // PublicServerKeyE
            // 
            this.PublicServerKeyE.AutoSize = true;
            this.PublicServerKeyE.Location = new System.Drawing.Point(598, 245);
            this.PublicServerKeyE.Name = "PublicServerKeyE";
            this.PublicServerKeyE.Size = new System.Drawing.Size(101, 13);
            this.PublicServerKeyE.TabIndex = 23;
            this.PublicServerKeyE.Text = "Public Server Key E";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 298);
            this.Controls.Add(this.txtServerKeyN);
            this.Controls.Add(this.txtServerKeyE);
            this.Controls.Add(this.PublicServerKeyN);
            this.Controls.Add(this.PublicServerKeyE);
            this.Controls.Add(this.txtClientKeyN);
            this.Controls.Add(this.txtClientKeyE);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.PublicClientKeyN);
            this.Controls.Add(this.PublicClientKeyE);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.HostLabel);
            this.Controls.Add(this.txtServerStatus);
            this.Controls.Add(this.StatusServerLabel);
            this.Controls.Add(this.btnConnectServer);
            this.Controls.Add(this.boxDirectoryServer);
            this.Controls.Add(this.boxFileInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Internetych";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.boxFileInfo.ResumeLayout(false);
            this.boxFileInfo.PerformLayout();
            this.boxDirectoryServer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostPortToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label DirectoryNameLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox boxFileInfo;
        private System.Windows.Forms.Label txtStatusLabel;
        private System.Windows.Forms.Label txtSizeLabel;
        private System.Windows.Forms.TextBox txtDirectoryName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Button btnSendToServer;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.GroupBox boxDirectoryServer;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Button btnRefreshFileList;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.Label StatusServerLabel;
        private System.Windows.Forms.Label txtServerStatus;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PublicClientKeyE;
        private System.Windows.Forms.Label PublicClientKeyN;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.Label txtClientKeyE;
        private System.Windows.Forms.Label txtClientKeyN;
        private System.Windows.Forms.Label txtServerKeyN;
        private System.Windows.Forms.Label txtServerKeyE;
        private System.Windows.Forms.Label PublicServerKeyN;
        private System.Windows.Forms.Label PublicServerKeyE;
    }
}

