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
                name: "actshaltgaans",
                columns: table => new
                {
                    actshaltgaanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actshaltgaanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actshaltgaans", x => x.actshaltgaanId);
                });

            migrationBuilder.CreateTable(
                name: "albantushaals",
                columns: table => new
                {
                    albantushaalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    albantushaalName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albantushaals", x => x.albantushaalId);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "torguulishaltgaans",
                columns: table => new
                {
                    torguulishaltgaanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    torguulishaltgaanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_torguulishaltgaans", x => x.torguulishaltgaanId);
                });

            migrationBuilder.CreateTable(
                name: "turuls",
                columns: table => new
                {
                    turulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turulName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turuls", x => x.turulId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regdug = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    workerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    albantushaalId = table.Column<int>(type: "int", nullable: false),
                    regdug = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.workerId);
                    table.ForeignKey(
                        name: "FK_workers_albantushaals_albantushaalId",
                        column: x => x.albantushaalId,
                        principalTable: "albantushaals",
                        principalColumn: "albantushaalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dedTuruls",
                columns: table => new
                {
                    dedTurulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dedTurulName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    turulId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dedTuruls", x => x.dedTurulId);
                    table.ForeignKey(
                        name: "FK_dedTuruls_turuls_turulId",
                        column: x => x.turulId,
                        principalTable: "turuls",
                        principalColumn: "turulId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookimage = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_books", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_books_dedTuruls_dedTurulId",
                        column: x => x.dedTurulId,
                        principalTable: "dedTuruls",
                        principalColumn: "dedTurulId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_turuls_turulId",
                        column: x => x.turulId,
                        principalTable: "turuls",
                        principalColumn: "turulId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_workers_workerId",
                        column: x => x.workerId,
                        principalTable: "workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookacts",
                columns: table => new
                {
                    bookactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false),
                    act_count = table.Column<int>(type: "int", nullable: false),
                    actshaltgaanId = table.Column<int>(type: "int", nullable: false),
                    actdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookacts", x => x.bookactId);
                    table.ForeignKey(
                        name: "FK_bookacts_actshaltgaans_actshaltgaanId",
                        column: x => x.actshaltgaanId,
                        principalTable: "actshaltgaans",
                        principalColumn: "actshaltgaanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookacts_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookacts_workers_workerId",
                        column: x => x.workerId,
                        principalTable: "workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bookgives",
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
                    table.PrimaryKey("PK_bookgives", x => x.bookgiveId);
                    table.ForeignKey(
                        name: "FK_bookgives_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookgives_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookgives_workers_workerId",
                        column: x => x.workerId,
                        principalTable: "workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "torguulis",
                columns: table => new
                {
                    torguuliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: false),
                    ashigodor = table.Column<int>(type: "int", nullable: false),
                    torguulishaltgaanId = table.Column<int>(type: "int", nullable: false),
                    torguulihemje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_torguulis", x => x.torguuliId);
                    table.ForeignKey(
                        name: "FK_torguulis_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_torguulis_torguulishaltgaans_torguulishaltgaanId",
                        column: x => x.torguulishaltgaanId,
                        principalTable: "torguulishaltgaans",
                        principalColumn: "torguulishaltgaanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_torguulis_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_torguulis_workers_workerId",
                        column: x => x.workerId,
                        principalTable: "workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookacts_actshaltgaanId",
                table: "bookacts",
                column: "actshaltgaanId");

            migrationBuilder.CreateIndex(
                name: "IX_bookacts_bookId",
                table: "bookacts",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookacts_workerId",
                table: "bookacts",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_bookgives_bookId",
                table: "bookgives",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookgives_userId",
                table: "bookgives",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_bookgives_workerId",
                table: "bookgives",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_books_dedTurulId",
                table: "books",
                column: "dedTurulId");

            migrationBuilder.CreateIndex(
                name: "IX_books_turulId",
                table: "books",
                column: "turulId");

            migrationBuilder.CreateIndex(
                name: "IX_books_workerId",
                table: "books",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_dedTuruls_turulId",
                table: "dedTuruls",
                column: "turulId");

            migrationBuilder.CreateIndex(
                name: "IX_torguulis_bookId",
                table: "torguulis",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_torguulis_torguulishaltgaanId",
                table: "torguulis",
                column: "torguulishaltgaanId");

            migrationBuilder.CreateIndex(
                name: "IX_torguulis_userId",
                table: "torguulis",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_torguulis_workerId",
                table: "torguulis",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_albantushaalId",
                table: "workers",
                column: "albantushaalId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_departmentId",
                table: "workers",
                column: "departmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookacts");

            migrationBuilder.DropTable(
                name: "bookgives");

            migrationBuilder.DropTable(
                name: "torguulis");

            migrationBuilder.DropTable(
                name: "actshaltgaans");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "torguulishaltgaans");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "dedTuruls");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropTable(
                name: "turuls");

            migrationBuilder.DropTable(
                name: "albantushaals");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
