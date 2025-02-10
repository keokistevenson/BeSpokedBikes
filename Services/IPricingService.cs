using System;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Services
{
    public interface IPricingService
    {
        /// <summary>
        /// Calculates the effective sale price for a product based on its discount(s) and the sale date.
        /// </summary>
        /// <param name="product">The product being sold.</param>
        /// <param name="saleDate">The date the sale takes place.</param>
        /// <returns>The effective sale price after any discount is applied.</returns>
        decimal CalculateEffectiveSalePrice(Product product, DateTime saleDate);
    }
}
