using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Entities
{
    public class Livre
    {
        public int Id { get; set; }
        public required string Titre { get; set; }
        public int Annee { get; set; }
        public int NbrePage { get; set; }
        public required string Auteur { get; set; }
        public int UtilisateurId { get; set; }
    }
}
