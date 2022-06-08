using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDongHoTTCS.DTO
{
    public class DongHoKH
    {
        private string maDongHo;
        private string tenDongHo;
        private decimal gia;
        private int soLuongTon;
        private string moTa;
        private string trangThai;
        private string hinhAnh;
        private string loai;
        private string hang;
        private string nhaCungCap;
        private int soLuong = 0;

        public DongHoKH(string maDongHo, string tenDongHo, decimal gia, string moTa, string trangThai, string hinhAnh, string loai, string hang)
        {
            this.maDongHo = maDongHo;
            this.tenDongHo = tenDongHo;
            this.gia = gia;
            this.moTa = moTa;
            this.trangThai = trangThai;
            this.hinhAnh = hinhAnh;
            this.loai = loai;
            this.hang = hang;
        }

        public DongHoKH(string maDongHo, string tenDongHo, decimal gia, int soLuongTon, string moTa, string trangThai, string hinhAnh, string loai, string hang, string nhaCungCap)
        {
            this.maDongHo = maDongHo;
            this.tenDongHo = tenDongHo;
            this.gia = gia;
            this.soLuongTon = soLuongTon;
            this.moTa = moTa;
            this.trangThai = trangThai;
            this.hinhAnh = hinhAnh;
            this.loai = loai;
            this.hang = hang;
            this.nhaCungCap = nhaCungCap;
        }

        public string MaDongHo { get => maDongHo; set => maDongHo = value; }
        public string TenDongHo { get => tenDongHo; set => tenDongHo = value; }
        public decimal Gia { get => gia; set => gia = value; }
        public int SoLuongTon { get => soLuongTon; set => soLuongTon = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string Loai { get => loai; set => loai = value; }
        public string Hang { get => hang; set => hang = value; }
        public string NhaCungCap { get => nhaCungCap; set => nhaCungCap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
