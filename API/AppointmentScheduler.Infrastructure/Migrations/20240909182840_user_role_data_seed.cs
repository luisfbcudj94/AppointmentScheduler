using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppointmentScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class user_role_data_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d06e27e5-8dcf-4a80-92e4-fc9d257ec0a1"), "Admin" },
                    { new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cedula", "Name", "RoleId" },
                values: new object[,]
                {
                    { new Guid("43a13fae-d2e1-43f8-b774-7dd712777b95"), "987654321", "Elkin Dario Sanchez", new Guid("d06e27e5-8dcf-4a80-92e4-fc9d257ec0a1") },
                    { new Guid("4f3c447c-5283-4e13-8c44-2a0504ca7521"), "1152466496", "Luis Alejandro Pérez Abril", new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2") },
                    { new Guid("a46e77a5-3924-414f-8507-b5635b4a7449"), "47438962", "Marta Alejandra Soacha", new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2") },
                    { new Guid("f5d684d2-ed8f-467d-a835-2cb0067d4848"), "9396795", "Jose Eugenio Rodriguez", new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("43a13fae-d2e1-43f8-b774-7dd712777b95"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f3c447c-5283-4e13-8c44-2a0504ca7521"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a46e77a5-3924-414f-8507-b5635b4a7449"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5d684d2-ed8f-467d-a835-2cb0067d4848"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d06e27e5-8dcf-4a80-92e4-fc9d257ec0a1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Name",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
