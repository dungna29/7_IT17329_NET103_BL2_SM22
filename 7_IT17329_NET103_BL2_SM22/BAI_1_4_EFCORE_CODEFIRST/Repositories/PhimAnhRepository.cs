using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRST.Context;
using BAI_1_4_EFCORE_CODEFIRST.DomainClass;

namespace BAI_1_4_EFCORE_CODEFIRST.Repositories
{
    //Nơi CRUD đối tượng với CSDl
    public class PhimAnhRepository
    {
        private FpolyDBContext _dbContext;

        public PhimAnhRepository()
        {
            _dbContext = new FpolyDBContext();
        }

        public bool Add(PhimAnh obj)
        {
            if (obj == null) return false;
            obj.Id = Guid.NewGuid();//Khởi tạo khá chính khi thêm mới
            obj.TheLoaiPhims = _dbContext.TheLoaiPhims.FirstOrDefault(c => c.Id == obj.Id);
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(PhimAnh obj)
        {
            if (obj == null) return false;
            _dbContext.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(PhimAnh obj)
        {
            if (obj == null) return false;
            _dbContext.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public List<PhimAnh> GetAll()
        {
            return _dbContext.PhimAnhs.ToList();
        }
    }
}