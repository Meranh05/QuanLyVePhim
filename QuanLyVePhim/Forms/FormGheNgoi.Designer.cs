using QuanLyVeXemPhim.Data;
using QuanLyVeXemPhim.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormGheNgoi : Form
	 {
		  private readonly AppDbContext _db;
		  private int? _selectedGheId;

		  public FormGheNgoi()
		  {
				InitializeComponent();
				_db = new AppDbContext();
				LoadPhongChieu();
		  }

		  private void LoadPhongChieu()
		  {
				cmbPhong.DataSource = _db.PhongChieus.ToList();
				cmbPhong.DisplayMember = "TenPhong";
				cmbPhong.ValueMember = "MaPhong";
		  }

		  private void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
		  {
				if (cmbPhong.SelectedValue != null)
				{
					 int maPhong = (int)cmbPhong.SelectedValue;
					 LoadGhe(maPhong);
				}
		  }

		  private void LoadGhe(int maPhong)
		  {
				panelGhe.Controls.Clear();
				var ghes = _db.Ghes.Where(g => g.MaPhong == maPhong).ToList();
				int x = 10, y = 10;
				foreach (var ghe in ghes)
				{
					 Button btn = new Button
					 {
						  Text = ghe.SoGhe,
						  BackColor = ghe.TrangThai ? Color.Red : Color.Green,
						  Location = new Point(x, y),
						  Size = new Size(50, 50),
						  Tag = ghe.MaGhe
					 };
					 btn.Click += (s, e) =>
					 {
						  if (!ghe.TrangThai)
						  {
								_selectedGheId = ghe.MaGhe;
								foreach (Button b in panelGhe.Controls)
									 b.BackColor = _db.Ghes.Find(int.Parse(b.Tag.ToString())).TrangThai ? Color.Red : Color.Green;
								btn.BackColor = Color.Yellow;
						  }
					 };
					 panelGhe.Controls.Add(btn);
					 x += 60;
					 if (x > 300) { x = 10; y += 60; }
				}
		  }

		  private void btnChon_Click(object sender, EventArgs e)
		  {
				if (_selectedGheId.HasValue)
				{
					 this.Tag = _selectedGheId; // Truyền MaGhe ra ngoài
					 this.DialogResult = DialogResult.OK;
					 this.Close();
				}
				else
				{
					 MessageBox.Show("Vui lòng chọn một ghế!");
				}
		  }
	 }
}