using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Homework_for_class_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = this.textBox2.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("没有输入有效的递归深度", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Clear();
                return;
            }
            n = Convert.ToInt32(textBox2.Text);
            str = this.textBox9.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("没有输入有效的主干长度", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox9.Clear();
                return;
            }
            leng = Convert.ToDouble(textBox9.Text);
            str = this.textBox10.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("没有输入有效的右分支长度比", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Clear();
                return;
            }
            per1 = Convert.ToDouble(textBox10.Text);
            str = this.textBox11.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("没有输入有效的左分支长度比", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Clear();
                return;
            }
            per2 = Convert.ToDouble(textBox11.Text);
            str = this.textBox12.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("没有输入有效的右分支角度", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox12.Clear();
                return;
            }
            th1 = Convert.ToDouble(textBox12.Text);
            str = this.textBox13.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("没有输入有效的右分支角度", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox13.Clear();
                return;
            }
            th2 = Convert.ToDouble(textBox13.Text);
            if (graphics == null && color != Color.Empty) 
            {
                graphics = this.panel1.CreateGraphics();
                drawCayleyTree(n, 200, 310, leng, -Math.PI / 2, color, th1, th2, per1, per2);
                return;
            }
            else 
            {
                MessageBox.Show("已有图像！");
                return; 
            } ;
            
        }
        private Graphics graphics = null;
        int n = 0;
        double leng = 0;
        Color color = Color.Empty;
        double th1 = 0;                                             
        double th2 = 0;                                             
        double per1 = 0;                                                 
        double per2 = 0;                                                  
        void drawCayleyTree(int n, double x0, double y0, double leng, double th, Color color, double th1, double th2, double per1, double per2)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1, n/2);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, color, th1, th2, per1, per2);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, color, th1, th2, per1, per2);
        }
        void drawLine(double x0, double y0, double x1, double y1, int width)
        {
            graphics.DrawLine(new Pen(color, width), (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            color = this.colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            graphics = null;
            n = 0;
            leng = 0;
            color = Color.Empty;
            th1 = 0;
            th2 = 0;
            per1 = 0;
            per2 = 0;
            textBox2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            panel1.Refresh();
        }
    }
}
