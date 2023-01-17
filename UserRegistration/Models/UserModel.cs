using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DOB { get; set; }
        public string? Address { get; set; }
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? Mobile { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Salt { get; set; }
        public string? HashedPassword { get; set; }
    }
}
