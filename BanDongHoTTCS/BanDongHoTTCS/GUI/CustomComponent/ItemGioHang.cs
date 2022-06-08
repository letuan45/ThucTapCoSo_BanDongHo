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
    public partial class ItemGioHang : UserControl
    {
        DongHoKH dongHo;
        //public static List<DongHo> listDatHang = new List<DongHo>();
        public ItemGioHang(DongHoKH dongHo)
        {
            InitializeComponent();
            this.dongHo = dongHo;
            LoadUI();
        }

        public void LoadUI()
        {
            // Các label thông tin
            lbTen.Text = dongHo.TenDongHo;
            lbGia.Text = "Giá: " + MyFormat.FormatMoney(dongHo.Gia) + " VNĐ";
            numSl.Value =  dongHo.SoLuong;
            lbLoai.Text = "Loại: " + dongHo.Loai;
            lbHang.Text = "Hãng: " + dongHo.Hang;
            lbNhaCc.Text = "Nhà cung cấp: " + dongHo.NhaCungCap;
            lbTrangThai.Text = "Trạng thái: " + dongHo.TrangThai;
            lbMoTa.Text = "Mô tả: " + dongHo.MoTa;
            try
            {
                picDongHo.Image = Image.FromFile(MyFormat.GetFilePath(dongHo.HinhAnh));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Có lỗi khi load hình. " + ex.Message);
            }
        }

        private void numSl_ValueChanged(object sender, EventArgs e)
        {
            int sl = Convert.ToInt32(numSl.Value);
            foreach (DongHoKH dh in PanelListDongHo.listDongHo)
            {
                if (dh.MaDongHo.Equals(dongHo.MaDongHo))
                {
                    dongHo.SoLuongTon = dh.SoLuongTon;
                }
            }
            if (sl > dongHo.SoLuongTon)
            {
                numSl.Value--;
                //numSl.Enabled = false;
                //MessageBox.Show("Không còn đủ hàng", "", MessageBoxButtons.OK);
            }
        }

        private void cbDatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDatHang.Checked) // nếu được check thì thêm vào list
            {
              /* foreach(DongHo dh in PanelListDongHo.listDongHo)
                {
                    if (dh.MaDongHo.Equals(dongHo.MaDongHo))
                    {
                        dongHo.SoLuongTon = dh.SoLuongTon;
                    }
                }*/


                    dongHo.SoLuong = Convert.ToInt32(numSl.Value);
                    numSl.Enabled = false;
                
                
                if (dongHo.SoLuong == 0)
                {
                    MessageBox.Show("Chọn số lượng sản phẩm " + dongHo.TenDongHo + " > 0", "", MessageBoxButtons.OK);
                    cbDatHang.Checked = false;
                }
                else
                {
                    ItemDongHo.listDatHang.Add(dongHo);
                }
            }
            else
            {
                numSl.Enabled = true;
                ItemDongHo.listDatHang.Remove(dongHo);
            }
        }
    }
}
