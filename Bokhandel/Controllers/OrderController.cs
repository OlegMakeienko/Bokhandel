using Bokhandel.Data;
using Bokhandel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bokhandel.Controllers;

public class OrderController : Controller
{
    private readonly BokhandelContext _context;
    private readonly Cart _cart;

    public OrderController(BokhandelContext context, Cart cart)
    {
        _context = context;
        _cart = cart;
    }

    // GET
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        var cartItems = _cart.GetAllCartItems();
        _cart.CartItems = cartItems;
        if (_cart.CartItems.Count == 0)
        {
            ModelState.AddModelError("", "Cart is empty");
        }

        if (ModelState.IsValid)
        {
            CreateOrder(order);
            _cart.ClearCart();
            return View("CheckoutComplete", order);
        }

        return View(order);
    }

    public IActionResult CheckoutComplete(Order order)
    {
        return View(order);
    }
    
    public void CreateOrder(Order order) 
    {
        order.OrderPlaced = DateTime.Now;
        var cartIems = _cart.CartItems;

        foreach (var item in cartIems)
        {
            var orderItem = new OrderItem()
            {
                Quantity = item.Quantity,
                BookId = item.Book.Id,
                OrderId = order.Id,
                Price = item.Book.Price * item.Quantity
            };
            order.OrderItems.Add(orderItem);
            order.OrderTotal += orderItem.Price;
        }
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}