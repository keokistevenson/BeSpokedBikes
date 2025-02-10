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

        public CommissionService(BeSpokedContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalculateCommissionForSalespersonAsync(int salespersonId, int quarter, int year)
        {
            // Query sales for the specified salesperson that match the quarter and year.
            var totalCommission = await _context.Sales
                .Include(s => s.Product)
                .Where(s => s.SalespersonId == salespersonId &&
                            s.SalesDate.Year == year &&
                            (((s.SalesDate.Month - 1) / 3) + 1) == quarter)
                .SumAsync(s => s.Product.SalePrice * s.Product.CommissionPercentage);

            return totalCommission;
        }
    }
}
