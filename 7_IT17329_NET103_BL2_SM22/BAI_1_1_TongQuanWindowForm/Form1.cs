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
            LoadNamSinh();
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
