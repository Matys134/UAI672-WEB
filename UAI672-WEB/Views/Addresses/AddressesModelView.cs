using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using UAI672_WEB.Models;

namespace UAI672_WEB.Views.Addresses
{
    public class AddressesModelView
    {
        public int Id { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter the city.")]
        [StringLength(255, ErrorMessage = "City name cannot be longer than 255 characters.")]
        public string City { get; set; }

        [Display(Name = "Number")]
        public int? Number { get; set; }

        public AddressesModelView()
        {
            
        }
    }
}