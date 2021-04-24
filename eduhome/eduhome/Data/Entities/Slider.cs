using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Slider:BaseEntity
    {
        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 200, ErrorMessage = "Max character is 200!")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Obligatory!!!")]
        [StringLength(maximumLength: 450,ErrorMessage ="Max character is 450!")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 450, ErrorMessage = "Max character is 450!")]
        public string RedirectUrl { get; set; }

       
        [StringLength(maximumLength: 200, ErrorMessage = "Max character is 200!")]
        public string Photo { get; set; }

        public int Order { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
