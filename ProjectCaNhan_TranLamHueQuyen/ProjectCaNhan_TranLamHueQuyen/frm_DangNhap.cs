using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaNhan_TranLamHueQuyen
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        int dem = 0;
        

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông Báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string sql = "Select COUNT (*) from DangNhap where TaiKhoan = '" + txt_TenDangNhap.Text + "' and Matkhau = '" + txt_MatKhau.Text + "'";
            int kq = (int)lopchung.Scalar(sql);
            if (kq >= 1)
            {
                frm_Main main = new frm_Main();
                main.Show();
                MessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dem++;
                MessageBox.Show("Đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (dem == 3)
                {
                    MessageBox.Show("Nhập Sai Quá 3 Lần!", "Cảnh Cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
    }
}
