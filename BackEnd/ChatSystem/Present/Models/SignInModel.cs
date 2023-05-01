
using System.ComponentModel.DataAnnotations;

namespace Present.Models
{
    public class SignInModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string PassWord { get; set; } = null!;
    }
}
