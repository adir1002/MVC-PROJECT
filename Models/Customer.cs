using ProjectN.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectN.Models
{
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "Key")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "must by 9 Digits")]
        public string ID { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "length must be between 2 and 15 characters")]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Letters only, starts with capital")]
        public string FirstName { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "length must be between 2 and 15 characters")]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Letters only, starts with capital")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "length must be between 2 and 15 characters")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Letters and Digits Only")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Length: 6-15")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{6,15}$", ErrorMessage = "At least one lower case char, upper case char, digit ")]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^([0-9a-zA-Z]+)@([0-9a-zA-Z]+)(.(([0-9a-zA-Z]){2,3}))+$", ErrorMessage = "The Email is invalid")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression("^0|1")]
        public int AdminVal { get; set; }

        public static Customer getAdminById(string Id)
        {
            DataLayer dal = new DataLayer();
            List<Customer> admn = (from a in dal.Customers
                                where (a.ID == Id && a.AdminVal==1)
                                select a).ToList<Customer>();

            if (admn[0] != null)
            {
                return admn[0];
            }
            else
            {
                return null;
            }
        }
    }

}
