using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Models.Forms.Livre
{
    public class EditForm
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public required string Titre { get; set; }
        [Required]
        [Range(1500, 9999)]
        public int Annee { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int NbrePage { get; set; }
        [Required]
        [StringLength(75, MinimumLength = 1)]
        public required string Auteur { get; set; }
    }
}
