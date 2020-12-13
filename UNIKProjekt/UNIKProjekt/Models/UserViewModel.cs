using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Ugyldig email adresse!")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Zip { get; set; }

        [Required]
        public string Country { get; set; }

        public string UserType { get; set; }

        public string Requirements { get; set; }


    }

}
