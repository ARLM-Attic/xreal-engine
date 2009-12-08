using System;
using System.Windows.Forms;
using XRealEngine.Editor.Components;
using XRealEngine.Editor.Presenters;
using XRealEngine.Framework.Graphics;

namespace XRealEngine.Editor.Views
{
    public partial class SpritesSheetEditorView : Form, IView
    {
        private Presenter<SpritesSheetEditorView> presenter;
        public event EventHandler LoadSpritesSheet;
        public event EventHandler SaveSpritesSheet;
        public event SpriteEventHandler ChangeSelectedSprite;
        public event SpriteEventHandler EndOperation;
        public event SpriteEventHandler RemoveSelectedSprite;
        public event SpriteEventHandler AddSprite;

        public SpritesSheetEditorView()
        {
            InitializeComponent();

            presenter = new SpritesSheetEditorPresenter(this);
        }

        public string Title
        {
            set
            {
                this.Text = String.Format("Sprites Sheet Editor : {0}", value);
            }
        }

        public SpritesSheet SpritesSheet
        {
            get
            {
                return this.spritesSheetViewer1.SpritesSheet;
            }
            set
            {
                this.spritesSheetViewer1.SpritesSheet = value;
                this.spritesSheetList1.AddSpritesSheet(value);
            }
        }

        public SpriteDefinition SelectedSprite
        {
            get { return this.spritesSheetViewer1.SelectedSprite; }
            set
            {
                this.spritesSheetViewer1.SelectedSprite = value;
                this.propertyGrid1.SelectedObject = value;
                this.spritesSheetList1.SelectedSprite = value;
            }
        }

        public void RemoveSpriteFromSheet(SpriteDefinition sprite)
        {
            this.spritesSheetViewer1.RemoveSprite(sprite);
            this.propertyGrid1.SelectedObject = null;
            this.spritesSheetList1.RemoveSprite(sprite);
        }

        public void AddNewSprite(SpriteDefinition sprite)
        {
            this.spritesSheetViewer1.AddSprite(sprite);
            this.spritesSheetList1.AddSprite(sprite);
        }

        public IServiceProvider Services
        {
            get { return this.spritesSheetViewer1.Services; }
        }

        public void RefreshSelectedSprite()
        {
            this.spritesSheetList1.RefreshSpriteImage(this.SelectedSprite);
            this.propertyGrid1.Refresh();
        }

        private void openSpritesSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSpritesSheet(this, EventArgs.Empty);
        }

        private void spritesSheetViewer1_SelectedSpriteChanged(object sender, SpriteEventArgs e)
        {
            ChangeSelectedSprite(this, e);
        }

        private void spritesSheetViewer1_OperationEnded(object sender, SpriteEventArgs e)
        {
            EndOperation(this, e);
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            EndOperation(this, new SpriteEventArgs(this.SelectedSprite));
        }

        private void spritesSheetList1_SelectedSpriteChanged(object sender, SpriteEventArgs e)
        {
            ChangeSelectedSprite(this, e);
        }

        private void spritesSheetList1_SelectedSpriteRemoved(object sender, SpriteEventArgs e)
        {
            RemoveSelectedSprite(this, e);
        }

        private void spritesSheetList1_SpriteAdded(object sender, SpriteEventArgs e)
        {
            AddSprite(this, e);
        }

        private void saveSpritesSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSpritesSheet(this, e);
        }

    }
}
