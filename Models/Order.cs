using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchwimmbadLib;

namespace SchwimmbadWebApplication.Models
{
    public class Order
    {
        [Key]
        [Column(Order = 0)]
        public int BuchungId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int SchwimmbahnId { get; set; }
        public Buchung Buchung { get; set; }
        public Schwimmbahn Schwimmbahn { get; set; }
    }
}