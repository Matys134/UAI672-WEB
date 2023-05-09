using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UAI672_WEB.Models;

namespace UAI672_WEB.Views.DetailsView
{
    using System.ComponentModel.DataAnnotations;

    public class DetailsModelView
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the name.")]
        [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter the surname.")]
        [StringLength(255, ErrorMessage = "Surname cannot be longer than 255 characters.")]
        public string Surname { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please select an address.")]
        public int AddressId { get; set; }

        public DetailsModelView()
        {
        }

        public DetailsModelView(Details details)
        {
            Id = details.ID;
            Name = details.Name;
            Surname = details.Surname;
            AddressId = details.Address.Value;
        }
    }

}