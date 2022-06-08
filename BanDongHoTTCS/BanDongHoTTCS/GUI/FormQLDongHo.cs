using BanDongHoTTCS.DAO;
using BanDongHoTTCS.DTO;
using DangTinThueTro.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanDongHoTTCS.GUI
{
    public partial class FormQLDongHo : Form
    {
        private List<DongHo> listDongHo;
        private BindingSource bindingSource = new BindingSource();

        private const int CHUCNANG_THEM = 0;
        private const int CHUCNANG_SUA = 1;
        private int chucNangThucThi;

        private int position;
        private string hinhAnh;

        private const string TRANGTHAI_DEFAULT = "THH";
        public FormQLDongHo()
        {
            InitializeComponent();
            LoadUI();
            LoadData();
        }
        #region Giao diện
        private void LoadData()
        {
            listDongHo = DongHoDAO.Instance.GetListDongHo();
            bindingSource.DataSource = listDongHo;
            gridControlDongHo.DataSource = bindingSource;
            bindingSource.Position = 0;
        }
        private void LoadUI()
        {
            ResetTatCaComponent();
            // Combobox trạng thái
            comboBoxTrangThai.DataSource = DongHoDAO.Instance.GetListTrangThai();
            comboBoxTrangThai.DisplayMember = "TrangThai";
            comboBoxTrangThai.ValueMember = "MaTrangThai";
            // Combobox loại đồng hồ
            comboBoxLoai.DataSource = DongHoDAO.Instance.GetListLoai();
            comboBoxLoai.DisplayMember = "TenLoai";
            comboBoxLoai.ValueMember = "MaLoai";
            // Combobox hãng đồng hồ
            comboBoxHang.DataSource = DongHoDAO.Instance.GetListHang();
            comboBoxHang.DisplayMember = "TenHang";
            comboBoxHang.ValueMember = "MaHang";
            // Combobox nhà cung cấp
            comboBoxNhaCungCap.DataSource = DongHoDAO.Instance.GetLisNhaCungCap();
            comboBoxNhaCungCap.DisplayMember = "TenNhaCungCap";
            comboBoxNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        private void FillInput()
        {
            position = bindingSource.Position;
            DongHo dongHo = listDongHo[position];
            txtMaDongHo.Text = dongHo.MaDongHo;
            txtTenDongHo.Text = dongHo.TenDongHo;
            txtGia.Text = Convert.ToString(dongHo.Gia);
            txtSoLuongTon.Text = Convert.ToString(dongHo.SoLuongTon);
            txtMoTa.Text = dongHo.MoTa;
            comboBoxTrangThai.Text = dongHo.TrangThai;
            comboBoxLoai.Text = dongHo.Loai;
            comboBoxHang.Text = dongHo.Hang;
            comboBoxNhaCungCap.Text = dongHo.NhaCungCap;
            this.hinhAnh = dongHo.HinhAnh;
            try
            {
                pictureBoxHinhAnh.Image = Image.FromFile(MyFormat.GetFilePath(dongHo.HinhAnh));
            }
            catch (Exception e)
            {
                pictureBoxHinhAnh.Image = pictureBoxHinhAnh.ErrorImage;
                MessageBox.Show(e.Message);
            }
            btnNgungKinhDoanh.Enabled = btnSua.Enabled = dongHo.TrangThai.Equals("Ngừng kinh doanh") ? false : true;
        }
        private void ResetTatCaComponent()
        {
            chucNangThucThi = -1;
            // Enable các input và chuyển về ReadOnly
            ThayDoiInputEnabled(true);
            ThayDoiInputReadOnly(true);
            // Enable Grid control đồng hồ
            gridControlDongHo.Enabled = true;
            // Enable tất cả nút trừ Ghi và Thoát chức năng
            ThayDoiButtonEnabled(true);
            btnGhi.Enabled = false;
            btnThoatChucNang.Enabled = false;
        }
        private void ResetGiaTriInput()
        {
            txtMaDongHo.ResetText();
            txtTenDongHo.ResetText();
            txtGia.ResetText();
            txtSoLuongTon.ResetText();
            txtMoTa.ResetText();
            comboBoxTrangThai.SelectedIndex = 0;
            comboBoxLoai.SelectedIndex = 0;
            comboBoxHang.SelectedIndex = 0;
            comboBoxNhaCungCap.SelectedIndex = 0;
            hinhAnh = "";
            pictureBoxHinhAnh.Image = pictureBoxHinhAnh.InitialImage;
        }
        private void ThayDoiInputEnabled(bool enabled)
        {
            txtMaDongHo.Enabled = enabled;
            txtTenDongHo.Enabled = enabled;
            txtGia.Enabled = enabled;
            txtSoLuongTon.Enabled = enabled;
            txtMoTa.Enabled = enabled;
            comboBoxTrangThai.Enabled = enabled;
            comboBoxLoai.Enabled = enabled;
            comboBoxHang.Enabled = enabled;
            comboBoxNhaCungCap.Enabled = enabled;
        }
        private void ThayDoiInputReadOnly(bool readOnly)
        {
            txtMaDongHo.ReadOnly = readOnly;
            txtTenDongHo.ReadOnly = readOnly;
            txtGia.ReadOnly = readOnly;
            txtSoLuongTon.ReadOnly = readOnly;
            txtMoTa.ReadOnly = readOnly;
            comboBoxTrangThai.Enabled = !readOnly;
            comboBoxLoai.Enabled = !readOnly;
            comboBoxHang.Enabled = !readOnly;
            comboBoxNhaCungCap.Enabled = !readOnly;
        }
        private void ThayDoiButtonEnabled(bool enabled)
        {
            btnThem.Enabled = enabled;
            btnSua.Enabled = enabled;
            btnGhi.Enabled = enabled;
            btnXoa.Enabled = enabled;
            btnNgungKinhDoanh.Enabled = enabled;
            btnTaiLai.Enabled = enabled;
            btnThoatChucNang.Enabled = enabled;
        }
        #endregion Giao diện
        #region Chức năng
        private bool InputHopLe()
        {
            if (txtMaDongHo.Text.Equals(""))
            {
                MessageBox.Show("Mã đồng hồ không được trống");
                return false;
            }
            if (txtTenDongHo.Text.Equals(""))
            {
                MessageBox.Show("Tên đồng hồ không được trống");
                return false;
            }
            if (txtGia.Text.Equals(""))
            {
                MessageBox.Show("Giá bán đồng hồ không được trống");
                return false;
            }
            if (hinhAnh.Equals(""))
            {
                MessageBox.Show("Hình đại diện không được trống");
                return false;
            }
            return true;
        }
        private void ThemDongHo()
        {
            string maDongHo = txtMaDongHo.Text;
            string tenDongHo = txtTenDongHo.Text;
            decimal gia = decimal.Parse(txtGia.Text);
            int soLuongTon = int.Parse(txtSoLuongTon.Text);
            string moTa = txtMoTa.Text;
            string trangThai = (string)comboBoxTrangThai.SelectedValue;
            string hinhAnh = Path.GetFileName(this.hinhAnh);
            string loai = (string)comboBoxLoai.SelectedValue;
            string hang = (string)comboBoxHang.SelectedValue;
            string nhaCungCap = (string)comboBoxNhaCungCap.SelectedValue;
            DongHo dongHo = new DongHo(maDongHo, tenDongHo, gia, soLuongTon, moTa, trangThai, hinhAnh, loai, hang, nhaCungCap);
            if (DongHoDAO.Instance.ThemDongHo(dongHo))
            {
                // Chuyển ảnh đến folder resource
                if(!File.Exists(MyFormat.PATH_RESOURCE + dongHo.HinhAnh))
                {
                    try
                    {
                        File.Copy(this.hinhAnh, MyFormat.PATH_RESOURCE + dongHo.HinhAnh);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: Lỗi chuyển file. " + ex.Message);
                    }
                }
                // Thay mã bằng giá trị
                MessageBox.Show("Thêm đồng hồ thành công");
                dongHo.TrangThai = comboBoxTrangThai.Text;
                dongHo.Loai = comboBoxLoai.Text;
                dongHo.Hang = comboBoxHang.Text;
                dongHo.NhaCungCap = comboBoxNhaCungCap.Text;
                // Thêm vào gridview
                listDongHo.Add(dongHo);
                gridViewDongHo.RefreshData();
                bindingSource.Position = listDongHo.Count - 1;
                // Reset
                ResetTatCaComponent();
            }
            else
                MessageBox.Show("Thêm đồng hồ thất bại");
        }
        private void SuaDongHo()
        {
            string maDongHo = txtMaDongHo.Text;
            string tenDongHo = txtTenDongHo.Text;
            decimal gia = decimal.Parse(txtGia.Text);
            string moTa = txtMoTa.Text;
            string trangThai = (string)comboBoxTrangThai.SelectedValue;
            string hinhAnh = Path.GetFileName(this.hinhAnh);
            string loai = (string)comboBoxLoai.SelectedValue;
            string hang = (string)comboBoxHang.SelectedValue;
            DongHo dongHo = new DongHo(maDongHo, tenDongHo, gia, moTa, trangThai, hinhAnh, loai, hang);
            if (DongHoDAO.Instance.SuaDongHo(dongHo))
            {
                MessageBox.Show("Sửa thông tin đồng hồ thành công");
                DongHo dongHoCu = listDongHo[bindingSource.Position];
                // Chuyển ảnh đến folder Image
                if(listDongHo[bindingSource.Position].HinhAnh != this.hinhAnh)
                {
                    if (!File.Exists(MyFormat.PATH_RESOURCE + dongHo.HinhAnh))
                    {
                        try
                        {
                            File.Copy(this.hinhAnh, MyFormat.PATH_RESOURCE + dongHo.HinhAnh);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR: Lỗi chuyển file. " + ex.Message);
                        }
                    }
                }
                dongHoCu.TenDongHo = tenDongHo;
                dongHoCu.Gia = gia;
                dongHoCu.MoTa = moTa;
                dongHoCu.TrangThai = comboBoxTrangThai.Text;
                dongHoCu.HinhAnh = hinhAnh;
                dongHoCu.Loai = comboBoxLoai.Text;
                dongHoCu.Hang = comboBoxHang.Text;
                gridViewDongHo.RefreshData();
                // Reset
                ResetTatCaComponent();
            }
            else
                MessageBox.Show("Thêm đồng hồ thất bại");
        }
        private void XoaDongHo()
        {
            if (DongHoDAO.Instance.XoaDongHo(txtMaDongHo.Text))
            {
                MessageBox.Show("Xóa đồng hồ thành công");
                listDongHo.RemoveAt(bindingSource.Position);
                bindingSource.Position = 0;
                gridViewDongHo.RefreshData();
                ResetTatCaComponent();
            }
            else
                MessageBox.Show("Xóa đồng hồ thất bại");
        }
        private void ThucThiChucNang()
        {
            // Disable tất cả nút chức năng khác trừ Ghi và Thoát
            ThayDoiInputEnabled(true);
            ThayDoiInputReadOnly(false);
            ThayDoiButtonEnabled(false);
            btnGhi.Enabled = true;
            btnThoatChucNang.Enabled = true;
            // Thực thi
            switch (chucNangThucThi)
            {
                case CHUCNANG_THEM:
                    gridControlDongHo.Enabled = false;
                    ResetGiaTriInput();
                    txtSoLuongTon.Text = "0";
                    txtSoLuongTon.ReadOnly = true;
                    comboBoxTrangThai.SelectedValue = TRANGTHAI_DEFAULT;
                    comboBoxTrangThai.Enabled = false;
                    break;
                case CHUCNANG_SUA:
                    txtSoLuongTon.ReadOnly = true;
                    comboBoxNhaCungCap.Enabled = false;
                    comboBoxTrangThai.Enabled = false;
                    break;
            }
        }
        private void GhiDuLieu()
        {
            switch (chucNangThucThi)
            {
                case CHUCNANG_THEM:
                    if (InputHopLe())
                        ThemDongHo();
                    break;
                case CHUCNANG_SUA:
                    if (InputHopLe())
                    {
                        SuaDongHo();
                    }
                    break;
            }
        }
        #endregion Chức năng
        private void gridViewDongHo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FillInput();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            chucNangThucThi = CHUCNANG_THEM;
            ThucThiChucNang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            chucNangThucThi = CHUCNANG_SUA;
            ThucThiChucNang();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            GhiDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có thực sự muốn xóa đồng hồ này?\nSau khi xóa không thể phục hồi",
                "Xóa đồng hồ", 
                MessageBoxButtons.YesNoCancel);
            if(result == DialogResult.Yes)
            {
                XoaDongHo();
            }
        }
        private void btnNgungKinhDoanh_Click(object sender, EventArgs e)
        {
            if(listDongHo.Count > 0)
            {
                DongHo dongHo = listDongHo[bindingSource.Position];
                if (DongHoDAO.Instance.NgungKinhDoanhSP(dongHo.MaDongHo))
                {
                    MessageBox.Show("Ngừng kinh doanh sản phẩm thành công");
                }
                else
                    MessageBox.Show("Ngừng kinh doanh sản phẩm thất bại");
            }
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoatChucNang_Click(object sender, EventArgs e)
        {
            ResetTatCaComponent();
            FillInput();
        }
        private void pictureBoxHinhAnh_Click(object sender, EventArgs e)
        {
            if(chucNangThucThi == CHUCNANG_THEM || chucNangThucThi == CHUCNANG_SUA)
            {
                if (openFileDialogChonAnh.ShowDialog() == DialogResult.OK)
                {
                    hinhAnh = openFileDialogChonAnh.FileName;
                    pictureBoxHinhAnh.Image = Image.FromFile(hinhAnh);
                }
            }
        }
    }
}
