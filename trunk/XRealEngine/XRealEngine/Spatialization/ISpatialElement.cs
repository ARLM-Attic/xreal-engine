using Microsoft.Xna.Framework;
using System;

namespace XRealEngine.Framework.Spatialization
{
    public interface ISpatialElement
    {
        event EventHandler Moved;

        Rectangle BoundingBox
        {
            get;
        }
    }
}
