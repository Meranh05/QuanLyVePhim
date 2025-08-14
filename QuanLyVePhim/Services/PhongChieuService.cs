
using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyVeXemPhim.Services
{
	 public class PhongChieuService
	 {
		  private readonly AppDbContext _db;

		  public PhongChieuService()
		  {
				_db = new AppDbContext();
		  }

		  public List<PhongChieu> GetAllPhongChieus()
		  {
				return _db.PhongChieus.ToList();
		  }

		  public void AddPhongChieu(PhongChieu phongChieu, int soGhe)
		  {
				_db.PhongChieus.Add(phongChieu);
				_db.SaveChanges();

				for (int i = 1; i <= soGhe; i++)
				{
					 _db.Ghes.Add(new Ghe
					 {
						  MaPhong = phongChieu.MaPhong,
						  SoGhe = $"A{i}",
						  TrangThai = false
					 });
				}
				_db.SaveChanges();
		  }

		  public void UpdatePhongChieu(PhongChieu phongChieu)
		  {
				var existing = _db.PhongChieus.Find(phongChieu.MaPhong);
				if (existing != null)
				{
					 existing.TenPhong = phongChieu.TenPhong;
					 existing.LoaiPhong = phongChieu.LoaiPhong;
					 existing.SoGhe = phongChieu.SoGhe;
					 _db.SaveChanges();
				}
		  }

		  public void DeletePhongChieu(int maPhong)
		  {
				var phong = _db.PhongChieus.Find(maPhong);
				if (phong != null)
				{
					 var ghes = _db.Ghes.Where(g => g.MaPhong == maPhong);
					 _db.Ghes.RemoveRange(ghes);
					 _db.PhongChieus.Remove(phong);
					 _db.SaveChanges();
				}
		  }
	 }
}