using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Polo.Shop.Persistence.Migrations
{
   public partial class CustomerAggregateAdded : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.EnsureSchema(
             name: "CustomerContext");

         migrationBuilder.CreateTable(
             name: "Customer",
             schema: "CustomerContext",
             columns: table => new
             {
                Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                UserName = table.Column<string>(nullable: true),
                Email = table.Column<string>(type: "NVarChar", maxLength: 50, nullable: false),
                Password = table.Column<string>(type: "NVarChar", maxLength: 50, nullable: false),
                FirstName = table.Column<string>(type: "NVarChar", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "NVarChar", maxLength: 50, nullable: false),
                NationalCode = table.Column<string>(type: "Char", maxLength: 10, nullable: false)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_Customer", x => x.Id);
             });

         migrationBuilder.CreateTable(
             name: "Address",
             schema: "CustomerContext",
             columns: table => new
             {
                Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                PostalCode = table.Column<string>(type: "VarChar", maxLength: 10, nullable: false),
                AddressLine = table.Column<string>(type: "VarChar", maxLength: 500, nullable: false),
                CityId = table.Column<int>(type: "Int", nullable: false),
                CustomerId = table.Column<Guid>(nullable: false),
                Telephone = table.Column<string>(type: "VarChar", maxLength: 10, nullable: true),
                Coordinate = table.Column<string>(type: "VarChar", maxLength: 30, nullable: true)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_Address", x => x.Id);
                table.ForeignKey(
                       name: "FK_Address_Customer_CustomerId",
                       column: x => x.CustomerId,
                       principalSchema: "CustomerContext",
                       principalTable: "Customer",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
             });

         migrationBuilder.CreateIndex(
               name: "IX_Address_CustomerId",
               schema: "CustomerContext",
               table: "Address",
               column: "CustomerId");

         //--------------------------------------------------------------------------------------

         ///adding index on NationalCode Column
         migrationBuilder.CreateIndex(
              name: "IX_Customer_NationalCode",
              schema: "CustomerContext",
              table: "Customer",
              column: "NationalCode");


         migrationBuilder.EnsureSchema(
                name: "Basic");

         migrationBuilder.CreateTable(
                name: "State",
                schema: "Basic",
                columns: table => new
                {
                   Id = table.Column<int>(type: "Int", nullable: false),
                   //Id = table.Column<int>(type: "UniqueIdentifier", nullable: false),
                   Name = table.Column<string>(type: "NVarChar", maxLength: 20, nullable: false),
                },
                constraints: table =>
                {
                   table.PrimaryKey("PK_State", x => x.Id);
                });

         migrationBuilder.CreateTable(
                name: "City",
                schema: "Basic",
                columns: table => new
                {
                   Id = table.Column<int>(type: "UniqueIdentifier", nullable: false),
                   Name = table.Column<string>(type: "VarChar", maxLength: 50, nullable: false),
                   StateId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                   table.PrimaryKey("PK_City", x => x.Id);
                   table.ForeignKey(
                       name: "FK_City_State_StateId",
                       column: x => x.StateId,
                       principalSchema: "Basic",
                       principalTable: "State",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

         migrationBuilder.CreateIndex(
              name: "IX_City_StateId",
              schema: "Basic",
              table: "City",
              column: "StateId");
         //------------------------------------------------------------------------------------------


      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(
             name: "Address",
             schema: "CustomerContext");

         migrationBuilder.DropTable(
             name: "Customer",
             schema: "CustomerContext");


         //---------------------------------------------
         migrationBuilder.DropTable(
             name: "State",
             schema: "Basic");

         migrationBuilder.DropTable(
             name: "City",
             schema: "Basic");
         //---------------------------------------------

      }
   }
}
