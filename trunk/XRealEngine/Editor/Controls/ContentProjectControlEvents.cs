using System;
using XRealEngine.Windows.Builders;

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
