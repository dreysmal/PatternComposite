using System;
using System.Windows.Forms;

namespace Composite_Xml_File_System
{
    public partial class Form1 : Form , Ifiles 
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Tree { get => throw new NotImplementedException(); set => textBox1.Text = value; }
        public string Path
        {
            get
            {
                return textBox2.Text;
            }
        }
        public event EventHandler<EventArgs> Tree_string;

        private void button1_Click(object sender, EventArgs e)
        {
            Tree = String.Empty;
            try
            {
                Tree_string?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                MessageBox.Show("Wrong path!");
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }
    }
}
