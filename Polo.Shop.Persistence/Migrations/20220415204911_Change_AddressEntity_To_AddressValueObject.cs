using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Polo.Shop.Persistence.Migrations
{
   public partial class Change_AddressEntity_To_AddressValueObject : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         ////migrationBuilder.RenameTable(
         ////    name: "Address",
         ////    schema: "CustomerContext",
         ////    newName: "Address");

         ////migrationBuilder.DropPrimaryKey(
         ////      name: "Id",
         ////      schema: "CustomerContext",
         ////      table: "Address"
         ////  );

         ////migrationBuilder.AddPrimaryKey(
         ////       name: "Id",
         ////       schema: "CustomerContext",
         ////       column: "Id",
         ////       table: "Address"
         ////   );

         //migrationBuilder.AlterColumn<string>(
         //    name: "Coordinate",
         //    table: "Address",
         //    nullable: true,
         //    oldClrType: typeof(string),
         //    oldType: "VarChar",
         //    oldMaxLength: 30,
         //    oldNullable: true);

         //migrationBuilder.AlterColumn<long>(
         //    name: "Id",
         //    table: "Address",
         //    nullable: false,
         //    oldClrType: typeof(Guid),
         //    oldType: "UniqueIdentifier")
         //    .Annotation("SqlServer:Identity", "1, 1");

         migrationBuilder.DropTable(
            name: "Address",
            schema: "CustomerContext"
            );

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
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         //migrationBuilder.RenameTable(
         //    name: "Address",
         //    newName: "Address",
         //    newSchema: "CustomerContext");

         //migrationBuilder.DropPrimaryKey(
         //       name: "Id",
         //       schema: "CustomerContext",
         //       table: "Address"
         //   );

         //migrationBuilder.AddPrimaryKey(
         //       name: "Id",
         //       schema: "CustomerContext",
         //       column:"Id",
         //       table: "Address"
         //   );

         //migrationBuilder.AlterColumn<string>(
         //    name: "Coordinate",
         //    schema: "CustomerContext",
         //    table: "Address",
         //    type: "VarChar",
         //    maxLength: 30,
         //    nullable: true,
         //    oldClrType: typeof(string),
         //    oldNullable: true);

         //migrationBuilder.AlterColumn<Guid>(
         //    name: "Id",
         //    schema: "CustomerContext",
         //    table: "Address",
         //    type: "UniqueIdentifier",
         //    nullable: false,
         //    oldClrType: typeof(long))
         //    .OldAnnotation("SqlServer:Identity", "1, 1");
      }
   }
}
