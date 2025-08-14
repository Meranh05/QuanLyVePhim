
using QuanLyVeXemPhim.Services;
using System;
using System.Windows.Forms;
namespace QuanLyVeXemPhim.Models
{
	 public class NhanVien
	 {
		  public int MaNhanVien { get; set; }
		  public string? TenNhanVien { get; set; }
		  public string Username { get; set; } = string.Empty;
		  public string Password { get; set; } = string.Empty;
	 }
}