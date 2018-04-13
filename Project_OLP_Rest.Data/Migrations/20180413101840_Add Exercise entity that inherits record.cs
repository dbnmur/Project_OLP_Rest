using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_OLP_Rest.Data.Migrations
{
    public partial class AddExerciseentitythatinheritsrecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswerRegex",
                table: "Records",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Records",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Records",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerRegex",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Records");
        }
    }
}
