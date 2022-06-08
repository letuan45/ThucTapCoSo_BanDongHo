using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDongHoTTCS.DTO
{
    public class CTDonDatHang
    {
        private string maDonDatHang;
        private string maDongHo;
        private int soLuong;
        private decimal donGia;

        public CTDonDatHang(string maDonDatHang, string maDongHo, int soLuong, decimal donGia)
        {
            this.maDonDatHang = maDonDatHang;
            this.maDongHo = maDongHo;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }

        public string MaDonDatHang { get => maDonDatHang; set => maDonDatHang = value; }
        public string MaDongHo { get => maDongHo; set => maDongHo = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
    }
}
