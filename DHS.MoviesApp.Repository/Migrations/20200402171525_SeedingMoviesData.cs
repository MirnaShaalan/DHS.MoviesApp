using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DHS.MoviesApp.Repository.Migrations
{
    public partial class SeedingMoviesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Discription", "Image", "ImageName", "ImageType", "Name" },
                values: new object[] { new Guid("11223344-5566-7788-99aa-bbccddeeff00"), null, null, null, null, "Movie 1" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Discription", "Image", "ImageName", "ImageType", "Name" },
                values: new object[] { new Guid("12223344-2566-7788-99aa-bbccddeeff00"), null, null, null, null, "Movie 2" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Discription", "Image", "ImageName", "ImageType", "Name" },
                values: new object[] { new Guid("13223344-3566-7788-99aa-bbccddeeff00"), null, null, null, null, "Movie 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("12223344-2566-7788-99aa-bbccddeeff00"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("13223344-3566-7788-99aa-bbccddeeff00"));
        }
    }
}
