using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
namespace cityzbase
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double lat = Convert.ToDouble(textBox1.Text);
            double lon = Convert.ToDouble(textBox2.Text);
            gMapControl1.Position = new GMap.NET.PointLatLng(lat, lon);
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 15;
            gMapControl1.Zoom = 12;
        }
        
        private void Form4_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.DragButton = MouseButtons.Left;
            /////////
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        Point lastPoint;
        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
