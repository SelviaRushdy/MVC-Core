using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Core.Migrations
{
    /// <inheritdoc />
    public partial class Store2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("f62ba323-2be2-4ab2-b9f8-cfe023c17a66"), "Second Category" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CateogryID", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("7b64ea50-2014-4431-9f50-7e6020e9a220"), new Guid("f62ba323-2be2-4ab2-b9f8-cfe023c17a66"), "~/Images/shutterstock_662279290.png", "Second Product", 1m, 1m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("7b64ea50-2014-4431-9f50-7e6020e9a220"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: new Guid("f62ba323-2be2-4ab2-b9f8-cfe023c17a66"));
        }
    }
}
