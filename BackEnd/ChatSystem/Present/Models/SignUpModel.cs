using System.ComponentModel.DataAnnotations;

namespace Present.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName{ get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string PassWord { get; set; } = null!;
        [Required]
        public string ComfirmPassWord { get; set; } = null!;
    }
}
