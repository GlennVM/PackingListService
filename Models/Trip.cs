using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class Trip : TripComponent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripId { get; set; }
        public string Title { get; set; }
        public IList<Item> items { get; set; }
        public IList<Task> tasks { get; set; }
    }
}