using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectCaNhan_TranLamHueQuyen
{
    public partial class frm_KhachHang : Form
    {
        public frm_KhachHang()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public void LoadKhoa()
        {

            string sqlSV = "Select * from KHACHHANG";
            dt_KhachHang.DataSource = lopchung.LoadDL(sqlSV);
        }
        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông Báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert into KHACHHANG values ('" + txt_MaKH.Text + "',N'" + txt_Ten.Text + "',N'" + txt_SDT.Text + "',N'" + txt_DiaChi.Text + "')";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Thêm khách hàng thành công");
            else MessageBox.Show("Thêm khách hàng thất bại");
            LoadKhoa();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
            txt_MaKH.Text = " ";
            txt_Ten.Text = " ";
            txt_DiaChi.Text = " ";
            txt_SDT.Text = " ";
            LoadKhoa();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string sql = "Update KHACHHANG set Ten = N'" + txt_Ten.Text + "', DiaChi = '" + txt_DiaChi.Text + "', SDT = '" + txt_SDT.Text + "'where MaKH = '" + txt_MaKH.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Cập nhật khách hàng thành công");
            else MessageBox.Show("Cập nhật khách hàng thất bại");
            LoadKhoa();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete KHACHHANG where MaKH = '" + txt_MaKH.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Xoá khách hàng thành công");
            else MessageBox.Show("Xoá khách hàng thất bại");
            LoadKhoa();
        }

        private void dt_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaKH.Text = dt_KhachHang.CurrentRow.Cells[0].Value.ToString();
            txt_Ten.Text = dt_KhachHang.CurrentRow.Cells["Ten"].Value.ToString();
            txt_DiaChi.Text = dt_KhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txt_SDT.Text = dt_KhachHang.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKhoa();
        }
        private void btn_TimKiem_Click_1(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "MaKH", "*" + txt_TimKiem.Text + "*");
            (dt_KhachHang.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    
    }
}
