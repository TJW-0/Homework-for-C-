using Project_for_class_8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_for_class_8
{
    public partial class Form2 : Form
    {
        public string Good { get; set; }
        public int Price { get; set; }
        public int ItemId { get; set; }
        public int Num { get; set; }
        public string Client { get; set; }
        public List<OrderItem> orderItems = new List<OrderItem>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Good != null && Price != 0 && Num != 0 && Client != null)
            {
                orderItems.Add(new OrderItem(Good, Price, ItemId, Num));
                textBox10.ReadOnly = true;
                ItemId++;
            }
            else
            {
                textBox4.Clear();
                textBox3.Clear();
                textBox6.Clear();
                textBox8.Clear();
                MessageBox.Show("没有输入有效的内容", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.orderService.AddOrder(Form1.i, Client, orderItems);
                Form1.i++;
                Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Good = "Apple";
            Price = 10;
            Num = 2;
            ItemId = 1;
            Client = "Mike";
                textBox4.DataBindings.Add("Text", this, "Good");
                textBox3.DataBindings.Add("Text", this, "Price");
                textBox6.DataBindings.Add("Text", this, "Num");
                textBox8.DataBindings.Add("Text", this, "ItemId");
                textBox10.DataBindings.Add("Text", this, "Client");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.orderService.changeOrder(Form1.i, Client, Form1.orderService.orderItemList);
            Close();
        }
    }
}
