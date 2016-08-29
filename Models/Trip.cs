using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class Trip : TripComponent
    {
        public string Title { get; set; }
        public IList<TripComponent> items { get; set; }
        public IList<TripComponent> tasks { get; set; }
    }
}