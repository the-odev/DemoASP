using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class GameOfThrone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Externals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvrage = table.Column<int>(type: "int", nullable: false),
                    thetvdb = table.Column<int>(type: "int", nullable: false),
                    imdb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Externals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Previousepisode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    href = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previousepisode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    average = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Self",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    href = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Self", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.id);
                    table.ForeignKey(
                        name: "FK_Network_Country_countryid",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebChannel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebChannel", x => x.id);
                    table.ForeignKey(
                        name: "FK_WebChannel_Country_countryid",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selfid = table.Column<int>(type: "int", nullable: true),
                    previousepisodeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.id);
                    table.ForeignKey(
                        name: "FK_Links_Previousepisode_previousepisodeid",
                        column: x => x.previousepisodeid,
                        principalTable: "Previousepisode",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Links_Self_selfid",
                        column: x => x.selfid,
                        principalTable: "Self",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameOfThrones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    runtime = table.Column<int>(type: "int", nullable: false),
                    premiered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    officialSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scheduleid = table.Column<int>(type: "int", nullable: true),
                    ratingid = table.Column<int>(type: "int", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: false),
                    networkid = table.Column<int>(type: "int", nullable: true),
                    webChannelid = table.Column<int>(type: "int", nullable: true),
                    externalsid = table.Column<int>(type: "int", nullable: true),
                    imageid = table.Column<int>(type: "int", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated = table.Column<int>(type: "int", nullable: false),
                    _linksid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOfThrones", x => x.id);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_Externals_externalsid",
                        column: x => x.externalsid,
                        principalTable: "Externals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_Image_imageid",
                        column: x => x.imageid,
                        principalTable: "Image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_Links__linksid",
                        column: x => x._linksid,
                        principalTable: "Links",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_Network_networkid",
                        column: x => x.networkid,
                        principalTable: "Network",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_Rating_ratingid",
                        column: x => x.ratingid,
                        principalTable: "Rating",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_Schedule_scheduleid",
                        column: x => x.scheduleid,
                        principalTable: "Schedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameOfThrones_WebChannel_webChannelid",
                        column: x => x.webChannelid,
                        principalTable: "WebChannel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    season = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airtime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airstamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    runtime = table.Column<int>(type: "int", nullable: false),
                    imageid = table.Column<int>(type: "int", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _linksid = table.Column<int>(type: "int", nullable: true),
                    GameOfThroneid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Episodes_GameOfThrones_GameOfThroneid",
                        column: x => x.GameOfThroneid,
                        principalTable: "GameOfThrones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Episodes_Image_imageid",
                        column: x => x.imageid,
                        principalTable: "Image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Episodes_Links__linksid",
                        column: x => x._linksid,
                        principalTable: "Links",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes__linksid",
                table: "Episodes",
                column: "_linksid");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_GameOfThroneid",
                table: "Episodes",
                column: "GameOfThroneid");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_imageid",
                table: "Episodes",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones__linksid",
                table: "GameOfThrones",
                column: "_linksid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones_externalsid",
                table: "GameOfThrones",
                column: "externalsid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones_imageid",
                table: "GameOfThrones",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones_networkid",
                table: "GameOfThrones",
                column: "networkid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones_ratingid",
                table: "GameOfThrones",
                column: "ratingid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones_scheduleid",
                table: "GameOfThrones",
                column: "scheduleid");

            migrationBuilder.CreateIndex(
                name: "IX_GameOfThrones_webChannelid",
                table: "GameOfThrones",
                column: "webChannelid");

            migrationBuilder.CreateIndex(
                name: "IX_Links_previousepisodeid",
                table: "Links",
                column: "previousepisodeid");

            migrationBuilder.CreateIndex(
                name: "IX_Links_selfid",
                table: "Links",
                column: "selfid");

            migrationBuilder.CreateIndex(
                name: "IX_Network_countryid",
                table: "Network",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_WebChannel_countryid",
                table: "WebChannel",
                column: "countryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "GameOfThrones");

            migrationBuilder.DropTable(
                name: "Externals");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "WebChannel");

            migrationBuilder.DropTable(
                name: "Previousepisode");

            migrationBuilder.DropTable(
                name: "Self");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
