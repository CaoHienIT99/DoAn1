using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using DA1.Data;
using DA1.Helper;
using DA1.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace DA1.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {

        DataContext dataContext;
        public CartController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [Route("index")]
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") == null)
            {

                return RedirectToAction("Cartnull", "Lambor");
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                ViewBag.cart = cart; ViewBag.total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
                return View();
            }     
        }
       
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") == null)
            {
                List<ProductToCart> cart = new List<ProductToCart>();
                cart.Add(new ProductToCart { Product = dataContext.Products.FirstOrDefault(p => p.ProductId == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                int index = isExist(id); if (index != -1)
                {
                    cart[index].Quantity++;
                }

                else
                {
                    cart.Add(new ProductToCart { Product = dataContext.Products.FirstOrDefault(p => p.ProductId == id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            int index = isExist(id); cart.RemoveAt(index); SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


        private int isExist(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id) { return i; }
            }
            return -1; 
        }
        [HttpGet]
        public IActionResult Pay()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.ProductPrice * item.Quantity);
            return View();
        }
        public ActionResult ResultPay(IFormCollection fmOrder, Order order)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            //save order
            order.OrderDate = DateTime.Now;
            order.FirstName = fmOrder["FirstName"];
            order.LastName =  fmOrder["LastName"];
            order.Address = fmOrder["Address"];
            order.PhoneNumber = fmOrder["PhoneNumber"];
            order.Email = fmOrder["Email"];
            dataContext.Orders.Add(order);
            dataContext.SaveChanges();
            //save orderdetail

            foreach (ProductToCart itemcart in cart)
            {
                var price = itemcart.Product.ProductPrice * itemcart.Quantity;
                var orderDetail = new OrderDetail();
                orderDetail.ProductId = itemcart.Product.ProductId;
                orderDetail.Quantity = itemcart.Quantity;
                orderDetail.OrderId = order.OrderId;
                orderDetail.Price = (int)price;
                dataContext.OrderDetails.Add(orderDetail);
                dataContext.SaveChanges();
            } 
            HttpContext.Session.Clear();    

            return View();
        }
    }
}