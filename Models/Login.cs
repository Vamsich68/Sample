using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name="EmailAddress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
