using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Reservation
    {
        public int reservationID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime arrive { get; set; }
        [Column(TypeName = "Date")]
        public DateTime depart { get; set; }
        public int etablishmentID { get; set; }
        public virtual Etablishment etablishment { get; set; }
    }
}
