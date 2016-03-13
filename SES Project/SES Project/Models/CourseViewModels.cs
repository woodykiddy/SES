using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SES_Project.Models
{
    public class CourseViewModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Max character length is 250")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Venue { get; set; }
    }
}