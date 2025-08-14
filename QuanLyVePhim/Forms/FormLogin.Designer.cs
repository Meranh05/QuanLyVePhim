using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using QuanLyVeXemPhim.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormLogin : Form
	 {
		  private readonly AppDbContext _db;

		  public FormLogin()
		  {
				InitializeComponent();
				_db = new AppDbContext();
		  }

		  private void btnLogin_Click(object sender, EventArgs e)
		  {
				var nhanVien = _db.NhanViens
					 .FirstOrDefault(n => n.Username == txtUsername.Text && n.Password == txtPassword.Text);
				if (nhanVien != null)
				{
					 MessageBox.Show("Đăng nhập thành công!");
					 new FormMain().Show();
					 this.Hide();
				}
				else
				{
					 MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
				}
		  }
	 }
}