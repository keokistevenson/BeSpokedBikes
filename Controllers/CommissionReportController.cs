
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;
using BeSpokedBikes.Models;
using BeSpokedBikes.Services;

namespace BeSpokedBikes.Controllers
{
    public class CommissionReportController : Controller
    {
        private readonly ICommissionService _commissionService;
        private readonly BeSpokedContext _context;

        public CommissionReportController(ICommissionService commissionService, BeSpokedContext context)
        {
            _commissionService = commissionService;
            _context = context;
        }

        // GET: CommissionReport?quarter=2&year=2023
        public async Task<IActionResult> Index(int? quarter, int? year)
        {
            // Use current quarter and year if not provided.
            if (!quarter.HasValue || !year.HasValue)
            {
                var now = DateTime.Now;
                year = now.Year;
                quarter = ((now.Month - 1) / 3) + 1;
            }

            // Retrieve all salespersons from the database.
            var salespersons = await _context.Salespersons.ToListAsync();

            // Build the commission report view model.
            var report = new List<CommissionReportViewModel>();
            foreach (var sp in salespersons)
            {
                var commission = await _commissionService.CalculateCommissionForSalespersonAsync(sp.Id, quarter.Value, year.Value);
                report.Add(new CommissionReportViewModel
                {
                    SalespersonId = sp.Id,
                    FullName = $"{sp.FirstName} {sp.LastName}",
                    TotalCommission = commission
                });
            }

            // Pass the selected quarter and year so the view can show current filters.
            ViewBag.SelectedQuarter = quarter.Value;
            ViewBag.SelectedYear = year.Value;

            // Optionally, build lists of available quarters and recent years.
            ViewBag.Quarters = new List<int> { 1, 2, 3, 4 };
            var currentYear = DateTime.Now.Year;
            // Example: a list of the past 5 years plus the current year.
            ViewBag.Years = Enumerable.Range(currentYear - 5, 6).OrderByDescending(y => y).ToList();

            return View(report);
        }
    }
}
