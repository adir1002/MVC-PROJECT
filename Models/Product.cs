using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectN.Models
{
    public class Product
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9A-Z]{4,8}$", ErrorMessage = "Minimum 4 Characters, Maximum 8 Characters, Numbers and Capitals")]
        public string CatalogNumber { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Length: 2-15")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+\.[0-9]+|[0-9]+$", ErrorMessage = "Integer or Float")]
        public double Price { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$",ErrorMessage ="must by positive int")]
        public int Quantity { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Image { get; set; }
    }
}