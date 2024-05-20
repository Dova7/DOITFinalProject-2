using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a5c5f4d-5e84-4d76-8436-149d53727afb", "AQAAAAIAAYagAAAAEOhMIBeNoBAlkOoH/TPJNQ4kGZB5qB2m3eZn0dSa8DvuseNwdlBQGNLt3Bk+/sTNeA==", "9d8e09a2-9368-488c-b7e0-8d02b5b28132" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230669E4-C593-4084-BACC-E5A1AD1AD494",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2545f9d6-a318-4a15-a01a-6ff309b2df1f", "AQAAAAIAAYagAAAAEGHixEg8uaxmlmA2ONVtuHf6MiQsXSQAJjch6cIr+taefCz0dopQe/S8UWEa8VpEMA==", "33a0850b-3389-4405-b3ae-1764d9a787b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24614412-A49F-4DC8-BCE1-EE5AFF9B11BC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52723dfe-d4f0-4c71-8a7e-9b8c02cfa974", "AQAAAAIAAYagAAAAEDlVC/skF+DKj3eJRJt/5a4DOedQmhyE8S5mXLnrXsD4HWt1phfBDKadkcG27ucAMQ==", "e1b3da04-4de6-4b93-bb9d-9c12555f8318" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5CB83547-A7E4-4064-81AF-640D2B9ED831",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "649741e1-6de3-4c78-9148-42c5c86f1cc0", "AQAAAAIAAYagAAAAEATuu7t1+JTO0xXjNtZTQgFAjkiKh13tB2VnqrbvqtHMV+RnsBoSQgJvuCjgw6YHJQ==", "44603981-994d-46fc-96d0-a376bdeddb0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "CD04B747-A694-4431-8C8A-7CBF278A3832",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65fd5a51-5de7-40c5-ada2-07651e26b15b", "AQAAAAIAAYagAAAAECDsfcV6Gp4xNPfwMSvbjRW88yVvZiv9ZHePVboAf/5TFToS0/PWwEV22BDK18+pWQ==", "45b4a03e-0da4-488b-95b9-d14de202fdc8" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3de83fe1-7390-4cdf-84ef-c403ac9cce6c"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5ce3ed72-1029-41a2-a957-e9d61928105f"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("76d4cf19-b62d-4a1d-a9fe-dd1f34009c41"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b53a2b67-c7c7-4937-b2ee-275d66dd803e"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b7d286fe-6ac7-48ed-a29c-dfc475cea0bb"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fa088c36-d4f7-4dca-82d1-51c18c830c31"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("0257e1e3-2135-444e-8854-dbc588a7b29b"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("33b7ed72-9434-434a-82d4-3018b018cb87"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("5b365ad2-0264-46b2-86a8-c9c426ee88dd"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("e18a5600-0d2a-4d43-b045-f7773c5c2d8d"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9234));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0eefac9-cc54-49de-b5dc-e26e2fbaec0d", "AQAAAAIAAYagAAAAEFEWtEE4nA3yj8ONT44o+9xVO6qdBc5aVyCmetwBme++ytj63Oxb7UQL9nKxLfKe2w==", "f6038fe6-0e0d-4381-8868-0bb4450d23b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230669E4-C593-4084-BACC-E5A1AD1AD494",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f9c0cbf-a935-4002-8b9f-dc66641039c5", "AQAAAAIAAYagAAAAEArF2Fwo9/RAASGfjHaGo4WTJgdki0+sPvMLjvnD1CMPhvGws5mesGWvLSE0FWwJCA==", "2e4691ae-1778-4822-acfc-9fcd177c3b63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24614412-A49F-4DC8-BCE1-EE5AFF9B11BC",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab190609-792d-47a7-a94c-f6b56eb396b9", "AQAAAAIAAYagAAAAEBB56IPfxksVdrtBkg4bUOwCnXcdfLlluio9SRI5f8JpJ42/ZeQYDd7gjdEp1hrlLg==", "2cd2b9cd-96f6-4a7b-9cf3-8deb94071dfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5CB83547-A7E4-4064-81AF-640D2B9ED831",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6688f883-ef78-493f-adfc-ed72d95e7800", "AQAAAAIAAYagAAAAEIPO+WVDjGxJHUqxebFV1ZlxX9djDVKkQ2M3KWTM4ZigSr68Gfh0P2et5x69Rho+vw==", "3be8b228-c11a-4827-bb75-23f1ff5c2e96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "CD04B747-A694-4431-8C8A-7CBF278A3832",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40948512-18fd-4a5a-8fdb-0a713d227da8", "AQAAAAIAAYagAAAAEAeEXLTWKTFnN7B73cZLgZOZv6RMeKC9MwGShqtCJeA0Nq23IyyboT+oCwmdu/9yzg==", "32d754ce-dc99-440f-b22a-004deb0aae91" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3de83fe1-7390-4cdf-84ef-c403ac9cce6c"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5ce3ed72-1029-41a2-a957-e9d61928105f"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("76d4cf19-b62d-4a1d-a9fe-dd1f34009c41"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b53a2b67-c7c7-4937-b2ee-275d66dd803e"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b7d286fe-6ac7-48ed-a29c-dfc475cea0bb"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fa088c36-d4f7-4dca-82d1-51c18c830c31"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("0257e1e3-2135-444e-8854-dbc588a7b29b"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("33b7ed72-9434-434a-82d4-3018b018cb87"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("5b365ad2-0264-46b2-86a8-c9c426ee88dd"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("e18a5600-0d2a-4d43-b045-f7773c5c2d8d"),
                column: "PostDate",
                value: new DateTime(2024, 5, 21, 2, 4, 54, 235, DateTimeKind.Local).AddTicks(3283));
        }
    }
}
