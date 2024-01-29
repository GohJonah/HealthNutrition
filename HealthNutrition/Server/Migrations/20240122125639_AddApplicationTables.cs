using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthNutrition.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1939fbf3-3c15-423b-bf91-df2905a32589", "AQAAAAIAAYagAAAAENTZK5F+rQqucOO2xJ/+xMVc0A+nRC3nOyaXToGgyN9Y4ZiSD8abhbf2yySk57w7Fg==", "78cc2595-637f-4442-ae29-5f327378106a" });

            migrationBuilder.UpdateData(
                table: "ExerciseRoutines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 22, 20, 56, 38, 942, DateTimeKind.Local).AddTicks(5224), new DateTime(2024, 1, 22, 20, 56, 38, 942, DateTimeKind.Local).AddTicks(5225) });

            migrationBuilder.UpdateData(
                table: "HealthNutritionBenefits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 22, 20, 56, 38, 942, DateTimeKind.Local).AddTicks(4938), new DateTime(2024, 1, 22, 20, 56, 38, 942, DateTimeKind.Local).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 22, 20, 56, 38, 942, DateTimeKind.Local).AddTicks(5379), new DateTime(2024, 1, 22, 20, 56, 38, 942, DateTimeKind.Local).AddTicks(5379) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "097c63a3-a271-4482-9747-c4bba2f72fb0", "AQAAAAIAAYagAAAAEJaIKWXRmTOkeequiiHfpqxox7m082Xqf+dq4ITdGP+MU0jk+7PQXiDWfTRkhcY6ow==", "0f5ddbcc-c255-4c3b-9f7f-dee7f79a7a2a" });

            migrationBuilder.UpdateData(
                table: "ExerciseRoutines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 22, 20, 56, 30, 947, DateTimeKind.Local).AddTicks(4083), new DateTime(2024, 1, 22, 20, 56, 30, 947, DateTimeKind.Local).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "HealthNutritionBenefits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 22, 20, 56, 30, 947, DateTimeKind.Local).AddTicks(3799), new DateTime(2024, 1, 22, 20, 56, 30, 947, DateTimeKind.Local).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 22, 20, 56, 30, 947, DateTimeKind.Local).AddTicks(4238), new DateTime(2024, 1, 22, 20, 56, 30, 947, DateTimeKind.Local).AddTicks(4238) });
        }
    }
}
