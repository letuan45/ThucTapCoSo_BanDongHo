using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDongHoTTCS.DTO
{
    public class CtDatHangKh
    {
        private int maCtPhieuDat;
        private int maPhieuDat;
        private string maDongHo;
        private int soLuong;
        private decimal donGia;

        public CtDatHangKh(int maCtPhieuDat, int maPhieuDat, string maDongHo, int soLuong, decimal donGia)
        {
            this.maCtPhieuDat = maCtPhieuDat;
            this.maPhieuDat = maPhieuDat;
            this.maDongHo = maDongHo;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }

        public CtDatHangKh(int maPhieuDat, string maDongHo, int soLuong, decimal donGia)
        {
            this.maPhieuDat = maPhieuDat;
            this.maDongHo = maDongHo;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }

        public int MaCtPhieuDat { get => maCtPhieuDat; set => maCtPhieuDat = value; }
        public int MaPhieuDat { get => maPhieuDat; set => maPhieuDat = value; }
        public string MaDongHo { get => maDongHo; set => maDongHo = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
    }
}
