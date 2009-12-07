using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Editor.Views;
using XRealEngine.ContentPipeline;
using XRealEngine.Framework.Sprites;
using System.Windows.Forms;
using XRealEngine.Windows.Builders;
using Microsoft.Xna.Framework.Content;
using XRealEngine.Editor.Components;
using System.IO;

namespace XRealEngine.Editor.Presenters
{
    class SpritesSheetEditorPresenter : Presenter<SpritesSheetEditorView>
    {
        private string fileName;

        public SpritesSheetEditorPresenter(SpritesSheetEditorView view)
            : base(view)
        {
            View.LoadSpritesSheet += new EventHandler(View_LoadSpritesSheet);
            View.ChangeSelectedSprite += new SpriteEventHandler(View_ChangeSelectedSprite);
            View.EndOperation += new SpriteEventHandler(View_EndOperation);
            View.RemoveSelectedSprite += new SpriteEventHandler(View_RemoveSelectedSprite);
            View.AddSprite += new SpriteEventHandler(View_AddSprite);
            View.SaveSpritesSheet += new EventHandler(View_SaveSpritesSheet);
        }

        void View_SaveSpritesSheet(object sender, EventArgs e)
        {
            SpritesSheetContent content = new SpritesSheetContent(View.SpritesSheet);
            Serializer.Serialize<SpritesSheetContent>(fileName, content);
        }

        void View_AddSprite(object sender, SpriteEventArgs e)
        {
            View.AddNewSprite(e.Sprite);
        }

        void View_RemoveSelectedSprite(object sender, SpriteEventArgs e)
        {
            View.RemoveSpriteFromSheet(e.Sprite);
        }

        void View_EndOperation(object sender, SpriteEventArgs e)
        {
            View.RefreshSelectedSprite();
        }

        void View_ChangeSelectedSprite(object sender, SpriteEventArgs e)
        {
            View.SelectedSprite = e.Sprite;
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
                fileName = openDialog.FileName;
                View.Title = openDialog.FileName;
            }
        }

        void BuildAndLoadSpriteSheet(string filename)
        {
            ContentBuilder builder = new ContentBuilder(XnaVersion.XNA_3_1, null);
            builder.AddAssembly(String.Format("{0}\\{1}", Application.StartupPath, "XRealEngine.ContentPipeline.dll"));
            builder.AddFileToBuild(filename, "sheet", "XmlImporter", "SpritesSheetContentProcessor");
            builder.AddFileToBuild(filename, "sheet", "XmlImporter", "SpritesSheetContentProcessor");
            builder.BasePath = Path.GetDirectoryName(filename);
            builder.BuildProject();

            ContentManager content = new ContentManager(View.Services, builder.ContentPath);
            View.SpritesSheet = content.Load<SpritesSheet>("sheet");
        }


    }

}
