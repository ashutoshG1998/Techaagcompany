using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.UI.ViewModel.StateViewmodel
{
    public class EditStateviewmodel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        [DisplayName("Country Name")]

        public int CountryId { get; set; }
    }
}
