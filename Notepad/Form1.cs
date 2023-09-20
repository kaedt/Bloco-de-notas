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
        private OpenFileDialog AbrirDialogo;
        private SaveFileDialog SalvarDialogo;
        private FontDialog FonteDialogo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FonteDialogo = new FontDialog();
        }
        private void CriarNovo()
        {
            try
            { if (!string.IsNullOrEmpty(this.richTextBox1.Text)) 
                {
                    this.Text = "Sem titulo";
                }
            else 
                {
                    MessageBox.Show("Não há nada para salvar.");
                }

            }
            catch (Exception ex) 
            { 
            
            
            }
            finally 
            { 
            
            }
        }

        private void AbrirArquivo()
        {
            try 
            { 
            AbrirDialogo = new OpenFileDialog();
                if (AbrirDialogo.ShowDialog() == DialogResult.OK) 
                { 
                this.richTextBox1.Text = File.ReadAllText(AbrirDialogo.FileName);
                this.Text = AbrirDialogo.FileName;
                }
            }
            catch (Exception ex)
            { 
            
            }
            finally 
            { 
            AbrirDialogo = null;
            }
        }
        private void SalvarArquivo() 
        {
            try
            {
                SalvarDialogo = new SaveFileDialog();
                SalvarDialogo.Filter = "Arquivo de texto (*.txt) | * .txt";
                if (SalvarDialogo.ShowDialog() != DialogResult.OK) 
                { 
                File.WriteAllText(SalvarDialogo.FileName, this.richTextBox1.Text);
                    this.Text=SalvarDialogo.FileName;
                }
            }
            catch (Exception ex) 
            { 
            
            }
            finally 
            { 
            
            }
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarNovo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarArquivo();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (FonteDialogo.ShowDialog() == DialogResult.OK) 
                {
                    this.richTextBox1.Font = FonteDialogo.Font;
                }
            }
            catch (Exception ex) 
            { 
            
            }
            finally 
            { 
            
            }
        }
    }
}
