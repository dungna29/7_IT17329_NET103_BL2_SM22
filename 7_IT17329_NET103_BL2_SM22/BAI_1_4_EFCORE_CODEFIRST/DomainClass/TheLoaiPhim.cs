using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BAI_1_4_EFCORE_CODEFIRST.DomainClass
{
    [Table("TheLoaiPhim")]
    public class TheLoaiPhim
    {
        [Key]//Chỉ ra khóa chính
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        public string MaPhim { get; set; }
    }
}