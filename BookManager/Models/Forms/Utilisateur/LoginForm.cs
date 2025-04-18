using System.ComponentModel.DataAnnotations;

namespace BookManager.Models.Forms.Utilisateur
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public required string Mdp { get; set; }
    }
}
