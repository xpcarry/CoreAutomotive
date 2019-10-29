using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAutomotive.Migrations
{
    public partial class dodanie_opinii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opinie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NazwaUzytkownika = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Wiadomosc = table.Column<string>(nullable: true),
                    OczekujeOdpowiedzi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinie", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinie");
        }
    }
}
