
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject
{

    public class SUMComparer : IComparer<Order>  //比较器
    {
        public int Compare(Order o1, Order o2)
        {
            return o1.sum - o2.sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService ordService = new OrderService();
            Console.WriteLine("输入你想建立的订单数：");
            int n1 = Convert.ToInt32(Console.ReadLine()) + 1;
            int i = 1;
            while (i < n1)
            {
                Console.WriteLine("输入下单用户名：");
                string c = Console.ReadLine();
                Console.WriteLine("输入订单明细数目：");
                int n2 = Convert.ToInt32(Console.ReadLine()) + 1;
                int itemId = 1;
                while (itemId < n2)
                {
                    Console.WriteLine("输入商品名称：");
                    string n = Console.ReadLine();
                    Console.WriteLine("输入该商品价格：");
                    int p = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("输入购买数量：");
                    int num = Convert.ToInt32(Console.ReadLine());
                    ordService.addOrderItem(n, p, itemId, num);
                    itemId++;
                }
                ordService.AddOrder(i, c);
                i++;
            }
            ordService.Show();
            //ordService.Export();
            //ordService.Import();
            Console.WriteLine("请输入你接下来想进行的操作：");
            Console.WriteLine("1:删除订单，2：修改订单,3：查询订单");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("请输入你想删除的订单序号：");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    ordService.deleteOrder(id1);
                    break;
                case "2":
                    Console.WriteLine("请输入你想修改的订单序号：");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("输入下单用户名：");
                    string c = Console.ReadLine();
                    Console.WriteLine("输入订单明细数目：");
                    int n2 = Convert.ToInt32(Console.ReadLine());
                    List<OrderItem> list = new List<OrderItem>();
                    int itemId = 0;
                    while (itemId < n2)
                    {
                        Console.WriteLine("输入商品名称：");
                        string n = Console.ReadLine();
                        Console.WriteLine("输入该商品价格：");
                        int p = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("输入购买数量：");
                        int num = Convert.ToInt32(Console.ReadLine());
                        ordService.addOrderItem(n, p, itemId, num);
                        itemId++;
                    }
                    ordService.changeOrder(id2, c, ordService.orderItemList);
                    break;
                case "3":
                    Console.WriteLine("请输入你想查询的订单序号：");
                    int id = Convert.ToInt32(Console.ReadLine());
                    ordService.findOrder(id);
                    break;
                default:
                    break;
            }
        }
    }
}
