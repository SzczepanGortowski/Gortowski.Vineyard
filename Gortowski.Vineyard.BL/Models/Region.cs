using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Core.Enum;

namespace Gortowski.Vineyard.BL.Models
{

    public class Region : ValidateData, IRegion
    {
        private string _name;

        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisanie regionnu jest wymagane!")]
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public string Country { get; set; }
    }
}
