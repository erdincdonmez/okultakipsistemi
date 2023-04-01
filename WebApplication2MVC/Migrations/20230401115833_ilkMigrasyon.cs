using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2MVC.Migrations
{
    public partial class ilkMigrasyon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOgrenciler",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Soyadi = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    AdSoyad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    TC = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Sinifi = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrenciler", x => x.OgrenciId);
                });

            migrationBuilder.CreateTable(
                name: "tblOgretmenler",
                columns: table => new
                {
                    Ogretmenid = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Soyadi = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    AdSoyad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Brans = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgretmenler", x => x.Ogretmenid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciler");

            migrationBuilder.DropTable(
                name: "tblOgretmenler");
        }
    }
}
