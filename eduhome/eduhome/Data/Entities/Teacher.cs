using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class Teacher:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength:80, ErrorMessage = "Max character is 80!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 120, ErrorMessage = "Max character is 120!")]
        public string TeachingStatus { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 1500,ErrorMessage = "Max character is 1500!")]
        public string Desc { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100,ErrorMessage = "Max character is 100!")]
        public string Degree { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Experience { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string Hobby { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string Faculty { get; set; }


        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string Skype { get; set; }

      
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string FacebookUrl { get; set; }

     
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string PinterestUrl { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string VimeoUrl { get; set; }

      
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Max character is 500!")]
        public string Photo { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        [Range(1,100,ErrorMessage = "The range is from 1 to 100")]
        public int LanguagePercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100")]
        public int TeamLeaderPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100")]
        public int DevelopmentPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100")]
        public int DesignPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100")]
        public int InnovationPercentage { get; set; }

        [Range(1, 100, ErrorMessage = "The range is from 1 to 100")]
        public int CommunicationPercentage { get; set; }


        public List<EventTeacher> EventTeachers { get; set; }
    }
}
