﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Graphics
{
    public class Map
    {
        private SpritesSheetCollection spritesSheets;
        private MapLayersCollection layers;
        private MapSegmentsCollection segments;

        public Map()
        {
            spritesSheets = new SpritesSheetCollection();
            layers = new MapLayersCollection();
            segments = new MapSegmentsCollection();
        }

        public void AddSpritesSheet(string spritesSheetName, ISpritesSheet spritesSheet)
        {
            spritesSheets.Add(spritesSheetName, spritesSheet);
        }

        public void AddLayer(MapLayer layer)
        {
            layers.Add(layer);
        }

        public void AddSegment(MapSegment segment)
        {
            segments.Add(segment);
        }

        public void AddSegment(int layerIndex, int spriteSheetIndex, int spriteDefinitionIndex, Point location)
        {
            MapSegment segment = new MapSegment();
            
            segment.LayerIndex = layerIndex;
            segment.BoundingBox = spritesSheets[spriteSheetIndex][spriteDefinitionIndex].Rectangle;
            segment.Location = location;
            segment.SpriteSheetIndex = spriteSheetIndex;
            segment.SpriteDefinitionIndex = spriteDefinitionIndex;

            segments.Add(segment);
        }
    }
}
