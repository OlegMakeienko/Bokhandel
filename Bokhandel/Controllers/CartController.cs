using Bokhandel.Data;
using Bokhandel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bokhandel.Controllers
{
    public class CartController(BokhandelContext context, Cart cart) : Controller
    {
        // GET: CartController
        public ActionResult Index()
        {
            var items = cart.GetAllCartItems();
            cart.CartItems = items;
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            var selectedBook = GetBookById(id);
            if (selectedBook != null)
            {
                cart.AddToCart(selectedBook, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var selectedBook = GetBookById(id);
            if (selectedBook != null)
            {
                cart.RemoveFronCart(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ReduceQuantity(int id)
        {
            var selectedBook = GetBookById(id);
            if (selectedBook != null)
            {
                cart.ReduceQuantity(selectedBook);
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult IncreaseQuantity(int id)
        {
            var selectedBook = GetBookById(id);
            if (selectedBook != null)
            {
                cart.IncreaseQuantity(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            cart.ClearCart();
            return RedirectToAction("Index");
        }
        
        public Book GetBookById(int id)
        {
            return context.Books.FirstOrDefault(b => b.Id == id);
        }

    }
}
