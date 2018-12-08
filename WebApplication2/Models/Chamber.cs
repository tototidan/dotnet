using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Chamber
    {
        public int chamberID { get; set; }
        public int etablishmentID { get; set; }
        public virtual Etablishment etablishment { get; set; }
    }
}
