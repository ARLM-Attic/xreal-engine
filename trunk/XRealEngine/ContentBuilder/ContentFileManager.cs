using System.Collections.Generic;

namespace XRealEngine.Framework
{
    class ContentFileManager:IEnumerable<ContentFile>
    {
        private List<ContentFile> files;

        public ContentFileManager()
        {
            files = new List<ContentFile>();
        }

        public void AddFile(string filename, string name)
        {
            files.Add(new ContentFile (filename, name, null, null));
        }
        
        public void AddFile(string filename, string name, string importer)
        {
            files.Add(new ContentFile(filename, name, importer, null));
        }

        public void AddFile(string filename, string name, string importer, string processor)
        {
            files.Add(new ContentFile(filename, name, importer, processor));
        }

        public void AddFile(ContentFile file)
        {
            files.Add(file);
        }

        #region IEnumerable<string> Members

        public IEnumerator<ContentFile> GetEnumerator()
        {
            return files.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return files.GetEnumerator();
        }

        #endregion
    }
}
