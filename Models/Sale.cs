using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BeSpokedBikes.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [AllowNull]
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        public int SalespersonId { get; set; }

        [AllowNull]
        [ForeignKey("SalespersonId")]
        public virtual Salesperson Salesperson { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [AllowNull]
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [AllowNull]
        [DataType(DataType.Date)]
        public virtual DateTime SalesDate { get; set; }
        //public DateTime SalesDate
        //{
        //    get => salesDate;
        //    set
        //    {
        //        salesDate = value;
        //        CategorizeSaleQuarterAndYear(); // Update Quarter and Year whenever SalesDate is set.
        //    }
        //}

        //public int Quarter { get; set; }


        //public int Year { get; set; }

        //private void CategorizeSaleQuarterAndYear()
        //{
        //    Year = SalesDate.Year;
        //    int month = SalesDate.Month; // 1 to 12

        //    if ((month >= 1) && (month <=3))
        //    {
        //        Quarter = 1;
        //    }
        //    else if ((month >= 4) && (month <= 6))
        //    {
        //        Quarter = 2;
        //    }
        //    else if ((month >= 7) && (month <= 9))
        //    {
        //        Quarter = 3;
        //    }
        //    else if ((month >= 10) && (month <= 12))
        //    {
        //        Quarter = 4;
        //    }

    }
    
}