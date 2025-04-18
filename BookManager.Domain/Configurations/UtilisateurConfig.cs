using BookManager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Domain.Configurations
{
    internal class UtilisateurConfig : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.ToTable(nameof(Utilisateur));

            builder.Property(u => u.Nom)
                .HasColumnType("NVARCHAR(75)");

            builder.Property(u => u.Prenom)
                .HasColumnType("NVARCHAR(75)");

            builder.Property(u => u.Email)
                .HasColumnType("NVARCHAR(384)");

            builder.Property(u => u.Mdp)
                .HasColumnType("NVARCHAR(20)")
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("UK_Utilisateur_Email");
        }
    }
}
