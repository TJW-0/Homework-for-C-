using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        double num1;
        double num2;
        bool c = false;
        string d;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d = this.comboBox1.Text;
            c = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string str1 = this.NumBox1.Text.Trim();//第一个文本框的名字为Tex01第二个文本框为Tex02第三个框为Texresult
            string str2 = this.NumBox2.Text.Trim();
            if (str1.Length == 0)
            {
                MessageBox.Show("第一个数没有输入有效的数字", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.NumBox1.Text = string.Empty;
                this.NumBox1.Focus();
                return;
            }
            num1 = Convert.ToDouble(str1);
            if (str2.Length == 0)
            {
                MessageBox.Show("第二个数没有输入有效的数字", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.NumBox2.Text = string.Empty;
                this.NumBox2.Focus();
                return;
            }
            num2 = Convert.ToDouble(str2);
            if (c != true)
            {
                MessageBox.Show("还未选择运算符号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            switch (d)
            {
                case "+":
                    this.ResultBox.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    this.ResultBox.Text = (num1 - num2).ToString();
                    break;
                case "*":
                    this.ResultBox.Text = (num1 * num2).ToString();
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("请不要将0作为除数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.ResultBox.Text = (num1 / num2).ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.NumBox1.Text = string.Empty;
            this.NumBox2.Text = string.Empty;
            this.ResultBox.Text = string.Empty;
            this.NumBox1.Focus();
        }
    }
}
