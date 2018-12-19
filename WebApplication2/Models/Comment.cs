using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Comment
    {
        public int rating { get; set; }
        public string comment { get; set; }
        public int userID { get; set; }
        public int etablishmentID { get; set; }
        public virtual User user { get; set; }
        public virtual Etablishment etablishment { get; set; }
    }
}
