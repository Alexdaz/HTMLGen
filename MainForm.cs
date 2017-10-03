using HTMLGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTMLGen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog Colr = new ColorDialog();
            if (Colr.ShowDialog() == DialogResult.OK)
            {
                rchtxt.SelectionBackColor = Colr.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cor = new ColorDialog();
            if (cor.ShowDialog() == DialogResult.OK)
            {
                rchtxt.SelectionColor = cor.Color;
            }
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                rchtxt.SelectionFont = font.Font;
            }
        }

        private void fondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColrB = new ColorDialog();
            if (ColrB.ShowDialog() == DialogResult.OK)
            {
                rchtxt.BackColor = ColrB.Color;
            }
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (rchtxt.Text.Length == 0)
            {
                MessageBox.Show("Debes de ingresar almenos una letra.", "Error Falta texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rchtxtCode.Clear();
            }
            else
            {
                rchtxtCode.Text = new ConvertText().TextToHtml(rchtxt);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rchtxt.Text.Length == 0 || rchtxtCode.Text.Length == 0)
            {
                MessageBox.Show("Falta texto por convertir o todavia no has convertido el texto.", "Error Falta texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SaveFileDialog ar = new SaveFileDialog();
                ar.Title = "Guardar Como";

                ar.Filter = "Documento HTML|*.html";

                ar.DefaultExt = "html";


                if (ar.ShowDialog() == DialogResult.OK)
                {
                    {
                        rchtxtCode.SaveFile(ar.FileName, RichTextBoxStreamType.UnicodePlainText);
                        this.Text = ar.FileName;
                    }
                }
            }

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutD ab = new AboutD();
            ab.Show();
        }

    }
}
