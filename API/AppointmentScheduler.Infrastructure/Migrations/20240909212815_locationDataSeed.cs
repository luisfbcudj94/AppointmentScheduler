using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppointmentScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class locationDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("6cee7750-2bcf-4bd0-8ed2-bb1fc9195f40"), "Centro comercial mayorca local 102", "Bancolombia sucursal mayorca" },
                    { new Guid("a6b80fea-a94b-4219-a717-155437d5e9f3"), "Avenida la playa edificio colteger piso 17", "Bancolombia sucursal centro" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cedula", "Name", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1b5f08f2-e97c-4d21-a6e4-ef3fcabf8052"), "1152466496", "Luis Alejandro Pérez Abril", new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2") },
                    { new Guid("41f1dcda-acbd-4587-b25a-7273443002b1"), "47438962", "Marta Alejandra Soacha", new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2") },
                    { new Guid("885e840a-c9f5-4b32-b2d8-26d16404b5fe"), "987654321", "Elkin Dario Sanchez", new Guid("d06e27e5-8dcf-4a80-92e4-fc9d257ec0a1") },
                    { new Guid("b35aa608-0966-49ea-bb70-2094d7543d09"), "9396795", "Jose Eugenio Rodriguez", new Guid("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("6cee7750-2bcf-4bd0-8ed2-bb1fc9195f40"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a6b80fea-a94b-4219-a717-155437d5e9f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b5f08f2-e97c-4d21-a6e4-ef3fcabf8052"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41f1dcda-acbd-4587-b25a-7273443002b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("885e840a-c9f5-4b32-b2d8-26d16404b5fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b35aa608-0966-49ea-bb70-2094d7543d09"));

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
    }
}
