using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Oras = table.Column<string>(nullable: true),
                    Tara = table.Column<string>(nullable: true),
                    Strada = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    An = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume_Materie = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(maxLength: 50, nullable: true),
                    Prenume = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(maxLength: 50, nullable: true),
                    Prenume = table.Column<string>(maxLength: 100, nullable: true),
                    DataNastere = table.Column<DateTime>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curs",
                columns: table => new
                {
                    MaterieId = table.Column<int>(nullable: false),
                    ProfesorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curs", x => new { x.MaterieId, x.ProfesorId });
                    table.ForeignKey(
                        name: "FK_Curs_Materie_MaterieId",
                        column: x => x.MaterieId,
                        principalTable: "Materie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curs_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupareStudenti",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    GrupaId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Curent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupareStudenti", x => new { x.GrupaId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GrupareStudenti_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupareStudenti_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orar",
                columns: table => new
                {
                    GrupaId = table.Column<int>(nullable: false),
                    MaterieId = table.Column<int>(nullable: false),
                    ProfesorId = table.Column<int>(nullable: false),
                    GrupareStudentiGrupaId = table.Column<int>(nullable: true),
                    GrupareStudentiStudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orar", x => new { x.GrupaId, x.MaterieId, x.ProfesorId });
                    table.ForeignKey(
                        name: "FK_Orar_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orar_Materie_MaterieId",
                        column: x => x.MaterieId,
                        principalTable: "Materie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orar_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orar_GrupareStudenti_GrupareStudentiGrupaId_GrupareStudentiStudentId",
                        columns: x => new { x.GrupareStudentiGrupaId, x.GrupareStudentiStudentId },
                        principalTable: "GrupareStudenti",
                        principalColumns: new[] { "GrupaId", "StudentId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orar_Curs_MaterieId_ProfesorId",
                        columns: x => new { x.MaterieId, x.ProfesorId },
                        principalTable: "Curs",
                        principalColumns: new[] { "MaterieId", "ProfesorId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    GrupaId = table.Column<int>(nullable: false),
                    MaterieId = table.Column<int>(nullable: false),
                    ProfesorId = table.Column<int>(nullable: false),
                    Valoare = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => new { x.StudentId, x.GrupaId, x.MaterieId, x.ProfesorId });
                    table.ForeignKey(
                        name: "FK_Nota_Grupa_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Materie_MaterieId",
                        column: x => x.MaterieId,
                        principalTable: "Materie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nota_Orar_GrupaId_MaterieId_ProfesorId",
                        columns: x => new { x.GrupaId, x.MaterieId, x.ProfesorId },
                        principalTable: "Orar",
                        principalColumns: new[] { "GrupaId", "MaterieId", "ProfesorId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curs_ProfesorId",
                table: "Curs",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupareStudenti_StudentId",
                table: "GrupareStudenti",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_MaterieId",
                table: "Nota",
                column: "MaterieId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_ProfesorId",
                table: "Nota",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_GrupaId_MaterieId_ProfesorId",
                table: "Nota",
                columns: new[] { "GrupaId", "MaterieId", "ProfesorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orar_ProfesorId",
                table: "Orar",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orar_GrupareStudentiGrupaId_GrupareStudentiStudentId",
                table: "Orar",
                columns: new[] { "GrupareStudentiGrupaId", "GrupareStudentiStudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orar_MaterieId_ProfesorId",
                table: "Orar",
                columns: new[] { "MaterieId", "ProfesorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdresaId",
                table: "Student",
                column: "AdresaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Orar");

            migrationBuilder.DropTable(
                name: "GrupareStudenti");

            migrationBuilder.DropTable(
                name: "Curs");

            migrationBuilder.DropTable(
                name: "Grupa");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Adresa");
        }
    }
}
