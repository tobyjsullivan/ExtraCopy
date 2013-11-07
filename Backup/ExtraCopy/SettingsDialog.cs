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

        public SettingsDialog()
        {
            InitializeComponent();
            this.m_settings.Load();
            this.ApplyWatch();
            this.UpdateUI();
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
            this.w_fileSystemWatcher.Path = this.m_settings.SourceDirectory;
            this.RunComparison();
        }

        private void w_fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            RunComparison();
        }

        private void RunComparison()
        {
            if (!Directory.Exists(this.m_settings.SourceDirectory))
            {
                return;
            }

            if (!Directory.Exists(this.m_settings.TargetDirectory))
            {
                return;
            }

            if (this.m_settings.SourceDirectory == this.m_settings.TargetDirectory)
            {
                return;
            }

            try
            {
                DirectoryInfo dirSource = new DirectoryInfo(this.m_settings.SourceDirectory);
                DirectoryInfo dirTarget = new DirectoryInfo(this.m_settings.TargetDirectory);

                FileInfo[] filesSource = dirSource.GetFiles();
                FileInfo[] filesTarget = dirTarget.GetFiles();
                foreach (FileInfo fileCurSource in filesSource)
                {
                    bool bTargetExists = false;
                    foreach (FileInfo fileCurTarget in filesTarget)
                    {
                        if (fileCurSource.Name == fileCurTarget.Name)
                        {
                            if (GetFileMD5(fileCurSource) == GetFileMD5(fileCurTarget))
                            {
                                bTargetExists = true;
                            }
                            break;
                        }
                    }

                    if (!bTargetExists)
                    {
                        BackupFile(fileCurSource);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void BackupFile(FileInfo fileSource)
        {
            string sFilename = fileSource.Name;
            int iPosDot = sFilename.LastIndexOf('.');
            string sDate = string.Format("{0:yyyyMMddHHmmss}", fileSource.LastWriteTime);
            string sFilenameDated = sFilename.Substring(0, iPosDot) + sDate + sFilename.Substring(iPosDot);

            FileStream fsSource = new FileStream(fileSource.FullName, FileMode.Open, FileAccess.Read);
            FileStream fsTarget = new FileStream(Path.Combine(this.m_settings.TargetDirectory, sFilename), FileMode.Create, FileAccess.Write);
            FileStream fsTagetDated = new FileStream(Path.Combine(this.m_settings.TargetDirectory, sFilenameDated), FileMode.Create, FileAccess.Write);

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
            RunComparison();
        }

        private void w_fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            RunComparison();
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
    }
}