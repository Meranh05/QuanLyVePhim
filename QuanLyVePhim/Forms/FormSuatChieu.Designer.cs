using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using QuanLyVeXemPhim.Services;
using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormSuatChieu : Form
	 {
		  private readonly SuatChieuService _suatChieuService;
		  private readonly AppDbContext _db;

		  public FormSuatChieu()
		  {
				InitializeComponent();
				_suatChieuService = new SuatChieuService();
				_db = new AppDbContext();
				LoadData();
				LoadComboBoxes();
		  }

		  private void LoadData()
		  {
				dgvSuatChieu.DataSource = _suatChieuService.GetAllSuatChieus();
		  }

		  private void LoadComboBoxes()
		  {
				cmbPhim.DataSource = _db.Phims.ToList();
				cmbPhim.DisplayMember = "TenPhim";
				cmbPhim.ValueMember = "MaPhim";

				cmbPhong.DataSource = _db.PhongChieus.ToList();
				cmbPhong.DisplayMember = "TenPhong";
				cmbPhong.ValueMember = "MaPhong";
		  }

		  private void btnThem_Click(object sender, EventArgs e)
		  {
				try
				{
					 var suat = new SuatChieu
					 {
						  MaPhim = (int)cmbPhim.SelectedValue,
						  MaPhong = (int)cmbPhong.SelectedValue,
						  GioChieu = dtpGioChieu.Value,
						  GiaVe = numGiaVe.Value
					 };
					 _suatChieuService.AddSuatChieu(suat);
					 LoadData();
					 MessageBox.Show("Thêm suất chiếu thành công!");
				}
				catch (Exception ex)
				{
					 MessageBox.Show($"Lỗi: {ex.Message}");
				}
		  }

		  private void btnSua_Click(object sender, EventArgs e)
		  {
				if (dgvSuatChieu.SelectedRows.Count > 0)
				{
					 var suat = (SuatChieu)dgvSuatChieu.SelectedRows[0].DataBoundItem;
					 suat.MaPhim = (int)cmbPhim.SelectedValue;
					 suat.MaPhong = (int)cmbPhong.SelectedValue;
					 suat.GioChieu = dtpGioChieu.Value;
					 suat.GiaVe = numGiaVe.Value;
					 _suatChieuService.UpdateSuatChieu(suat);
					 LoadData();
					 MessageBox.Show("Sửa suất chiếu thành công!");
				}
		  }

		  private void btnXoa_Click(object sender, EventArgs e)
		  {
				if (dgvSuatChieu.SelectedRows.Count > 0)
				{
					 var maSuat = ((SuatChieu)dgvSuatChieu.SelectedRows[0].DataBoundItem).MaSuat;
					 _suatChieuService.DeleteSuatChieu(maSuat);
					 LoadData();
					 MessageBox.Show("Xóa suất chiếu thành công!");
				}
		  }

		  private void dgvSuatChieu_SelectionChanged(object sender, EventArgs e)
		  {
				if (dgvSuatChieu.SelectedRows.Count > 0)
				{
					 var suat = (SuatChieu)dgvSuatChieu.SelectedRows[0].DataBoundItem;
					 cmbPhim.SelectedValue = suat.MaPhim;
					 cmbPhong.SelectedValue = suat.MaPhong;
					 dtpGioChieu.Value = suat.GioChieu;
					 numGiaVe.Value = suat.GiaVe;
				}
		  }
	 }
}