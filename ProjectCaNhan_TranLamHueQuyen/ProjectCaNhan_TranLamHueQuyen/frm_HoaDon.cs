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
using System.Configuration;
using System.Runtime.InteropServices;

namespace ProjectCaNhan_TranLamHueQuyen
{
    public partial class frm_HoaDon : Form
    {
        public frm_HoaDon()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        public void LoadKhoa()
        {

            string sqlSV = "Select * from CTHoaDon";
            dt_HoaDon.DataSource = lopchung.LoadDL(sqlSV);
        }
        public void LoadCBKHACHHANG()
        {
            string sql = "Select * from KHACHHANG";
            cb_MaKH.DataSource = lopchung.LoadDL(sql);
            cb_MaKH.ValueMember = "MaKH";
            cb_MaKH.DisplayMember = "MaKH";
        }
        public void LoadCBTHUCUNG()
        {
            string sql = "Select * from THUCUNG";
            cb_MaTC.DataSource = lopchung.LoadDL(sql);
            cb_MaTC.ValueMember = "MaTC";
            cb_MaKH.DisplayMember = "MaTC";
        }
        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            LoadCBKHACHHANG();
            LoadCBTHUCUNG();
        }

        private void cb_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select Ten from KHACHHANG where MaKH = N'" + cb_MaKH.SelectedValue + "'";
            txt_Ten.Text = lopchung.GetFieldValues(str);
            str = "Select DiaChi from KHACHHANG where MaKH = N'" + cb_MaKH.SelectedValue + "'";
            txt_DiaChi.Text = lopchung.GetFieldValues(str);
            str = "Select SDT from KHACHHANG where MaKH= N'" + cb_MaKH.SelectedValue + "'";
            txt_SDT.Text = lopchung.GetFieldValues(str);
        }

        private void cb_MaTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select Ten from THUCUNG where MaTC = N'" + cb_MaTC.SelectedValue + "'";
            txt_TenTC.Text = lopchung.GetFieldValues(str);
            str = "Select Loai from THUCUNG where MaTC = N'" + cb_MaTC.SelectedValue + "'";
            txt_Loai.Text = lopchung.GetFieldValues(str);
            str = "Select SoLuong from THUCUNG where MaTC= N'" + cb_MaTC.SelectedValue + "'";
            txt_SoLuong.Text = lopchung.GetFieldValues(str);
            str = "Select DonGia from THUCUNG where MaTC= N'" + cb_MaTC.SelectedValue + "'";
            txt_DonGia.Text = lopchung.GetFieldValues(str);
            
        }
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert into CTHoaDon values ('" + txt_MaHD.Text + "',N'" + cb_MaTC.Text + "',N'" + txt_SoLuong.Text + "',N'" + txt_DonGia.Text + "',N'" + cb_MaKH.Text + "',N'" + txt_Ten.Text + "',N'" + txt_DiaChi.Text + "',N'" + txt_SDT.Text + "',N'" + date_NgayXuat.Text + "',N'" + txt_Loai.Text + "',N'" + txt_TenTC.Text + "')";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Thêm khách hàng thành công");
            else MessageBox.Show("Thêm khách hàng thất bại");
            LoadKhoa();
        }

        private void dt_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaHD.Text = dt_HoaDon.CurrentRow.Cells[0].Value.ToString();
            cb_MaTC.Text = dt_HoaDon.CurrentRow.Cells["MaTC"].Value.ToString();
            txt_TenTC.Text = dt_HoaDon.CurrentRow.Cells["TenTC"].Value.ToString();
            txt_SoLuong.Text = dt_HoaDon.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_DonGia.Text = dt_HoaDon.CurrentRow.Cells["DonGia"].Value.ToString();
            txt_Loai.Text = dt_HoaDon.CurrentRow.Cells["Loai"].Value.ToString();
            cb_MaKH.Text = dt_HoaDon.CurrentRow.Cells["MaKH"].Value.ToString();
            txt_Ten.Text = dt_HoaDon.CurrentRow.Cells["Ten"].Value.ToString();
            txt_DiaChi.Text = dt_HoaDon.CurrentRow.Cells["DiaChi"].Value.ToString();
            txt_SDT.Text = dt_HoaDon.CurrentRow.Cells["SDT"].Value.ToString();
            date_NgayXuat.Text = dt_HoaDon.CurrentRow.Cells["NgayXuat"].Value.ToString();

        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaHD.Text = "";
            cb_MaKH.Text = " ";
            txt_Ten.Text = " ";
            txt_DiaChi.Text = " ";
            txt_SDT.Text = " ";
            cb_MaTC.Text = " ";
            txt_TenTC.Text = " ";
            txt_SoLuong.Text = " ";
            txt_Loai.Text = " ";
            txt_DonGia.Text = " ";
            LoadKhoa();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string sql = "Update CTHoaDon set MaTC = N'" + cb_MaTC.Text + "', SoLuong = N'" + txt_SoLuong.Text + "', DonGia = '" + txt_DonGia.Text + "', MaKH = '" + cb_MaKH.Text + "', Ten = '" + txt_Ten.Text + "', DiaChi = '" + txt_DiaChi.Text + "', SDT = '" + txt_SDT.Text + "', NgayXuat = '" + date_NgayXuat.Text + "', Loai = '" + txt_Loai.Text + "', TenTC = '" + txt_TenTC.Text + "'where MaHD = '" + txt_MaHD.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Cập nhật hoá đơn thành công");
            else MessageBox.Show("Cập nhật hoá đơn thất bại");
            LoadKhoa();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete CTHoaDon where MaHD = '" + txt_MaHD.Text + "'";
            int kq = lopchung.ThemXoaSua(sql);
            if (kq >= 1)
                MessageBox.Show("Xoá khách hàng thành công");
            else MessageBox.Show("Xoá khách hàng thất bại");
            LoadKhoa();
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
    }
}
