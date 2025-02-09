﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}