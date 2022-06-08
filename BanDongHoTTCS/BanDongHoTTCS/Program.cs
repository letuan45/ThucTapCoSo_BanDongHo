using BanDongHoTTCS.GUI;
using DangTinThueTro.DAO;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BanDongHoTTCS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataProvider.Instance.SetConnectionStrDefault();
            Application.Run(new FormDangNhap());
        }
    }
}
