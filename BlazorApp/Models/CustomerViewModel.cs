using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }

        [Required, RegularExpression("^[a-zA-Z ]*$")]
        public string CompanyName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string ContactName { get; set; }
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Address { get; set; }
        [RegularExpression("^[a-zA-Z ]*$")]
        public string City { get; set; }
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Region { get; set; }

        public string PostalCode { get; set; }
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Country { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
