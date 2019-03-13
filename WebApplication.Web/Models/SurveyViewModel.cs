using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Display(Name = "Your Email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Must be valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string State { get; set; }

        [Required]
        [Range(0,10)]
        public int ActivityLevel { get; set; }
    }
}
