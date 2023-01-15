using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Models
{
    public class UserModel
    {
        public int UserId { get; set; } = 1;
        [Required]
        public string UserName { get; set; } = "vasuklk";
        [Required]
        public string? FirstName { get; set; } = "Vasu";
        public string? LastName { get; set; } = "Kulkarni";
        public string? Address { get; set; } = "8-11-184/235 Krishnadevaraya Nagar";
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Mobile { get; set; } = 8123980995;
        [Required]
        public string? Password { get; set; } = "123456";
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = "vasu@gmail.com";
    }
}
