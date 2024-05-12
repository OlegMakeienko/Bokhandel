using Bokhandel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bokhandel.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;

        public CartController(Cart cart)
        {
            _cart = cart;
        }

        // GET: CartController
        public ActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;
            return View(_cart);
        }

    }
}
