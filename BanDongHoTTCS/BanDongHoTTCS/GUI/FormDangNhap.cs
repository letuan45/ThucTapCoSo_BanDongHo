using BanDongHoTTCS.DAO;
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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        private bool InputHopLe()
        {
            if (txtTaiKhoan.Text.Equals(""))
            {
                MessageBox.Show("Tài khoản không được trống");
                return false;
            }
            if (txtMatKhau.Text.Equals(""))
            {
                MessageBox.Show("Mật khẩu không được trống");
                return false;
            }
            return true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (InputHopLe())
            {
                if (DangNhapDAO.Instance.DangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công. " + DangNhapDAO.Instance.Nhom);
                    this.Hide();
                    if (DangNhapDAO.Instance.Nhom.Equals(DangNhapDAO.NHOM_NHANVIEN) ||
                        DangNhapDAO.Instance.Nhom.Equals(DangNhapDAO.NHOM_QUANTRI))
                    {
                        new FormMainNV(this).ShowDialog();
                    }
                    else if (DangNhapDAO.Instance.Nhom.Equals(DangNhapDAO.NHOM_KHACHHANG))
                    {
                        new FormMainKH(this).ShowDialog();
                    } 
                }
            }
        }

        private void labelDangKy_Click(object sender, EventArgs e)
        {
            FormDangKy form = new FormDangKy();
            form.ShowDialog();
            if (form.IsAdded)
            {
                txtTaiKhoan.Text = form.TaiKhoan;
                txtMatKhau.Text = form.MatKhau;
            }
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
