using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using XRealEngine.ContentPipeline;
using XRealEngine.Framework.Sprites;
using XRealEngine.Windows.Builders;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace XRealEngine.Editor.ViewModels
{
    class SpriteSheetViewModel : ViewModelBase
    {
        SpritesSheetContent contentSheet;
        SpritesSheet sheet;
        ContentManager content;

        #region Constructor

        public SpriteSheetViewModel(string filename, IServiceProvider provider)
        {
            content = new ContentManager(provider);
            /*
            _customer = customer;
            _customerRepository = customerRepository;
            _customerType = Strings.CustomerViewModel_CustomerTypeOption_NotSpecified;
             * */
        }

        #endregion // Constructor

        private void LoadSpritesSheet(string filename)
        {
            if (String.IsNullOrEmpty(filename)) throw new ArgumentNullException("filename");

            string contentSheetAssetName = String.Format("{0}_content", Path.GetFileNameWithoutExtension(filename));
            string sheetAssetName = String.Format("{0}", Path.GetFileNameWithoutExtension(filename));

            ContentBuilder builder = new ContentBuilder(XnaVersion.XNA_3_1, null);
            
            builder.AddAssembly(@"XRealEngine.ContentPipeline.dll");
            builder.AddFileToBuild(filename, contentSheetAssetName, "XMLImporter", null);
            builder.AddFileToBuild(filename, sheetAssetName, "XMLImporter", "SpritesSheetProcessor");
            builder.BuildProject();
            
            content.RootDirectory = builder.ContentPath;
            contentSheet = content.Load<SpritesSheetContent>(contentSheetAssetName);
            sheet = content.Load<SpritesSheet>(sheetAssetName);

        }
    }
}
