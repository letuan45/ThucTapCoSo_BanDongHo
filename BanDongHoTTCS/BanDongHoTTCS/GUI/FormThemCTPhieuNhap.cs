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
    public partial class FormThemCTPhieuNhap : Form
    {
        private bool isAdded = false;
        private CTPhieuNhap chiTiet;

        public bool IsAdded { get => isAdded;}
        public CTPhieuNhap ChiTiet { get => chiTiet; }

        public FormThemCTPhieuNhap(string maPhieuNhap)
        {
            InitializeComponent();
            LoadUI(maPhieuNhap);
        }

        private void LoadUI(string maPhieuNhap)
        {
            txtMaPhieuNhap.Text = maPhieuNhap;
            // Load combobox đồng hồ trong đơn đặt hàng
            DataTable dt = DongHoDAO.Instance.GetListDongHoTrongDonDat(maPhieuNhap);
            comboBoxDongHo.DataSource = dt;
            comboBoxDongHo.DisplayMember = "TenDongHo";
            comboBoxDongHo.ValueMember = "MaDongHo";
        }
        private bool InputHopLe()
        {
            if(numericUpDownSoLuong.Value == 0)
            {
                MessageBox.Show("Đồng hồ này đã nhập đủ số lượng, không thể nhập thêm");
                return false;
            }
            if (txtDonGia.Text.Equals(""))
            {
                MessageBox.Show("Đơn giá không được trống");
                return false;
            }
            return true;
        }
        private void comboBoxDongHo_SelectedValueChanged(object sender, EventArgs e)
        {
            string maDongHo = comboBoxDongHo.SelectedValue.ToString();
            if (!maDongHo.Equals("System.Data.DataRowView"))
            {
                CTDonDatHang chiTiet = DonDatHangDAO.Instance.GetCTDonDatHang(txtMaPhieuNhap.Text, maDongHo);
                if(chiTiet != null)
                {
                    txtDonGia.Text = chiTiet.DonGia.ToString();
                    numericUpDownSoLuong.Maximum = chiTiet.SoLuong;
                    numericUpDownSoLuong.Value = chiTiet.SoLuong;
                    numericUpDownSoLuong.Minimum = chiTiet.SoLuong == 0 ? 0 : 1;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (InputHopLe())
            {
                string maPhieNhap = txtMaPhieuNhap.Text;
                string maDongHo = comboBoxDongHo.SelectedValue.ToString();
                decimal donGia = Decimal.Parse(txtDonGia.Text);
                int soLuong = (int)numericUpDownSoLuong.Value;
                chiTiet = new CTPhieuNhap(maPhieNhap, maDongHo, donGia, soLuong);
                if (PhieuNhapDAO.Instance.ThemCTPhieuNhap(chiTiet))
                {
                    MessageBox.Show("Thêm chi tiết phiếu nhập thành công");
                    isAdded = true;
                    this.Dispose();
                }
                else
                    MessageBox.Show("Thêm chi tiết phiếu nhập thất bại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
