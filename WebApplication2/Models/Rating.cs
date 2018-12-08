using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Rating
    {
        public int userID { get; set; }
        public int etablishmentID { get; set; }
        public int rating { get; set; }
        public int commentID { get; set; }
        public Comment comment {get;set;}
        public virtual Etablishment etablishment { get; set; }
        public virtual User user { get; set; }
    }
}
