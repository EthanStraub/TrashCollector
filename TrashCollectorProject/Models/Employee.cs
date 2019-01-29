using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;

namespace TrashCollectorProject.Models
{
    public class Employee
    {
        [Key]
        public string ID { get; set; }
        [Display(Name = "Address line 1")]
        public string addressLine1 { get; set; }
        [Display(Name = "Address line 2 (optional)")]
        public string addressLine2 { get; set; }
        [Display(Name = "City and state (i.e 'Madison, WI')")]
        public string cityAndState { get; set; }
        [Display(Name = "Zip code")]
        public int zipCode { get; set; }
    }
}