using System.ComponentModel;

namespace TechAgCompany.UI.ViewModel.StateViewmodel
{
    public class CreateStateviewmodel
    {

        public string StateName { get; set; }
        [DisplayName("Country ")]
        public int CountryId {  get; set; }
    }
}
