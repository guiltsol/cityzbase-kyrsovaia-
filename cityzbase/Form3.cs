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
    public partial class Form3 : Form
    {
        DataTable dt;
        string filterField = "Страна";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            StreamReader file = new StreamReader(@"C:\Users\Администратор\source\repos\cityzbase\citibase.txt");
            
            dt = new DataTable();
            
            dt.Columns.Add("Страна");
            dt.Columns.Add("Название города");
            dt.Columns.Add("Население");
            dt.Columns.Add("Площадь города(км^2)");
            dt.Columns.Add("Столица");
            dt.Columns.Add("Общая зп города");
          

            

            string[] values; 
            string newline; 
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow(); 
                values = newline.Split(' '); 
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i]; 
                }

                dt.Rows.Add(dr); 
            }
            file.Close();
            
            dataGridView1.DataSource = dt;
           
            dataGridView1.AutoResizeColumns();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                
                dt.Columns.Add("Средняя плотность населения");
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double nas = Convert.ToDouble(dt.Rows[i]["Население"]);
                    double s = Convert.ToDouble(dt.Rows[i]["Площадь города(км^2)"]);
                    dt.Rows[i]["Средняя плотность населения"] = nas/s;
                }
                dataGridView1.DataSource = dt;
            }
            else
            
            {
                dt.Columns.Remove("Средняя плотность населения");
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                
                dt.Columns.Add("Средняя зп населения");
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double zp = Convert.ToDouble(dt.Rows[i]["Общая зп города"]);
                    double nas = Convert.ToDouble(dt.Rows[i]["Население"]);
                    dt.Rows[i]["Средняя зп населения"] = zp/nas;
                }
                dataGridView1.DataSource = dt;
            }
            else
         
            {
                dt.Columns.Remove("Средняя зп населения");
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterField, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelApp.Cells[1, 1] = "Страна";
            ExcelApp.Cells[1, 2] = "Город";
            ExcelApp.Cells[1, 3] = "Население";
            ExcelApp.Cells[1, 4] = "Площадь(км^2)";
            ExcelApp.Cells[1, 5] = "Столица";
            ExcelApp.Cells[1, 6] = "Общая зп города";
            if (checkBox1.Checked && checkBox2.Checked)
            {
                ExcelApp.Cells[1, 7] = "Средняя зп";
                ExcelApp.Cells[1, 8] = "Средняя плотность населения";
            }
            else if (checkBox1.Checked)
            {
                ExcelApp.Cells[1, 7] = "Средняя зп";
            }
            else if (checkBox2.Checked) {
                ExcelApp.Cells[1, 7] = "Средняя плотность населения";
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            ExcelWorkBook.SaveAs(@"C:\Users\Администратор\source\repos\cityzbase\tabs.xlsx");
            ExcelWorkBook.Close(true);
            ExcelApp.Quit();
            MessageBox.Show("Excel file created , you can find the file C:/Users/Администратор/source/repos/cityzbase/tabs.xlsx");

        }
    }
}
