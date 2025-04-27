

using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagment.Application.Models.Identity.Registration
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Minimum length of Password is 6")]
        public string Password { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Minimum length of UserName is 6")]
        public string UserName { get; set; }
    }
}
