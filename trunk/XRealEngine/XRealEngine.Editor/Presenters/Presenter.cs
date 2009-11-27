using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Editor.Views;

namespace XRealEngine.Editor.Presenters
{
    abstract class Presenter<T> where T:IView
    {
        private T view;

        public Presenter(T view)
        {
            this.view = view;
        }

        public T View
        {
            get { return view; }
        }
    }
}
