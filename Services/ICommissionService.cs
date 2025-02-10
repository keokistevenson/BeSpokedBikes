using System.Threading.Tasks;

namespace BeSpokedBikes.Services
{
    public interface ICommissionService
    {        
        Task<decimal> CalculateCommissionForSalespersonAsync(int salespersonId, int quarter, int year);
    }
}