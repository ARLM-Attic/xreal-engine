using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Graphics
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Define a playable map
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Map
    {
        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Holds the sprites sheets collection</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private SpritesSheetCollection spritesSheets;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Holds the layers collection</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private MapLayersCollection layers;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Holds the segments collection</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private MapSegmentsCollection segments;

        #endregion

        #region Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Return the sprites sheets collection of the map</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SpritesSheetCollection SpritesSheets
        {
            get {return spritesSheets;}
        }

        #endregion

        #region Constructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new Map
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Map()
        {
            spritesSheets = new SpritesSheetCollection();
            layers = new MapLayersCollection();
            segments = new MapSegmentsCollection();
        }

        #endregion

        #region Methods
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Add a new sprites sheet to the map
        /// </summary>
        /// <param name="spritesSheet">The sprites sheet to be added</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddSpritesSheet(ISpritesSheet spritesSheet)
        {
            spritesSheets.Add(spritesSheet);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Add a new layer to the map
        /// </summary>
        /// <param name="layer">The layer to be added</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddLayer(MapLayer layer)
        {
            layers.Add(layer);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create and add a new segment to the map
        /// </summary>
        /// <param name="layerIndex">The layer on which the segment will be added</param>
        /// <param name="location">The position on the map at which the segment will be added</param>     
        /// <param name="spriteSheetIndex">The index of the spritesSheet from which the segment is readed</param>
        /// <param name="spriteDefinitionIndex">The index of the sprite in the sprites sheet</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MapSegment AddSegment(int layerIndex, int spriteSheetIndex, int spriteDefinitionIndex, Point location)
        {
            MapSegment segment = new MapSegment();
            Rectangle boundingBox = spritesSheets[spriteSheetIndex][spriteDefinitionIndex].Rectangle;
            boundingBox.Location = location;

            segment.LayerIndex = layerIndex;
            segment.BoundingBox = boundingBox;
            segment.SpriteSheetIndex = spriteSheetIndex;
            segment.SpriteDefinitionIndex = spriteDefinitionIndex;

            segments.Add(segment);

            return segment;
        }

        #endregion
    }
}
