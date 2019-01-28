using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "HotelTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HotelTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "HotelTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AmenitiesTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AmenitiesTable",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Balcony" },
                    { 2, "In room kitchen" },
                    { 3, "Mini bar" },
                    { 4, "Jet tub" },
                    { 5, "High speed internet" }
                });

            migrationBuilder.InsertData(
                table: "HotelTable",
                columns: new[] { "ID", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Fake Street Seattle, WA 98121", "J&J Hotel", "206 123 4567" },
                    { 2, "456 Fake Street Seattle, WA 98155", "JK Hotel", "206 987 6543" },
                    { 3, "789 Fake Street Seattle, WA 98040", "Seattle Hide Away Hotel", "425 999 9999" },
                    { 4, "123 Fake Lane Seattle, WA 98121", "Up & Up Hotel", "206 112 2334" },
                    { 5, "456 Fake Place Seattle, WA 98133", "No Wheres Land Hotel", "206 998 7655" }
                });

            migrationBuilder.InsertData(
                table: "RoomTable",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Sleepless in Seattle" },
                    { 2, 2, "Stay in Bed" },
                    { 3, 1, "Gogo" },
                    { 4, 2, "HoneyMoon" },
                    { 5, 2, "Red Solo Cup" },
                    { 6, 0, "Blue Solo Hen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AmenitiesTable",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AmenitiesTable",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AmenitiesTable",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AmenitiesTable",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AmenitiesTable",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HotelTable",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelTable",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelTable",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotelTable",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HotelTable",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTable",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTable",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTable",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTable",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTable",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTable",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomTable",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "HotelTable",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HotelTable",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "HotelTable",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AmenitiesTable",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
