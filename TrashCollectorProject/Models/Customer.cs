using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;

namespace TrashCollectorProject.Models
{
    
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string pickupDay { get; set; }
        public string oneTimePickupDay { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int dueBalance { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string cityAndState { get; set; }
        public int zipCode { get; set; }
    }
}