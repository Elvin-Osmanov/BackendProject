using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Event:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string Title { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Photo { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 200, ErrorMessage = "Max character is 200!")]
        public string Venue { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 5000, ErrorMessage = "Max character is 5000!")]
        public string Desc { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<EventTag> EventTags { get; set; }

        public List<EventTeacher> EventTeachers { get; set; }

        [NotMapped]
        public int[] TagIds { get; set; }

        [NotMapped]
        public int[] TeacherIds { get; set; }

        public List<EventReview> EventReviews { get; set; }
    }
}
