using QuanLyVeXemPhim.Services;
using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormTimKiem : Form
	 {
		  private readonly TimKiemService _timKiemService;

		  public FormTimKiem()
		  {
				InitializeComponent();
				_timKiemService = new TimKiemService();
				cmbLoaiTimKiem.Items.AddRange(new[] { "Phim", "Suất Chiếu", "Khách Hàng" });
		  }

		  private void btnTimKiem_Click(object sender, EventArgs e)
		  {
				try
				{
					 string keyword = txtKeyword.Text;
					 string? loai = cmbLoaiTimKiem.SelectedItem?.ToString();
					 if (loai == "Phim")
						  dgvKetQua.DataSource = _timKiemService.TimKiemPhim(keyword);
					 else if (loai == "Suất Chiếu")
						  dgvKetQua.DataSource = _timKiemService.TimKiemSuatChieu(keyword);
					 else if (loai == "Khách Hàng")
						  dgvKetQua.DataSource = _timKiemService.TimKiemVe(keyword);
				}
				catch (Exception ex)
				{
					 MessageBox.Show($"Lỗi: {ex.Message}");
				}
		  }
	 }
}