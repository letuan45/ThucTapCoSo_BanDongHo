using BanDongHoTTCS.DAO;
using BanDongHoTTCS.DTO;
using BanDongHoTTCS.GUI.CustomComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanDongHoTTCS.GUI
{
    public partial class FormDatHang : Form
    {
        private bool isAdded = false;
        public bool IsAdded { get => isAdded; }
        private PhieuDatKh phieuDat;
        private CtDatHangKh chiTiet;
        public FormDatHang()
        {
            InitializeComponent();
            FillInputKh();
            LoadUI();

        }

        public void LoadUI()
        {
            if (ItemDongHo.listDatHang != null)
            {
                flowLayoutPanel2.Controls.Clear();
                foreach (DongHoKH dh in ItemDongHo.listDatHang)
                {
                    flowLayoutPanel2.Controls.Add(new ItemDatHang(dh));
                }
            }

        }

        private void FillInputKh()
        {
            txtHoTenKh.Text = DangNhapDAO.Instance.HoTen;
            txtSdtKh.Text = DangNhapDAO.Instance.Sdt;
            txtDiaChiKh.Text = DangNhapDAO.Instance.DiaChi;
        }

        private bool InputHopLe()
        {
            if (txtTenNN.Text.Equals(""))
            {
                MessageBox.Show("Họ tên người nhận không được trống");
                return false;
            }
            if (txtSdtNN.Text.Equals(""))
            {
                MessageBox.Show("Số điện thoại người nhận không được trống");
                return false;
            }
            if (txtDiaChiNN.Text.Equals(""))
            {
                MessageBox.Show("Địa chỉ người nhận không được trống");
                return false;
            }
            return true;
        }

        public void ThemCtPhieuDat()
        {
            foreach (DongHoKH dh in ItemDongHo.listDatHang)
            {
                chiTiet = new CtDatHangKh(phieuDat.MaPhieuDat, dh.MaDongHo, dh.SoLuong, dh.SoLuong * dh.Gia);
                if (PhieuDatKhDAO.Instance.ThemCTPhieuDat(chiTiet))
                {
                }
            }
            if(PanelListDongHo.trangThai == 0)
            {
                foreach(DongHoKH dh in ItemDongHo.listDatHang)
                {
                    ItemDongHo.listGioHang.Remove(dh);
                }
            }

            ItemDongHo.listDatHang.Clear();

        }

        public void ThemPhieuDat()
        {
            if (cbNguoiNhan.Checked)
            {
                if (InputHopLe())
                {
                    phieuDat = new PhieuDatKh(DateTime.Now, txtTenNN.Text, txtDiaChiNN.Text, txtSdtNN.Text, DangNhapDAO.Instance.Id);
                    phieuDat.MaPhieuDat = PhieuDatKhDAO.Instance.ThemPhieuDatHang(phieuDat);
                    if (phieuDat.MaPhieuDat != -1)
                    {
                        ThemCtPhieuDat();
                        MessageBox.Show("Tạo phiếu đặt hàng thành công " + phieuDat.MaPhieuDat);
                        isAdded = true;
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tạo phiếu đặt hàng thất bại");
                    }
                }
            }
            else
            {
                phieuDat = new PhieuDatKh(DateTime.Now, txtHoTenKh.Text, txtDiaChiKh.Text, txtSdtKh.Text, DangNhapDAO.Instance.Id);
                phieuDat.MaPhieuDat = PhieuDatKhDAO.Instance.ThemPhieuDatHang(phieuDat);
                if (phieuDat.MaPhieuDat != -1)
                {
                    ThemCtPhieuDat();
                    MessageBox.Show("Tạo phiếu đặt hàng thành công " + phieuDat.MaPhieuDat);
                    isAdded = true;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tạo phiếu đặt hàng thất bại");
                }
            }
        }



        private void cbNguoiNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNguoiNhan.Checked == true)
            {
                pnNguoiNhan.Size = pnNguoiNhan.MaximumSize;
            }
            else
            {
                pnNguoiNhan.Size = pnNguoiNhan.MinimumSize;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ThemPhieuDat();
            
        }
    }
}
