using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using QuanLyVeXemPhim.Services;
using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormDatVe : Form
	 {
		  private readonly VeService _veService;
		  private readonly AppDbContext _db;
		  private int? _selectedGheId;

		  public FormDatVe()
		  {
				InitializeComponent();
				_veService = new VeService();
				_db = new AppDbContext();
				LoadSuatChieu();
		  }

		  private void LoadSuatChieu()
		  {
				cmbSuatChieu.DataSource = _db.SuatChieus
					 .Join(_db.Phims, s => s.MaPhim, p => p.MaPhim, (s, p) => new { s.MaSuat, Display = $"{p.TenPhim} - {s.GioChieu}" })
					 .ToList();
				cmbSuatChieu.DisplayMember = "Display";
				cmbSuatChieu.ValueMember = "MaSuat";
		  }

		  private void btnChonGhe_Click(object sender, EventArgs e)
		  {
				var formGhe = new FormGheNgoi();
				if (formGhe.ShowDialog() == DialogResult.OK)
				{
					 _selectedGheId = formGhe.Tag as int?;
				}
		  }

		  private void btnDatVe_Click(object sender, EventArgs e)
		  {
				try
				{
					 if (cmbSuatChieu.SelectedValue != null && _selectedGheId.HasValue)
					 {
						  var suat = _db.SuatChieus.Find((int)cmbSuatChieu.SelectedValue);
						  _veService.DatVe((int)cmbSuatChieu.SelectedValue, _selectedGheId.Value, txtTenKhach.Text, suat.GiaVe);
						  MessageBox.Show("Đặt vé thành công!");
						  var ve = _db.Ves.OrderByDescending(v => v.MaVe).FirstOrDefault();
						  if (ve != null)
						  {
								new FormThanhToan(ve.MaVe).ShowDialog();
						  }
					 }
					 else
					 {
						  MessageBox.Show("Vui lòng chọn suất chiếu và ghế!");
					 }
				}
				catch (Exception ex)
				{
					 MessageBox.Show($"Lỗi: {ex.Message}");
				}
		  }
	 }
}