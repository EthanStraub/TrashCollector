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
        //[ForeignKey("UserName")]
        //public string ApplicationUserName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "First name (required)")]
        public string firstName { get; set; }
        [Display(Name = "Last name (required)")]
        public string lastName { get; set; }
        [Display(Name = "Pickup day (required)")]
        public Day pickupDay { get; set; }
        [Display(Name = "One-time pickup date (optional) (i.e '2/15/2019')")]
        public DateTime oneTimePickupDay { get; set; }
        [Display(Name = "Pickup suspension start date (optional)")]
        public DateTime startDate { get; set; }
        [Display(Name = "Pickup suspension end date (optional)")]
        public DateTime endDate { get; set; }
        [Display(Name = "Due balance on your account")]
        public int dueBalance { get; set; }
        [Display(Name = "Address line 1 (required)")]
        public string addressLine1 { get; set; }
        [Display(Name = "Address line 2 (optional)")]
        public string addressLine2 { get; set; }
        [Display(Name = "City and state (i.e 'Madison, WI')")]
        public string cityAndState { get; set; }
        [Display(Name = "Zip code (required)")]
        public int zipCode { get; set; }
        [Display(Name = "Pickup Confirmation")]
        public PickupStatus pickupStatus { get; set; }
        public Customer()
        {
            pickupStatus = 0;
            dueBalance = 0;
        }
    }
    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public enum PickupStatus
    {
        Pending,
        Aproved
    }
}