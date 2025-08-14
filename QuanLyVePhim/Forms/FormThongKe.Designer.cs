using QuanLyVeXemPhim.Services;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyVeXemPhim.Forms
{
	 public partial class FormThongKe : Form
	 {
		  private readonly ThongKeService _thongKeService;

		  public FormThongKe()
		  {
				InitializeComponent();
				_thongKeService = new ThongKeService();
		  }

		  private void btnThongKe_Click(object sender, EventArgs e)
		  {
				chartDoanhThu.Series.Clear();
				var series = new Series("DoanhThu");
				series.ChartType = SeriesChartType.Column;

				var doanhThuNgay = _thongKeService.TinhDoanhThuTheoNgay(dtpNgay.Value);
				series.Points.AddXY("Ngày " + dtpNgay.Value.ToShortDateString(), doanhThuNgay);

				var doanhThuTuan = _thongKeService.TinhDoanhThuTheoTuan(dtpTuan.Value);
				series.Points.AddXY("Tuần từ " + dtpTuan.Value.ToShortDateString(), doanhThuTuan);

				var doanhThuThang = _thongKeService.TinhDoanhThuTheoThang(dtpThang.Value.Year, dtpThang.Value.Month);
				series.Points.AddXY($"Tháng {dtpThang.Value.Month}/{dtpThang.Value.Year}", doanhThuThang);

				chartDoanhThu.Series.Add(series);
		  }
	 }
}