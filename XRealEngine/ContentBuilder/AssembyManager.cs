using System.Collections.Generic;

namespace XRealEngine.Framework
{
    class AssemblyManager:IEnumerable<string>
    {
        private List<string> assemblies;

        public AssemblyManager()
        {
            assemblies = new List<string>();
        }

        public void AddAssembly(string assemblyPath)
        {
            assemblies.Add(assemblyPath);
        }



        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            return assemblies.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return assemblies.GetEnumerator();
        }

        #endregion
    }
}
