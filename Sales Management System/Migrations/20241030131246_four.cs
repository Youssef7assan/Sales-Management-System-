using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Management_System.Migrations
{
	/// <inheritdoc />
	public partial class four : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "ImageUrl",
				table: "Products",
				type: "nvarchar(max)",
				nullable: true);

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ImageUrl",
				table: "Products");

		}
	}
}
