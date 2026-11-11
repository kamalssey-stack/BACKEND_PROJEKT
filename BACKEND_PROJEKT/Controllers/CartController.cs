using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using BACKEND_PROJEKT.DATA;
using BACKEND_PROJEKT.ViewModels;

namespace BACKEND_PROJEKT.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private const string BasketCookieKey = "BASKET_ITEMS";

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        private List<BasketItemVM> GetBasket()
        {
            var cookie = Request.Cookies[BasketCookieKey];
            if (string.IsNullOrEmpty(cookie))
            {
                return new List<BasketItemVM>();
            }

            try
            {
                return JsonSerializer.Deserialize<List<BasketItemVM>>(cookie) ?? new List<BasketItemVM>();
            }
            catch
            {
                return new List<BasketItemVM>();
            }
        }

        private void SaveBasket(List<BasketItemVM> basket)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7),
                HttpOnly = true,
                IsEssential = true
            };
            var json = JsonSerializer.Serialize(basket);
            Response.Cookies.Append(BasketCookieKey, json, cookieOptions);
        }

        public IActionResult Index()
        {
            var basket = GetBasket();
            return View(basket);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var basket = GetBasket();
            var item = basket.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                basket.Add(new BasketItemVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    Count = 1
                });
            }
            else
            {
                item.Count++;
            }

            SaveBasket(basket);

            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            var basket = GetBasket();
            var item = basket.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                basket.Remove(item);
                SaveBasket(basket);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Increase(int id)
        {
            var basket = GetBasket();
            var item = basket.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Count++;
                SaveBasket(basket);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Decrease(int id)
        {
            var basket = GetBasket();
            var item = basket.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Count--;
                if (item.Count <= 0)
                {
                    basket.Remove(item);
                }
                SaveBasket(basket);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
