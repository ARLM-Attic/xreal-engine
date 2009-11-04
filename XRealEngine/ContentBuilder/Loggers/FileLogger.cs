using System;
using System.IO;
using Microsoft.Build.Framework;

namespace XRealEngine.Framework.Loggers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Represents a build logger which logs to the specified file.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    public class FileLogger : ILogger
    {
        #region Fields
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The filename of the log file to be produced.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private string filename;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The writer used to write to the log file.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private StreamWriter writer;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The total number of warnings the build process has trigerred.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int warningsCount = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The total number of errors the build process has trigerred.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int errorsCount = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The logger parameters.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private string parameters;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The logger verbosity.</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private LoggerVerbosity verbosity = LoggerVerbosity.Normal;

        #endregion

        #region Properties
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets the full path to the log file
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Filename { get { return filename; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the parameters of the logger
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the verbosity of the logger
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public LoggerVerbosity Verbosity
        {
            get { return verbosity; }
            set { verbosity = value; }
        }

        #endregion

        #region Constructor
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes new FileLogger instance.
        /// </summary>
        /// <param name="filename">The full path of the file to log to.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public FileLogger(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            this.filename = filename;
            this.writer = new StreamWriter(filename);
        }
        #endregion

        #region Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Shuts down the logger.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Shutdown()
        {
            writer.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initializes logger instance.
        /// </summary>
        /// <param name="eventSource">Event source for the logger.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Initialize(Microsoft.Build.Framework.IEventSource eventSource)
        {
            eventSource.ProjectStarted += new ProjectStartedEventHandler(eventSource_ProjectStarted);
            eventSource.TargetStarted += new TargetStartedEventHandler(eventSource_TargetStarted);
            eventSource.ProjectFinished += new ProjectFinishedEventHandler(eventSource_ProjectFinished);        
            eventSource.ErrorRaised += new BuildErrorEventHandler(eventSource_ErrorRaised);
            eventSource.WarningRaised += new BuildWarningEventHandler(eventSource_WarningRaised);
        }

        #endregion

        #region Logger Implemented Events

        private void eventSource_ProjectStarted(object sender, Microsoft.Build.Framework.ProjectStartedEventArgs e)
        {
            this.writer.WriteLine("Project Started: " + e.ProjectFile);
        }

        private void eventSource_TargetStarted(object sender, Microsoft.Build.Framework.TargetStartedEventArgs e)
        {
            if (Verbosity == LoggerVerbosity.Detailed)
            {
                Console.WriteLine("Target Started: " + e.TargetName);
            }
        }

        private void eventSource_ProjectFinished(object sender, Microsoft.Build.Framework.ProjectFinishedEventArgs e)
        {
            this.writer.WriteLine("Project Finished: " + e.ProjectFile);
        }


        private void eventSource_WarningRaised(object sender, Microsoft.Build.Framework.BuildWarningEventArgs e)
        {
            warningsCount++;
            this.writer.WriteLine(String.Format("WARNING : {0}",e.Message));
        }

        private void eventSource_ErrorRaised(object sender, Microsoft.Build.Framework.BuildErrorEventArgs e)
        {
            errorsCount++;
            this.writer.WriteLine(String.Format("ERROR : {0}", e.Message));
        }

        #endregion
    }
}
