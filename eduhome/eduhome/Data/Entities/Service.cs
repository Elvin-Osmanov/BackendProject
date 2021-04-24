using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Service:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Name { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "Max character is 200!")]
        public string Desc { get; set; }
    }
}
