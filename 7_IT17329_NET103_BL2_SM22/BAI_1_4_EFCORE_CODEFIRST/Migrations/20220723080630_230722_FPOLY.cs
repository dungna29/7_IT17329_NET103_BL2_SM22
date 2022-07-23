using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_4_EFCORE_CODEFIRST.Migrations
{
    public partial class _230722_FPOLY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheLoaiPhim",
                table: "PhimAnh");

            migrationBuilder.RenameColumn(
                name: "MaPhim",
                table: "TheLoaiPhim",
                newName: "Ma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ma",
                table: "TheLoaiPhim",
                newName: "MaPhim");

            migrationBuilder.AddColumn<string>(
                name: "TheLoaiPhim",
                table: "PhimAnh",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
