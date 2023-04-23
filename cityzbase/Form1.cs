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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;


namespace cityzbase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\Администратор\source\repos\cityzbase\citibase.txt"))
            {
                Form3 f = new Form3();
                f.Show();
            }
            else
            {
                MessageBox.Show("Файла нет");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.PowerPoint.Application app = new Microsoft.Office.Interop.PowerPoint.Application();
           
            app.Presentations.Open(@"C:\Users\Администратор\source\repos\cityzbase\citis.pptx");
        }
    }
}
