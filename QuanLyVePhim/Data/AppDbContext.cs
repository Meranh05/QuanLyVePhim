
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuanLyVeXemPhim.Models;
using System.Configuration;

namespace QuanLyVeXemPhim.Data
{
	 public class AppDbContext:DbContext
	 {
		  public DbSet<Phim> Phims { get; set; }
		  public DbSet<PhongChieu> PhongChieus { get; set; }
		  public DbSet<Ghe> Ghes { get; set; }
		  public DbSet<SuatChieu> SuatChieus { get; set; }
		  public DbSet<Ve> Ves { get; set; }
		  public DbSet<NhanVien> NhanViens { get; set; }
		  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		  {
				var configuration = new ConfigurationBuilder()
					 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
					 .AddJsonFile("appsetting.json")
					 .Build();
				optionsBuilder.UseSqlServer(configuration.GetConnectionString
					 ("DefaultConmection"));
		  }
	 }
}


