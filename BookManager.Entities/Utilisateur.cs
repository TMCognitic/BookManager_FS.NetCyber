namespace BookManager.Entities
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public string? Mdp { get; set; }

        public virtual ICollection<Livre> Livres { get; } = new List<Livre>();
    }
}
