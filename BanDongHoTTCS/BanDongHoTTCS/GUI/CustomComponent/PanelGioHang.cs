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

namespace BanDongHoTTCS.GUI.CustomComponent
{
    public partial class PanelGioHang : UserControl
    {
        public PanelGioHang()
        {
            InitializeComponent();
        }

        public void LoadUI(List<DongHoKH> listDongHo)
        {
            if (listDongHo != null)
            {
                flowLayoutPanelMain.Controls.Clear();
                foreach (DongHoKH dh in listDongHo)
                {
                    flowLayoutPanelMain.Controls.Add(new ItemGioHang(dh));
                }
            }

        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            PanelListDongHo.trangThai = 0;
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
                    LoadUI(ItemDongHo.listGioHang);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(ItemDongHo.listDatHang.Count > 0)
            {
                foreach (DongHoKH dh in ItemDongHo.listDatHang)
                {
                    ItemDongHo.listGioHang.Remove(dh);
                }
                ItemDongHo.listDatHang.Clear();
                MessageBox.Show("Xóa khỏi giỏ hàng thành công");
                LoadUI(ItemDongHo.listGioHang);
            } else
            {
                MessageBox.Show("Chọn sản phẩm để xóa");
            }
            
        }
    }
}
