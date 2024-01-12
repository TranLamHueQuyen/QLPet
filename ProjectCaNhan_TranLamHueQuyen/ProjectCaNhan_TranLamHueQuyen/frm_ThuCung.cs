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
    public partial class frm_ThuCung : Form
    {
        public frm_ThuCung()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public void LoadKhoa()
        {

            string sqlSV = "Select * from THUCUNG";
            dt_ThuCung.DataSource = lopchung.LoadDL(sqlSV);
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert into THUCUNG values ('" + txt_MaTC.Text + "',N'" + txt_Ten.Text + "',N'" + txt_Loai.Text + "',N'" + txt_SoLuong.Text + "',N'" + txt_DonGia.Text + "')";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Thêm thú cưng thành công");
            else MessageBox.Show("Thêm thú cưng thất bại");
            LoadKhoa();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string sql = "Update THUCUNG set Ten = N'" + txt_Ten.Text + "', Loai = '" + txt_Loai.Text + "', SoLuong = '" + txt_SoLuong.Text + "', DonGia = '" + txt_DonGia.Text + "'where MaTC = '" + txt_MaTC.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Cập nhật thú cưng thành công");
            else MessageBox.Show("Cập nhật thú cưng thất bại");
            LoadKhoa();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete THUCUNG where MaTC = '" + txt_MaTC.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Xoá thú cưng thành công");
            else MessageBox.Show("Xoá thú cưng thất bại");
            LoadKhoa();
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông Báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        

        private void frm_ThuCung_Load(object sender, EventArgs e)
        {
            LoadKhoa();
        }

        

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
            txt_MaTC.Text = " ";
            txt_Ten.Text = " ";
            txt_Loai.Text = " ";
            txt_SoLuong.Text = " ";
            txt_DonGia.Text = " ";
            LoadKhoa();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "MaTC", "*" + txt_TimKiem.Text + "*");
            (dt_ThuCung.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void dt_ThuCung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaTC.Text = dt_ThuCung.CurrentRow.Cells[0].Value.ToString();
            txt_Ten.Text = dt_ThuCung.CurrentRow.Cells["Ten"].Value.ToString();
            txt_Loai.Text = dt_ThuCung.CurrentRow.Cells["Loai"].Value.ToString();
            txt_SoLuong.Text = dt_ThuCung.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_DonGia.Text = dt_ThuCung.CurrentRow.Cells["DonGia"].Value.ToString();
        }
    }
}
