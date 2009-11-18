using System;
using System.Windows.Forms;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace XRealEngine.Framework.Loggers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Represents a build logger which logs to the specified TextBox.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    public class ListViewLogger : Logger
    {
        delegate void AddNodeCallBack(string nodeText);

        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The TexBox to log to.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private ListView listView;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The total number of warnings produced by the building process.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int warningsCount = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The total number of errors produced by the building process.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int errorsCount = 0;

        private bool needToLog;

        #endregion

        #region Properties

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Gets or sets text box to log to.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public ListView ListView 
        {
            get { return listView; } 
            set { listView = value; } 
        }

        #endregion

        #region Contructors / Destructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes new TextBoxLogger instance.
        /// </summary>
        /// <param name="textBox">Text box to log to.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ListViewLogger(ListView listView)
        {
            if (listView == null) throw new ArgumentNullException("listView");

            ListView = listView;
        }

        #endregion

        #region Methods

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Initializes logger instance.
        /// </summary>
        /// <param name="eventSource">Event source for the logger.</param>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public override void Initialize(Microsoft.Build.Framework.IEventSource eventSource)
        {
            eventSource.BuildFinished += new BuildFinishedEventHandler(eventSource_BuildFinished);
            eventSource.BuildStarted += new BuildStartedEventHandler(eventSource_BuildStarted);
            eventSource.WarningRaised += new BuildWarningEventHandler(eventSource_WarningRaised);
            eventSource.ErrorRaised += new BuildErrorEventHandler(eventSource_ErrorRaised);
            eventSource.TargetFinished += new TargetFinishedEventHandler(eventSource_TargetFinished);
            eventSource.TargetStarted += new TargetStartedEventHandler(eventSource_TargetStarted);
            eventSource.MessageRaised += new BuildMessageEventHandler(eventSource_MessageRaised);
            eventSource.AnyEventRaised += new AnyEventHandler(eventSource_AnyEventRaised);
            eventSource.CustomEventRaised += new CustomBuildEventHandler(eventSource_CustomEventRaised);
            
            eventSource.ProjectFinished += new ProjectFinishedEventHandler(eventSource_ProjectFinished);
            eventSource.ProjectStarted += new ProjectStartedEventHandler(eventSource_ProjectStarted);
            
            eventSource.TaskFinished += new TaskFinishedEventHandler(eventSource_TaskFinished);
            eventSource.TaskStarted += new TaskStartedEventHandler(eventSource_TaskStarted);
            
         
        }

        #endregion

        private void AddNode(string nodeText)
        {
            if (listView.InvokeRequired)
            {
                AddNodeCallBack callback = new AddNodeCallBack(AddNode);
                listView.Invoke(callback, new object[] { nodeText });
            }
            else
            {
                listView.Items.Add(nodeText);
            }
        }

        #region Implemented Events

        private void eventSource_MessageRaised(object sender, Microsoft.Build.Framework.BuildMessageEventArgs e)
        {
            if (needToLog) this.AddNode(e.Message);
        }

        private void eventSource_ErrorRaised(object sender, Microsoft.Build.Framework.BuildErrorEventArgs e)
        {
            errorsCount++;
            this.AddNode(e.Message);
        }

        private void eventSource_WarningRaised(object sender, Microsoft.Build.Framework.BuildWarningEventArgs e)
        {
            warningsCount++;
            this.AddNode(e.Message);
        }

        private void eventSource_CustomEventRaised(object sender, Microsoft.Build.Framework.CustomBuildEventArgs e)
        {
            if (needToLog) this.AddNode(e.Message);
        }

        private void eventSource_AnyEventRaised(object sender, Microsoft.Build.Framework.BuildEventArgs e)
        {
            if (needToLog) this.AddNode(e.Message);
        }

        private void eventSource_TaskStarted(object sender, Microsoft.Build.Framework.TaskStartedEventArgs e)
        {
            this.AddNode(e.Message);
        }

        private void eventSource_TaskFinished(object sender, Microsoft.Build.Framework.TaskFinishedEventArgs e)
        {
            this.AddNode(e.Message);
            
        }

        private void eventSource_TargetStarted(object sender, Microsoft.Build.Framework.TargetStartedEventArgs e)
        {
            if (e.TargetName == "Compile")
                needToLog = true;
            else
                needToLog = true;
        }

        private void eventSource_TargetFinished(object sender, Microsoft.Build.Framework.TargetFinishedEventArgs e)
        {
           if (needToLog)  needToLog = false;
        }

        private void eventSource_StatusEventRaised(object sender, Microsoft.Build.Framework.BuildStatusEventArgs e)
        {
            this.AddNode(e.Message);
        }

        private void eventSource_ProjectStarted(object sender, Microsoft.Build.Framework.ProjectStartedEventArgs e)
        {
            this.AddNode(e.Message);
        }

        private void eventSource_ProjectFinished(object sender, Microsoft.Build.Framework.ProjectFinishedEventArgs e)
        {
            this.AddNode(e.Message);
        }

        private void eventSource_BuildStarted(object sender, Microsoft.Build.Framework.BuildStartedEventArgs e)
        {
            errorsCount = 0;
            warningsCount = 0;
            this.AddNode(e.Message);
        }

        private void eventSource_BuildFinished(object sender, Microsoft.Build.Framework.BuildFinishedEventArgs e)
        {
            this.AddNode(e.Message);
            this.AddNode(errorsCount.ToString() + " errors, " + warningsCount.ToString() + " warnings.");
        }

       

        #endregion
    }
}
