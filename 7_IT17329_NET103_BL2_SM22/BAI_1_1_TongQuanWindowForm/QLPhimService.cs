using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    internal class QLPhimService
    {
        private List<PhimAnh> _lstPhimAnhs;
        public QLPhimService()
        {
            _lstPhimAnhs = new List<PhimAnh>();
        }

        public string Add(PhimAnh pa)
        {
            _lstPhimAnhs.Add(pa);
            return "Thêm thành công";
        }
        public string Update(PhimAnh pa)
        {
            int index = _lstPhimAnhs.FindIndex(c => c.Id == pa.Id);
            if (index == -1)
            {
                return "Sửa không thành công";
            }
            _lstPhimAnhs[index] = pa;
            return "Sửa thành công";
        }
        public string Delete(PhimAnh pa)
        {
            int index = _lstPhimAnhs.FindIndex(c => c.Id == pa.Id);
            if (index == -1)
            {
                return "Xóa không thành công";
            }
            _lstPhimAnhs.RemoveAt(index);
            return "Xóa thành công";
        }

        public List<PhimAnh> GetAll()
        {
            return _lstPhimAnhs;
        }
        public List<PhimAnh> GetAll(string input)
        {
            return _lstPhimAnhs.Where(c => c.Ten.StartsWith(input) || c.MaPhim.StartsWith(input)).ToList();
        }

        public void FakeData()
        {
            _lstPhimAnhs = new List<PhimAnh>() {
                new PhimAnh(){Id = Guid.NewGuid(),MaPhim = "PA",Ten = "Bảo Bảo Phần 1",TheLoaiPhim = "18+",TrangThai = 1},
                new PhimAnh(){Id = Guid.NewGuid(),MaPhim = "ZX",Ten = "Anh Bảo Phần 2",TheLoaiPhim = "18+",TrangThai = 1},
                new PhimAnh(){Id = Guid.NewGuid(),MaPhim = "UA",Ten = "Tiểu Bảo Phần 1",TheLoaiPhim = "18+",TrangThai = 0},
                new PhimAnh(){Id = Guid.NewGuid(),MaPhim = "TA",Ten = "Thần Bảo Phần 1",TheLoaiPhim = "18+",TrangThai = 1},
            };
        }

        public List<string> GetAllTLPhim()
        {
            return new List<string>() {"12+","16+","18+","21+","61+" };
        }

    }
}
