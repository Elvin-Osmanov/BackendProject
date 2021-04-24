using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eduhome.Data.Migrations
{
    public partial class SettingAndTestimonailTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLogo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FooterLogo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FooterDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VideoRedirectUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VimeoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PinterestUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ServicePhone = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SupportPhone = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Webname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SupportEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AboutTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AboutDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AboutPhoto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Testimonials");
        }
    }
}
