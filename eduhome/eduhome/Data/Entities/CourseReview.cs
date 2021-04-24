﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class CourseReview:BaseEntity
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        public string Subject { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        [Required]
        public string Message { get; set; }

        public Course Course { get; set; }
    }
}
