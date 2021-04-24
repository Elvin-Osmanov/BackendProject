using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Notice:BaseEntity
    { 

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 1000, ErrorMessage = "Max character is 100!")]
        public string Desc { get; set; }
    }
}
