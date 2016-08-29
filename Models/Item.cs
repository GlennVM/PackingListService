using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class Item : TripComponent
    {
        public Boolean Checked { get; set; }
        public int Amount { get; set; }
        public String Category { get; set; }
    }
}