using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace project1
{
    public class Order //订单
    {
        public int id { get; set; }  //订单号
        public string client { get; set; }  //客户
        List<OrderItem> orderItem = new List<OrderItem>();
        public Order(int i, string c, List<OrderItem> list)
        {
            id = i; client = c;
            foreach (OrderItem temp in list) { orderItem.Add(temp); }
        }
        public override bool Equals(object obj)
        {
            Order ord = obj as Order;
            return ord != null && ord.id == id && ord.client == client;
        }
        public override string ToString()
        {
            return "订单号为" + id + "," + "客户名为" + client;
        }
    }
    public class IDComparer : IComparer<Order>
    {

        public int Compare(Order o1, Order o2)
        {
            return o1.id - o2.id;
        }
    }
    public class OrderItem //订单明细
    {
        public string name { get; set; }  //商品名
        public int price { get; set; }  //价格
        public int itemId { get; set; } //订单明细项号
        public int Num { get; set; }
        public OrderItem(string n, int p, int i,int num)
        {
            name = n; price = p; itemId = i;Num = num;
        }
        public override bool Equals(object obj)
        {
            OrderItem oit = obj as OrderItem;
            return oit != null && oit.name == name && oit.itemId == itemId && oit.price == price;
        }
        public override string ToString()
        {
            return "该明细编号为" + itemId + "购买商品名称为" + name + "," + "其价格为" + price + "," + "购买数量为" + Num;
        }

    }
    public class OrderService  //订单服务
    {
        public List<Order> orderList = new List<Order>();
        public List<OrderItem> orderItemList = new List<OrderItem>();
        public void addOrder(int i, string c, List<OrderItem> list)  //添加订单
        {
            int flagNum = 0;
            list = orderItemList;
            Order temp = new Order(i, c, list);
            foreach (Order orders in orderList)
            {
                if (orders.Equals(temp) == true)
                {
                    flagNum++;
                }
            }
            if (flagNum == 0)
            {
                orderList.Add(temp);
                Console.WriteLine(temp.ToString());
                foreach (OrderItem orderitems in orderItemList)
                {
                    Console.WriteLine(orderitems.ToString());
                }
            }
            orderItemList.Clear();
        }
        public void SortOrder()  //订单排序
        {
            orderList.Sort(new IDComparer());
            orderList.ForEach(p => Console.WriteLine(p));
        }
        public void addOrderItem(string n, int p, int o, int num)  //设置项目细项
        {
            OrderItem temp = new OrderItem(n, p, o ,num);
            int flagNum = 0;
            foreach (OrderItem orderitems in orderItemList)
            {
                if (orderitems.Equals(temp) == true)
                {
                    flagNum++;
                }
            }
            if (flagNum == 0)
            {
                orderItemList.Add(new OrderItem(n,p,o,num));
            }
        }
        public void deleteOrder(int id) //删除订单
        {
            orderList.RemoveAt(id);
            foreach (Order orders in orderList)
            {
                Console.WriteLine(orders.ToString());
                foreach (OrderItem orderitems in orderItemList)
                {
                    Console.WriteLine(orderitems.ToString());
                }
            }
        }
        public void changeOrder(int i, string c, List<OrderItem> list)  //修改订单
        {
            orderList.RemoveAt(i);
            orderList.Insert(i, new Order(i, c, list));
            foreach (Order orders in orderList)
            {
                Console.WriteLine(orders.ToString());
                foreach (OrderItem orderitems in orderItemList)
                {
                    Console.WriteLine(orderitems.ToString());
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService ordService = new OrderService();
            Console.WriteLine("输入你想建立的订单数：");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i < n1)
            {
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
                ordService.addOrder(i, c, list);
                i++;
            }
            Console.WriteLine("请输入你接下来想进行的操作：");
            Console.WriteLine("1:排序,2:删除订单，3：修改订单");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ordService.SortOrder();
                    break;
                case "2":
                    Console.WriteLine("请输入你想删除的订单序号：");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    ordService.deleteOrder(id1);
                    break;
                case "3":
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
                default:
                    break;
            }
        }
    }
}
