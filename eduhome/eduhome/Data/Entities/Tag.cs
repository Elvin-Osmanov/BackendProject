using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Tag:BaseEntity
    {
        [StringLength(maximumLength: 30)]
        public string Name { get; set; }

        public List<CourseTag> CourseTags { get; set; }

        public List<EventTag> EventTags { get; set; }
    }
}
