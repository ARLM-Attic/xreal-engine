using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace XRealEngine.ContentPipeline
{
    [ContentTypeSerializer]
    class SpriteSheetSerializer : ContentTypeSerializer<SpritesSheet>
    {
        protected override void Serialize(IntermediateWriter output, SpritesSheet value, ContentSerializerAttribute format)
        {
            // Saving the sprites list

            output.Xml.WriteStartElement("SpritesList");
            foreach (SpriteDefinition sprite in value)
            {
                output.WriteRawObject<SpriteDefinition>(sprite, CreateAttribute("Sprite"));
            }
            output.Xml.WriteEndElement();

            // Saving the texture

            ExternalReference<Texture2DContent> texture = new ExternalReference<Texture2DContent>();
            texture.Filename = @"C:\Users\LEPECQMI\Documents\Visual Studio 2008\Projects\XRealEngine\ANotSoDeadPirate\Content\maps1.png"; 
            output.Xml.WriteStartElement("Texture");
            output.WriteExternalReference<Texture2DContent>(texture);
            output.Xml.WriteEndElement(); 
            
        }

        protected override SpritesSheet Deserialize(IntermediateReader input, ContentSerializerAttribute format, SpritesSheet existingInstance)
        {
            if (existingInstance == null) existingInstance = new SpritesSheet();

            // Reading the sprites list

            input.MoveToElement("SpritesList");
            input.Xml.ReadStartElement();
            while (input.MoveToElement("Sprite"))
            {
                existingInstance.Add(input.ReadRawObject<SpriteDefinition>(CreateAttribute("Sprite")));
            }
            input.Xml.ReadEndElement();

            // Reading the texture

            input.MoveToElement("Texture");
            input.Xml.ReadStartElement();
            ExternalReference<Texture2DContent> texture = new ExternalReference<Texture2DContent>();
            input.ReadExternalReference<Texture2DContent>(texture);
            input.Xml.ReadEndElement();
            
            return existingInstance;
            
        }

        private static ContentSerializerAttribute CreateAttribute(string name)
        {
            ContentSerializerAttribute attribute = new ContentSerializerAttribute();
            attribute.ElementName = name;
            return attribute;
        }
    }
}
