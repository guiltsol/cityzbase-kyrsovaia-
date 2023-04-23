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

namespace cityzbase
{
    public partial class Form2 : Form
    {
        static string contry;
        static string cityname;
        double nasel;
        double plos;
        static string stol;
        double obzp;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            string[] st = { "Да", "Нет"};

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.DataSource = st;
            comboBox1.SelectedIndex = 0;
            
            string[] con = { "Франция", "Швеция","Россия","США" };

            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox2.DataSource = con;
            comboBox2.SelectedIndex = 0;
            
            string[] cit = { "Санкт-Петербург", "Москва","Стокгольм","Париж","Нью-Йорк" };

            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            comboBox3.DataSource = cit;
            comboBox3.SelectedIndex = 0;
            
        }

        static void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            stol = comboBox.SelectedItem.ToString();
        }
        static void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            contry = comboBox.SelectedItem.ToString();
        }

        static void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            cityname = comboBox.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png";
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openPicture.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
                | (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
                | (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
                | (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != String.Empty)
            {
                //ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
                nasel = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                textBox3.Focus();
                MessageBox.Show("Заполните поле Население");
                return;
            }
            if (textBox4.Text != String.Empty)
            {
                //cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
                plos = Convert.ToDouble(textBox4.Text);
            }
            else
            {
                textBox4.Focus();
                MessageBox.Show("Заполните поле Площадь города");
                return;
            }
            if (textBox5.Text != String.Empty)
            {
                //cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
                obzp = Convert.ToDouble(textBox5.Text);
            }
            else
            {
                textBox5.Focus();
                MessageBox.Show("Заполните поле Общая зп населения");
                return;
            }
            Cityz s = new Cityz(contry,cityname,nasel,plos,stol,obzp);

            MessageBox.Show(s.Info());

            String fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Сохранить успеваемость";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog.FileName = @"C:\Users\Администратор\source\repos\cityzbase\citibase.txt";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;// Сохранить имя файла
                StreamWriter streamwriter = new StreamWriter(fileName, true, System.Text.Encoding.GetEncoding("utf-8"));
                streamwriter.WriteLine(s.Info());

                streamwriter.Close();

                pictureBox1.Image.Save(@"C:\Users\Администратор\source\repos\cityzbase\img\" + comboBox3.Text + ".jpg");

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double sred_zp = 0;
            if (textBox5.Text != String.Empty)
            {
                
                obzp = Convert.ToDouble(textBox5.Text);
            }
            else
            {
                textBox5.Focus();
                MessageBox.Show("Заполните поле Общая зп населения");
                return;
            }
            if (textBox3.Text != String.Empty)
            {
                
                nasel = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                textBox3.Focus();
                MessageBox.Show("Заполните поле Население");
                return;
            }
            sred_zp = obzp/nasel;
            textBox6.Text = sred_zp.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            double sred_pl = 0;
            
            if (textBox4.Text != String.Empty)
            {
                //ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
                plos = Convert.ToDouble(textBox4.Text);
            }
            else
            {
                textBox4.Focus();
                MessageBox.Show("Заполните поле Площадь");
                return;
            }
            if (textBox3.Text != String.Empty)
            {
                //cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
                nasel = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                textBox3.Focus();
                MessageBox.Show("Заполните поле Население");
                return;
            }
            sred_pl = nasel / plos;
            
            textBox1.Text = sred_pl.ToString();
        }

        
        
    }
}
