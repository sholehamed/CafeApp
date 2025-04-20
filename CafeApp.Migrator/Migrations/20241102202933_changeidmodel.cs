using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeApp.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class changeidmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditiveEntity_Materials_MaterialId1",
                table: "AdditiveEntity");

            migrationBuilder.DropIndex(
                name: "IX_AdditiveEntity_MaterialId1",
                table: "AdditiveEntity");

            migrationBuilder.DropColumn(
                name: "MaterialId1",
                table: "AdditiveEntity");

            migrationBuilder.AlterColumn<long>(
                name: "Relation",
                table: "Units",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "AdditiveEntity",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveEntity_MaterialId",
                table: "AdditiveEntity",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditiveEntity_Materials_MaterialId",
                table: "AdditiveEntity",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditiveEntity_Materials_MaterialId",
                table: "AdditiveEntity");

            migrationBuilder.DropIndex(
                name: "IX_AdditiveEntity_MaterialId",
                table: "AdditiveEntity");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "Relation",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "AdditiveEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId1",
                table: "AdditiveEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveEntity_MaterialId1",
                table: "AdditiveEntity",
                column: "MaterialId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditiveEntity_Materials_MaterialId1",
                table: "AdditiveEntity",
                column: "MaterialId1",
                principalTable: "Materials",
                principalColumn: "Id");
        }
    }
}
