using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskWise.Infrastructure.Migrations;

/// <inheritdoc />
public partial class LoginSetup : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Role = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                UpdatedBy = table.Column<int>(type: "int", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User_Id", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "UQ_User_Email",
            table: "User",
            column: "Email",
            unique: true);

        migrationBuilder.Sql(@"
                    INSERT INTO [dbo].[User](LastName, Email, PasswordHash, [Role], CreatedBy)
                    VALUES('Admin', 'admin@taskwise.com', '', 1, 1)
            ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "User");
    }
}
