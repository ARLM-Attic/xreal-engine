using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRealEngine.Framework
{
    public struct ContentFile
    {
        public string Filename;
        public string Name;
        public string Importer;
        public string Processor;

        public ContentFile(string filename, string name, string importer, string processor)
        {
            this.Filename = filename;
            this.Name = name;
            this.Importer = importer;
            this.Processor = processor;
        }
    }
}
