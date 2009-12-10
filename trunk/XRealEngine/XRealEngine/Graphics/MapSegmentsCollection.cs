using System;
using System.Collections.Generic;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegmentsCollection
    {
        private List<MapSegment> mapSegments;

        public MapSegmentsCollection()
        {
            mapSegments = new List<MapSegment>();
        }

        public MapSegment this[int segmentIndex]
        {
            get { return mapSegments[segmentIndex]; }
        }

        public int Count
        {
            get { return mapSegments.Count; }
        }

        public void Add(MapSegment segment)
        {
            mapSegments.Add(segment);
        }
    }
}
