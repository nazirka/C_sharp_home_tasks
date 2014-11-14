using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        TTextClass m_Text;

        public Form1()
        {
            InitializeComponent();

            m_Text = new TTextClass();
        }
                

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            m_Text.Dictionary.Clear();
            m_Text.Dictionary.Load_From_File(openFileDialog1.FileName, "\r\n");             
        }

        private void загрузитьФайлСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            m_Text.Read_File_Name = openFileDialog2.FileName;
        }

        private void выбратьФайлТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void преобразоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_Text.Read_File_Name == "")
                MessageBox.Show("Не выбран файл текста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
                m_Text.Convert();            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
