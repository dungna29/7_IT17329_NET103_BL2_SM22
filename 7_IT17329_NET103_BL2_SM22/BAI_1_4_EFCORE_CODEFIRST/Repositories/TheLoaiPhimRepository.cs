using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAI_1_4_EFCORE_CODEFIRST.Context;
using BAI_1_4_EFCORE_CODEFIRST.DomainClass;

namespace BAI_1_4_EFCORE_CODEFIRST.Repositories
{
    public class TheLoaiPhimRepository
    {
        private FpolyDBContext _dbContext;

        public TheLoaiPhimRepository()
        {
            _dbContext = new FpolyDBContext();
        }

        public List<TheLoaiPhim> GetAll()
        {
            return _dbContext.TheLoaiPhims.ToList();
        }
    }
}