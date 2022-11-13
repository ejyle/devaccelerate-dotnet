using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejyle.DevAccelerate.Files.EF.Migrations
{
    /// <inheritdoc />
    public partial class DaFilesDbMigrationv700 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Files");

            migrationBuilder.CreateTable(
                name: "FileCollections",
                schema: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ObjectInstanceId = table.Column<int>(type: "int", nullable: true),
                    IsUserDefined = table.Column<bool>(type: "bit", nullable: false),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    FileStorageLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileCollections_FileCollections_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Files",
                        principalTable: "FileCollections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileStorages",
                schema: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Root = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageType = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GuidFileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileCollectionId = table.Column<int>(type: "int", nullable: true),
                    ObjectInstanceId = table.Column<int>(type: "int", nullable: true),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    FileStorageLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_FileCollections_FileCollectionId",
                        column: x => x.FileCollectionId,
                        principalSchema: "Files",
                        principalTable: "FileCollections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileStorageAttributes",
                schema: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileStorageId = table.Column<int>(type: "int", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorageAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileStorageAttributes_FileStorages_FileStorageId",
                        column: x => x.FileStorageId,
                        principalSchema: "Files",
                        principalTable: "FileStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileStorageLocations",
                schema: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FileStorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorageLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileStorageLocations_FileStorages_FileStorageId",
                        column: x => x.FileStorageId,
                        principalSchema: "Files",
                        principalTable: "FileStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileCollections_ParentId",
                schema: "Files",
                table: "FileCollections",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileCollectionId",
                schema: "Files",
                table: "Files",
                column: "FileCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_GuidFileName",
                schema: "Files",
                table: "Files",
                column: "GuidFileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileStorageAttributes_FileStorageId",
                schema: "Files",
                table: "FileStorageAttributes",
                column: "FileStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_FileStorageLocations_FileStorageId",
                schema: "Files",
                table: "FileStorageLocations",
                column: "FileStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_FileStorages_Name",
                schema: "Files",
                table: "FileStorages",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "Files");

            migrationBuilder.DropTable(
                name: "FileStorageAttributes",
                schema: "Files");

            migrationBuilder.DropTable(
                name: "FileStorageLocations",
                schema: "Files");

            migrationBuilder.DropTable(
                name: "FileCollections",
                schema: "Files");

            migrationBuilder.DropTable(
                name: "FileStorages",
                schema: "Files");
        }
    }
}
