namespace ExtraCopy
{
    partial class SettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.w_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.w_contextMenuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w_lSource = new System.Windows.Forms.Label();
            this.w_tbSource = new System.Windows.Forms.TextBox();
            this.w_lTarget = new System.Windows.Forms.Label();
            this.w_tbTarget = new System.Windows.Forms.TextBox();
            this.w_bApply = new System.Windows.Forms.Button();
            this.w_bSourceBrowse = new System.Windows.Forms.Button();
            this.w_bTargetBrowse = new System.Windows.Forms.Button();
            this.w_bCancel = new System.Windows.Forms.Button();
            this.w_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.w_fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.w_bOk = new System.Windows.Forms.Button();
            this.w_contextMenuNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.w_fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // w_notifyIcon
            // 
            this.w_notifyIcon.ContextMenuStrip = this.w_contextMenuNotify;
            this.w_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("w_notifyIcon.Icon")));
            this.w_notifyIcon.Text = "ExtraCopy";
            this.w_notifyIcon.Visible = true;
            this.w_notifyIcon.DoubleClick += new System.EventHandler(this.w_notifyIcon_DoubleClick);
            // 
            // w_contextMenuNotify
            // 
            this.w_contextMenuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.w_contextMenuNotify.Name = "w_contextMenuNotify";
            this.w_contextMenuNotify.Size = new System.Drawing.Size(128, 54);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // w_lSource
            // 
            this.w_lSource.AutoSize = true;
            this.w_lSource.Location = new System.Drawing.Point(12, 17);
            this.w_lSource.Name = "w_lSource";
            this.w_lSource.Size = new System.Drawing.Size(81, 13);
            this.w_lSource.TabIndex = 0;
            this.w_lSource.Text = "Source location";
            // 
            // w_tbSource
            // 
            this.w_tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.w_tbSource.Location = new System.Drawing.Point(102, 14);
            this.w_tbSource.Name = "w_tbSource";
            this.w_tbSource.ReadOnly = true;
            this.w_tbSource.Size = new System.Drawing.Size(243, 20);
            this.w_tbSource.TabIndex = 1;
            // 
            // w_lTarget
            // 
            this.w_lTarget.AutoSize = true;
            this.w_lTarget.Location = new System.Drawing.Point(12, 46);
            this.w_lTarget.Name = "w_lTarget";
            this.w_lTarget.Size = new System.Drawing.Size(84, 13);
            this.w_lTarget.TabIndex = 2;
            this.w_lTarget.Text = "Backup location";
            // 
            // w_tbTarget
            // 
            this.w_tbTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.w_tbTarget.Location = new System.Drawing.Point(102, 43);
            this.w_tbTarget.Name = "w_tbTarget";
            this.w_tbTarget.ReadOnly = true;
            this.w_tbTarget.Size = new System.Drawing.Size(243, 20);
            this.w_tbTarget.TabIndex = 3;
            // 
            // w_bApply
            // 
            this.w_bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.w_bApply.Location = new System.Drawing.Point(270, 72);
            this.w_bApply.Name = "w_bApply";
            this.w_bApply.Size = new System.Drawing.Size(75, 23);
            this.w_bApply.TabIndex = 4;
            this.w_bApply.Text = "Apply";
            this.w_bApply.UseVisualStyleBackColor = true;
            this.w_bApply.Click += new System.EventHandler(this.w_bApply_Click);
            // 
            // w_bSourceBrowse
            // 
            this.w_bSourceBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.w_bSourceBrowse.Location = new System.Drawing.Point(351, 12);
            this.w_bSourceBrowse.Name = "w_bSourceBrowse";
            this.w_bSourceBrowse.Size = new System.Drawing.Size(75, 23);
            this.w_bSourceBrowse.TabIndex = 5;
            this.w_bSourceBrowse.Text = "Browse...";
            this.w_bSourceBrowse.UseVisualStyleBackColor = true;
            this.w_bSourceBrowse.Click += new System.EventHandler(this.w_bSourceBrowse_Click);
            // 
            // w_bTargetBrowse
            // 
            this.w_bTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.w_bTargetBrowse.Location = new System.Drawing.Point(351, 41);
            this.w_bTargetBrowse.Name = "w_bTargetBrowse";
            this.w_bTargetBrowse.Size = new System.Drawing.Size(75, 23);
            this.w_bTargetBrowse.TabIndex = 6;
            this.w_bTargetBrowse.Text = "Browse...";
            this.w_bTargetBrowse.UseVisualStyleBackColor = true;
            this.w_bTargetBrowse.Click += new System.EventHandler(this.w_bTargetBrowse_Click);
            // 
            // w_bCancel
            // 
            this.w_bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.w_bCancel.Location = new System.Drawing.Point(351, 72);
            this.w_bCancel.Name = "w_bCancel";
            this.w_bCancel.Size = new System.Drawing.Size(75, 23);
            this.w_bCancel.TabIndex = 7;
            this.w_bCancel.Text = "Cancel";
            this.w_bCancel.UseVisualStyleBackColor = true;
            this.w_bCancel.Click += new System.EventHandler(this.w_bCancel_Click);
            // 
            // w_fileSystemWatcher
            // 
            this.w_fileSystemWatcher.EnableRaisingEvents = true;
            this.w_fileSystemWatcher.IncludeSubdirectories = true;
            this.w_fileSystemWatcher.SynchronizingObject = this;
            this.w_fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.w_fileSystemWatcher_Renamed);
            this.w_fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.w_fileSystemWatcher_Created);
            this.w_fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.w_fileSystemWatcher_Changed);
            // 
            // w_bOk
            // 
            this.w_bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.w_bOk.Location = new System.Drawing.Point(189, 72);
            this.w_bOk.Name = "w_bOk";
            this.w_bOk.Size = new System.Drawing.Size(75, 23);
            this.w_bOk.TabIndex = 9;
            this.w_bOk.Text = "OK";
            this.w_bOk.UseVisualStyleBackColor = true;
            this.w_bOk.Click += new System.EventHandler(this.w_bOk_Click);
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.w_bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.w_bCancel;
            this.ClientSize = new System.Drawing.Size(438, 107);
            this.Controls.Add(this.w_bCancel);
            this.Controls.Add(this.w_bOk);
            this.Controls.Add(this.w_bTargetBrowse);
            this.Controls.Add(this.w_bSourceBrowse);
            this.Controls.Add(this.w_bApply);
            this.Controls.Add(this.w_tbTarget);
            this.Controls.Add(this.w_lTarget);
            this.Controls.Add(this.w_tbSource);
            this.Controls.Add(this.w_lSource);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(454, 145);
            this.MinimumSize = new System.Drawing.Size(454, 145);
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExtraCopy";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Shown += new System.EventHandler(this.SettingsDialog_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDialog_FormClosing);
            this.Resize += new System.EventHandler(this.SettingsDialog_Resize);
            this.w_contextMenuNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.w_fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon w_notifyIcon;
        private System.Windows.Forms.Label w_lSource;
        private System.Windows.Forms.TextBox w_tbSource;
        private System.Windows.Forms.Label w_lTarget;
        private System.Windows.Forms.TextBox w_tbTarget;
        private System.Windows.Forms.Button w_bApply;
        private System.Windows.Forms.Button w_bSourceBrowse;
        private System.Windows.Forms.Button w_bTargetBrowse;
        private System.Windows.Forms.Button w_bCancel;
        private System.Windows.Forms.FolderBrowserDialog w_folderBrowserDialog;
        private System.IO.FileSystemWatcher w_fileSystemWatcher;
        private System.Windows.Forms.ContextMenuStrip w_contextMenuNotify;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button w_bOk;
    }
}

