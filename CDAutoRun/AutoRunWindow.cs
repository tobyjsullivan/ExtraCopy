using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDAutoRun
{
    public partial class AutoRunWindow : Form
    {
        public AutoRunWindow()
        {
            InitializeComponent();
        }

        private void w_bInstall_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo fiSetup = new System.IO.FileInfo("./ExtraCopySetup.msi");
            if (!fiSetup.Exists)
            {
                MessageBox.Show("The setup file cannot be found. Make sure you are running this installer from the installation CD", "Missing File: ExtraCopySetup.msi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process installProcess;
            installProcess = System.Diagnostics.Process.Start(fiSetup.FullName);
        }

        private void w_bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void w_bRemove_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo fiSetup = new System.IO.FileInfo("./ExtraCopySetup.msi");
            if (!fiSetup.Exists)
            {
                MessageBox.Show("The setup file cannot be found. Make sure you are running this installer from the installation CD", "Missing File: ExtraCopySetup.msi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process installProcess;
            installProcess = System.Diagnostics.Process.Start(fiSetup.FullName, "/uninstall \"{14CB2DAD-D60A-4FE9-9A04-8983A956304D}\"");
        }
    }
}
