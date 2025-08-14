
using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyVeXemPhim.Services
{
	 public class SuatChieuService
	 {
		  private readonly AppDbContext _db;

		  public SuatChieuService()
		  {
				_db = new AppDbContext();
		  }

		  public List<SuatChieu> GetAllSuatChieus()
		  {
				return _db.SuatChieus.ToList();
		  }

		  public void AddSuatChieu(SuatChieu suatChieu)
		  {
				_db.SuatChieus.Add(suatChieu);
				_db.SaveChanges();
		  }

		  public void UpdateSuatChieu(SuatChieu suatChieu)
		  {
				var existing = _db.SuatChieus.Find(suatChieu.MaSuat);
				if (existing != null)
				{
					 existing.MaPhim = suatChieu.MaPhim;
					 existing.MaPhong = suatChieu.MaPhong;
					 existing.GioChieu = suatChieu.GioChieu;
					 existing.GiaVe = suatChieu.GiaVe;
					 _db.SaveChanges();
				}
		  }

		  public void DeleteSuatChieu(int maSuat)
		  {
				var suat = _db.SuatChieus.Find(maSuat);
				if (suat != null)
				{
					 _db.SuatChieus.Remove(suat);
					 _db.SaveChanges();
				}
		  }
	 }
}