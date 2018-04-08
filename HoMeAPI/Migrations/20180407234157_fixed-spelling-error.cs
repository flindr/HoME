using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HoMeAPI.Migrations
{
    public partial class fixedspellingerror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Humdidity",
                table: "Measurements",
                newName: "Humidity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "Measurements",
                newName: "Humdidity");
        }
    }
}
