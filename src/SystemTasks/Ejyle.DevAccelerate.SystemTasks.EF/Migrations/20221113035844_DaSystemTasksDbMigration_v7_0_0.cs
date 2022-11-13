using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejyle.DevAccelerate.SystemTasks.EF.Migrations
{
    /// <inheritdoc />
    public partial class DaSystemTasksDbMigrationv700 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SystemTasks");

            migrationBuilder.CreateTable(
                name: "SystemTaskDefinitions",
                schema: "SystemTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SystemTaskType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SystemTaskData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemTaskDataType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ErrorDataType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemTaskDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemTaskDefinitionAttributes",
                schema: "SystemTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemTaskId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemTaskDefinitionAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemTaskDefinitionAttributes_SystemTaskDefinitions_SystemTaskId",
                        column: x => x.SystemTaskId,
                        principalSchema: "SystemTasks",
                        principalTable: "SystemTaskDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemTaskDefinitionAttributes_SystemTaskId",
                schema: "SystemTasks",
                table: "SystemTaskDefinitionAttributes",
                column: "SystemTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemTaskDefinitionAttributes",
                schema: "SystemTasks");

            migrationBuilder.DropTable(
                name: "SystemTaskDefinitions",
                schema: "SystemTasks");
        }
    }
}
