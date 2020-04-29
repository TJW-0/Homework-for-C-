using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;

namespace OrderProject
{
    public class OrderService  //订单服务
    {
        public List<Order> orderList = new List<Order>();
        public List<Order> orderListDes = new List<Order>();
        public List<OrderItem> orderItemList = new List<OrderItem>();
        public int newOrderId = 0;
        public int newOrderItemId = 0;
        public string sortTest = "";
        public OrderService() { }
        public void Show()
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.OrderBy(b => b.OrderId);
                foreach (var b in query)
                {
                    Console.WriteLine(b.ToString());
                }
            }
        }
        public void findOrder(int i)//查询订单
        {
            using (var context = new OrderContext())
            {
                Console.WriteLine("查询编号为" + i + "的订单的内容。");
                var query = context.Orders.Where(b=>b.OrderId == i).OrderBy(b => b.OrderId);
                Order order = query.First();
                order.ToString();
                var querys = context.OrderItems.Where(p => p.Order.OrderId == i).OrderBy(p => p.OrderItemId);
                foreach (var p in querys)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
        public void AddOrder(int i, string c, List<OrderItem> orderItems)  //添加订单
        {
            using (var context = new OrderContext())
            {
                var order = new Order { client = c};
                order.OrderItems = orderItems;
                context.Orders.Add(order);
                context.SaveChanges();
                newOrderId = order.OrderId;
            }
            /*int flagNum = 0;
            Order temp = new Order(i, c, orderItems);
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
            }
            orderItemList.Clear();*/
        }
        /*public void SortOrder()  //订单排序
        {
            orderList.Sort((o1, o2) => o2.sum - o1.sum);
            orderList.ForEach(p => Console.WriteLine(p));
            orderList.ForEach(p => sortTest = sortTest + " " + p.OrderId);
            Console.WriteLine(sortTest);
        }*/
        public void addOrderItem(string n, int p, int i, int num)  //设置项目细项
        {
            using (var context = new OrderContext())
            {
                Console.WriteLine("添加帖子");
                var orderItem = new OrderItem() { name = n, price = p, OrderId = i, Num = num };
                context.Entry(orderItem).State = EntityState.Added;
                context.SaveChanges();
                newOrderItemId = orderItem.OrderItemId;
            }
            /*OrderItem temp = new OrderItem(n, p, i, num);
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
                orderItemList.Add(temp);
            }*/
        }
        public void deleteOrder(int id) //删除订单
        {
            using (var context = new BloggingContext())
            {
                Console.WriteLine("删除Id为"+id+"的博客及其帖子");
                var order = context.Orders.Include("OrderItems").FirstOrDefault(p => p.OrderId == id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
            /*orderList.RemoveAt(id - 1);
            foreach (Order orders in orderList)
            {
                Console.WriteLine(orders.ToString());
                foreach (OrderItem orderitems in orderItemList)
                {
                    Console.WriteLine(orderitems.ToString());
                }
            }*/
        }
        public bool changeOrder(int i, string c, List<OrderItem> list)  //修改订单
        {
            Console.WriteLine("修改ID为newPostID的帖子的评论");
            var order = new Order() { OrderId = i, client = c };
            context.Entry(order).State = EntityState.Modified;
            order.OrderItems = list;
            context.SaveChanges();
            /*if (i < orderList.Count())
            {
                orderList.RemoveAt(i - 1);
                orderList.Insert(i - 1, new Order(i, c, list));
            }
            else if (i == orderList.Count())
            {
                orderList.RemoveAt(i - 1);
                orderList.Add(new Order(i, c, list));
            }
            else
            {
                Console.WriteLine("超过订单上限！");
                return false;
            }
            foreach (Order orders in orderList)
            {
                Console.WriteLine(orders.ToString());
                foreach (OrderItem orderitems in orderItemList)
                {
                    Console.WriteLine(orderitems.ToString());
                }
            }*/
            return true;
        }
        /*public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderList);
            }
            Console.WriteLine("序列化后的订单如下：");
            Console.WriteLine(File.ReadAllText("s.xml"));
        }
        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                orderListDes = (List<Order>)xmlSerializer.Deserialize(fs);
                Console.WriteLine("反序列化后的订单如下：");
                foreach (Order ordListDes in orderListDes)
                {
                    ordListDes.ToString();
                }
            }
        }*/
    }
}
