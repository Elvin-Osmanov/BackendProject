using eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.ViewModels
{
    public class TeacherDetailViewModel
    {
        public List<Teacher> Teachers { get; set; }

        public Teacher Teacher { get; set; }
    }
}
