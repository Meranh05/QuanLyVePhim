# QuanLyVeXemPhim

Ứng dụng quản lý rạp chiếu phim bằng **Windows Forms** và **.NET 8.0**, sử dụng **Entity Framework Core** để kết nối SQL Server. Hỗ trợ quản lý phim, phòng chiếu, suất chiếu, đặt vé, thanh toán, thống kê doanh thu, và tìm kiếm.

## Tính năng

- **Quản lý**: Thêm, sửa, xóa phim, phòng chiếu, suất chiếu, ghế ngồi.
- **Đặt vé**: Chọn suất chiếu, ghế, nhập thông tin khách hàng.
- **Thanh toán**: Tính tiền, áp dụng giảm giá, in vé, tạo QR Code (tùy chọn).
- **Thống kê**: Doanh thu theo ngày, tuần, tháng (biểu đồ).
- **Tìm kiếm**: Tìm phim, suất chiếu, hoặc vé theo từ khóa.
- **Tùy chọn**: Đăng nhập nhân viên, gửi email xác nhận.

## Yêu cầu

- **OS**: Windows 10/11
- **.NET**: 8.0 SDK
- **IDE**: Visual Studio 2022+
- **Database**: SQL Server (LocalDB hoặc Express)
- **NuGet Packages**:
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.Extensions.Configuration.Json`
  - `System.Windows.Forms.DataVisualization`
  - `ZXing.Net`

## Cài đặt

1. **Tạo dự án**:

   - Tạo Windows Forms App (.NET 8.0) trong Visual Studio.
   - Cài NuGet packages:
   Tools > NuGet packages Manager > Packages Manager Console
     ```bash
     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
     dotnet add package Microsoft.Extensions.Configuration.Json
     dotnet add package System.Windows.Forms.DataVisualization
     dotnet add package ZXing.Net
     ```

2. **Tạo database**:

   - Chạy script SQL trong SQL Server Management Studio (xem source).

3. **Cấu hình**:

   - Thêm `appsettings.json`:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=QuanLyVePhim;Trusted_Connection=True;"
       }
     }
     ```
   - Đặt `Copy to Output Directory` thành `Copy always`.

4. **Build & Chạy**:

   - Build: `Ctrl+Shift+B`.
   - Chạy: `F5`.

## Hướng dẫn sử dụng

1. Đăng nhập (tùy chọn): Nhập username/password.
2. Menu chính: Chọn chức năng (Quản lý Phim, Đặt Vé, v.v.).
3. Quản lý: Thêm/sửa/xóa dữ liệu qua các Form.
4. Đặt vé: Chọn suất chiếu, ghế, thanh toán.
5. Thống kê/Tìm kiếm: Xem doanh thu hoặc tìm thông tin.

## Lưu ý

- Kiểm tra connection string.
- Debug lỗi qua Output Window trong Visual Studio.

