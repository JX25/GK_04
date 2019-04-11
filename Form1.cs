using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK04
{
    public partial class Form1 : Form
    {

        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            float newX = (float)Double.Parse(textBox1.Text);
            float newY = (float)Double.Parse(textBox2.Text);
            float r = (float)Double.Parse(textBox3.Text);
            g.DrawEllipse(pen1, newX - r, newY - r, 2 * r, 2 * r);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            float newX = (float)Double.Parse(textBox1.Text);
            float newY = (float)Double.Parse(textBox2.Text);
            float a = (float)Double.Parse(textBox4.Text);
            double kat = Double.Parse(textBox5.Text); //radiany
            double kat2 = Double.Parse(textBox5.Text); //radiany
            kat = 360 * kat / 2 * Math.PI;
            double[,] mRotacji = makeRotationMatrix(kat2);

            PointF p1 = new PointF(newX, newY);
            PointF p2 = new PointF(a+ newX, newY);
            PointF p3 = new PointF(a+ newX, a+ newY);
            PointF p4 = new PointF(newX, a+ newY);

            PointF[] kwadrat = { p1, p2, p3, p4 };
            for (int i = 0; i < 4; i++)
            {
                float x = kwadrat[i].X;
                float y = kwadrat[i].Y;
                kwadrat[i].X = x * (float)mRotacji[0, 0] + y * (float)mRotacji[0, 1] ;
                kwadrat[i].Y = x * (float)mRotacji[1, 0] + y * (float)mRotacji[1, 1] ;

            }

            Matrix rotMatrix = new Matrix();

             g.DrawLine(pen1, kwadrat[0], kwadrat[1]);
             g.DrawLine(pen1, kwadrat[1], kwadrat[2]);
             g.DrawLine(pen1, kwadrat[2], kwadrat[3]);
             g.DrawLine(pen1, kwadrat[3], kwadrat[0]);
            Matrix myMatrix = new Matrix();
            Matrix myMatrix2 = new Matrix();
            myMatrix2.Translate(newX, newY);
            myMatrix2.Rotate((float)kat);
            myMatrix2.Scale(2, 3);
            g.Transform = myMatrix2;
            g.DrawRectangle(pen1, 0, 0, a, a);
            Double skalax = 0.2;
            Double skalay = 1.5;
            myMatrix.Scale((float)skalax, (float)skalay);
            myMatrix.Scale(30, 25, MatrixOrder.Append);
            g.Transform = myMatrix;


            rotMatrix.Rotate((float)kat, MatrixOrder.Append);
            g.Transform = rotMatrix;
            //g.DrawRectangle(pen1, newX, newY, a, a);




        }

        private double [,] makeRotationMatrix( double rad)
        {
            double[,] matrix = new double[,] { { Math.Cos(rad), Math.Sin(rad), 0 }, { -Math.Sin(rad), Math.Cos(rad), 0 }, { 0, 0, 1 } };
            return matrix;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            PointF p1 = new PointF(0, 0);
            PointF p2 = new PointF(80, 215);
            PointF p3 = new PointF(40, 300);
            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen1, p2, p3);
            g.DrawLine(pen1, p3, p1);
            float skala = (float)Double.Parse(textBox6.Text);
            p2.X = p2.X * skala;
            p2.Y = p2.Y * skala;
            p3.X = p3.X * skala;
            p3.Y = p3.Y * skala;
            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen1, p2, p3);
            g.DrawLine(pen1, p3, p1);


             
        }
    }
}
