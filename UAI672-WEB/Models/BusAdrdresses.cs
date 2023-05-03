using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UAI672_WEB.Models
{
    public class BusAddresses
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }
        public int Number { get; set; }

    }
}