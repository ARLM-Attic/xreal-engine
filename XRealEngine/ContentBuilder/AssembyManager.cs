﻿using System.Collections.Generic;

namespace XRealEngine.Framework
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Represents the list of the different assemblies used to make the build
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    class AssemblyManager:IEnumerable<string>
    {
        #region Fields
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The list of the needed assemblies</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private List<string> assemblies;

        #endregion

        #region Contructor

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Standard constructor
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public AssemblyManager()
        {
            assemblies = new List<string>();
        }

        #endregion

        #region Methods

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Add a needed assembly to the assemblies list
        /// </summary>
        /// <param name="assemblyPath">The path to the assembly file</param>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public void AddAssembly(string assemblyPath)
        {
            assemblies.Add(assemblyPath);
        }

        #endregion

        #region IEnumerable<string> Members

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Return the enumerator to the assemblies list
        /// </summary>
        /// <returns>A string enumerator</returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public IEnumerator<string> GetEnumerator()
        {
            return assemblies.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Return the enumerator to the assemblies list
        /// </summary>
        /// <returns>An enumerator</returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return assemblies.GetEnumerator();
        }

        #endregion
    }
}
