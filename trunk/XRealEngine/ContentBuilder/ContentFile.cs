using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRealEngine.Framework
{
    public struct ContentFile
    {
        public string Filename;
        public string AssetName;
        public string Importer;
        public string Processor;

        public ContentFile(string filename, string assetName, string importer, string processor)
        {
            this.Filename = filename;
            this.AssetName = assetName;
            this.Importer = importer;
            this.Processor = processor;
        }
    }
}
