using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocakBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_app_user_perm_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPermGranted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPermGranted",
                table: "AspNetUsers");
        }
    }
}
