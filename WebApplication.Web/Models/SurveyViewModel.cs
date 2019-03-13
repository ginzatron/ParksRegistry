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
        public string Code { get; set; }

        [Display(Name = "Your Email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Must be valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [MinLength(2)]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }
    }
}
