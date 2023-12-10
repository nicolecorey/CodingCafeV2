using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodingCafeV2.Models
{
    public class Customers
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "Please enter your first name (2 characters or more).")]
        [StringLength(30, ErrorMessage = "Please enter your first name (max 30 characters).")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Please enter your Last name (max 30 characters).")]
        public string? LastName { get; set; }


        [StringLength(50, ErrorMessage = "Please enter your address (max 50 characters)")]
        public string? Address { get; set; }

        [StringLength(30, ErrorMessage = "Please enter your city (max 30 characters)")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter your state (2 characters, example: MI")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string? State { get; set; }

        //[Range(5,10, ErrorMessage = "Please enter your zipcode (between 5 and 10 numbers)")]
        public string? Zip { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Favorite Drink")]
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}