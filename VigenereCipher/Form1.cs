using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace VigenereCipher
{
    public partial class Form1 : Form
    {
        public bool addedFile = false;
        public string inputFilePath;
        public string outputFilePath;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void encruptButton_Click(object sender, EventArgs e)
        {
            if (addedFile && keyTextBox.Text != null)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(inputFilePath);
                    StreamWriter streamWriter = new StreamWriter(new FileStream("template.txt", FileMode.Create, FileAccess.Write), Encoding.UTF8);
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine(Cipher.VigenereEncrypt(line, keyTextBox.Text));
                        line = streamReader.ReadLine();
                    }
                    streamWriter.Close();
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        
                        outputFilePath = saveFileDialog1.FileName;
                        File.Move("template.txt", outputFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (inputTextBox.Text != null && keyTextBox.Text != null)
            {
                outputTextBox.Text = Cipher.VigenereEncrypt(inputTextBox.Text, keyTextBox.Text);
            }
            else
            {
                MessageBox.Show("Fill input and key text boxs");
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (addedFile && keyTextBox.Text != null)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(inputFilePath);
                    StreamWriter streamWriter = new StreamWriter(new FileStream("template.txt", FileMode.Create, FileAccess.Write), Encoding.UTF8);
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine(Cipher.VigenereDecrypt(line, keyTextBox.Text));
                        line = streamReader.ReadLine();
                    }
                    streamWriter.Close();
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        outputFilePath = saveFileDialog1.FileName;
                        File.Move("template.txt", outputFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (inputTextBox.Text != null && keyTextBox.Text != null)
            {
                outputTextBox.Text = Cipher.VigenereDecrypt(inputTextBox.Text, keyTextBox.Text);
            }
            else
            {
                MessageBox.Show("Fill input and key text boxs");
            }
        }

        private void openFileWithInputText_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFilePath = openFileDialog1.FileName;
                addedFile = true;
            }
        }
    }
}
