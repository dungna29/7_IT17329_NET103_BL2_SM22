using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Yêu cầu import thử viện forms

namespace BAI_1_0_TaoWindowFormBangCode
{
    internal class Frm1:Form
    {
        //Khai báo các control
        private Label lblName;
        private Button btnOk;

        public Frm1()
        {
            //Phần 1: Tạo form
            this.Text = "Form C#3 Buổi 1";
            this.Size = new Size(800, 500);

            //Phần 2: Thêm control vào form
            lblName = new Label();
            lblName.Text = "Đây là label";
            lblName.Location = new Point(100, 200);
            this.Controls.Add(lblName);

            btnOk = new Button();
            btnOk.Text = "Bấm vào đây";
            btnOk.Width = 200;
            btnOk.Height = 150;
            btnOk.Location = new Point(150, 250);
            this.Controls.Add(btnOk);
        }

        public static void Main(string[] arg)
        {
            Application.Run(new Frm1());
        }
    }
}
