using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Course:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Name { get; set; }

       
        [StringLength(maximumLength: 120, ErrorMessage = "Max character is 120!")]
        public string Slug { get; set; }

        [StringLength(maximumLength: 2000, ErrorMessage = "Max character is 2000!")]
        public string Desc { get; set; }

        [StringLength(maximumLength: 2000, ErrorMessage = "Max character is 2000!")]
        public string AboutText { get; set; }

        [StringLength(maximumLength: 2000, ErrorMessage = "Max character is 2000!")]
        public string ApplyText { get; set; }

        [StringLength(maximumLength: 2000, ErrorMessage = "Max character is 2000!")]
        public string CertificationText { get; set; }

        public DateTime Start { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Duration { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Hours { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string SkillLevel { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Language { get; set; }

        public int StudentCount { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<CourseTag> CourseTags { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Photo { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }

        [NotMapped]
        public int[] TagIds { get; set; }

        public List<CourseReview> CourseReviews { get; set; }

        public List<Order> Orders { get; set; }
    }
}
