using System;
using System.Collections.Generic;

namespace XRealEngine.Framework.Graphics
{
    internal class MapLayersCollection
    {
        private List<MapLayer> layers;

        internal MapLayersCollection()
        {
            layers = new List<MapLayer>();
        }

        internal void Add(MapLayer layer)
        {
            layers.Add(layer);
        }

    }
}
