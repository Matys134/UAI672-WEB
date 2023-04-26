using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace UAI672_WEB.Models
{
    [Table("Persons.Addresses")]
    public class Addresses
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addresses()
        {
            Details = new HashSet<Details>();
        }

        public int Id { get; set; }

        [StringLength(255)] public string City { get; set; }

        public int? Number { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Details> Details { get; set; }
    }
}