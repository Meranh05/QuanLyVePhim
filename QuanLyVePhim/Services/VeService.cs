
using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System;

namespace QuanLyVeXemPhim.Services
{
	 public class VeService
	 {
		  private readonly AppDbContext _db;

		  public VeService()
		  {
				_db = new AppDbContext();
		  }

		  public void DatVe(int maSuat, int maGhe, string tenKhach, decimal tongTien)
		  {
				var ve = new Ve
				{
					 MaSuat = maSuat,
					 MaGhe = maGhe,
					 TenKhach = tenKhach,
					 NgayDat = DateTime.Now,
					 TongTien = tongTien
				};
				var ghe = _db.Ghes.Find(maGhe);
				if (ghe != null && !ghe.TrangThai)
				{
					 ghe.TrangThai = true;
					 _db.Ves.Add(ve);
					 _db.SaveChanges();
				}
				else
				{
					 throw new Exception("Ghế đã được đặt hoặc không tồn tại!");
				}
		  }
	 }
}