using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Web;

namespace UAI672_WEB.Models
{
    public class BusDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Surname { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Addresses Address { get; set; }
    }

}