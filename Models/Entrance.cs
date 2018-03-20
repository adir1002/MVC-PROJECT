using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectN.Models
{
    public class Entrance
    {
        [Key]
        public DateTime date { get; set; }

        public int Counter { get; set; }
    }
}