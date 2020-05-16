using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Homework_for_class_12.Models;

namespace Homework_for_class_12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrdersController(OrderContext context)
        {
            orderDB = context;
        }

        // GET: api/Orders
        [HttpGet("Order")]
        public ActionResult<Order> GetOrder(long id)
        {
            var order = orderDB.Orders.FirstOrDefault(t => t.Id == id.ToString());
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // GET: api/Orders/5
        [HttpGet("Customer")]
        public ActionResult<Customer> GetCustomer(long id)
        {
            var customer = orderDB.Customers.FirstOrDefault(t => t.ID == id.ToString());
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpGet("Goods")]
        public ActionResult<Goods> GetGoods(long id)
        {
            var goods = orderDB.GoodItems.FirstOrDefault(t => t.ID == id.ToString());
            if (goods == null)
            {
                return NotFound();
            }
            return goods;
        }
        [HttpGet("OrderItems")]
        public ActionResult<OrderItem> GetOrderItem(long id)
        {
            var orderitem = orderDB.OrderItems.FirstOrDefault(t => t.Id == id.ToString());
            if (orderitem == null)
            {
                return NotFound();
            }
            return orderitem;
        }
        [HttpGet("orderitemQuery")]
        public ActionResult<List<OrderItem>> queryTodoItem(string name, int skip, int take)
        {
            var query = buildQuery(name).Skip(skip).Take(take);
            return query.ToList();
        }

        private IQueryable<OrderItem> buildQuery(string name)
        {
            IQueryable<OrderItem> query = orderDB.OrderItems;
            if (name != null)
            {
                query = query.Where(t => t.GoodsName.Contains(name));
            }

            return query;
        }
        [HttpPost("Order")]
        public ActionResult<Order> PostTodoItem(Order order)
        {
            try
            {
                orderDB.Orders.Add(order);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;

        }

        [HttpPost("Customer")]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            try
            {
                orderDB.Customers.Add(customer);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return customer;
        }
        [HttpPost("Goods")]
        public ActionResult<Goods> PostGoods(Goods goods)
        {
            try
            {
                orderDB.GoodItems.Add(goods);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return goods;
        }
        [HttpPut("Order")]
        public ActionResult<Order> PutOrder(long id, Order order)
        {
            if (id.ToString() != order.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDB.Entry(order).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpPut("Customer")]
        public ActionResult<Customer> PutCustomer(long id, Customer customer)
        {
            if (id.ToString() != customer.ID)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDB.Entry(customer).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }
        [HttpPut("Goods")]
        public ActionResult<Goods> PutGoodsItem(long id, Goods goods)
        {
            if (id.ToString() != goods.ID)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDB.Entry(goods).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }
        [HttpDelete("Order")]
        public ActionResult DeleteOrder(long id)
        {
            try
            {
                var order = orderDB.Orders.FirstOrDefault(t => t.Id == id.ToString());
                if (order != null)
                {
                    orderDB.Remove(order);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
        [HttpDelete("Customer")]
        public ActionResult DeleteCustomer(long id)
        {
            try
            {
                var customer = orderDB.Customers.FirstOrDefault(t => t.ID == id.ToString());
                if (customer != null)
                {
                    orderDB.Remove(customer);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
        [HttpDelete("Goods")]
        public ActionResult DeleteGoods(long id)
        {
            try
            {
                var order = orderDB.GoodItems.FirstOrDefault(t => t.ID == id.ToString());
                if (order != null)
                {
                    orderDB.Remove(order);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}
