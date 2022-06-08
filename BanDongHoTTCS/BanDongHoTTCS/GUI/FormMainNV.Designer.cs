
namespace BanDongHoTTCS.GUI
{
    partial class FormMainNV
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelOption = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.btnBackupRestore = new System.Windows.Forms.Button();
            this.btnQLNhanVien = new System.Windows.Forms.Button();
            this.btnQLNhapHang = new System.Windows.Forms.Button();
            this.btnQLDonDatHang = new System.Windows.Forms.Button();
            this.btnQLDongHo = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelOption.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelOption);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(270, 702);
            this.panelMenu.TabIndex = 0;
            // 
            // panelOption
            // 
            this.panelOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.panelOption.Controls.Add(this.btnQLTaiKhoan);
            this.panelOption.Controls.Add(this.btnBackupRestore);
            this.panelOption.Controls.Add(this.btnQLNhanVien);
            this.panelOption.Controls.Add(this.splitter1);
            this.panelOption.Controls.Add(this.btnQLNhapHang);
            this.panelOption.Controls.Add(this.btnQLDonDatHang);
            this.panelOption.Controls.Add(this.btnQLDongHo);
            this.panelOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOption.ForeColor = System.Drawing.Color.White;
            this.panelOption.Location = new System.Drawing.Point(0, 200);
            this.panelOption.Name = "panelOption";
            this.panelOption.Padding = new System.Windows.Forms.Padding(8);
            this.panelOption.Size = new System.Drawing.Size(270, 502);
            this.panelOption.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(8, 173);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(254, 1);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(40);
            this.panelLogo.Size = new System.Drawing.Size(270, 200);
            this.panelLogo.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(270, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(806, 702);
            this.panelContainer.TabIndex = 1;
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQLTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnQLTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTaiKhoan.Image = global::BanDongHoTTCS.Properties.Resources.account_white_20px;
            this.btnQLTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(8, 449);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(254, 45);
            this.btnQLTaiKhoan.TabIndex = 6;
            this.btnQLTaiKhoan.Text = "        Full name";
            this.btnQLTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // btnBackupRestore
            // 
            this.btnBackupRestore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackupRestore.FlatAppearance.BorderSize = 0;
            this.btnBackupRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupRestore.Image = global::BanDongHoTTCS.Properties.Resources.folder_download_free_icon_font;
            this.btnBackupRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupRestore.Location = new System.Drawing.Point(8, 229);
            this.btnBackupRestore.Name = "btnBackupRestore";
            this.btnBackupRestore.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnBackupRestore.Size = new System.Drawing.Size(254, 55);
            this.btnBackupRestore.TabIndex = 4;
            this.btnBackupRestore.Text = "        Back up và Restore";
            this.btnBackupRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupRestore.UseVisualStyleBackColor = true;
            this.btnBackupRestore.Visible = false;
            this.btnBackupRestore.Click += new System.EventHandler(this.btnBackupRestore_Click);
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLNhanVien.FlatAppearance.BorderSize = 0;
            this.btnQLNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLNhanVien.Image = global::BanDongHoTTCS.Properties.Resources.users_free_icon_font;
            this.btnQLNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhanVien.Location = new System.Drawing.Point(8, 174);
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnQLNhanVien.Size = new System.Drawing.Size(254, 55);
            this.btnQLNhanVien.TabIndex = 3;
            this.btnQLNhanVien.Text = "        Quản lý nhân viên";
            this.btnQLNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhanVien.UseVisualStyleBackColor = true;
            this.btnQLNhanVien.Visible = false;
            this.btnQLNhanVien.Click += new System.EventHandler(this.btnQLNhanVien_Click);
            // 
            // btnQLNhapHang
            // 
            this.btnQLNhapHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLNhapHang.FlatAppearance.BorderSize = 0;
            this.btnQLNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLNhapHang.Image = global::BanDongHoTTCS.Properties.Resources.sign_in_free_icon_font;
            this.btnQLNhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhapHang.Location = new System.Drawing.Point(8, 118);
            this.btnQLNhapHang.Name = "btnQLNhapHang";
            this.btnQLNhapHang.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnQLNhapHang.Size = new System.Drawing.Size(254, 55);
            this.btnQLNhapHang.TabIndex = 1;
            this.btnQLNhapHang.Text = "        Quản lý nhập hàng";
            this.btnQLNhapHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLNhapHang.UseVisualStyleBackColor = true;
            this.btnQLNhapHang.Click += new System.EventHandler(this.btnQLNhapHang_Click);
            // 
            // btnQLDonDatHang
            // 
            this.btnQLDonDatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLDonDatHang.FlatAppearance.BorderSize = 0;
            this.btnQLDonDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDonDatHang.Image = global::BanDongHoTTCS.Properties.Resources.document_free_icon_font;
            this.btnQLDonDatHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDonDatHang.Location = new System.Drawing.Point(8, 63);
            this.btnQLDonDatHang.Name = "btnQLDonDatHang";
            this.btnQLDonDatHang.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnQLDonDatHang.Size = new System.Drawing.Size(254, 55);
            this.btnQLDonDatHang.TabIndex = 2;
            this.btnQLDonDatHang.Text = "        Quản lý đơn đặt hàng";
            this.btnQLDonDatHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDonDatHang.UseVisualStyleBackColor = true;
            this.btnQLDonDatHang.Click += new System.EventHandler(this.btnQLDonDatHang_Click);
            // 
            // btnQLDongHo
            // 
            this.btnQLDongHo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLDongHo.FlatAppearance.BorderSize = 0;
            this.btnQLDongHo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDongHo.Image = global::BanDongHoTTCS.Properties.Resources.clock_five_free_icon_font_white_24px;
            this.btnQLDongHo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDongHo.Location = new System.Drawing.Point(8, 8);
            this.btnQLDongHo.Name = "btnQLDongHo";
            this.btnQLDongHo.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnQLDongHo.Size = new System.Drawing.Size(254, 55);
            this.btnQLDongHo.TabIndex = 0;
            this.btnQLDongHo.Text = "        Quản lý đồng hồ";
            this.btnQLDongHo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDongHo.UseVisualStyleBackColor = true;
            this.btnQLDongHo.Click += new System.EventHandler(this.btnQLDongHo_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogo.Image = global::BanDongHoTTCS.Properties.Resources.watch;
            this.pictureBoxLogo.Location = new System.Drawing.Point(40, 40);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(190, 120);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormMainNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 702);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMainNV";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelOption.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelOption;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnQLDongHo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnQLNhapHang;
        private System.Windows.Forms.Button btnQLDonDatHang;
        private System.Windows.Forms.Button btnBackupRestore;
        private System.Windows.Forms.Button btnQLNhanVien;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnQLTaiKhoan;
    }
}