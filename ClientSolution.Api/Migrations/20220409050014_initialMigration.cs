using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientSolution.Api.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTypeId = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "Email", "GenderId", "LastName", "Name", "PrimaryNumber", "SecondaryNumber" },
                values: new object[,]
                {
                    { 1, "sullivans@gmail,com", 1, "sullivans", "Sam", "01125200125", "101255225566" },
                    { 2, "Jackson@gmail,com", 1, "Jackson", "Peter", "0140225522144", "01325588855" },
                    { 3, "Elize@gmail,com", 2, "Elize", "Tania", "01255444555", "012533699555" },
                    { 4, "Prudence@gmail,com", 2, "Prudence", "Gordon", "01258554411", "013255899552" },
                    { 5, "Greyling@gmail,com", 2, "Greyling", "Brian", "012588745566", "102365889966" },
                    { 6, "Noel@gmail,com", 1, "Noel", "Shaun", "102255544555", "012654788999" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AddressTypeId", "PersonId", "ProvinceId", "StreetName", "Town" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "157 Voortrekker rd", "Germiston" },
                    { 2, 2, 1, 1, "157 Voortrekker rd", "Germiston" },
                    { 3, 1, 2, 1, "150 West Street", "Sandton" },
                    { 4, 2, 2, 1, "150 West Street", "Sandton" },
                    { 5, 1, 3, 1, "157 Voortrekker rd", "Roodepoort" },
                    { 6, 2, 3, 1, "157 Voortrekker rd", "Roodepoort" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
