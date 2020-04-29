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
    [Serializable]
    public class Order //订单
    {
        public int OrderId { get; set; }  //订单号
        public string client { get; set; }  //客户
        public int sum { get; set; }  //总价格
        public List<OrderItem> OrderItems = new List<OrderItem>();
        public Order() { }
        /*public Order(int i, string c, List<OrderItem> list)
        {
            OrderId = i; client = c;
            OrderItems = list;
            foreach (OrderItem ordItem in OrderItems)
            {
                sum = sum + ordItem.Num * ordItem.price;
            }
        }*/
        public override bool Equals(object obj)
        {
            Order ord = obj as Order;
            return ord != null && ord.OrderId == OrderId && ord.client == client;
        }
        public override string ToString()
        {
            Console.WriteLine("订单号为" + OrderId + "," + "客户名为" + client + "订单总价为" + sum);
            foreach (OrderItem ordItem in OrderItems)
            {
                Console.WriteLine(ordItem.ToString());
            }
            return "---------------";
        }
        public override int GetHashCode()
        {
            var hashCode = 1903320604;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderId + "");
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(client);
            return hashCode;
        }
    }
}
