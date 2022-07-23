using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRST.DomainClass;
using BAI_1_4_EFCORE_CODEFIRST.Repositories;

namespace BAI_1_4_EFCORE_CODEFIRST.Services
{
    public class QLPhimService
    {
        private List<PhimAnh> _lstPhimAnhs;
        private PhimAnhRepository _paRepository;
        private TheLoaiPhimRepository _TLPARepository;

        public QLPhimService()
        {
            _lstPhimAnhs = new List<PhimAnh>();
            _paRepository = new PhimAnhRepository();
            _TLPARepository = new TheLoaiPhimRepository();
            GetDataFromDB();
            PhimAnh anh = new PhimAnh() { Id = Guid.Empty, };
        }

        private void GetDataFromDB()
        {
            _lstPhimAnhs = _paRepository.GetAll();
        }

        public string Add(PhimAnh pa)
        {
            if (_paRepository.Add(pa))
            {
                GetDataFromDB();
                return "Thêm thành công";
            }
            return "Không thành công";
        }

        public string Update(PhimAnh pa)
        {
            int index = _lstPhimAnhs.FindIndex(c => c.Id == pa.Id);
            if (index == -1)
            {
                return "Không tìm thấy";
            }

            if (_paRepository.Update(pa))
            {
                GetDataFromDB();
                return "Sửa thành công";
            }
            return "Không thành công";
        }

        public string Delete(PhimAnh pa)
        {
            int index = _lstPhimAnhs.FindIndex(c => c.Id == pa.Id);
            if (index == -1)
            {
                return "Không tìm thấy";
            }
            if (_paRepository.Delete(pa))
            {
                GetDataFromDB();
                return "Xóa thành công";
            }
            return "Không thành công";
        }

        public List<PhimAnh> GetAll()
        {
            return _lstPhimAnhs;
        }

        public List<PhimAnh> GetAll(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return GetAll();
            }
            return _paRepository.GetAll().Where(c => c.Ten.ToLower().StartsWith(input.ToLower()) || c.MaPhim.ToLower().StartsWith(input.ToLower())).ToList();
        }

        public List<TheLoaiPhim> GetAllTLPhim()
        {
            return _TLPARepository.GetAll().ToList();
        }
    }
}