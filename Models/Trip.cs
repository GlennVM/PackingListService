using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class Trip
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Item[] Items { get; set; }
    }
}