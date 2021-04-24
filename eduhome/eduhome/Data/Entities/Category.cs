using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Category : BaseEntity
    {
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        public List<Course> Courses { get; set; }

        public List<Event> Events { get; set; }
    }
}
