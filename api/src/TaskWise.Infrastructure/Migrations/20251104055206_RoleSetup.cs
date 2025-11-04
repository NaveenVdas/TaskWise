using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskWise.Infrastructure.Migrations;

/// <inheritdoc />
public partial class RoleSetup : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Role",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                UpdatedBy = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Role_Id", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "UQ_Role_Name",
            table: "Role",
            column: "Name",
            unique: true);

        migrationBuilder.Sql(@"
                INSERT INTO Role(Id, Name, CreatedBy)
                VALUES(1, 'Admin', 1),(2, 'Manager', 1),(3, 'Team Member', 1)
        ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
                DELETE FROM Role
        ");
        migrationBuilder.DropTable(
            name: "Role");
    }
}
