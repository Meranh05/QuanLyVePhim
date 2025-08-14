using QuanLyVeXemPhim.Models;
using QuanLyVeXemPhim.Services;
using QuanLyVeXemPhim.Models;
using QuanLyVeXemPhim.Services;
using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormPhim : Form
	 {
		  private readonly PhimService _phimService;

		  public FormPhim()
		  {
				InitializeComponent();
				_phimService = new PhimService();
				LoadData();
		  }

		  private void LoadData()
		  {
				dgvPhim.DataSource = _phimService.GetAllPhims();
		  }

		  private void btnThem_Click(object sender, EventArgs e)
		  {
				try
				{
					 var phim = new Phim
					 {
						  TenPhim = txtTen.Text,
						  TheLoai = txtTheLoai.Text,
						  ThoiLuong = (int)numThoiLuong.Value,
						  KhoiChieu = dtpKhoiChieu.Value,
						  MoTa = txtMoTa.Text
					 };
					 _phimService.AddPhim(phim);
					 LoadData();
					 MessageBox.Show("Thêm phim thành công!");
				}
				catch (Exception ex)
				{
					 MessageBox.Show($"Lỗi: {ex.Message}");
				}
		  }

		  private void btnSua_Click(object sender, EventArgs e)
		  {
				if (dgvPhim.SelectedRows.Count > 0)
				{
					 var phim = (Phim)dgvPhim.SelectedRows[0].DataBoundItem;
					 phim.TenPhim = txtTen.Text;
					 phim.TheLoai = txtTheLoai.Text;
					 phim.ThoiLuong = (int)numThoiLuong.Value;
					 phim.KhoiChieu = dtpKhoiChieu.Value;
					 phim.MoTa = txtMoTa.Text;
					 _phimService.UpdatePhim(phim);
					 LoadData();
					 MessageBox.Show("Sửa phim thành công!");
				}
		  }

		  private void btnXoa_Click(object sender, EventArgs e)
		  {
				if (dgvPhim.SelectedRows.Count > 0)
				{
					 var maPhim = ((Phim)dgvPhim.SelectedRows[0].DataBoundItem).MaPhim;
					 _phimService.DeletePhim(maPhim);
					 LoadData();
					 MessageBox.Show("Xóa phim thành công!");
				}
		  }

		  private void dgvPhim_SelectionChanged(object sender, EventArgs e)
		  {
				if (dgvPhim.SelectedRows.Count > 0)
				{
					 var phim = (Phim)dgvPhim.SelectedRows[0].DataBoundItem;
					 txtTen.Text = phim.TenPhim;
					 txtTheLoai.Text = phim.TheLoai ?? string.Empty;
					 numThoiLuong.Value = phim.ThoiLuong;
					 dtpKhoiChieu.Value = phim.KhoiChieu;
					 txtMoTa.Text = phim.MoTa ?? string.Empty;
				}
		  }
	 }
}