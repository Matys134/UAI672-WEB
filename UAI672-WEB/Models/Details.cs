using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UAI672_WEB.Models
{
    [Table("Persons.Details")]
    public class Details
    {
        public int ID { get; set; }

        [StringLength(255)] public string Name { get; set; }

        [StringLength(255)] public string Surname { get; set; }

        public int? Address { get; set; }

        public virtual Addresses Addresses { get; set; }
    }
}