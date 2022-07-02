using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_1_TongQuanWindowForm
{
    public partial class FrmQLPhim : Form
    {
        private QLPhimService _qlPhimService;
        public FrmQLPhim()
        {
            InitializeComponent();
            _qlPhimService = new QLPhimService();
            _qlPhimService.FakeData();//Đổ dữ liệu vào List
            LoadDataPhim();
        }

        private void LoadDataPhim()
        {
            int stt = 1;
            Type type = typeof(PhimAnh);
            int countCl = type.GetProperties().Length;//Số lượng prop của lớp đối tượng phim ảnh.
            dgrid_Phim.ColumnCount = countCl + 1;//Vì muốn thêm cột số thứ tự
            dgrid_Phim.Columns[0].Name = "Stt";
            dgrid_Phim.Columns[1].Name = "Id";
            dgrid_Phim.Columns[2].Name = "Tên";
            dgrid_Phim.Columns[3].Name = "Mã";
            dgrid_Phim.Columns[4].Name = "Thể loại";
            dgrid_Phim.Columns[5].Name = "Trạng Thái";
            dgrid_Phim.Rows.Clear();//Xóa toàn bộ các row có trong grid khi load lại
            foreach (var x in _qlPhimService.GetAll())
            {
                dgrid_Phim.Rows.Add(stt++,x.Id, x.Ten, x.MaPhim, x.TheLoaiPhim,
                    (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
        }
    }
}
