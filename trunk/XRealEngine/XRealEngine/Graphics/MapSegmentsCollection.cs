using System;
using System.Collections.Generic;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegmentsCollection
    {
        private List<List<MapSegment>> mapSegments;

        public MapSegmentsCollection()
        {
            mapSegments = new List<List<MapSegment>>();
        }

        public MapSegment this[int layerIndex, int segmentIndex]
        {
            get { return mapSegments[layerIndex][segmentIndex]; }
        }

        public int GetSegmentsCount(int layerIndex)
        {
            return mapSegments[layerIndex].Count;
        }

        public void Add(int layerIndex, MapSegment segment)
        {
            mapSegments[layerIndex].Add(segment);
        }
    }
}
