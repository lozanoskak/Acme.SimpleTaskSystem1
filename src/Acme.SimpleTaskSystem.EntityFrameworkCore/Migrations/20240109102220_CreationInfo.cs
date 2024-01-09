using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreationInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "StsTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DelitedBy",
                table: "StsTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelitedTime",
                table: "StsTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedById",
                table: "StsTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedTime",
                table: "StsTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "StsTasks");

            migrationBuilder.DropColumn(
                name: "DelitedBy",
                table: "StsTasks");

            migrationBuilder.DropColumn(
                name: "DelitedTime",
                table: "StsTasks");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "StsTasks");

            migrationBuilder.DropColumn(
                name: "LastUpdatedTime",
                table: "StsTasks");
        }
    }
}
