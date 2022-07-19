using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BAI_1_3_EFCORE_DBFIRST.DomainClass
{
    [Table("NhanVien")]
    [Index(nameof(Ma), Name = "UQ__NhanVien__3214CC9E68F1B1CF", IsUnique = true)]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            InverseIdGuiBcNavigation = new HashSet<NhanVien>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }
        [StringLength(30)]
        public string TenDem { get; set; }
        [StringLength(30)]
        public string Ho { get; set; }
        [StringLength(10)]
        public string GioiTinh { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        [StringLength(100)]
        public string DiaChi { get; set; }
        [StringLength(30)]
        public string Sdt { get; set; }
        public string MatKhau { get; set; }
        [Column("IdCH")]
        public Guid? IdCh { get; set; }
        [Column("IdCV")]
        public Guid? IdCv { get; set; }
        [Column("IdGuiBC")]
        public Guid? IdGuiBc { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdCh))]
        [InverseProperty(nameof(CuaHang.NhanViens))]
        public virtual CuaHang IdChNavigation { get; set; }
        [ForeignKey(nameof(IdCv))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public virtual ChucVu IdCvNavigation { get; set; }
        [ForeignKey(nameof(IdGuiBc))]
        [InverseProperty(nameof(NhanVien.InverseIdGuiBcNavigation))]
        public virtual NhanVien IdGuiBcNavigation { get; set; }
        [InverseProperty(nameof(HoaDon.IdNvNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [InverseProperty(nameof(NhanVien.IdGuiBcNavigation))]
        public virtual ICollection<NhanVien> InverseIdGuiBcNavigation { get; set; }
    }
}
