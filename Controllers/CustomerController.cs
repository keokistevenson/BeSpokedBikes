using Microsoft.AspNetCore.Mvc;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;

namespace BeSpokedBikes.Controllers
{
    public class CustomerController : Controller
    {
        private readonly BeSpokedContext _context;

        public CustomerController(BeSpokedContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return View(customers);
        }
    }
}
