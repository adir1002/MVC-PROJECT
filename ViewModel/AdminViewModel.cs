using ProjectN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectN.ViewModel
{
    public class AdminViewModel
    {
        public Product product { get; set; }
        public List<Product> products { get; set; }

        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }

        public Purchase purchase { get; set; }
        public List<Purchase> purchases { get; set; }

        public Entrance entrance { get; set; }
        public List<Entrance> entrances { get; set; }
    }
}