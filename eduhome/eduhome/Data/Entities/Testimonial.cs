using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Testimonial:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 50, ErrorMessage = "Max character is 50!")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Place { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 400, ErrorMessage = "Max character is 400!")]
        public string Desc { get; set; }

        
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string ProfilePhoto { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
