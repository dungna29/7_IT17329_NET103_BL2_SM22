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
        private Guid _idWhenClick;

        public FrmQLPhim()
        {
            InitializeComponent();
            _qlPhimService = new QLPhimService();
            _qlPhimService.FakeData();//Đổ dữ liệu vào List
            LoadDataPhim(null);
            rbtn_KoHoatDong.Checked = true;
            LoadTheLoaiPhim();
            txt_MaPhim.Enabled = false;//Không cho can thiệp vào ô Mã phim
        }

        private void LoadTheLoaiPhim()
        {
            foreach (var x in _qlPhimService.GetAllTLPhim())
            {
                cmb_TheLoai.Items.Add(x);
            }
            cmb_TheLoai.SelectedIndex = 0;
        }

        private void LoadDataPhim(string input)
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
            foreach (var x in _qlPhimService.GetAll(input))
            {
                dgrid_Phim.Rows.Add(stt++, x.Id, x.Ten, x.MaPhim, x.TheLoaiPhim,
                    (x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"));
            }
        }

        //Code 1 phương thức lấy dữ liệu trên form gán về đối tượng
        private PhimAnh GetDataFromGui()
        {
            return new PhimAnh() { Id = Guid.Empty, MaPhim = txt_MaPhim.Text, Ten = txtTenPhim.Text, TheLoaiPhim = cmb_TheLoai.Text, TrangThai = (rbtn_HoatDong.Checked ? 1 : 0) };
            //Id = Guid.Empty vì nếu là thêm mới thì bên Service sẽ tự sinh khóa chính còn nếu trong trường hợp update thì sẽ được gán khóa chính sau
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_qlPhimService.Add(GetDataFromGui()));
            //Load lại dữ liệu khi thêm mới ở Datagridview
            LoadDataPhim(null);
        }

        private void txtTenPhim_TextChanged(object sender, EventArgs e)
        {
            txt_MaPhim.Text = Utility.GetMaTuSinh(txtTenPhim.Text) + _qlPhimService.GetAll().Count;
        }

        //Sự kiện xảy ra khi bấm vào 1 control khác không phải control TXT TÊN PHIM
        private void txtTenPhim_Leave(object sender, EventArgs e)
        {
            txtTenPhim.Text = Utility.VietHoaChuCaiDau(txtTenPhim.Text);
        }

        private void dgrid_Phim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //1. Lấy được index tại dòng người dùng click
            int rowindex = e.RowIndex;
            if (rowindex == _qlPhimService.GetAll().Count) return;//Khi người dùng bấm ra bên ngoài index mà trong list không có sẽ gây chết chương trình
            _idWhenClick = Guid.Parse(dgrid_Phim.Rows[rowindex].Cells[1].Value.ToString());
            var phim = _qlPhimService.GetAll().FirstOrDefault(c => c.Id == _idWhenClick);//Trả về 1 đối tượng tương ứng với khóa chính
            txtTenPhim.Text = phim.Ten;
            cmb_TheLoai.SelectedIndex = cmb_TheLoai.FindStringExact(phim.TheLoaiPhim);
            txt_MaPhim.Text = phim.MaPhim;
            if (phim.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
                return;
            }
            rbtn_KoHoatDong.Checked = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            var temp = GetDataFromGui();
            temp.Id = _idWhenClick;
            MessageBox.Show(_qlPhimService.Update(temp));
            LoadDataPhim(null);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            var temp = GetDataFromGui();
            temp.Id = _idWhenClick;
            MessageBox.Show(_qlPhimService.Delete(temp));
            LoadDataPhim(null);
        }

        private void txt_TimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txt_TimKiem.Text = "";
        }

        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "Tìm kiếm ....";
            LoadDataPhim(null);
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            // if (string.IsNullOrEmpty(txt_TimKiem.Text))
            // {
            //     return;
            // }
            LoadDataPhim(txt_TimKiem.Text);
        }
    }
}