﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Data.Entities
{
    public class CourseTag:BaseEntity
    {
        public int CourseId { get; set; }

        public int TagId { get; set; }

        public Course Course { get; set; }

        public Tag Tag { get; set; }
    }
}
