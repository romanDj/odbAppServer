using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gasDiesel.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Dt { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [MaxLength(70)]
        public string Subject { get; set; }
    }
}