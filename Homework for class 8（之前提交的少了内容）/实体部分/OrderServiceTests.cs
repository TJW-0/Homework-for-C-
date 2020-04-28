using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_for_class_8;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Project_for_class_8.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceTest()
        {
            OrderService orderService = new OrderService();
            Assert.IsNotNull(orderService);
        }

        [TestMethod()]
        public void addOrderTest()
        {
            int i = 0;
            string c = "Anna";
            List<OrderItem> orderItemListTest = new List<OrderItem> {new OrderItem ("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            OrderService orderService = new OrderService();
            orderService.orderItemList = orderItemListTest;
            orderService.addOrder(i, c);
            foreach(Order order in orderService.orderList)
            {
                Assert.AreEqual(order, new Order(i, c, orderItemListTest));
            }
        }

        [TestMethod()]
        public void SortOrderTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            List<OrderItem> orderItemListTest2 = new List<OrderItem> { new OrderItem("computer", 20000, 1, 1) };
            Order order2 = new Order(2, "Mike", orderItemListTest2);
            orderService.orderList.Add(order1);
            orderService.orderList.Add(order2);
            orderService.SortOrder();
            Assert.IsTrue(orderService.sortTest == " 2 1");
        }

        [TestMethod()]
        public void addOrderItemTest()
        {
            OrderService orderService = new OrderService();
            string n = "apple";
            int p = 2;
            int i = 1;
            int num = 10;
            orderService.addOrderItem(n, p, i, num);
            foreach (OrderItem orderitem in orderService.orderItemList)
            {
                Assert.AreEqual(orderitem, new OrderItem(n,p,i,num));
            }
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            List<OrderItem> orderItemListTest2 = new List<OrderItem> { new OrderItem("computer", 20000, 1, 1) };
            Order order2 = new Order(2, "Mike", orderItemListTest2);
            orderService.orderList.Add(order1);
            orderService.orderList.Add(order2);
            orderService.deleteOrder(1);
            Assert.AreEqual(orderService.orderList[0],order2);
        }

        [TestMethod()]
        public void changeOrderTest1()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            List<OrderItem> orderItemListTest2 = new List<OrderItem> { new OrderItem("computer", 20000, 1, 1) };
            Order order2 = new Order(2, "Mike", orderItemListTest2);
            orderService.orderList.Add(order1);
            orderService.orderList.Add(order2);
            string c = "John";
            List<OrderItem> orderItemListTest3 = new List<OrderItem> { new OrderItem("Books", 200, 1, 1), new OrderItem("Iphone", 3000, 2, 1) };
            orderService.changeOrder(2, c, orderItemListTest3);
            Assert.AreEqual(orderService.orderList[1], new Order(2,c,orderItemListTest3));
        }

        [TestMethod()]
        public void changeOrderTest2()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            List<OrderItem> orderItemListTest2 = new List<OrderItem> { new OrderItem("computer", 20000, 1, 1) };
            Order order2 = new Order(2, "Mike", orderItemListTest2);
            orderService.orderList.Add(order1);
            orderService.orderList.Add(order2);
            string c = "John";
            List<OrderItem> orderItemListTest3 = new List<OrderItem> { new OrderItem("Books", 200, 1, 1), new OrderItem("Iphone", 3000, 2, 1) };
            orderService.changeOrder(1, c, orderItemListTest3);
            Assert.AreEqual(orderService.orderList[0], new Order(1, c, orderItemListTest3));
        }

        [TestMethod()]
        public void changeOrderTest3()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            List<OrderItem> orderItemListTest2 = new List<OrderItem> { new OrderItem("computer", 20000, 1, 1) };
            Order order2 = new Order(2, "Mike", orderItemListTest2);
            orderService.orderList.Add(order1);
            orderService.orderList.Add(order2);
            string c = "John";
            List<OrderItem> orderItemListTest3 = new List<OrderItem> { new OrderItem("Books", 200, 1, 1), new OrderItem("Iphone", 3000, 2, 1) };
            Assert.IsTrue(orderService.changeOrder(3, c, orderItemListTest3) == false);
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            orderService.orderList.Add(order1);
            orderService.Export();
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                List<Order> orderListDes = (List<Order>)xmlSerializer.Deserialize(fs);
                Assert.AreEqual(orderListDes[0], order1);
            }
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItemListTest1 = new List<OrderItem> { new OrderItem("apple", 2, 1, 10), new OrderItem("banana", 3, 2, 5) };
            Order order1 = new Order(1, "Anna", orderItemListTest1);
            orderService.orderList.Add(order1);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderService.orderList);
            }
            orderService.Import();
            Assert.AreEqual(orderService.orderListDes[0],order1);
        }
    }
}
