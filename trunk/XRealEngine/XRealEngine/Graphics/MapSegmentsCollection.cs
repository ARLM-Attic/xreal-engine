using System;
using System.Collections.Generic;
using XRealEngine.Framework.Spatialization;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegmentsCollection
    {
        private QuadTree<MapSegment> mapSegments;

        public MapSegmentsCollection()
        {
            mapSegments = new QuadTree<MapSegment>();
        }

        public void Add(MapSegment segment)
        {
            mapSegments.Add(segment);
        }
    }
}
