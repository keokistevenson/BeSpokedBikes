using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeSpokedBikes.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        public int SalespersonId { get; set; }

        [ForeignKey("SalespersonId")]
        public virtual Salesperson Salesperson { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }
    }
}