using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BAI_1_3_EFCORE_DBFIRST.DomainClass
{
    [Table("GioHangChiTiet")]
    public partial class GioHangChiTiet
    {
        [Key]
        public Guid IdGioHang { get; set; }
        [Key]
        [Column("IdChiTietSP")]
        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? DonGia { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? DonGiaKhiGiam { get; set; }

        [ForeignKey(nameof(IdChiTietSp))]
        [InverseProperty(nameof(ChiTietSp.GioHangChiTiets))]
        public virtual ChiTietSp IdChiTietSpNavigation { get; set; }
        [ForeignKey(nameof(IdGioHang))]
        [InverseProperty(nameof(GioHang.GioHangChiTiets))]
        public virtual GioHang IdGioHangNavigation { get; set; }
    }
}
