using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Homework_for_class_12.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public String CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime CreateTime { get; set; }
        public List<OrderItem> Items { get; set; }
        public string CustomerName { get => (Customer != null) ? Customer.Name : ""; }
    }
}
