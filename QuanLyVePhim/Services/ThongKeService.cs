
using QuanLyVeXemPhim.Data;
using System;
using System.Linq;

namespace QuanLyVeXemPhim.Services
{
	 public class ThongKeService
	 {
		  private readonly AppDbContext _db;

		  public ThongKeService()
		  {
				_db = new AppDbContext();
		  }

		  public decimal TinhDoanhThuTheoNgay(DateTime ngay)
		  {
				return _db.Ves.Where(v => v.NgayDat.Date == ngay.Date).Sum(v => v.TongTien);
		  }

		  public decimal TinhDoanhThuTheoTuan(DateTime startDate)
		  {
				var endDate = startDate.AddDays(7);
				return _db.Ves.Where(v => v.NgayDat.Date >= startDate.Date && v.NgayDat.Date < endDate.Date).Sum(v => v.TongTien);
		  }

		  public decimal TinhDoanhThuTheoThang(int year, int month)
		  {
				return _db.Ves.Where(v => v.NgayDat.Year == year && v.NgayDat.Month == month).Sum(v => v.TongTien);
		  }
	 }
}