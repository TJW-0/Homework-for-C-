using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;

namespace OrderProject
{
    [Serializable]
    public class OrderItem //订单明细
    {
        public string name { get; set; }  //商品名
        public int price { get; set; }  //价格
        public int OrderItemId { get; set; } //订单明细项号
        public int Num { get; set; }  //数量
        public int OrderId { get; set; }//形成关联
        public Order Order { get; set; }
        /*public OrderItem(string n, int p, int i, int num)
        {
            name = n; price = p; OrderItemId = i; Num = num;
        }*/
        public OrderItem() { }
        public override bool Equals(object obj)
        {
            OrderItem oit = obj as OrderItem;
            return oit != null && oit.name == name && oit.OrderItemId == OrderItemId && oit.price == price;
        }
        public override string ToString()
        {
            return "该明细编号为" + OrderItemId + "购买商品名称为" + name + "," + "其价格为" + price + "," + "购买数量为" + Num + "该项总价格为" + price * Num;
        }
        public override int GetHashCode()
        {
            var hashCode = 2036580019;
            hashCode = hashCode * -1521134295 + OrderItemId.GetHashCode();
            hashCode = hashCode * -1521134295 + Num.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            return hashCode;
        }
    }
}
