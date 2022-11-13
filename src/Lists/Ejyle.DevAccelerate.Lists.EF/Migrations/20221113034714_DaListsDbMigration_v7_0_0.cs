using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejyle.DevAccelerate.Lists.EF.Migrations
{
    /// <inheritdoc />
    public partial class DaListsDbMigrationv700 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lists");

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AlphabeticCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumericCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateFormats",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    DateFormatExpression = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenericLists",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemLanguages",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    SystemTimeZoneId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SupportsDaylightSavingTime = table.Column<bool>(type: "bit", nullable: false),
                    DaylightName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    InternationalDialingCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TwoLetterCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ThreeLetterCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumericCode = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DefaultTimeZoneId = table.Column<int>(type: "int", nullable: true),
                    DefaultDateFormatId = table.Column<int>(type: "int", nullable: true),
                    DefaultSystemLanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Lists",
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenericListItems",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericListItems_GenericLists_ListId",
                        column: x => x.ListId,
                        principalSchema: "Lists",
                        principalTable: "GenericLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryDateFormats",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DateFormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDateFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryDateFormats_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Lists",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryDateFormats_DateFormats_DateFormatId",
                        column: x => x.DateFormatId,
                        principalSchema: "Lists",
                        principalTable: "DateFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegions",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryRegions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Lists",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRegions_CountryRegions_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Lists",
                        principalTable: "CountryRegions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountrySystemLanguages",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    SystemLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySystemLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountrySystemLanguages_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Lists",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountrySystemLanguages_SystemLanguages_SystemLanguageId",
                        column: x => x.SystemLanguageId,
                        principalSchema: "Lists",
                        principalTable: "SystemLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTimeZones",
                schema: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    TimeZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimeZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTimeZones_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Lists",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTimeZones_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalSchema: "Lists",
                        principalTable: "TimeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                schema: "Lists",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                schema: "Lists",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ThreeLetterCode",
                schema: "Lists",
                table: "Countries",
                column: "ThreeLetterCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TwoLetterCode",
                schema: "Lists",
                table: "Countries",
                column: "TwoLetterCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryDateFormats_CountryId",
                schema: "Lists",
                table: "CountryDateFormats",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryDateFormats_DateFormatId",
                schema: "Lists",
                table: "CountryDateFormats",
                column: "DateFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegions_CountryId",
                schema: "Lists",
                table: "CountryRegions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegions_ParentId",
                schema: "Lists",
                table: "CountryRegions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySystemLanguages_CountryId",
                schema: "Lists",
                table: "CountrySystemLanguages",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySystemLanguages_SystemLanguageId",
                schema: "Lists",
                table: "CountrySystemLanguages",
                column: "SystemLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimeZones_CountryId",
                schema: "Lists",
                table: "CountryTimeZones",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTimeZones_TimeZoneId",
                schema: "Lists",
                table: "CountryTimeZones",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_AlphabeticCode",
                schema: "Lists",
                table: "Currencies",
                column: "AlphabeticCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Name",
                schema: "Lists",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DateFormats_DateFormatExpression",
                schema: "Lists",
                table: "DateFormats",
                column: "DateFormatExpression",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DateFormats_Name",
                schema: "Lists",
                table: "DateFormats",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenericListItems_ListId",
                schema: "Lists",
                table: "GenericListItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericLists_Name",
                schema: "Lists",
                table: "GenericLists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemLanguages_Name",
                schema: "Lists",
                table: "SystemLanguages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeZones_Name",
                schema: "Lists",
                table: "TimeZones",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryDateFormats",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "CountryRegions",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "CountrySystemLanguages",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "CountryTimeZones",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "GenericListItems",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "DateFormats",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "SystemLanguages",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "TimeZones",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "GenericLists",
                schema: "Lists");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Lists");
        }
    }
}
