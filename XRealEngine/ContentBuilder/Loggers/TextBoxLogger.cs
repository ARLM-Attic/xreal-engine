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
    public class TextBoxLogger : Logger
    {
        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The TexBox to log to.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private TextBoxBase textBox;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The total number of warnings produced by the building process.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int warningsCount = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The total number of errors produced by the building process.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int errorsCount = 0;

        #endregion

        #region Properties

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Gets or sets text box to log to.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public TextBoxBase TextBox 
        {
            get { return textBox; } 
            set { textBox = value; } 
        }

        #endregion

        #region Contructors / Destructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes new TextBoxLogger instance.
        /// </summary>
        /// <param name="textBox">Text box to log to.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public TextBoxLogger(TextBoxBase textBox)
        {
            if (textBox == null) throw new ArgumentNullException("textBox");

            TextBox = textBox;
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
            eventSource.CustomEventRaised += new CustomBuildEventHandler(eventSource_CustomEventRaised);
            eventSource.ErrorRaised += new BuildErrorEventHandler(eventSource_ErrorRaised);
            eventSource.MessageRaised += new BuildMessageEventHandler(eventSource_MessageRaised);
            eventSource.ProjectFinished += new ProjectFinishedEventHandler(eventSource_ProjectFinished);
            eventSource.ProjectStarted += new ProjectStartedEventHandler(eventSource_ProjectStarted);
            eventSource.TargetFinished += new TargetFinishedEventHandler(eventSource_TargetFinished);
            eventSource.TargetStarted += new TargetStartedEventHandler(eventSource_TargetStarted);
            eventSource.TaskFinished += new TaskFinishedEventHandler(eventSource_TaskFinished);
            eventSource.TaskStarted += new TaskStartedEventHandler(eventSource_TaskStarted);
            eventSource.WarningRaised += new BuildWarningEventHandler(eventSource_WarningRaised);
        }

        #endregion

        #region Implemented Events

        private void eventSource_WarningRaised(object sender, Microsoft.Build.Framework.BuildWarningEventArgs e)
        {
            warningsCount++;
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_TaskStarted(object sender, Microsoft.Build.Framework.TaskStartedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_TaskFinished(object sender, Microsoft.Build.Framework.TaskFinishedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_TargetStarted(object sender, Microsoft.Build.Framework.TargetStartedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_TargetFinished(object sender, Microsoft.Build.Framework.TargetFinishedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_StatusEventRaised(object sender, Microsoft.Build.Framework.BuildStatusEventArgs e)
        {
            textBox.Text += Environment.NewLine + "Status Event";
        }

        private void eventSource_ProjectStarted(object sender, Microsoft.Build.Framework.ProjectStartedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_ProjectFinished(object sender, Microsoft.Build.Framework.ProjectFinishedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_MessageRaised(object sender, Microsoft.Build.Framework.BuildMessageEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_ErrorRaised(object sender, Microsoft.Build.Framework.BuildErrorEventArgs e)
        {
            errorsCount++;
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_CustomEventRaised(object sender, Microsoft.Build.Framework.CustomBuildEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
        }

        private void eventSource_BuildStarted(object sender, Microsoft.Build.Framework.BuildStartedEventArgs e)
        {
            errorsCount = 0;
            warningsCount = 0;
            textBox.Text = e.Message;
        }

        private void eventSource_BuildFinished(object sender, Microsoft.Build.Framework.BuildFinishedEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.Message;
            textBox.Text += Environment.NewLine + errorsCount.ToString() + " errors, " + warningsCount.ToString() + " warnings.";
        }

        private void eventSource_AnyEventRaised(object sender, Microsoft.Build.Framework.BuildEventArgs e)
        {
            textBox.Text += Environment.NewLine + e.ToString();
        }

        #endregion
    }
}
