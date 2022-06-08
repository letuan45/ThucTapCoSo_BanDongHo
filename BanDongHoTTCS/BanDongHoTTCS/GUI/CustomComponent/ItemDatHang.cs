﻿using BanDongHoTTCS.DTO;
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
    public partial class ItemDatHang : UserControl
    {
        public DongHoKH dongHo;
        public ItemDatHang(DongHoKH dongHo)
        {
            InitializeComponent();
            this.dongHo = dongHo;
            LoadUI();
        }

        public void LoadUI()
        {
            // Các label thông tin
            lbTen.Text = dongHo.TenDongHo;
            lbGia.Text = "Tổng tiền: " + MyFormat.FormatMoney(dongHo.SoLuong * dongHo.Gia) + " VNĐ";
            lbSl.Text = "x " + dongHo.SoLuong;
            // Hình tham khảo
            try
            {
                picSp.Image = Image.FromFile(MyFormat.GetFilePath(dongHo.HinhAnh));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Có lỗi khi load hình. " + ex.Message);
            }
        }
    }
}
