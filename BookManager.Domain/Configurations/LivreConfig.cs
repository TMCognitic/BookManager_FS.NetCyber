using BookManager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Domain.Configurations
{
    internal class LivreConfig : IEntityTypeConfiguration<Livre>
    {
        public void Configure(EntityTypeBuilder<Livre> builder)
        {
            builder.ToTable(nameof(Livre),
                t =>
                {
                    t.HasCheckConstraint("CK_Livre_Annee", "Annee >= 1500");
                    t.HasCheckConstraint("CK_Livre_NbrePage", "NbrePage > 0");
                });

            builder.Property(u => u.Titre)
                .HasColumnType("NVARCHAR(128)");

            builder.Property(u => u.Auteur)
                .HasColumnType("NVARCHAR(75)");
        }
    }
}
