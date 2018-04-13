using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_OLP_Rest.Data.Migrations
{
    public partial class RemoveRecordTypemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_RecordType_RecordTypeId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "RecordType");

            migrationBuilder.DropIndex(
                name: "IX_Records_RecordTypeId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "RecordTypeId",
                table: "Records");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordTypeId",
                table: "Records",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecordType",
                columns: table => new
                {
                    RecordTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordType", x => x.RecordTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_RecordTypeId",
                table: "Records",
                column: "RecordTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_RecordType_RecordTypeId",
                table: "Records",
                column: "RecordTypeId",
                principalTable: "RecordType",
                principalColumn: "RecordTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
