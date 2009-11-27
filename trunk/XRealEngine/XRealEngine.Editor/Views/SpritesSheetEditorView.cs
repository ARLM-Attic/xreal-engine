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

namespace XRealEngine.Editor.Views
{
    public partial class SpritesSheetEditorView : Form, IView
    {
        private Presenter<SpritesSheetEditorView> presenter;
        public event EventHandler ShowMessage;
        public event EventHandler LoadSpritesSheet;

        public SpritesSheetEditorView()
        {
            InitializeComponent();

            presenter = new SpritesSheetEditorPresenter(this);
        }

        public string Message
        {
            set { this.label1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowMessage(this, EventArgs.Empty);
        }

        private void openSpritesSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSpritesSheet(this, EventArgs.Empty);
        }
        
    }
}
