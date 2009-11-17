using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace Editor
{
    internal class Serializer
    {
        public static void Serialize<TInput>(string filename, TInput objectToSerialize)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                IntermediateSerializer.Serialize<TInput>(writer, objectToSerialize, null);
            }
        }
    }
}
