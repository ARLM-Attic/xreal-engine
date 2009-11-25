using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace XRealEngine.ContentPipeline
{
    public class Serializer
    {
        public static void Serialize<T>(string filename, T objectToSerialize)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            using (XmlWriter xmlWriter = XmlWriter.Create(filename, xmlSettings))
            {
                IntermediateSerializer.Serialize(xmlWriter, objectToSerialize, null);
            }
    
        }
            

    }
}
