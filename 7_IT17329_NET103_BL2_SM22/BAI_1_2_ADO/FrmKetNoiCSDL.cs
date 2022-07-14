using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_2_ADO
{
    public partial class FrmKetNoiCSDL : Form
    {
        private string _sqlConnectionStr = @"Data Source=DUNGNAPC\SQLEXPRESS;Initial Catalog=FINALASS_FPTShop_SP22_BL2_DUNGNA29;Persist Security Info=True;User ID=dungna32;Password=123456";
        private SqlConnection _conn;
        private SqlCommand _cmd;

        public FrmKetNoiCSDL()
        {
            InitializeComponent();
        }

        private void btn_KetNoi_Click(object sender, EventArgs e)
        {
            //1. Khởi tạo kết nối đến CSDl
            _conn = new SqlConnection(_sqlConnectionStr);
            //2. Mở kết nối
            _conn.Open();
            //3. Sau khi mở kết nối thì sẽ thực hiện 1 hành động nào đó.
            //4. Viết 1 lệnh sql
            _cmd = new SqlCommand("SELECT * FROM CHUCVU", _conn);
            //5. Sau khi thực thi sẽ hứng dữ liệu từ câu truy vấn
            SqlDataAdapter data = new SqlDataAdapter(_cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            //6. Sau khi thực hiện xong các hành động với CSDL phải đóng kết nối
            _conn.Close();
        }
    }
}