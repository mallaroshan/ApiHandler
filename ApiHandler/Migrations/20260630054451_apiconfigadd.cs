using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiHandler.Migrations
{
    /// <inheritdoc />
    public partial class apiconfigadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalApis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    AuthenticationType = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeoutInSeconds = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalApis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalApiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeaderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSecret = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiHeaders_ExternalApis_ExternalApiId",
                        column: x => x.ExternalApiId,
                        principalTable: "ExternalApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalApiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JsonPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestParameters_ExternalApis_ExternalApiId",
                        column: x => x.ExternalApiId,
                        principalTable: "ExternalApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalApiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JsonPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseParameters_ExternalApis_ExternalApiId",
                        column: x => x.ExternalApiId,
                        principalTable: "ExternalApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiHeaders_ExternalApiId",
                table: "ApiHeaders",
                column: "ExternalApiId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestParameters_ExternalApiId",
                table: "RequestParameters",
                column: "ExternalApiId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseParameters_ExternalApiId",
                table: "ResponseParameters",
                column: "ExternalApiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiHeaders");

            migrationBuilder.DropTable(
                name: "RequestParameters");

            migrationBuilder.DropTable(
                name: "ResponseParameters");

            migrationBuilder.DropTable(
                name: "ExternalApis");
        }
    }
}
