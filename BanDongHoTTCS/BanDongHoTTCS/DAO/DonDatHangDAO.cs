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
    public class DonDatHangDAO
    {
        private static DonDatHangDAO instance;
        public static DonDatHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonDatHangDAO();
                return instance;
            }
        }
        public List<DonDatHang> GetListDonDatHang()
        {
            string query = "EXEC SP_GET_DONDATHANG";
            string maDonDatHang;
            DateTime ngayDatHang;
            int maNhanVien;
            string nhaCungCap;
            int daNhapHang;
            try
            {
                List<DonDatHang> list = new List<DonDatHang>();
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                foreach (DataRow dr in dt.Rows)
                {
                    maDonDatHang = (string)dr["MaDonDatHang"];
                    ngayDatHang = (DateTime)dr["NgayDatHang"];
                    maNhanVien = (int)dr["MaNhanVien"];
                    nhaCungCap = (string)dr["NhaCungCap"];
                    daNhapHang = (int)dr["DaNhapHang"];
                    list.Add(new DonDatHang(maDonDatHang, ngayDatHang, maNhanVien, nhaCungCap, daNhapHang));
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách đơn đặt hàng. " + e.Message);
                return null;
            }
        }
        public List<CTDonDatHang> GetListCTDonDatHang(string maDonDatHang)
        {
            string query = "EXEC SP_GET_CT_DONDATHANG @MADONDATHANG";
            string maDongHo;
            int soLuong;
            decimal donGia;
            try
            {
                List<CTDonDatHang> list = new List<CTDonDatHang>();
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query, new object[] { maDonDatHang });
                foreach (DataRow dr in dt.Rows)
                {
                    maDongHo = (string)dr["MaDongHo"];
                    soLuong = (int)dr["SoLuong"];
                    donGia = (decimal)dr["DonGia"];
                    list.Add(new CTDonDatHang(maDonDatHang, maDongHo, soLuong, donGia));
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách chi tiết đơn đặt hàng. " + e.Message);
                return null;
            }
        }
        public CTDonDatHang GetCTDonDatHang(string maDonDatHang, string maDongHo)
        {
            string query = "EXEC SP_GET_1_CT_DONDATHANG @MADONDATHANG , @MADONGHO";
            int soLuong;
            decimal donGia;
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query,
                    new object[] { maDonDatHang, maDongHo });
                soLuong = (int)dt.Rows[0]["SoLuong"];
                donGia = (decimal)dt.Rows[0]["DonGia"];
                return new CTDonDatHang(maDonDatHang, maDongHo, soLuong, donGia);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy chi tiết đơn đặt hàng. " + e.Message);
                return null;
            }
        }
        public bool ThemDonDatHang(DonDatHang donDatHang)
        {
            string query = "EXEC SP_THEM_DONDATHANG @MADONDATHANG , @MANHANVIEN , @MANHACUNGCAP";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                {
                    donDatHang.MaDonDatHang,
                    donDatHang.MaNhanVien,
                    donDatHang.NhaCungCap
                });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi tạo đơn đặt hàng. " + e.Message);
                return false;
            }
        }
        public bool XoaDonDatHang(string maDonDatHang)
        {
            string query = "EXEC SP_XOA_DONDATHANG @MADONDATHANG";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[] { maDonDatHang });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi xóa đơn đặt hàng. " + e.Message);
                return false;
            }
        }
        public bool ThemCTDonDatHang(CTDonDatHang chiTiet)
        {
            string query = "EXEC SP_THEM_CT_DONDATHANG @MADONDATHANG , @MADONGHO , @SOLUONG , @DONGIA";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                {
                    chiTiet.MaDonDatHang,
                    chiTiet.MaDongHo,
                    chiTiet.SoLuong,
                    chiTiet.DonGia
                });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thêm chi tiết đơn đặt hàng. " + e.Message);
                return false;
            }
        }
        public bool SuaCTDonDatHang(CTDonDatHang chiTiet)
        {
            string query = "EXEC SP_SUA_CT_DONDATHANG @MADONDATHANG , @MADONGHO , @SOLUONG , @DONGIA";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                {
                    chiTiet.MaDonDatHang,
                    chiTiet.MaDongHo,
                    chiTiet.SoLuong,
                    chiTiet.DonGia
                });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi sửa chi tiết đơn đặt hàng. " + e.Message);
                return false;
            }
        }
        public bool XoaCTDonDatHang(CTDonDatHang chiTiet)
        {
            string query = "EXEC SP_XOA_CT_DONDATHANG @MADONDATHANG , @MADONGHO";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                {
                    chiTiet.MaDonDatHang,
                    chiTiet.MaDongHo
                });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi xóa chi tiết đơn đặt hàng. " + e.Message);
                return false;
            }
        }
    }
}
