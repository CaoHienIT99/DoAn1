using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class addTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 7, 18, 16, 41, 59, 893, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 7, 18, 16, 41, 59, 895, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 7, 18, 16, 41, 59, 895, DateTimeKind.Local).AddTicks(2015));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 7, 18, 16, 35, 30, 136, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 7, 18, 16, 35, 30, 137, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 7, 18, 16, 35, 30, 137, DateTimeKind.Local).AddTicks(9249));
        }
    }
}
