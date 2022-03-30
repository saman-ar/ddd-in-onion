using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.Persistence
{
   //class tempMigration
   //{
   //   //--------------------------------------------------------------------------------------

   //   ///adding index on NationalCode Column
   //   migrationBuilder.CreateIndex(
   //        name: "IX_Customer_NationalCode",
   //           schema: "CustomerContext",
   //           table: "Customer",
   //           column: "NationalCode");


   //      migrationBuilder.EnsureSchema(
   //             name: "Basic");

   //      migrationBuilder.CreateTable(
   //             name: "State",
   //             schema: "Basic",
   //             columns: table => new
   //             {
   //                Id = table.Column<int>(type: "Int", nullable: false),
   //                //Id = table.Column<int>(type: "UniqueIdentifier", nullable: false),
   //                Name = table.Column<string>(type: "NVarChar", maxLength: 20, nullable: false),
   //             },
   //             constraints: table =>
   //             {
   //                table.PrimaryKey("PK_State", x => x.Id);
   //             });

   //      migrationBuilder.CreateTable(
   //             name: "City",
   //             schema: "Basic",
   //             columns: table => new
   //             {
   //                Id = table.Column<int>(type: "UniqueIdentifier", nullable: false),
   //                Name = table.Column<string>(type: "VarChar", maxLength: 50, nullable: false),
   //                StateId = table.Column<int>(nullable: false),
   //             },
   //             constraints: table =>
   //             {
   //                table.PrimaryKey("PK_City", x => x.Id);
   //                table.ForeignKey(
   //                    name: "FK_City_State_StateId",
   //                    column: x => x.StateId,
   //                    principalSchema: "Basic",
   //                    principalTable: "State",
   //                    principalColumn: "Id",
   //                    onDelete: ReferentialAction.Cascade);
   //             });

   //      migrationBuilder.CreateIndex(
   //           name: "IX_City_StateId",
   //           schema: "Basic",
   //           table: "City",
   //           column: "StateId");
   //      //------------------------------------------------------------------------------------------

   //}
}
