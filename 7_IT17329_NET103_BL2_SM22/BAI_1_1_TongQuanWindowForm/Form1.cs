using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_1_TongQuanWindowForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Khi muốn chạy form lên load các thành phần thì đưa các phương thức vào đây
            LoadNamSinh();
            LoadGridPhim();
        }

        void LoadGridPhim()
        {
            Phim p = new Phim();
            //Cách 1:
            //dgrid_Phim.DataSource = p.GetLstPhims();

            //Cách 2: Datatable
            DataTable dt = new DataTable();
            //Tạo cột
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Thể loại", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            int stt = 1;
            //Fill data
            foreach (var x in p.GetLstPhims())
            {
                dt.Rows.Add(stt++,x.Ten,x.TheLoaiPhim,(x.TrangThai==1?"Hoạt động":"Hủy"));
            }

            //dgrid_Phim.DataSource = dt;//Đổ Datatable vào grid

            //Cách 3: Làm việc trực tiếp với Datagridview
            //Định nghĩa ra các cột
            dgrid_Phim.ColumnCount = 4;//Định nghĩa số lượng cột
            dgrid_Phim.Columns[0].Name = "STT";
            dgrid_Phim.Columns[1].Name = "Tên";
            dgrid_Phim.Columns[2].Name = "Loại";
            dgrid_Phim.Columns[3].Name = "Status";
            stt = 1;
            //Fill data
            foreach (var x in p.GetLstPhims())
            {
                dgrid_Phim.Rows.Add(stt++, x.Ten, x.TheLoaiPhim, (x.TrangThai == 1 ? "Hoạt động" : "Hủy"));
            }
        }

        private void LoadNamSinh()
        {
            for (int i = 1600; i < 2023; i++)
            {
                cmb_NamSinh.Items.Add(i);
                
            }
            //cmb_NamSinh.SelectedIndex = 0;//Set giá trị mặc định khi form chạy là 1600
            cmb_NamSinh.SelectedIndex = cmb_NamSinh.FindStringExact("2001");
        }

        private void btn_ClickVaoDay_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_HienThi.Text = "MouseDown....";
        }

        private void btn_ClickVaoDay_MouseUp(object sender, MouseEventArgs e)
        {
            lbl_HienThi.Text = "MouseUp";
        }

        private void btn_ClickVaoDay_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Chào bạn {txt_Input.Text} đến với C#3");
        }
    }
}
