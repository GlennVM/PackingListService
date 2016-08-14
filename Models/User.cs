using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Trip[] Trips { get; set; }
    }
}