using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagementAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Document", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "0381298134", "amanda@gmail.com", "Amanda Gay", "+1 888-452-1232" },
                    { 2, "-1082451256", "amanda@yahoo.com", "Amanda MacDonald", "+1 888-452-1232" },
                    { 3, "-809430696", "carl@icloud.com", "Carl Strip", "+1 888-452-1232" },
                    { 4, "0580722840", "carl@icloud.com", "Carl Bailee", "+1 888-452-1232" },
                    { 5, "-114129484", "neil@outlook.com", "Neil Bailee", "+1 888-452-1232" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
