using BanDongHoTTCS.DAO;
using BanDongHoTTCS.DTO;
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
    public partial class FormThemCTDonDatHang : Form
    {
        private bool isAdded = false;
        private CTDonDatHang chiTiet;

        public bool IsAdded { get => isAdded;}
        public CTDonDatHang ChiTiet { get => chiTiet;}

        public FormThemCTDonDatHang(DonDatHang donDatHang)
        {
            InitializeComponent();
            LoadUI(donDatHang);
        }
        private void LoadUI(DonDatHang donDatHang)
        {
            txtMaDonDatHang.Text = donDatHang.MaDonDatHang;
            txtNhaCungCap.Text = donDatHang.NhaCungCap;
            DataTable dt = DongHoDAO.Instance.GetListDongHoNCC(donDatHang.MaDonDatHang);
            comboBoxDongHo.DataSource = dt;
            comboBoxDongHo.DisplayMember = "TenDongHo";
            comboBoxDongHo.ValueMember = "MaDongHo";
        }
        private bool InputHopLe()
        {
            if(comboBoxDongHo.SelectedValue == null)
            {
                MessageBox.Show("Đồng hồ không được trống");
                return false;
            }
            if (txtDonGia.Text.Equals(""))
            {
                MessageBox.Show("Đơn giá không được trống");
                return false;
            }
            return true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (InputHopLe())
            {
                string maDonDatHang = txtMaDonDatHang.Text;
                string maDongHo = comboBoxDongHo.SelectedValue.ToString();
                int soLuong = (int)numericUpDownSoLuong.Value;
                decimal donGia = Convert.ToDecimal(txtDonGia.Text);
                chiTiet = new CTDonDatHang(maDonDatHang, maDongHo, soLuong, donGia);
                if (DonDatHangDAO.Instance.ThemCTDonDatHang(chiTiet))
                {
                    MessageBox.Show("Thêm chi tiết đơn đặt hàng thành công");
                    isAdded = true;
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm chi tiết đơn đặt hàng thất bại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
