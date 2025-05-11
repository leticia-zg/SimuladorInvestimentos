﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorInvestimentos.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INVESTIMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorInicial = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PrazoMeses = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TaxaJurosMensal = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVESTIMENTOS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVESTIMENTOS");
        }
    }
}
