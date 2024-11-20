using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDetailID",
                table: "OrderDetails",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OrderDetails",
                newName: "OrderDetailID");
        }
    }
}
