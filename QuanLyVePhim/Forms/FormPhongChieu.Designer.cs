using QuanLyVeXemPhim.Models;
using QuanLyVeXemPhim.Services;
using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormPhongChieu : Form
	 {
		  private readonly PhongChieuService _phongChieuService;

		  public FormPhongChieu()
		  {
				InitializeComponent();
				_phongChieuService = new PhongChieuService();
				LoadData();
				cmbLoaiPhong.Items.AddRange(new[] { "2D", "3D", "IMAX" });
		  }

		  private void LoadData()
		  {
				dgvPhongChieu.DataSource = _phongChieuService.GetAllPhongChieus();
		  }

		  private void btnThem_Click(object sender, EventArgs e)
		  {
				try
				{
					 var phong = new PhongChieu
					 {
						  TenPhong = txtTenPhong.Text,
						  LoaiPhong = cmbLoaiPhong.SelectedItem?.ToString(),
						  SoGhe = (int)numSoGhe.Value
					 };
					 _phongChieuService.AddPhongChieu(phong, (int)numSoGhe.Value);
					 LoadData();
					 MessageBox.Show("Thêm phòng chiếu thành công!");
				}
				catch (Exception ex)
				{
					 MessageBox.Show($"Lỗi: {ex.Message}");
				}
		  }

		  private void btnSua_Click(object sender, EventArgs e)
		  {
				if (dgvPhongChieu.SelectedRows.Count > 0)
				{
					 var phong = (PhongChieu)dgvPhongChieu.SelectedRows[0].DataBoundItem;
					 phong.TenPhong = txtTenPhong.Text;
					 phong.LoaiPhong = cmbLoaiPhong.SelectedItem?.ToString();
					 phong.SoGhe = (int)numSoGhe.Value;
					 _phongChieuService.UpdatePhongChieu(phong);
					 LoadData();
					 MessageBox.Show("Sửa phòng chiếu thành công!");
				}
		  }

		  private void btnXoa_Click(object sender, EventArgs e)
		  {
				if (dgvPhongChieu.SelectedRows.Count > 0)
				{
					 var maPhong = ((PhongChieu)dgvPhongChieu.SelectedRows[0].DataBoundItem).MaPhong;
					 _phongChieuService.DeletePhongChieu(maPhong);
					 LoadData();
					 MessageBox.Show("Xóa phòng chiếu thành công!");
				}
		  }

		  private void dgvPhongChieu_SelectionChanged(object sender, EventArgs e)
		  {
				if (dgvPhongChieu.SelectedRows.Count > 0)
				{
					 var phong = (PhongChieu)dgvPhongChieu.SelectedRows[0].DataBoundItem;
					 txtTenPhong.Text = phong.TenPhong;
					 cmbLoaiPhong.SelectedItem = phong.LoaiPhong;
					 numSoGhe.Value = phong.SoGhe;
				}
		  }
	 }
}