using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeSpokedBikes.Models
{
    public class Discount
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        public virtual Product Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Discount percentage expressed as a decimal (e.g. 0.10 for 10%)
        /// </summary>
        [Range(0, 1)]
        public decimal DiscountPercentage { get; set; }
    }
}