using System.ComponentModel.DataAnnotations;

namespace Nxm.Conan.Users.Application.Requests
{
    public class CreateUserRequest
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Address { get; set; }

        //[Required]
        //public string ImageUrl { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Phone { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        //[Required]
        //[Compare("Password")]
        //public string ConfirmPassword { get; set; }
    }
}
