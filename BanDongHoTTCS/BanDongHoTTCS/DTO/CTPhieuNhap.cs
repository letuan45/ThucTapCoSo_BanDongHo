using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDongHoTTCS.DTO
{
    public class CTPhieuNhap
    {
        private string maPhieuNhap;
        private string maDongHo;
        private decimal donGia;
        private int soLuong;

        public CTPhieuNhap(string maPhieuNhap, string maDongHo, decimal donGia, int soLuong)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.maDongHo = maDongHo;
            this.donGia = donGia;
            this.soLuong = soLuong;
        }

        public string MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }
        public string MaDongHo { get => maDongHo; set => maDongHo = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
