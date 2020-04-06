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
    public partial class Form1 : Form
    {
        public static OrderService orderService = new Project_for_class_8.OrderService();
        public static int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //创建订单（弹出窗口）
        {
            orderService.orderItemList.Clear();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)  //删除订单
        {
            int id = Convert.ToInt32(deleteText.Text);
            string str = deleteText.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("错误，应输入订单号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deleteText.Clear();
                return;
            }
            orderService.deleteOrder(id);
        }

        private void button3_Click(object sender, EventArgs e)  //导入订单
        {
            orderService.Import();
            orderService.orderList = orderService.orderListDes;
        }

        private void button4_Click(object sender, EventArgs e)  //导出订单
        {
            orderService.Export();
        }

        private void button5_Click(object sender, EventArgs e)  //修改订单（弹出窗口）
        {
            int id = Convert.ToInt32(changeText.Text);
            string str = changeText.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("错误，应输入订单号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                changeText.Clear();
                return;
            }
            i = id;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)  //查询订单（按订单号）
        {
            int Id = Convert.ToInt32(findText.Text);
            string str = findText.Text.Trim();
            if (str.Length == 0)
            {
                MessageBox.Show("错误，应输入订单号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                findText.Clear();
                return;
            }
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = orderService.orderList.Where(s => s.id == Id);
            Order order = orderService.orderList[Id-1];
            orderItemBindingSource.DataSource = null;
            orderItemBindingSource.DataSource = orderService.orderList[Id-1].OrderItem;
        }

        private void button7_Click(object sender, EventArgs e)  //刷新
        {
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = orderService.orderList;
        }

        private void bindingNavigator2_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
