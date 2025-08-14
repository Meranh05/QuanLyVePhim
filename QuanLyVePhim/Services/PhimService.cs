using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System.Security.Cryptography.X509Certificates;

namespace QuanLyVeXemPhim.Services
{
	 public class PhimService
	 {
		  private readonly AppDbContext _db;
		  public PhimService()
		  {
				_db = new AppDbContext();
		  }
		  public List<Phim> GetAllPhims()
		  {
				return _db.Phims.ToList();
		  }

		  public void AddPhim (Phim phim)
		  {
				_db.Phims.Add(phim);
				_db.SaveChanges();
		  }
		  public void UpdatePhim(Phim phim)
		  {
				var existing = _db.Phims.Find(phim.MaPhim);
				if(existing!=null)
				{
					 existing.TenPhim = phim.TenPhim;
					 existing.TheLoai = phim.TheLoai;
					 existing.ThoiLuong = phim.ThoiLuong;
					 existing.KhoiChieu = phim.KhoiChieu;
					 existing.MoTa = phim.MoTa;
					 _db.SaveChanges();
				}
				
		  }
		  public void DeletePhim(int maPhim)
		  {
				var phim = _db.Phims.Find(maPhim);
				if(phim != null)
				{
					 _db.Phims.Remove(phim);
					 _db.SaveChanges();
				}
		  }
	 }
}