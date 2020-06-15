using BigSchool.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CustomViewModel
    {
        [Required]
        public String Place { get; set; }
        [Required]
        [FutureDate]
        public String Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }
    }
}