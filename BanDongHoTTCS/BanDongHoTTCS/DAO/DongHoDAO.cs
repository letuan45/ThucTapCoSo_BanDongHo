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
    public class DongHoDAO
    {
        private static DongHoDAO instance;
        public static DongHoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DongHoDAO();
                return instance;
            }
        }
        public List<DongHo> GetListDongHo()
        {
            string query = "EXEC SP_GET_DONGHO";
            string maDongHo;
            string tenDongHo;
            decimal gia;
            int soLuongTon;
            string moTa;
            string trangThai;
            string hinhAnh;
            string loai;
            string hang;
            string nhaCungCap;
            try
            {
                List<DongHo> list = new List<DongHo>();
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                foreach(DataRow dr in dt.Rows)
                {
                    maDongHo = (string)dr["MaDongHo"];
                    tenDongHo = (string)dr["TenDongHo"];
                    gia = (decimal)dr["Gia"];
                    soLuongTon = (int)dr["SoLuongTon"];
                    moTa = (string)dr["MoTa"];
                    trangThai = (string)dr["TrangThai"];
                    hinhAnh = (string)dr["HinhAnh"];
                    loai = (string)dr["Loai"];
                    hang = (string)dr["Hang"];
                    nhaCungCap = (string)dr["NhaCungCap"];
                    list.Add(new DongHo(maDongHo, tenDongHo, gia, soLuongTon, moTa, trangThai, hinhAnh, loai, hang, nhaCungCap));
                }
                return list;
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách đồng hồ. " + e.Message);
                return null;
            }
        }
        public List<DongHoKH> GetListDongHo_KH()
        {
            string query = "EXEC SP_GET_DONGHO_KH";
            string maDongHo;
            string tenDongHo;
            decimal gia;
            int soLuongTon;
            string moTa;
            string trangThai;
            string hinhAnh;
            string loai;
            string hang;
            string nhaCungCap;
            try
            {
                List<DongHoKH> list = new List<DongHoKH>();
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                foreach (DataRow dr in dt.Rows)
                {
                    maDongHo = (string)dr["MaDongHo"];
                    tenDongHo = (string)dr["TenDongHo"];
                    gia = (decimal)dr["Gia"];
                    soLuongTon = (int)dr["SoLuongTon"];
                    moTa = (string)dr["MoTa"];
                    trangThai = (string)dr["TrangThai"];
                    hinhAnh = (string)dr["HinhAnh"];
                    loai = (string)dr["Loai"];
                    hang = (string)dr["Hang"];
                    nhaCungCap = (string)dr["NhaCungCap"];
                    list.Add(new DongHoKH(maDongHo, tenDongHo, gia, soLuongTon, moTa, trangThai, hinhAnh, loai, hang, nhaCungCap));
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách đồng hồ. " + e.Message);
                return null;
            }
        }
        public DataTable GetListDongHoNCC(string maDonDatHang)
        {
            string query = "SELECT * FROM FN_GET_DONGHO_NCC( @MADONDATHANG )";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query, new object[] {maDonDatHang });
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách đồng hồ. " + e.Message);
                return null;
            }
        }
        public DataTable GetListDongHoTrongDonDat(string maDonDatHang)
        {
            string query = "SELECT * FROM FN_GET_DONGHO_TRONG_DONDAT( @MADONDATHANG )";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query, new object[] { maDonDatHang });
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách đồng hồ. " + e.Message);
                return null;
            }
        }
        public bool ThemDongHo(DongHo dongHo)
        {
            string query = "EXEC SP_THEM_DONGHO @MADONGHO , @TENDONGHO , @GIA , @SOLUONGTON , @MOTA , @HINHANH , @MATRANGTHAI , @MALOAI , @MAHANG , @MANHACUNGCAP";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                {
                    dongHo.MaDongHo,
                    dongHo.TenDongHo,
                    dongHo.Gia,
                    dongHo.SoLuongTon,
                    dongHo.MoTa,
                    dongHo.HinhAnh,
                    dongHo.TrangThai,
                    dongHo.Loai,
                    dongHo.Hang,
                    dongHo.NhaCungCap
                });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thêm đồng hồ. " + e.Message);
                return false;
            }
        }
        public bool SuaDongHo(DongHo dongHo)
        {
            string query = "EXEC SP_CAPNHAT_DONGHO @MADONGHO , @TENDONGHO , @GIA , @MOTA , @HINHANH , @MATRANGTHAI , @MALOAI , @MAHANG";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]
                {
                    dongHo.MaDongHo,
                    dongHo.TenDongHo,
                    dongHo.Gia,
                    dongHo.MoTa,
                    dongHo.HinhAnh,
                    dongHo.TrangThai,
                    dongHo.Loai,
                    dongHo.Hang,
                });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi sửa thông tin đồng hồ. " + e.Message);
                return false;
            }
        }
        public bool XoaDongHo(string maDongHo)
        {
            string query = "EXEC SP_XOA_DONGHO @MADONGHO";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[] { maDongHo });
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi xóa đồng hồ. " + e.Message);
                return false;
            }
        }
        public List<DongHoKH> Search_DongHo(string loaiDh, string nhaCungCapDh, string hangDh)
        {
            string query = "EXEC SP_TIM_KIEM_DH @MaLoai , @MaNhaCungCap , @MaHang";
            string maDongHo;
            string tenDongHo;
            decimal gia;
            int soLuongTon;
            string moTa;
            string trangThai;
            string hinhAnh;
            string loai;
            string hang;
            string nhaCungCap;
            try
            {
                List<DongHoKH> list = new List<DongHoKH>();
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query, new object[] { loaiDh, nhaCungCapDh, hangDh });
                foreach (DataRow dr in dt.Rows)
                {
                    maDongHo = (string)dr["MaDongHo"];
                    tenDongHo = (string)dr["TenDongHo"];
                    gia = (decimal)dr["Gia"];
                    soLuongTon = (int)dr["SoLuongTon"];
                    moTa = (string)dr["MoTa"];
                    trangThai = (string)dr["TrangThai"];
                    hinhAnh = (string)dr["HinhAnh"];
                    loai = (string)dr["Loai"];
                    hang = (string)dr["Hang"];
                    nhaCungCap = (string)dr["NhaCungCap"];
                    list.Add(new DongHoKH(maDongHo, tenDongHo, gia, soLuongTon, moTa, trangThai, hinhAnh, loai, hang, nhaCungCap));
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy danh sách đồng hồ. " + e.Message);
                return null;
            }
        }
        public DataTable GetListTrangThai()
        {
            string query = "SELECT * FROM TrangThai";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetListLoai()
        {
            string query = "SELECT * FROM LoaiDongHo";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetListHang()
        {
            string query = "SELECT * FROM HangDongHo";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetLisNhaCungCap()
        {
            string query = "SELECT * FROM NhaCungCap";
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        internal bool NgungKinhDoanhSP(string maDongHo)
        {
            string query = "EXEC SP_NGUNGKINHDOANH_DONGHO @MADONGHO";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[] { maDongHo });
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi ngừng kinh doanh sản phẩm này. " + e.Message);
                return false;
            }
        }
    }
}
