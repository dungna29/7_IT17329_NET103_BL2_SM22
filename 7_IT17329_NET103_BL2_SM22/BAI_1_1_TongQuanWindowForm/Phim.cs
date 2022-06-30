using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    internal class Phim
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string TheLoaiPhim { get; set; }
        public int TrangThai { get; set; }

        public List<Phim> GetLstPhims()
        {
            return new List<Phim>()
            {
                new Phim(){Id = Guid.NewGuid(),Ten = "Bảo Bảo",TheLoaiPhim = "18+",TrangThai = 1}, 
                new Phim(){Id = Guid.NewGuid(),Ten = "Duy Bảo",TheLoaiPhim = "19+",TrangThai = 0}, 
                new Phim(){Id = Guid.NewGuid(),Ten = "Bảo Bảo Phần 2",TheLoaiPhim = "18+",TrangThai = 1}
            };

        }
    }
}
