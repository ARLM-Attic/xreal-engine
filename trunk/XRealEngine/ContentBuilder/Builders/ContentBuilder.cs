using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Framework;
using System.Runtime.InteropServices;

namespace XRealEngine.Windows.Builders
{
    public enum XnaVersion 
    {
        Xna20,
        XNA_3_0,
        XNA_3_1
    }

    public class ContentBuilder : IDisposable
    {
        private static int TempPathId = 0;

        private XnaVersion xnaVersion;
        private AssemblyManager assemblyManager;
        private ContentFileManager contentFileManager;
        private ILogger logger;
        private string projectPath;
        private string outputPath;

        
        private string basePath;
        private bool isDisposed;

        public XnaVersion XnaVersion
        {
            get { return xnaVersion; }
            private set { xnaVersion = value; }
        }
        
        public ILogger Logger
        {
            get { return logger; }
            private set
            {
                if (value == null)
                {
                    logger = new FileLogger();
                    logger.Parameters = @"logfile=C:\temp\xrealengine.build.log";
                }
                else
                {
                    logger = value;
                }

            }
        }

        private string OutputPath
        {
            get { return outputPath; }
        }
        
        public string ContentPath
        {
            get { return String.Format("{0}/content",outputPath); }
        }

        private AssemblyManager AssemblyManager
        {
            get { return assemblyManager; }
            set { assemblyManager = value; }
        }
        
        public ContentBuilder(XnaVersion version, ILogger logger)
        {
            this.XnaVersion = version;
            this.Logger = logger;
            this.assemblyManager = new AssemblyManager();
            this.contentFileManager = new ContentFileManager();
            this.basePath = GetTempPath();
            this.projectPath = Path.Combine(basePath, "content.contentproj");
            this.outputPath = Path.Combine(basePath, "bin");

            assemblyManager.AddAssembly(String.Format("Microsoft.Xna.Framework.Content.Pipeline.FBXImporter, Version={0}.0.0, PublicKeyToken=6d5c3888ef60e27d", GetXnaFrameworkVersion(version)));
            assemblyManager.AddAssembly(String.Format("Microsoft.Xna.Framework.Content.Pipeline.XImporter, Version={0}.0.0, PublicKeyToken=6d5c3888ef60e27d", GetXnaFrameworkVersion(version)));
            assemblyManager.AddAssembly(String.Format("Microsoft.Xna.Framework.Content.Pipeline.TextureImporter, Version={0}.0.0, PublicKeyToken=6d5c3888ef60e27d", GetXnaFrameworkVersion(version)));
            assemblyManager.AddAssembly(String.Format("Microsoft.Xna.Framework.Content.Pipeline.EffectImporter, Version={0}.0.0, PublicKeyToken=6d5c3888ef60e27d", GetXnaFrameworkVersion(version)));

           

        }

        ~ContentBuilder()
        {
            Dispose(false);
        }

        public void AddAssembly(string filename)
        {
            assemblyManager.AddAssembly(filename);
        }

        public void AddFileToBuild(ContentFile file)
        {
            contentFileManager.AddFile(file);
        }

        public void AddFileToBuild(string filename, string name)
        {
            contentFileManager.AddFile(new ContentFile(filename, name, null, null));
        }

        public void AddFileToBuild(string filename, string name, string importer)
        {
            contentFileManager.AddFile(new ContentFile(filename, name, importer, null));
        }

        public void AddFileToBuild(string filename, string name, string importer, string processor)
        {
            contentFileManager.AddFile(new ContentFile(filename, name, importer, processor));
        }

        public void BuildProject()
        {
            Directory.CreateDirectory(this.basePath);

            Engine msBuildEngine;
            Project msBuildProject;

            msBuildEngine = new Engine();
            msBuildEngine.RegisterLogger(Logger);
            msBuildEngine.DefaultToolsVersion = "3.5";

            msBuildProject = new Project(msBuildEngine);
            msBuildProject.FullFileName = this.projectPath;
            msBuildProject.SetProperty("Configuration", "Release");
            msBuildProject.SetProperty("OutputPath", this.outputPath);
            msBuildProject.SetProperty("XnaPlatform", "Windows");
            msBuildProject.SetProperty("OutputType", "Library");
            msBuildProject.SetProperty("TargetFrameworkVersion", "v3.5");
            msBuildProject.SetProperty("XnaFrameworkVersion", String.Format("v{0}", GetXnaFrameworkVersion(this.XnaVersion)));
            msBuildProject.DefaultTargets = "Build";
   
            foreach (string assembly in assemblyManager)
            {
                msBuildProject.AddNewItem("Reference", assembly);
            }

            foreach (ContentFile content in contentFileManager)
            {
                BuildItem buildItem = msBuildProject.AddNewItem("Compile", content.Filename);
                buildItem.SetMetadata("Link", Path.GetFileName(content.Filename));
                buildItem.SetMetadata("Name", content.AssetName);
                if (!String.IsNullOrEmpty(content.Importer)) buildItem.SetMetadata("Importer", content.Importer);
                if (!String.IsNullOrEmpty(content.Processor)) buildItem.SetMetadata("Processor", content.Processor);
            }

            msBuildProject.AddNewImport("$(MSBuildExtensionsPath)\\Microsoft\\XNA " +
                                       "Game Studio\\$(XnaFrameworkVersion)\\Microsoft.Xna.GameStudio" +
                                       ".ContentPipeline.targets", null);

            msBuildProject.Build();
        }

        private static string GetXnaFrameworkVersion(XnaVersion version)
        {
            switch (version)
            {
                case XnaVersion.Xna20:
                    return "2.0";
                case XnaVersion.XNA_3_0:
                    return "3.0";
                case XnaVersion.XNA_3_1:
                    return "3.1";
                default:
                    throw new ArgumentException("This version of the XNA Framework in not supported");
            }
        }

        private static string GetTempPath()
        {
            TempPathId++;

            int processId = Process.GetCurrentProcess().Id;
            string baseDirectory = Path.Combine(Path.GetTempPath(), "XRealEngine.ContentBuilder");
            string processDirectory = Path.Combine(baseDirectory, processId.ToString());
            string buildDirectory = Path.Combine(baseDirectory, TempPathId.ToString());

            return buildDirectory;
        }

        #region IDisposable Members

        /// <summary>
        /// Disposes the content builder when it is no longer required.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implements the standard .NET IDisposable pattern.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                isDisposed = true;
                Directory.Delete(basePath, true);
            }
        }


        #endregion
    }
}
