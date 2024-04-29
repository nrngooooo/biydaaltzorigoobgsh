using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biydaalt.Migrations
{
    /// <inheritdoc />
    public partial class biydaalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albantushaals",
                columns: table => new
                {
                    albantushaalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    albantushaalName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albantushaals", x => x.albantushaalId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "Turuls",
                columns: table => new
                {
                    turulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turulName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turuls", x => x.turulId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regdug = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    workerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    albantushaalId = table.Column<int>(type: "int", nullable: false),
                    regdug = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.workerId);
                    table.ForeignKey(
                        name: "FK_Workers_Albantushaals_albantushaalId",
                        column: x => x.albantushaalId,
                        principalTable: "Albantushaals",
                        principalColumn: "albantushaalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DedTuruls",
                columns: table => new
                {
                    dedTurulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dedTurulName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    turulId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DedTuruls", x => x.dedTurulId);
                    table.ForeignKey(
                        name: "FK_DedTuruls_Turuls_turulId",
                        column: x => x.turulId,
                        principalTable: "Turuls",
                        principalColumn: "turulId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    page_count = table.Column<int>(type: "int", nullable: false),
                    turulId = table.Column<int>(type: "int", nullable: false),
                    dedTurulId = table.Column<int>(type: "int", nullable: false),
                    book_count = table.Column<int>(type: "int", nullable: false),
                    pub_date = table.Column<DateOnly>(type: "date", nullable: false),
                    pub_company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_Books_DedTuruls_dedTurulId",
                        column: x => x.dedTurulId,
                        principalTable: "DedTuruls",
                        principalColumn: "dedTurulId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Turuls_turulId",
                        column: x => x.turulId,
                        principalTable: "Turuls",
                        principalColumn: "turulId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookacts",
                columns: table => new
                {
                    bookactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false),
                    act_count = table.Column<int>(type: "int", nullable: false),
                    actshaltgaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookacts", x => x.bookactId);
                    table.ForeignKey(
                        name: "FK_Bookacts_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookacts_Workers_workerId",
                        column: x => x.workerId,
                        principalTable: "Workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookgives",
                columns: table => new
                {
                    bookgiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false),
                    enterdate = table.Column<DateOnly>(type: "date", nullable: false),
                    retdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookgives", x => x.bookgiveId);
                    table.ForeignKey(
                        name: "FK_Bookgives_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookgives_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookgives_Workers_workerId",
                        column: x => x.workerId,
                        principalTable: "Workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Torguulis",
                columns: table => new
                {
                    torguuliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    ashigodor = table.Column<int>(type: "int", nullable: false),
                    torguulihemje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torguulis", x => x.torguuliId);
                    table.ForeignKey(
                        name: "FK_Torguulis_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Torguulis_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Torguulis_Workers_workerId",
                        column: x => x.workerId,
                        principalTable: "Workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookacts_bookId",
                table: "Bookacts",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookacts_workerId",
                table: "Bookacts",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookgives_bookId",
                table: "Bookgives",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookgives_userId",
                table: "Bookgives",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookgives_workerId",
                table: "Bookgives",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_dedTurulId",
                table: "Books",
                column: "dedTurulId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_turulId",
                table: "Books",
                column: "turulId");

            migrationBuilder.CreateIndex(
                name: "IX_DedTuruls_turulId",
                table: "DedTuruls",
                column: "turulId");

            migrationBuilder.CreateIndex(
                name: "IX_Torguulis_bookId",
                table: "Torguulis",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Torguulis_userId",
                table: "Torguulis",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Torguulis_workerId",
                table: "Torguulis",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_albantushaalId",
                table: "Workers",
                column: "albantushaalId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_departmentId",
                table: "Workers",
                column: "departmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookacts");

            migrationBuilder.DropTable(
                name: "Bookgives");

            migrationBuilder.DropTable(
                name: "Torguulis");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "DedTuruls");

            migrationBuilder.DropTable(
                name: "Albantushaals");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Turuls");
        }
    }
}
