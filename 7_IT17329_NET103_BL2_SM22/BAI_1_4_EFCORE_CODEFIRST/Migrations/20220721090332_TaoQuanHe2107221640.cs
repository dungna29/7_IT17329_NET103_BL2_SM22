using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_4_EFCORE_CODEFIRST.Migrations
{
    public partial class TaoQuanHe2107221640 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id_TheLoaiPhim",
                table: "PhimAnh",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhimAnh_Id_TheLoaiPhim",
                table: "PhimAnh",
                column: "Id_TheLoaiPhim");

            migrationBuilder.AddForeignKey(
                name: "FK_PhimAnh_TheLoaiPhim_Id_TheLoaiPhim",
                table: "PhimAnh",
                column: "Id_TheLoaiPhim",
                principalTable: "TheLoaiPhim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhimAnh_TheLoaiPhim_Id_TheLoaiPhim",
                table: "PhimAnh");

            migrationBuilder.DropIndex(
                name: "IX_PhimAnh_Id_TheLoaiPhim",
                table: "PhimAnh");

            migrationBuilder.DropColumn(
                name: "Id_TheLoaiPhim",
                table: "PhimAnh");
        }
    }
}
