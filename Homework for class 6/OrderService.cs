using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class OrderService  //订单服务
    {
        public List<Order> orderList = new List<Order>();
        public List<Order> orderListDes = new List<Order>();
        public List<OrderItem> orderItemList = new List<OrderItem>();
        public string sortTest = "";
        public OrderService() { }
        public void addOrder(int i, string c)  //添加订单
        {
            int flagNum = 0;
            Order temp = new Order(i, c, orderItemList);
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
            orderItemList.Clear();
        }
        public void SortOrder()  //订单排序
        {
            orderList.Sort((o1,o2)=>o2.sum-o1.sum);
            orderList.ForEach(p => Console.WriteLine(p));
            orderList.ForEach(p => sortTest = sortTest + " " + p.id);
            Console.WriteLine(sortTest);
        }
        public void addOrderItem(string n, int p, int i, int num)  //设置项目细项
        {
            OrderItem temp = new OrderItem(n, p, i, num);
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
            }
        }
        public void deleteOrder(int id) //删除订单
        {
            orderList.RemoveAt(id-1);
            foreach (Order orders in orderList)
            {
                Console.WriteLine(orders.ToString());
                foreach (OrderItem orderitems in orderItemList)
                {
                    Console.WriteLine(orderitems.ToString());
                }
            }
        }
        public bool changeOrder(int i, string c, List<OrderItem> list)  //修改订单
        {
            if (i < orderList.Count())
            {
                orderList.RemoveAt(i-1);
                orderList.Insert(i-1, new Order(i, c, list));
            }
            else if(i == orderList.Count())
            {
                orderList.RemoveAt(i-1);
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
            }
            return true;
        }
        public void Export()
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
        }
    }
}
