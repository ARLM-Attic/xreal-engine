using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRealEngine.Framework.Loggers;
using System.IO;

namespace Editor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region Menu Events

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = OpenFileDialog("Open a project file", "Content Project Files (*.contentproj)|*.contentproj");
 
            if (!String.IsNullOrEmpty(filename))
            {
                this.projectExplorer.Logger = new ListViewLogger(this.listViewLog);
                this.projectExplorer.ProjectFullPath = filename;
                this.backgroundBuilder.WorkerReportsProgress = true;
                this.backgroundBuilder.RunWorkerAsync();
               
            }
        }

        #endregion

        private string OpenFileDialog(string title, string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = Properties.Settings.Default.OpenDialogFilePath;
            openFileDialog.Filter = filter;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.OpenDialogFilePath = Path.GetDirectoryName(openFileDialog.FileName);
                Properties.Settings.Default.Save();
                return openFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }

        private void backgroundBuilder_DoWork(object sender, DoWorkEventArgs e)
        {
            this.backgroundBuilder.ReportProgress(0);
            this.projectExplorer.LoadProject();
            this.backgroundBuilder.ReportProgress(1);
            this.projectExplorer.BuildProject();   
        }

        private void backgroundBuilder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.projectExplorer.RefreshTreeview();
            MessageBox.Show(this.projectExplorer.ContentPath);
            this.statusLabel.Text = "Ready";
        }

        private void backgroundBuilder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    this.statusLabel.Text = String.Format("Loading {0} ...", this.projectExplorer.ProjectFullPath);
                    this.statusStrip.Refresh();
                    break;
                case 1:
                    this.statusLabel.Text = String.Format("Building {0} ...", this.projectExplorer.ProjectFullPath);
                    this.statusStrip.Refresh();
                    break;
            }
        }

        private void projectExplorer_AssetsListDoubleClick(object sender, Editor.Controls.AssetsListEventArg e)
        {
            switch (e.Asset.Importer)
            {
                case "":
                    break;
            }
        }
    }
}
