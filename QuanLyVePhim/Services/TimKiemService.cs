
using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyVeXemPhim.Services
{
	 public class TimKiemService
	 {
		  private readonly AppDbContext _db;

		  public TimKiemService()
		  {
				_db = new AppDbContext();
		  }

		  public List<Phim> TimKiemPhim(string keyword)
		  {
				return _db.Phims.Where(p => p.TenPhim.Contains(keyword) || (p.TheLoai != null && p.TheLoai.Contains(keyword))).ToList();
		  }

		  public List<SuatChieu> TimKiemSuatChieu(string keyword)
		  {
				return _db.SuatChieus
					 .Join(_db.Phims, s => s.MaPhim, p => p.MaPhim, (s, p) => new { SuatChieu = s, Phim = p })
					 .Where(sp => sp.Phim.TenPhim.Contains(keyword))
					 .Select(sp => sp.SuatChieu)
					 .ToList();
		  }

		  public List<Ve> TimKiemVe(string tenKhach)
		  {
				return _db.Ves.Where(v => v.TenKhach != null && v.TenKhach.Contains(tenKhach)).ToList();
		  }
	 }
}