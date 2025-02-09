using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public string Style { get; set; }

        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal SalePrice { get; set; }

        public int QtyOnHand { get; set; }

        /// <summary>
        /// Commission percentage expressed as a decimal (e.g. 0.05 for 5%)
        /// </summary>
        [Range(0, 1)]
        public decimal CommissionPercentage { get; set; }
    }
}