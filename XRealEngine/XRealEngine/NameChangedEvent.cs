using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRealEngine.Framework
{
    internal class NameChangedEventArgs:EventArgs
    {
        private string oldName;
        private string newName;

        public string NewName
        {
            get { return newName; }
        }

        public string OldName
        {
            get { return oldName; }
        }

        public NameChangedEventArgs(string oldName, string newName)
        {
            if (newName == null) throw new NullReferenceException("The new name must not be null");

            this.oldName = oldName;
            this.newName = newName;
        }

    }
}
