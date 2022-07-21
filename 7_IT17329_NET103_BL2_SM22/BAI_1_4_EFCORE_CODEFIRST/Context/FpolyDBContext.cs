using System;
using System.Collections.Generic;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRST.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace BAI_1_4_EFCORE_CODEFIRST.Context
{
    public class FpolyDBContext : DbContext//Bắt buộc phải kế thừa lớp cha DBcontext
    {
        //1. Ghi đè lại phương OnConfiguring của lớp cha
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Để cấu hình đường dẫn ở đây
            optionsBuilder.UseSqlServer(@"Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=PHIMANH_IT17329;Persist Security Info=True;User ID=dungna32;Password=123456");
        }

        //2. Khai báo các bảng ở đây
        public DbSet<PhimAnh> PhimAnhs { get; set; }

        public DbSet<TheLoaiPhim> TheLoaiPhims { get; set; }
    }
}