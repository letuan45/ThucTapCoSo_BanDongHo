using BanDongHoTTCS.DAO;
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
    public partial class FormMainKH : Form
    {
        private FormDangNhap formDangNhap;
        private bool isDangXuat = false;

        private PanelListDongHo panelListDongHo;
        private PanelGioHang panelGioHang;

        private FormListDongHo formListDongHo;
        private FormGioHang formGioHang;
        private FormQLTaiKhoan formQLTaiKhoan;

        private int btnThucThi = -1;
        private const int BTN_HOME = 0;
        private const int BTN_GIOHANG = 1;

        public bool IsDangXuat { get => isDangXuat; set => isDangXuat = value; }

        public FormMainKH(FormDangNhap formDangNhap)
        {
            InitializeComponent();
            this.formDangNhap = formDangNhap;
            Init();
        }

        private void Init()
        {
            panelListDongHo = new PanelListDongHo();
            panelGioHang = new PanelGioHang();

            formListDongHo = new FormListDongHo();
            formGioHang = new FormGioHang();
            formQLTaiKhoan = new FormQLTaiKhoan(this);
            btnQLTaiKhoan.Text = "        " + DangNhapDAO.Instance.HoTen;
        }

        private void LoadUI(UserControl panel)
        {
            if (!panelContainer.Contains(panel))
            {
                panelContainer.Controls.Clear();
                panelContainer.Controls.Add(panel);
            }
        }
        private void MoFormCon(Form formCon)
        {
            if (!panelContainer.Controls.Contains(formCon))
            {
                formCon.TopLevel = false;
                panelContainer.Controls.Clear();
                panelContainer.Controls.Add(formCon);
                formCon.Show();
            }
        }
        private void EnableButton()
        {
            Color enableColor = Color.FromArgb(3, 169, 244);
            switch (btnThucThi)
            {
                case BTN_HOME:
                    btnQLDongHo.Enabled = true;
                    btnQLDongHo.BackColor = enableColor;
                    break;
                case BTN_GIOHANG:
                    btnQLDonDatHang.Enabled = true;
                    btnQLDonDatHang.BackColor = enableColor;
                    break;
            }
        }
        private void DisableButton()
        {
            Color disableColor = Color.FromArgb(1, 87, 155);
            switch (btnThucThi)
            {
                case BTN_HOME:
                    btnQLDongHo.BackColor = disableColor;
                    break;
                case BTN_GIOHANG:
                    btnQLDonDatHang.BackColor = disableColor;
                    break;
            }
        }
        private void btnQLDongHo_Click(object sender, EventArgs e)
        {
            EnableButton();
            btnThucThi = BTN_HOME;
            DisableButton();
            panelListDongHo.LoadData();
            panelListDongHo.LoadUI();
            ItemDongHo.listDatHang.Clear();
            LoadUI(panelListDongHo);
            //MoFormCon(formListDongHo);
        }

        private void btnQLDonDatHang_Click(object sender, EventArgs e)
        {
            EnableButton();
            btnThucThi = BTN_GIOHANG;
            DisableButton();
            panelGioHang.LoadUI(ItemDongHo.listGioHang);
            ItemDongHo.listDatHang.Clear();
            LoadUI(panelGioHang);
            //MoFormCon(formGioHang);
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            MoFormCon(formQLTaiKhoan);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (isDangXuat)
            {
                formDangNhap.Visible = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
