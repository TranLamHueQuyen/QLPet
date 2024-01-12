using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaNhan_TranLamHueQuyen
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void btn_TrangChu_MouseHover(object sender, EventArgs e)
        {
            btn_TrangChu.BackColor = Color.RosyBrown;
        }
        private void btn_TrangChu_MouseLeave(object sender, EventArgs e)
        {
            btn_TrangChu.BackColor = Color.DimGray;
        }
        private void btn_ThuCung_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_ThuCung"] == null)
            {
                frm_ThuCung khoa = new frm_ThuCung();
                khoa.MdiParent = this;
                khoa.Show();
            }
            else
                Application.OpenForms["frm_ThuCung"].Activate();
        }

        private void btn_ThuCung_MouseHover(object sender, EventArgs e)
        {
            btn_ThuCung.BackColor = Color.RosyBrown;
        }
        private void btn_ThuCung_MouseLeave(object sender, EventArgs e)
        {
            btn_ThuCung.BackColor = Color.DimGray;
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_KhachHang"] == null)
            {
                frm_KhachHang khoa = new frm_KhachHang();
                khoa.MdiParent = this;
                khoa.Show();
            }
            else
                Application.OpenForms["frm_KhachHang"].Activate();
        }

        private void btn_KhachHang_MouseHover(object sender, EventArgs e)
        {
            btn_KhachHang.BackColor = Color.RosyBrown;
        }

        private void btn_KhachHang_MouseLeave(object sender, EventArgs e)
        {
            btn_KhachHang.BackColor = Color.DimGray;
        }

        private void btn_DangXuat_MouseHover(object sender, EventArgs e)
        {
            btn_DangXuat.BackColor = Color.RosyBrown;
        }

        private void btn_DangXuat_MouseLeave(object sender, EventArgs e)
        {
            btn_DangXuat.BackColor = Color.DimGray;
        }

        private void btn_ThanhToan_MouseHover(object sender, EventArgs e)
        {
            btn_HoaDon.BackColor = Color.RosyBrown;
        }

        private void btn_ThanhToan_MouseLeave(object sender, EventArgs e)
        {
            btn_HoaDon.BackColor = Color.DimGray;
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_HoaDon"] == null)
            {
                frm_HoaDon khoa = new frm_HoaDon();
                khoa.MdiParent = this;
                khoa.Show();
            }
            else
                Application.OpenForms["frm_HoaDon"].Activate();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn Đăng Xuất hay không?", "Thông Báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
