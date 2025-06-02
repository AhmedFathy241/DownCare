using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DownCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateActivityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 1,
                column: "SoundPath",
                value: "/Sound/OneWord/ارنب.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 2,
                column: "SoundPath",
                value: "/Sound/OneWord/استيكة.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 3,
                column: "SoundPath",
                value: "/Sound/OneWord/اسد.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 4,
                column: "SoundPath",
                value: "/Sound/OneWord/اسنان.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 37,
                column: "SoundPath",
                value: "/Sound/TwoWord/أستيقظ مبكرا.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 39,
                column: "SoundPath",
                value: "/Sound/TwoWord/أغسل أسنانى.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 78,
                column: "SoundPath",
                value: "/Sound/ThreeWord/الولد يذهب للمدرسة.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Label", "SoundPath" },
                values: new object[] { "يعالج الدكتور الطفل المريض فى المستشفى", "/Sound/FiveWord/يعالج الدكتور الطفل المريض فى المستشفى.mp3" });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 3, 2, 55, 716, DateTimeKind.Local).AddTicks(7030));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 1,
                column: "SoundPath",
                value: "/Sound/OneWord/أرنب.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 2,
                column: "SoundPath",
                value: "/Sound/OneWord/استيكه.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 3,
                column: "SoundPath",
                value: "/Sound/OneWord/أسد.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 4,
                column: "SoundPath",
                value: "/Sound/OneWord/أسنان.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 37,
                column: "SoundPath",
                value: "/Sound/TwoWord/استيقظ مبكرا.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 39,
                column: "SoundPath",
                value: "/Sound/TwoWord/أغسل اسنانى.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 78,
                column: "SoundPath",
                value: "/Sound/ThreeWord/الولد يذهب للمدرسه.mp3");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Label", "SoundPath" },
                values: new object[] { "يعالج الطبيب الطفل المريض فى المستشفى", "/Sound/FiveWord/يعالج الطبيب الطفل المريض فى المستشفى.mp3" });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 19, 18, 33, 38, 444, DateTimeKind.Local).AddTicks(2102));
        }
    }
}
