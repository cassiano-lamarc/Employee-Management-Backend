using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasctructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Employee",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedUserId",
                table: "Employee",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedUserId",
                table: "Employee",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UpdatedUserId",
                table: "Employee",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_UserLogin_CreatedUserId",
                table: "Employee",
                column: "CreatedUserId",
                principalTable: "UserLogin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_UserLogin_UpdatedUserId",
                table: "Employee",
                column: "UpdatedUserId",
                principalTable: "UserLogin",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_UserLogin_CreatedUserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_UserLogin_UpdatedUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CreatedUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UpdatedUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Employee");
        }
    }
}
