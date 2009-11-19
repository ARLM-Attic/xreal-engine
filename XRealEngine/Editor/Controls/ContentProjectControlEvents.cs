using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Framework;

namespace Editor.Controls
{
    public class AssetsListEventArg : EventArgs
    {
        public ContentFile Asset;

        public AssetsListEventArg(ContentFile asset)
        {
            Asset = asset;
        }
    }
}
