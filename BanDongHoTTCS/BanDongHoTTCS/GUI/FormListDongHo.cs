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
    public partial class FormListDongHo : Form
    {
        public static List<DongHoKH> listDongHo;
        public static int trangThai; // 0 là của giỏ hàng, 1 là của trang chủ
        //Loai loaiDongHo = new Loai("", "Loại đồng hồ");
        public FormListDongHo()
        {
            InitializeComponent();
            //LoadCbLoai();
            loadCom();
            LoadData();
            LoadUI();
        }

        public void LoadData()
        {
            listDongHo = DongHoDAO.Instance.GetListDongHo_KH();
        }

        public void loadCom()
        {
            // Combobox loại đồng hồ
            cmbLoai.DataSource = DongHoDAO.Instance.GetListLoai();
            cmbLoai.DisplayMember = "TenLoai";
            cmbLoai.ValueMember = "MaLoai";
            // Combobox hãng đồng hồ
            cmbHang.DataSource = DongHoDAO.Instance.GetListHang();
            cmbHang.DisplayMember = "TenHang";
            cmbHang.ValueMember = "MaHang";
            // Combobox nhà cung cấp
            cmbNhaCc.DataSource = DongHoDAO.Instance.GetLisNhaCungCap();
            cmbNhaCc.DisplayMember = "TenNhaCungCap";
            cmbNhaCc.ValueMember = "MaNhaCungCap";
        }
        public void LoadUI()
        {
            if (listDongHo != null)
            {
                flowLayoutPanelMain.Controls.Clear();
                foreach (DongHoKH dh in listDongHo)
                {
                    flowLayoutPanelMain.Controls.Add(new ItemDongHo(dh));
                }
            }

        }

        public void LoadCbLoai()
        {
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            trangThai = 1;
            if (ItemDongHo.listDatHang.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để đặt hàng", "", MessageBoxButtons.OK);
            }
            else
            {
                FormDatHang form = new FormDatHang();
                form.ShowDialog();
                if (form.IsAdded)
                {
                    LoadData();
                    LoadUI();
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadUI();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string loai = (string)cmbLoai.SelectedValue;
            string hang = (string)cmbHang.SelectedValue;
            string nhaCungCap = (string)cmbNhaCc.SelectedValue;
            listDongHo = DongHoDAO.Instance.Search_DongHo(loai, nhaCungCap, hang);
            if (listDongHo.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào phù hợp", "", MessageBoxButtons.OK);
            }
            else
            {
                LoadUI();
            }
        }
    }
}
