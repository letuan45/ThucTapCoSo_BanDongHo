
namespace BanDongHoTTCS.GUI
{
    partial class FormQLDongHo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnGhi = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnNgungKinhDoanh = new System.Windows.Forms.ToolStripButton();
            this.btnTaiLai = new System.Windows.Forms.ToolStripButton();
            this.btnThoatChucNang = new System.Windows.Forms.ToolStripButton();
            this.gridControlDongHo = new DevExpress.XtraGrid.GridControl();
            this.gridViewDongHo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.comboBoxNhaCungCap = new System.Windows.Forms.ComboBox();
            this.comboBoxHang = new System.Windows.Forms.ComboBox();
            this.comboBoxLoai = new System.Windows.Forms.ComboBox();
            this.comboBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.txtMoTa = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDongHo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDongHo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxHinhAnh = new System.Windows.Forms.PictureBox();
            this.openFileDialogChonAnh = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDongHo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDongHo)).BeginInit();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnGhi,
            this.btnXoa,
            this.btnNgungKinhDoanh,
            this.btnTaiLai,
            this.btnThoatChucNang});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(8);
            this.toolStripMenu.Size = new System.Drawing.Size(1247, 51);
            this.toolStripMenu.TabIndex = 0;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Image = global::BanDongHoTTCS.Properties.Resources.add_free_icon_font_blue_24px;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnThem.Size = new System.Drawing.Size(92, 32);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Image = global::BanDongHoTTCS.Properties.Resources.edit_free_icon_font_blue_24px;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnSua.Size = new System.Drawing.Size(77, 32);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.ForeColor = System.Drawing.Color.Black;
            this.btnGhi.Image = global::BanDongHoTTCS.Properties.Resources.disk_free_icon_font_blue_24px;
            this.btnGhi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnGhi.Size = new System.Drawing.Size(74, 32);
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Image = global::BanDongHoTTCS.Properties.Resources.trash_free_icon_font_blue_24px;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnXoa.Size = new System.Drawing.Size(78, 32);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnNgungKinhDoanh
            // 
            this.btnNgungKinhDoanh.ForeColor = System.Drawing.Color.Black;
            this.btnNgungKinhDoanh.Image = global::BanDongHoTTCS.Properties.Resources.trash_free_icon_font_blue_24px;
            this.btnNgungKinhDoanh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNgungKinhDoanh.Name = "btnNgungKinhDoanh";
            this.btnNgungKinhDoanh.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnNgungKinhDoanh.Size = new System.Drawing.Size(209, 32);
            this.btnNgungKinhDoanh.Text = "Ngừng kinh doanh";
            this.btnNgungKinhDoanh.Click += new System.EventHandler(this.btnNgungKinhDoanh_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.ForeColor = System.Drawing.Color.Black;
            this.btnTaiLai.Image = global::BanDongHoTTCS.Properties.Resources.reload;
            this.btnTaiLai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnTaiLai.Size = new System.Drawing.Size(94, 32);
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnThoatChucNang
            // 
            this.btnThoatChucNang.ForeColor = System.Drawing.Color.Black;
            this.btnThoatChucNang.Image = global::BanDongHoTTCS.Properties.Resources.sign_out_alt_free_icon_font_blue_24px;
            this.btnThoatChucNang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoatChucNang.Name = "btnThoatChucNang";
            this.btnThoatChucNang.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnThoatChucNang.Size = new System.Drawing.Size(189, 32);
            this.btnThoatChucNang.Text = "Thoát chức năng";
            this.btnThoatChucNang.Click += new System.EventHandler(this.btnThoatChucNang_Click);
            // 
            // gridControlDongHo
            // 
            this.gridControlDongHo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControlDongHo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.gridControlDongHo.Location = new System.Drawing.Point(0, 51);
            this.gridControlDongHo.MainView = this.gridViewDongHo;
            this.gridControlDongHo.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.gridControlDongHo.Name = "gridControlDongHo";
            this.gridControlDongHo.Size = new System.Drawing.Size(1247, 500);
            this.gridControlDongHo.TabIndex = 1;
            this.gridControlDongHo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDongHo});
            // 
            // gridViewDongHo
            // 
            this.gridViewDongHo.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewDongHo.Appearance.Row.Options.UseFont = true;
            this.gridViewDongHo.DetailHeight = 437;
            this.gridViewDongHo.GridControl = this.gridControlDongHo;
            this.gridViewDongHo.Name = "gridViewDongHo";
            this.gridViewDongHo.OptionsBehavior.Editable = false;
            this.gridViewDongHo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDongHo_FocusedRowChanged);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInput.Controls.Add(this.comboBoxNhaCungCap);
            this.panelInput.Controls.Add(this.comboBoxHang);
            this.panelInput.Controls.Add(this.comboBoxLoai);
            this.panelInput.Controls.Add(this.comboBoxTrangThai);
            this.panelInput.Controls.Add(this.txtMoTa);
            this.panelInput.Controls.Add(this.label9);
            this.panelInput.Controls.Add(this.label8);
            this.panelInput.Controls.Add(this.label7);
            this.panelInput.Controls.Add(this.label6);
            this.panelInput.Controls.Add(this.label5);
            this.panelInput.Controls.Add(this.txtSoLuongTon);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Controls.Add(this.txtGia);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.txtTenDongHo);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.txtMaDongHo);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.pictureBoxHinhAnh);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(0, 551);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1247, 402);
            this.panelInput.TabIndex = 2;
            // 
            // comboBoxNhaCungCap
            // 
            this.comboBoxNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNhaCungCap.FormattingEnabled = true;
            this.comboBoxNhaCungCap.Location = new System.Drawing.Point(746, 183);
            this.comboBoxNhaCungCap.Name = "comboBoxNhaCungCap";
            this.comboBoxNhaCungCap.Size = new System.Drawing.Size(190, 36);
            this.comboBoxNhaCungCap.TabIndex = 8;
            // 
            // comboBoxHang
            // 
            this.comboBoxHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHang.FormattingEnabled = true;
            this.comboBoxHang.Location = new System.Drawing.Point(746, 125);
            this.comboBoxHang.Name = "comboBoxHang";
            this.comboBoxHang.Size = new System.Drawing.Size(190, 36);
            this.comboBoxHang.TabIndex = 7;
            // 
            // comboBoxLoai
            // 
            this.comboBoxLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoai.FormattingEnabled = true;
            this.comboBoxLoai.Location = new System.Drawing.Point(746, 69);
            this.comboBoxLoai.Name = "comboBoxLoai";
            this.comboBoxLoai.Size = new System.Drawing.Size(190, 36);
            this.comboBoxLoai.TabIndex = 6;
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrangThai.FormattingEnabled = true;
            this.comboBoxTrangThai.Location = new System.Drawing.Point(746, 18);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(190, 36);
            this.comboBoxTrangThai.TabIndex = 5;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(957, 49);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(287, 178);
            this.txtMoTa.TabIndex = 9;
            this.txtMoTa.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(952, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 28);
            this.label9.TabIndex = 17;
            this.label9.Text = "Mô tả:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(594, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 28);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nhà cung cấp:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(594, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 28);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hãng đồng hồ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(594, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Loại đồng hồ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Trạng thái:";
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(379, 185);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(180, 34);
            this.txtSoLuongTon.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số lượng tồn:";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(379, 127);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(180, 34);
            this.txtGia.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giá bán (VNĐ):";
            // 
            // txtTenDongHo
            // 
            this.txtTenDongHo.Location = new System.Drawing.Point(379, 71);
            this.txtTenDongHo.Name = "txtTenDongHo";
            this.txtTenDongHo.Size = new System.Drawing.Size(180, 34);
            this.txtTenDongHo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đồng hồ:";
            // 
            // txtMaDongHo
            // 
            this.txtMaDongHo.Location = new System.Drawing.Point(379, 15);
            this.txtMaDongHo.Name = "txtMaDongHo";
            this.txtMaDongHo.Size = new System.Drawing.Size(180, 34);
            this.txtMaDongHo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã đồng hồ:";
            // 
            // pictureBoxHinhAnh
            // 
            this.pictureBoxHinhAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHinhAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHinhAnh.ErrorImage = global::BanDongHoTTCS.Properties.Resources.error_image;
            this.pictureBoxHinhAnh.InitialImage = global::BanDongHoTTCS.Properties.Resources.init_image;
            this.pictureBoxHinhAnh.Location = new System.Drawing.Point(8, 8);
            this.pictureBoxHinhAnh.Name = "pictureBoxHinhAnh";
            this.pictureBoxHinhAnh.Size = new System.Drawing.Size(230, 230);
            this.pictureBoxHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHinhAnh.TabIndex = 0;
            this.pictureBoxHinhAnh.TabStop = false;
            this.pictureBoxHinhAnh.Click += new System.EventHandler(this.pictureBoxHinhAnh_Click);
            // 
            // openFileDialogChonAnh
            // 
            this.openFileDialogChonAnh.FileName = "openFileDialog";
            // 
            // FormQLDongHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 953);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.gridControlDongHo);
            this.Controls.Add(this.toolStripMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormQLDongHo";
            this.Text = "FormQLDongHo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDongHo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDongHo)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnGhi;
        private System.Windows.Forms.ToolStripButton btnTaiLai;
        private System.Windows.Forms.ToolStripButton btnThoatChucNang;
        private DevExpress.XtraGrid.GridControl gridControlDongHo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDongHo;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.PictureBox pictureBoxHinhAnh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDongHo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDongHo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtMoTa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxNhaCungCap;
        private System.Windows.Forms.ComboBox comboBoxHang;
        private System.Windows.Forms.ComboBox comboBoxLoai;
        private System.Windows.Forms.ComboBox comboBoxTrangThai;
        private System.Windows.Forms.OpenFileDialog openFileDialogChonAnh;
        private System.Windows.Forms.ToolStripButton btnNgungKinhDoanh;
    }
}