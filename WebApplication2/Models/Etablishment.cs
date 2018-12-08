using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Etablishment
    {
        public int etablishmentID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string street { get; set; }
        public string postalcode { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public int average { get; set; }
        public int etablishmenttypeID { get; set; }
        public virtual EtablishmentType etablishmentType { get; set; }
    }
}
