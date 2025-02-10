using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Data;
using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly BeSpokedContext _context;
        private readonly IPricingService _pricingService;

        public CommissionService(BeSpokedContext context, IPricingService pricingService)
        {
            _context = context;
            _pricingService = pricingService;
        }

        public async Task<decimal> CalculateCommissionForSalespersonAsync(int salespersonId, int quarter, int year)
        {
            // Query sales for the specified salesperson that match the quarter and year.
            var sales = await _context.Sales
                .Include(s => s.Product)
                    .ThenInclude(p => p.Discounts)
                .Where(s => s.SalespersonId == salespersonId &&
                            s.SalesDate.Year == year &&
                            (((s.SalesDate.Month - 1) / 3) + 1) == quarter)
                .ToListAsync();

            decimal totalCommission = 0m;

            foreach (var sale in sales)
            {
                // Get the effective sale price (after applying discount, if any).
                decimal effectivePrice = _pricingService.CalculateEffectiveSalePrice(sale.Product, sale.SalesDate);

                // Calculate commission (assuming commission is a percentage of the effective sale price).
                totalCommission += effectivePrice * sale.Product.CommissionPercentage;
            }

            return totalCommission;
        }
    }
}
