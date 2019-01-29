using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollectorProject.Models
{
    
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Pickup day (i.e 'Monday', 'Tuesday', and so on)")]
        public string pickupDay { get; set; }
        [Display(Name = "One-time pickup date (optional) (i.e '2/15/2019')")]
        public DateTime oneTimePickupDay { get; set; }
        [Display(Name = "Pickup suspension start date (optional)")]
        public DateTime startDate { get; set; }
        [Display(Name = "Pickup suspension end date (optional)")]
        public DateTime endDate { get; set; }
        [Display(Name = "Due balance on your account")]
        public int dueBalance { get; set; }
        [Display(Name = "Address line 1")]
        public string addressLine1 { get; set; }
        [Display(Name = "Address line 2 (optional)")]
        public string addressLine2 { get; set; }
        [Display(Name = "City and state (i.e 'Madison, WI')")]
        public string cityAndState { get; set; }
        [Display(Name = "Zip code")]
        public int zipCode { get; set; }
        //public IEnumerable<SelectListItem> Days { get; set; }

        public Customer()
        {
            dueBalance = 0;
        }
    }
}