using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WC.Service.EmailDomains.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class EmailDoamin_Using_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmailDomains_DomainName",
                table: "EmailDomains",
                column: "DomainName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmailDomains_DomainName",
                table: "EmailDomains");
        }
    }
}
