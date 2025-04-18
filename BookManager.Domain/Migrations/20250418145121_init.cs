using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Domain.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "NVARCHAR(75)", nullable: false),
                    Prenom = table.Column<string>(type: "NVARCHAR(75)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(384)", nullable: false),
                    Mdp = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    NbrePage = table.Column<int>(type: "int", nullable: false),
                    Auteur = table.Column<string>(type: "NVARCHAR(75)", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.Id);
                    table.CheckConstraint("CK_Livre_Annee", "Annee >= 1500");
                    table.CheckConstraint("CK_Livre_NbrePage", "NbrePage > 0");
                    table.ForeignKey(
                        name: "FK_Livre_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livre_UtilisateurId",
                table: "Livre",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "UK_Utilisateur_Email",
                table: "Utilisateur",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livre");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
