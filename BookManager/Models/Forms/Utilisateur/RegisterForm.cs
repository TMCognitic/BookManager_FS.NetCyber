using System.ComponentModel.DataAnnotations;

namespace BookManager.Models.Forms.Utilisateur
{
    public class RegisterForm
    {
        [Required]
        [StringLength(75, MinimumLength = 1)]
        public required string Nom { get; set; }
        [Required]
        [StringLength(75, MinimumLength = 1)]
        public required string Prenom { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public required string Mdp { get; set; }
    }
}
