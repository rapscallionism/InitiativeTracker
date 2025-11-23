using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class IdsToGuid2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // For safety, make sure pgcrypto extension exists (needed if you want gen_random_uuid())
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"pgcrypto\";");

            // If EquipmentId has valid GUIDs as strings
            migrationBuilder.Sql(@"
                ALTER TABLE features
                ALTER COLUMN ""EquipmentId"" TYPE uuid
                USING ""EquipmentId""::uuid;
            ");

            // Otherwise, generate new UUIDs for null or invalid rows
            // migrationBuilder.Sql(@"
            //     UPDATE features
            //     SET ""EquipmentId"" = gen_random_uuid()
            //     WHERE ""EquipmentId"" IS NULL;
            // ");

            // Update other column types (like Id) if needed
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "features",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "equipments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "EquipmentId",
            //    table: "features",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(Guid),
            //    oldType: "uuid",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "features",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uuid");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "equipments",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uuid");
        }
    }
}
