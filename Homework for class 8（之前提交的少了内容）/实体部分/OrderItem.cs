using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Project_for_class_8
{
    [Serializable]
    public class OrderItem //订单明细
    {
        public string name { get; set; }  //商品名
        public int price { get; set; }  //价格
        public int itemId { get; set; } //订单明细项号
        public int Num { get; set; }  //数量
        public OrderItem(string n, int p, int i, int num)
        {
            name = n; price = p; itemId = i; Num = num;
        }
        public OrderItem() { }
        public override bool Equals(object obj)
        {
            OrderItem oit = obj as OrderItem;
            return oit != null && oit.name == name && oit.itemId == itemId && oit.price == price;
        }
        public override string ToString()
        {
            return "该明细编号为" + itemId + "购买商品名称为" + name + "," + "其价格为" + price + "," + "购买数量为" + Num + "该项总价格为" + price * Num;
        }

    }
}
