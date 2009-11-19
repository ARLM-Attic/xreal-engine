using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Build.BuildEngine;
using XRealEngine.Framework;
using Microsoft.Build.Framework;
using System;

namespace Editor.Controls
{
    

    public partial class ContentProjectControl : UserControl
    {
        private const string COMPILE_ITEM = "Compile";
        private const string ASSET_NAME_PROPERTY = "Name";
        private const string IMPORTER_PROPERTY = "Importer";
        private const string PROCESSOR_PROPERTY = "Processor";

        Project contentProject;
        string projectFullPath;
        Dictionary<string, ContentFile> contentFilesDictionary;
        ILogger logger;

        // Declare the delegate (if using non-generic pattern).
        public delegate void AssetsListDoubleClickEventHandler(object sender, AssetsListEventArg e);

        // Declare the event.
        public event AssetsListDoubleClickEventHandler AssetsListDoubleClick;



        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public string ContentPath
        {
            get { return contentProject.EvaluatedProperties["OutputPath"].FinalValue; }
        }

        public ContentProjectControl()
        {
            InitializeComponent();
            contentFilesDictionary = new Dictionary<string, ContentFile>();
        }

        public string ProjectFullPath
        {
            get { return projectFullPath; }
            set { projectFullPath = value; }
        }

        public void LoadProject()
        {
            contentProject = new Project();
            contentProject.Load(projectFullPath);
            contentFilesDictionary.Clear();

            foreach (BuildItemGroup group in contentProject.ItemGroups)
            {
                foreach (BuildItem item in group)
                {
                    if (item.Name == COMPILE_ITEM) AddCompileItem(item);
                }
            }
        }

        public void BuildProject()
        {
            ILogger logger = this.Logger;

            if (logger == null)
            {
                logger = new FileLogger();
                logger.Parameters = @"logfile=C:\Temp\XRealEngine.Editor.log";
            }
            
            Engine msBuildEngine = contentProject.ParentEngine;
            msBuildEngine.RegisterLogger(logger);
            msBuildEngine.BuildProject(contentProject);
            msBuildEngine.UnregisterAllLoggers();
        }

        private void AddCompileItem(BuildItem item)
        {
            string fileName = item.Include;
            string assetName = item.GetEvaluatedMetadata(ASSET_NAME_PROPERTY);
            string processor = item.GetEvaluatedMetadata(PROCESSOR_PROPERTY);
            string importer = item.GetEvaluatedMetadata(IMPORTER_PROPERTY);

            contentFilesDictionary.Add(assetName, new ContentFile(fileName, assetName, importer, processor));
        }

        public void RefreshTreeview()
        {
            assetsTreeView.Nodes.Clear();
            foreach (ContentFile file in contentFilesDictionary.Values)
            {
                TreeNode node = new TreeNode(file.AssetName);
                assetsTreeView.Nodes.Add(node);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string assetName = assetsTreeView.SelectedNode.Text;
            AssetsListEventArg assetArg = new AssetsListEventArg(GetAsset(assetName));
            this.AssetsListDoubleClick(this, assetArg);
        }

        public ContentFile GetAsset(string assetName)
        {
            return contentFilesDictionary[assetName];
        }

    }
}
