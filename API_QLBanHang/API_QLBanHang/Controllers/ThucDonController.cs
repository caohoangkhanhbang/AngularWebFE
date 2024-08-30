using API_QLBanHang.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

//Thư viện tải ảnh
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace API_QLBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThucDonController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ThucDonController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        [Route("get-all/khanhBang")]
        public JsonResult Get()
        {
            String query = "Select * from sanpham";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBanHang");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = command.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult(dataTable);
        }

        [HttpPost]
        public JsonResult Post(SanPham sp)
        {
            String query = @"insert into SanPham values(N'"+sp.TenSanPham+"',N'"+sp.GiaBan
                +"',N'"+sp.AnhSanPham+"',N'"+sp.NgaySanXuat+"',N'"+sp.HangSuDung+"',N'"
                +sp.SoLuong+"',N'"+sp.XuatXu+"',N'"+sp.MoTa+"',N'"+sp.TrangThai+"',"+sp.MaLoai
                +","+sp.MaKhuyenMai+","+sp.MaNhaCungCap+")";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBanHang");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = command.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult("Thêm thành công!");
        }

        [HttpPut]
        public JsonResult Put(SanPham sp, String id)
        {
            String query = @"update SanPham set TenSanPham = N'"+sp.TenSanPham+"' where MaSanPham = "+id;
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBanHang");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = command.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult("Cập nhật thành công!");
        }

        [HttpDelete]
        public JsonResult Delete(String id)
        {
            String query = @"delete SanPham where MaSanPham = "+ id;
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBanHang");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = command.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult("Xóa thành công!");
        }

        [HttpPost]
        [Route("SaveFile")]
        public JsonResult SaveFile()
        {
            try
            {
                var httpReques = Request.Form;
                var postedFile = httpReques.Files[0];
                String fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(fileName);
            }
            catch (Exception ex)
            {
                return new JsonResult("bang.png");
            }
        }

        [HttpGet]
        [Route("danh-muc")]
        public JsonResult GetAllDanhMuc()
        {
            String query = "Select * from DanhMuc";
            DataTable dataTable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("QLBanHang");
            SqlDataReader sqlDataReader;
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlDataReader = command.ExecuteReader();
                    dataTable.Load(sqlDataReader);
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult(dataTable);
        }
    }
}
