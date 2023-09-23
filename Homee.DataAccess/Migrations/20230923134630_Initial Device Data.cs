using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homee.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDeviceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceType", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Light", "Living Room", "Living Room Light" },
                    { 2, "Thermostat", "Bedroom", "Thermostat" },
                    { 3, "Light", "Kitchen", "Kitchen Light" },
                    { 4, "Light", "Bedroom", "Bedroom Lamp" },
                    { 5, "Camera", "Front Door", "Security Camera 1" },
                    { 6, "Camera", "Backyard", "Security Camera 2" },
                    { 7, "Motion Sensor", "Hallway", "Motion Sensor 1" },
                    { 8, "Alarm", "Living Room", "Fire Alarm" },
                    { 9, "Lock", "Front Door", "Smart Lock" },
                    { 10, "Smart Plug", "Living Room", "Smart Plug 1" },
                    { 11, "Smart Plug", "Bedroom", "Smart Plug 2" },
                    { 12, "Smart TV", "Living Room", "Smart TV" },
                    { 13, "Smart Appliance", "Kitchen", "Smart Fridge" },
                    { 14, "Garage Door Opener", "Garage", "Garage Door Opener" },
                    { 15, "Temperature Sensor", "Living Room", "Temperature Sensor 1" },
                    { 16, "Temperature Sensor", "Bedroom", "Temperature Sensor 2" },
                    { 17, "Humidity Sensor", "Bathroom", "Humidity Sensor 1" },
                    { 18, "Humidity Sensor", "Kitchen", "Humidity Sensor 2" },
                    { 19, "Blinds", "Living Room", "Window Blinds" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
