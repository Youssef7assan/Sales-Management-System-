using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class tow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Customers_CustomerID",
                table: "Credit");

            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Orders_OrderID",
                table: "Credit");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credit",
                table: "Credit");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "Credit",
                newName: "credits");

            migrationBuilder.RenameIndex(
                name: "IX_Credit_OrderID",
                table: "credits",
                newName: "IX_credits_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Credit_CustomerID",
                table: "credits",
                newName: "IX_credits_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_credits",
                table: "credits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_credits_Orders_OrderID",
                table: "credits",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_credits_customers_CustomerID",
                table: "credits",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credits_Orders_OrderID",
                table: "credits");

            migrationBuilder.DropForeignKey(
                name: "FK_credits_customers_CustomerID",
                table: "credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_credits",
                table: "credits");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "credits",
                newName: "Credit");

            migrationBuilder.RenameIndex(
                name: "IX_credits_OrderID",
                table: "Credit",
                newName: "IX_Credit_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_credits_CustomerID",
                table: "Credit",
                newName: "IX_Credit_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credit",
                table: "Credit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Customers_CustomerID",
                table: "Credit",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Orders_OrderID",
                table: "Credit",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
