using eduhome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduhome.ViewModels
{
    public class EventDetailViewModel
    {
        public List<Event> Events { get; set; }

        public Event Event { get; set; }

        public List<Category> Categories { get; set; }
    }
}
