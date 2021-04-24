using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.Areas.Manage.ViewModels
{
    public class CategoryCreateViewModel
    {
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}
