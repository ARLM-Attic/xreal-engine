using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Spatialization
{
    public interface ISpatialElement
    {
        Rectangle BoundingBox
        {
            get;
        }
    }
}
