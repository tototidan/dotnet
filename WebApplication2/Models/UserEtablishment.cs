using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class UserEtablishment
    {
        
        public int etablishmentID { get; set; }
        public int userID { get; set; }
        public virtual User user { get; set; }
        public virtual Etablishment etablishment { get; set; }
    }
}
