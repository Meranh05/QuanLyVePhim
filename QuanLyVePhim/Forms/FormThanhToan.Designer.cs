using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Utilities;
using QuanLyVeXemPhim.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormThanhToan : Form
	 {
		  private readonly AppDbContext _db;
		  private readonly PrintUtility _printUtility;
		  private int _maVe;

		  public FormThanhToan(int maVe)
		  {
				InitializeComponent();
				_db = new AppDbContext();
				_printUtility = new PrintUtility();
				_maVe = maVe;
				LoadVe();
		  }

		  private void LoadVe()
		  {
				var ve = _db.Ves
					 .Join(_db.SuatChieus, v => v.MaSuat, s => s.MaSuat, (v, s) => new { v, s })
					 .Join(_db.Phims, vs => vs.s.MaPhim, p => p.MaPhim, (vs, p) => new { vs.v, vs.s, p })
					 .Join(_db.Ghes, vsp => vsp.v.MaGhe, g => g.MaGhe, (vsp, g) => new { vsp.v, vsp.s, vsp.p, g })
					 .Where(vspg => vspg.v.MaVe == _maVe)
					 .Select(vspg => new { vspg.v.TongTien, vspg.p.TenPhim, vspg.s.GioChieu, vspg.g.SoGhe })
					 .FirstOrDefault();
				if (ve != null)
				{
					 lblTongTien.Text = ve.TongTien.ToString("C");
				}
		  }

		  private void btnThanhToan_Click(object sender, EventArgs e)
		  {
				var ve = _db.Ves.Find(_maVe);
				if (ve != null)
				{
					 ve.TongTien = chkGiamGia.Checked ? ve.TongTien * 0.9m : ve.TongTien;
					 _db.SaveChanges();
					 lblTongTien.Text = ve.TongTien.ToString("C");
					 MessageBox.Show("Thanh toán thành công!");
				}
		  }

		  private void btnInVe_Click(object sender, EventArgs e)
		  {
				var ve = _db.Ves
					 .Join(_db.SuatChieus, v => v.MaSuat, s => s.MaSuat, (v, s) => new { v, s })
					 .Join(_db.Phims, vs => vs.s.MaPhim, p => p.MaPhim, (vs, p) => new { vs.v, vs.s, p })
					 .Join(_db.Ghes, vsp => vsp.v.MaGhe, g => g.MaGhe, (vsp, g) => new { vsp.v, vsp.s, vsp.p, g })
					 .Where(vspg => vspg.v.MaVe == _maVe)
					 .Select(vspg => new { vspg.v.MaVe, vspg.p.TenPhim, vspg.s.GioChieu, vspg.g.SoGhe })
					 .FirstOrDefault();
				if (ve != null)
				{
					 _printUtility.PrintVe(ve.MaVe.ToString(), ve.TenPhim, ve.GioChieu.ToString(), ve.SoGhe);
				}
		  }
	 }
}