using System;
using System.Linq;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculateEffectiveSalePrice(Product product, DateTime saleDate)
        {
            // Ensure there are discounts to evaluate.
            if (product.Discounts != null && product.Discounts.Any())
            {
                // Look for an applicable discount based on the sale date.
                var applicableDiscount = product.Discounts
                    .FirstOrDefault(d => saleDate >= d.BeginDate && saleDate <= d.EndDate);

                if (applicableDiscount != null)
                {
                    // Apply the discount to the product's sale price.
                    return product.SalePrice * (1 - applicableDiscount.DiscountPercentage);
                }
            }

            // No discount applies; return the full sale price.
            return product.SalePrice;
        }
    }
}
