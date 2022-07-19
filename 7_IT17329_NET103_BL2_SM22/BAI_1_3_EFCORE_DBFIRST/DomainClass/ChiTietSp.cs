using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BAI_1_3_EFCORE_DBFIRST.DomainClass
{
    [Table("ChiTietSP")]
    public partial class ChiTietSp
    {
        public ChiTietSp()
        {
            GioHangChiTiets = new HashSet<GioHangChiTiet>();
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("IdSP")]
        public Guid? IdSp { get; set; }
        public Guid? IdNsx { get; set; }
        public Guid? IdMauSac { get; set; }
        [Column("IdDongSP")]
        public Guid? IdDongSp { get; set; }
        [Column("NamBH")]
        public int? NamBh { get; set; }
        [StringLength(50)]
        public string MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaNhap { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaBan { get; set; }

        [ForeignKey(nameof(IdDongSp))]
        [InverseProperty(nameof(DongSp.ChiTietSps))]
        public virtual DongSp IdDongSpNavigation { get; set; }
        [ForeignKey(nameof(IdMauSac))]
        [InverseProperty(nameof(MauSac.ChiTietSps))]
        public virtual MauSac IdMauSacNavigation { get; set; }
        [ForeignKey(nameof(IdNsx))]
        [InverseProperty(nameof(Nsx.ChiTietSps))]
        public virtual Nsx IdNsxNavigation { get; set; }
        [ForeignKey(nameof(IdSp))]
        [InverseProperty(nameof(SanPham.ChiTietSps))]
        public virtual SanPham IdSpNavigation { get; set; }
        [InverseProperty(nameof(GioHangChiTiet.IdChiTietSpNavigation))]
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
        [InverseProperty(nameof(HoaDonChiTiet.IdChiTietSpNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
