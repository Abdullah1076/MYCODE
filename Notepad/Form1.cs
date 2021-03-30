using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                if (MessageBox.Show("would you like to save the file?", "warrning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "choose a location where you want to save file";
                    saveFileDialog1.Filter = "text file(.txt)|.txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
                else
                {
                    richTextBox1.Clear();
                }
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                if (MessageBox.Show("would you like to save the file?", "warrning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "choose a location where you want to save file";
                    saveFileDialog1.Filter = "text file(.txt)|.txt|PDF file|.pdf|Word File|*.doc";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
                else
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    }
                }

            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                saveFileDialog1.DefaultExt = ".txt";
                saveFileDialog1.Filter = "Text File|.txt|PDF file|.pdf|Word File|*.doc";
                DialogResult dialogResult = saveFileDialog1.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("file is empty would you like to save the file?", "warrning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "choose a location where you want to save file";
                    saveFileDialog1.Filter = "text file(.txt)|.txt|PDF file|.pdf|Word File|*.doc";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
}
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = true;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Text File|.txt|PDF file|.pdf|Word File|*.doc";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }

        }

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, Font, Brushes.Black, 12, 10);
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
        }

        private void HighlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.Black;
        }

        private void FormClosingExit(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                if (MessageBox.Show("would you like to save the file?", "warrning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "choose a location where you want to save file";
                    saveFileDialog1.Filter = "text file(.txt)|.txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
                else
                {
                    richTextBox1.Clear();
                }
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
           
        }
    }
}