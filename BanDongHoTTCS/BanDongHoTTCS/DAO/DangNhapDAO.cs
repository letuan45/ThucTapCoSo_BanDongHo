using BanDongHoTTCS.DTO;
using DangTinThueTro.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanDongHoTTCS.DAO
{
    public class DangNhapDAO
    {
        public const string NHOM_NHANVIEN = "nhanvien";
        public const string NHOM_KHACHHANG = "khachhang";   
        public const string NHOM_QUANTRI = "quantri";

        private static DangNhapDAO instance;
        private int id;
        private string nhom;
        private string hoTen;
        private string taiKhoan;
        private string sdt;
        private string diaChi;
        public static DangNhapDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DangNhapDAO();
                return instance;
            }
        }

        public bool DangNhap(string taiKhoan, string matKhau)
        {
            string query = "EXEC SP_DANGNHAP @TAIKHOAN , @MATKHAU";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query, new object[] { taiKhoan, matKhau });
                if(dt != null)
                {
                    this.id = (int)dt.Rows[0]["ID"];
                    this.nhom = (string)dt.Rows[0]["Nhom"];
                    this.hoTen = (string)dt.Rows[0]["HoTen"];
                    this.taiKhoan = (string)dt.Rows[0]["TaiKhoan"];
                    this.sdt = (string)dt.Rows[0]["SDT"];
                    this.diaChi = (string)dt.Rows[0]["DiaChi"];
                    if (nhom.Equals(NHOM_NHANVIEN) || nhom.Equals(NHOM_QUANTRI))
                    {
                        DataProvider.Instance.SetConnectionStrNhanVien();
                    }
                    else if (nhom.Equals(NHOM_KHACHHANG))
                    {
                        DataProvider.Instance.SetConnectionStrKhachHang();
                    }
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool DangKyKhachHang(KhachHang khachHang, string matKhau)
        {
            string query = "EXEC SP_DANGKY_KHACHHANG @TAIKHOAN , @MATKHAU , @CMND , @HO , @TEN , @GIOITINH , @NGAYSINH , @DIACHI , @SDT , @EMAIL , @MASOTHUE";
            try
            {
                if(khachHang.Email != null && khachHang.MaSoThue != null)
                {
                    DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                    {
                        khachHang.TaiKhoan,
                        matKhau,
                        khachHang.Cmnd,
                        khachHang.Ho,
                        khachHang.Ten,
                        khachHang.GioiTinh,
                        khachHang.NgaySinh,
                        khachHang.DiaChi,
                        khachHang.Sdt,
                        khachHang.Email,
                        khachHang.MaSoThue
                    });
                }
                else if(khachHang.Email == null && khachHang.MaSoThue == null)
                {
                    DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                    {
                        khachHang.TaiKhoan,
                        matKhau,
                        khachHang.Cmnd,
                        khachHang.Ho,
                        khachHang.Ten,
                        khachHang.GioiTinh,
                        khachHang.NgaySinh,
                        khachHang.DiaChi,
                        khachHang.Sdt,
                        DBNull.Value,
                        DBNull.Value
                    });
                }
                else if(khachHang.Email != null)
                {
                    DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                    {
                        khachHang.TaiKhoan,
                        matKhau,
                        khachHang.Cmnd,
                        khachHang.Ho,
                        khachHang.Ten,
                        khachHang.GioiTinh,
                        khachHang.NgaySinh,
                        khachHang.DiaChi,
                        khachHang.Sdt,
                        khachHang.Email,
                        DBNull.Value
                    });
                }
                else
                {
                    DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                    {
                        khachHang.TaiKhoan,
                        matKhau,
                        khachHang.Cmnd,
                        khachHang.Ho,
                        khachHang.Ten,
                        khachHang.GioiTinh,
                        khachHang.NgaySinh,
                        khachHang.DiaChi,
                        khachHang.Sdt,
                        DBNull.Value,
                        khachHang.MaSoThue
                    });
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi đăng ký khách hàng. " + e.Message);
                return false;
            }
        }
        public bool DoiMatKhau(string matKhauCu, string matKhauMoi)
        {
            string query = "EXEC SP_DOI_MATKHAU @TAIKHOAN , @MATKHAUCU , @MATKHAUMOI";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[] { taiKhoan, matKhauCu, matKhauMoi });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public int Id { get => id; set => id = value; }
        public string Nhom { get => nhom; set => nhom = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
    }
}
