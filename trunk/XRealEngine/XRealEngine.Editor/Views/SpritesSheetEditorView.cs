using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRealEngine.Editor.Presenters;
using Microsoft.Xna.Framework.Graphics;
using XRealEngine.Framework.Sprites;
using XRealEngine.Editor.Components;

namespace XRealEngine.Editor.Views
{
    public partial class SpritesSheetEditorView : Form, IView
    {
        private Presenter<SpritesSheetEditorView> presenter;
        public event EventHandler LoadSpritesSheet;
        public event SpriteEventHandler ChangeSelectedSprite;
        public event SpriteEventHandler EndOperation;

        public SpritesSheetEditorView()
        {
            InitializeComponent();

            presenter = new SpritesSheetEditorPresenter(this);
        }

        public string Title
        {
            set { this.Text = String.Format("Sprites Sheet Editor : {0}", value); }
        }

        public SpritesSheet SpritesSheet
        {
            get { return this.spritesSheetViewer1.SpritesSheet; }
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

        public IServiceProvider Services
        {
            get { return this.spritesSheetViewer1.Services; }
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
        
    }
}
