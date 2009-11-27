using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Editor.Views;
using XRealEngine.ContentPipeline;
using XRealEngine.Framework.Sprites;
using System.Windows.Forms;
using XRealEngine.Windows.Builders;

namespace XRealEngine.Editor.Presenters
{
    class SpritesSheetEditorPresenter : Presenter<SpritesSheetEditorView>
    {
        private SpritesSheetContent contentSheet;
        private SpritesSheet sheet;

        public SpritesSheetEditorPresenter(SpritesSheetEditorView view)
            : base(view)
        {
            View.ShowMessage += new EventHandler(View_ShowMessage);
            View.LoadSpritesSheet += new EventHandler(View_LoadSpritesSheet);
        }

        void View_LoadSpritesSheet(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "SpritesSheet File|*.xml";
            openDialog.Title = "Open a Sprites Sheet";
            DialogResult result = openDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                BuildAndLoadSpriteSheet(openDialog.FileName);
                View.Message = openDialog.FileName;
            }
        }

        void View_ShowMessage(object sender, EventArgs e)
        {
            View.Message = "Test";
        }

        void BuildAndLoadSpriteSheet(string filename)
        {
            ContentBuilder builder = new ContentBuilder(XnaVersion.XNA_3_1, null);
            builder.AddAssembly("XRealEngine.ContentPipeline");
            builder.AddFileToBuild(filename, "content", "XmlImporter", "SpritesSheetProcessor");
            builder.BuildProject();
        }

        

        
    }
    
}
