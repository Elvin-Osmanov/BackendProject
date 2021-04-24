using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eduhome.Data.Migrations
{
    public partial class TeacherTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                table: "Testimonials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TeachingStatus = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hobby = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PinterestUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    VimeoUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LanguagePercentage = table.Column<int>(type: "int", nullable: false),
                    TeamLeaderPercentage = table.Column<int>(type: "int", nullable: false),
                    DevelopmentPercentage = table.Column<int>(type: "int", nullable: false),
                    DesignPercentage = table.Column<int>(type: "int", nullable: false),
                    InnovationPercentage = table.Column<int>(type: "int", nullable: false),
                    CommunicationPercentage = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                table: "Testimonials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
