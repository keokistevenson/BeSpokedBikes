using Microsoft.AspNetCore.Mvc;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;

namespace BeSpokedBikes.Controllers
{
    public class ProductController : Controller
    {
        private readonly BeSpokedContext _context;

        public ProductController(BeSpokedContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> products =  _context.Products.ToList();
            return View(products);
        }
    }
}

