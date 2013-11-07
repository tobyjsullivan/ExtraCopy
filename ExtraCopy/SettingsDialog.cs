using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExtraCopy
{
    public partial class SettingsDialog : Form
    {
        private Settings m_settings = new Settings();
        private System.Threading.Thread m_comparisonThread;

        public SettingsDialog()
        {
            InitializeComponent();
            this.m_comparisonThread = null;
        }

        private void w_bSourceBrowse_Click(object sender, EventArgs e)
        {
            this.w_folderBrowserDialog.SelectedPath = this.m_settings.SourceDirectory;
            DialogResult dr = this.w_folderBrowserDialog.ShowDialog();

            if (dr != DialogResult.OK) return;

            this.m_settings.SourceDirectory = this.w_folderBrowserDialog.SelectedPath;
            this.w_tbSource.Text = this.m_settings.SourceDirectory;
        }

        private void w_bTargetBrowse_Click(object sender, EventArgs e)
        {
            this.w_folderBrowserDialog.SelectedPath = this.m_settings.TargetDirectory;
            DialogResult dr = this.w_folderBrowserDialog.ShowDialog();

            if (dr != DialogResult.OK) return;

            this.m_settings.TargetDirectory = this.w_folderBrowserDialog.SelectedPath;
            this.w_tbTarget.Text = this.m_settings.TargetDirectory;
        }

        private void w_bApply_Click(object sender, EventArgs e)
        {
            this.m_settings.Save();
            this.ApplyWatch();
            UpdateUI();
        }

        private void ApplyWatch()
        {
            if (!Directory.Exists(this.m_settings.SourceDirectory))
            {
                this.ShowSourceLocationNotFoundError();
                return;
            }

            this.w_fileSystemWatcher.Path = this.m_settings.SourceDirectory;
            this.TriggerComparison();
        }

        private void w_fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            this.TriggerComparison();
        }

        private void TriggerComparison()
        {
            if (this.m_comparisonThread == null || this.m_comparisonThread.ThreadState != System.Threading.ThreadState.Running)
            {
                this.m_comparisonThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.RunComparison));
                this.m_comparisonThread.Start();
            }
        }

        private delegate void ErrorMessageDelegate();

        private void ShowStillRunningNotification()
        {
            this.w_notifyIcon.ShowBalloonTip(15000, "Running in Background", "ExtraCopy is still running in the background to help protect your data. If you would like to close the application, right-click on this icon.", ToolTipIcon.Info);
        }

        private void ShowSourceLocationNotFoundError()
        {
            this.w_notifyIcon.ShowBalloonTip(15000, "Source Location Error", "ExtraCopy cannot find your source data. Please make sure your settings are correct.", ToolTipIcon.Error);
        }

        private void ShowTargetLocationNotFoundError()
        {
            this.w_notifyIcon.ShowBalloonTip(15000, "Backup Location Error", "ExtraCopy cannot find your backup location. Please make sure your settings are correct and that your backup medium is connected properly.", ToolTipIcon.Error);
        }

        private void ShowSourceAndTargetLocationsSameError()
        {
            this.w_notifyIcon.ShowBalloonTip(20000, "Invalid Backup Location", "You have set your backup location to be the same as your source data location. This is not permitted. Please re-check your settings.", ToolTipIcon.Error);
        }

        private void RunComparison()
        {
            if (!Directory.Exists(this.m_settings.SourceDirectory))
            {
                this.Invoke(new ErrorMessageDelegate(this.ShowSourceLocationNotFoundError));
                return;
            }

            if (!Directory.Exists(this.m_settings.TargetDirectory))
            {
                this.Invoke(new ErrorMessageDelegate(this.ShowTargetLocationNotFoundError));
                return;
            }

            if (this.m_settings.SourceDirectory == this.m_settings.TargetDirectory)
            {
                this.Invoke(new ErrorMessageDelegate(this.ShowSourceAndTargetLocationsSameError));
                return;
            }

            try
            {
                DirectoryInfo dirSource = new DirectoryInfo(this.m_settings.SourceDirectory);
                DirectoryInfo dirTarget = new DirectoryInfo(this.m_settings.TargetDirectory);

                CompareDirectories(dirSource, dirTarget);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CompareDirectories(DirectoryInfo diSource, DirectoryInfo diTarget)
        {
            if (diSource == null || diTarget == null) return;

            try
            {
                if (!diSource.Exists) return;

                if (!diTarget.Exists)
                {
                    diTarget.Create();
                }

                FileInfo[] filesSource = diSource.GetFiles();
                foreach (FileInfo fileCurSource in filesSource)
                {
                    FileInfo fileTarget = new FileInfo(Path.Combine(diTarget.FullName, fileCurSource.Name));

                    if (!fileTarget.Exists || GetFileMD5(fileCurSource) != GetFileMD5(fileTarget))
                    {
                        BackupFile(fileCurSource, fileTarget);
                    }
                }

                DirectoryInfo[] diSourceSubDirs = diSource.GetDirectories();
                foreach (DirectoryInfo diCurrentSource in diSourceSubDirs)
                {
                    DirectoryInfo diCurrentTarget = new DirectoryInfo(Path.Combine(diTarget.FullName, diCurrentSource.Name));

                    if (!diCurrentTarget.Exists)
                    {
                        diCurrentTarget.Create();
                    }

                    CompareDirectories(diCurrentSource, diCurrentTarget);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BackupFile(FileInfo fileSource, FileInfo fileTarget)
        {
            string sDate = string.Format("{0:yyyy-MM-dd-HHmm}", fileSource.LastWriteTime);
            string sFilenameDated = fileTarget.FullName + "." + sDate + fileTarget.Extension;

            FileStream fsSource = new FileStream(fileSource.FullName, FileMode.Open, FileAccess.Read);
            FileStream fsTarget = new FileStream(fileTarget.FullName, FileMode.Create, FileAccess.Write);
            FileStream fsTagetDated = new FileStream(sFilenameDated, FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[1024];
            int iReadLength = 0;
            while ((iReadLength = fsSource.Read(buffer, 0, 1024)) > 0)
            {
                fsTarget.Write(buffer, 0, iReadLength);
                fsTagetDated.Write(buffer, 0, iReadLength);
            }

            fsSource.Flush();
            fsSource.Close();
            fsTarget.Flush();
            fsTarget.Close();
            fsTagetDated.Flush();
            fsTagetDated.Close();
        }

        private void w_fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            this.TriggerComparison();
        }

        private void w_fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            this.TriggerComparison();
        }

        private void UpdateUI()
        {
            this.w_tbSource.Text = this.m_settings.SourceDirectory;
            this.w_tbTarget.Text = this.m_settings.TargetDirectory;
        }

        private void w_bCancel_Click(object sender, EventArgs e)
        {
            this.m_settings.Load();
            UpdateUI();
            MinimizeDialog();
        }

        private static string GetFileMD5(FileInfo file)
        {
            FileStream fs = file.Open(FileMode.Open, FileAccess.Read);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] checksum = md5.ComputeHash(fs);
            fs.Close();
            ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(checksum);
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreDialog();
        }

        private void RestoreDialog()
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void MinimizeDialog()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void w_notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreDialog();
        }

        private void w_bOk_Click(object sender, EventArgs e)
        {
            this.m_settings.Save();
            this.ApplyWatch();
            UpdateUI();
            MinimizeDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(e.CloseReason == CloseReason.UserClosing)) return;

            DialogResult dr = MessageBox.Show("Are you sure you want to close ExtraCopy? Your files will not be backed up if the program is not running.",
                "Close ExtraCopy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void SettingsDialog_Resize(object sender, EventArgs e)
        {
            this.ShowInTaskbar = this.WindowState != FormWindowState.Minimized;
        }

        private void SettingsDialog_Shown(object sender, EventArgs e)
        {
            if (!Settings.SettingsExist())
            {
                this.RestoreDialog();
            }
            else
            {
                this.m_settings.Load();
                this.ApplyWatch();
                this.UpdateUI();
            }
        }
    }
}