using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BAI_1_4_EFCORE_CODEFIRST.DomainClass;
using BAI_1_4_EFCORE_CODEFIRST.Services;
using BAI_1_4_EFCORE_CODEFIRST.Utilities;

namespace BAI_1_4_EFCORE_CODEFIRST.Views
{
    public partial class FrmQLPhimAnh : Form
    {
        private QLPhimService _qlPhimService;
        private Guid _idWhenClick;

        public FrmQLPhimAnh()
        {
            InitializeComponent();
            _qlPhimService = new QLPhimService();
            rbtn_KoHoatDong.Checked = true;
            txt_Ma.Enabled = false;
            LoadTheLoaiPhim();
            LoadDataPhim(null);
        }

        private void LoadTheLoaiPhim()
        {
            foreach (var x in _qlPhimService.GetAllTLPhim())
            {
                cmb_TheLoai.Items.Add(x.Ma);
            }
            cmb_TheLoai.SelectedIndex = 0;
        }

        private void LoadDataPhim(string input)
        {
            int stt = 1;
            Type type = typeof(PhimAnh);
            int countCl = type.GetProperties().Length;//Số lượng prop của lớp đối tượng phim ảnh.
            dgrid_PhimAnh.ColumnCount = countCl + 1;//Vì muốn thêm cột số thứ tự
            dgrid_PhimAnh.Columns[0].Name = "Stt";
            dgrid_PhimAnh.Columns[1].Name = "Id";
            dgrid_PhimAnh.Columns[2].Name = "Tên";
            dgrid_PhimAnh.Columns[3].Name = "Mã";
            dgrid_PhimAnh.Columns[4].Name = "Thể loại";
            dgrid_PhimAnh.Columns[5].Name = "Trạng Thái";
            dgrid_PhimAnh.Rows.Clear();//Xóa toàn bộ các row có trong grid khi load lại
            foreach (var x in _qlPhimService.GetAll(input))
            {
                var MaTL = _qlPhimService.GetAllTLPhim().FirstOrDefault(c => c.Id == x.Id_TheLoaiPhim);
                dgrid_PhimAnh.Rows.Add(stt++, x.Id, x.Ten, x.MaPhim, MaTL.Ma,
                    (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
        }

        private PhimAnh GetDataFromGui()
        {
            TheLoaiPhim tlp = _qlPhimService.GetAllTLPhim().FirstOrDefault(c => c.Ma == cmb_TheLoai.Text);
            return new PhimAnh() { Id = Guid.Empty, MaPhim = txt_Ma.Text, Ten = txt_Ten.Text, TheLoaiPhims = tlp, Id_TheLoaiPhim = tlp.Id, TrangThai = (rbtn_HoatDong.Checked ? 1 : 0) };
            //Id = Guid.Empty vì nếu là thêm mới thì bên Service sẽ tự sinh khóa chính còn nếu trong trường hợp update thì sẽ được gán khóa chính sau
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_qlPhimService.Add(GetDataFromGui()));
            //Load lại dữ liệu khi thêm mới ở Datagridview
            LoadDataPhim(null);
        }

        private void txt_Ten_TextChanged(object sender, EventArgs e)
        {
            txt_Ma.Text = Utility.GetMaTuSinh(txt_Ten.Text) + _qlPhimService.GetAll().Count;
        }
    }
}