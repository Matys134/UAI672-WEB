namespace UAI672_WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persons.Details")]
    public partial class Details
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Surname { get; set; }

        public int? Address { get; set; }

        public virtual Addresses Addresses { get; set; }
    }
}
