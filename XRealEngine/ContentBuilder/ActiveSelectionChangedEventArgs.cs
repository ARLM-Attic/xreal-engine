using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRealEngine.Framework
{
    internal class ActiveSelectionChangedEventArgs:EventArgs
    {
        private bool oldValue;
        private bool newValue;

        public bool NewValue
        {
            get { return newValue; }
        }

        public bool OldValue
        {
            get { return oldValue; }
        }

        public ActiveSelectionChangedEventArgs(bool oldValue, bool newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

    }
}
