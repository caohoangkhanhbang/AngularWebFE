namespace API_QLBanHang.Model
{
    public class SanPham
    {
        public SanPham()
        {
        }

        public SanPham(string maSanPham, string tenSanPham, string giaBan, string anhSanPham, string ngaySanXuat, string hangSuDung, string soLuong, string xuatXu, string moTa, string trangThai, string maLoai, string maKhuyenMai, string maNhaCungCap)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            GiaBan = giaBan;
            AnhSanPham = anhSanPham;
            NgaySanXuat = ngaySanXuat;
            HangSuDung = hangSuDung;
            SoLuong = soLuong;
            XuatXu = xuatXu;
            MoTa = moTa;
            TrangThai = trangThai;
            MaLoai = maLoai;
            MaKhuyenMai = maKhuyenMai;
            MaNhaCungCap = maNhaCungCap;
        }

        public String MaSanPham { get; set; }
        public String TenSanPham { get; set; }
        public String GiaBan { get; set; }
        public String AnhSanPham { get; set; }
        public String NgaySanXuat { get; set; }
        public String HangSuDung { get; set; }
        public String SoLuong { get; set; }
        public String XuatXu { get; set; }
        public String MoTa { get; set; }
        public String TrangThai { get; set; }
        public String MaLoai { get; set; }
        public String MaKhuyenMai { get; set; }
        public String MaNhaCungCap { get; set; }

    }
}
