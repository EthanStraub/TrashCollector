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
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        //[ForeignKey("UserName")]
        //public string ApplicationUserName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "First Name (required)")]
        public string firstName { get; set; }
        [Display(Name = "Last Name (required)")]
        public string lastName { get; set; }
        [Display(Name = "Zip code (required)")]
        public int zipCode { get; set; }
    }
}