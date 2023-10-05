using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homee.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addstateatDeviceState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "DeviceStates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "DeviceStates");
        }
    }
}
