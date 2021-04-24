using eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.ViewModels
{
    public class CourseDetailViewModel
    {
        public List<Course> Courses { get; set; }

        public List<Category> Categories { get; set; }

        public Course Course { get; set; }
    }
}
