using System;
using System.Windows.Forms;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormMain : Form
	 {

		  public FormMain()
		  {
				InitializeComponent();
		  }


		  private void quanLyPhimToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormPhim().ShowDialog();
		  }

		  private void quanLyPhongChieuToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormPhongChieu().ShowDialog();
		  }

		  private void quanLySuatChieuToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormSuatChieu().ShowDialog();
		  }

		  private void datVeToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormDatVe().ShowDialog();
		  }

		  private void thanhToanToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormThanhToan(0).ShowDialog(); // MaVe sẽ được truyền từ FormDatVe
		  }

		  private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormThongKe().ShowDialog();
		  }

		  private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormTimKiem().ShowDialog();
		  }

		  private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				new FormLogin().ShowDialog();
		  }

		  private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		  {
				Application.Exit();
		  }
	 }
}