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
//using System.Text;   

namespace NotepadM
{
    public partial class Form1 : Form
    {

        Stream myStream = null;

        OpenFileDialog openFile = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(openFile.FileName, richTextBox2.Text);
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                openFile.InitialDirectory = @"C:\";
                openFile.Multiselect = true;
                openFile.Title = "Abrir arquivo";
                openFile.Filter = " (*.txt)|*.txt";
                openFile.CheckFileExists = true;
                openFile.CheckPathExists = true;
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;
                openFile.ReadOnlyChecked = true;
                openFile.ShowReadOnly = true;
             

                try
                {
                    if ((myStream=openFile.OpenFile())!=null)
                    {
                        using (myStream)
                        {
                            richTextBox2.Text = File.ReadAllText(openFile.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ler arquivo do disco"+ex.Message);
                }
            }
            

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile.FileName = "";
            richTextBox2.Text = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox2.SelectedText != "")
            {
                Clipboard.SetText(richTextBox2.SelectedText);
                //MessageBox.Show(richTextBox2.SelectedText);                
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text += Clipboard.GetText();
        }

        //private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    lis
        //}
    }
}
