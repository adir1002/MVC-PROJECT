using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectN.Models
{
    public class Purchase
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Length: 2-15")]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "must by 9 Digits")]
        public string BuyerID { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}