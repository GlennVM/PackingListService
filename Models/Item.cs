using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class Item : TripComponent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public Boolean Checked { get; set; }
        public int Amount { get; set; }
        public String Category { get; set; }
    }
}