using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gasDiesel.Models
{
    public class LiveMetric
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Dt { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }

        [MaxLength(70)]
        public string Subject { get; set; }
    }
}