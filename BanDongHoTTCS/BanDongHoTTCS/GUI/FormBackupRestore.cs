using BanDongHoTTCS.DAO;
using BanDongHoTTCS.DTO;
using DangTinThueTro.DAO;
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
    public partial class FormBackupRestore : Form
    {
        private List<BackupHistory> listBKHistory;
        private BindingSource bindingSource = new BindingSource();
        public FormBackupRestore()
        {
            InitializeComponent();
            LoadData();
            LoadUI();
        }

        private void LoadData()
        {
            listBKHistory = BackupDAO.Instance.GetListBackupHistory();
            bindingSource.DataSource = listBKHistory;
            gridControlBK.DataSource = bindingSource;
            bindingSource.Position = 0;  
        }

        private void LoadUI()
        {
            //Backup Types
            List<string> backupTypes = new List<string>
            {
                "Full Backup",
                "Differential Backup",
                "Transaction Log Backup"
            };
            cmbBackupType.DataSource = backupTypes;

            //Restore Type
            List<string> restoreTypes = new List<string>
            {
                "Full Restore",
                "Differential Restore",
                "Transaction Log Restore"
            };
            cmbRestoreType.DataSource = restoreTypes;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string backupType = cmbBackupType.SelectedValue.ToString();
            if(backupType.Equals("Full Backup"))
            {
                if(BackupDAO.Instance.FullBackup())
                {
                    MessageBox.Show("Backup Full thành công");
                    LoadData();
                    return;
                }
            }
            else if (backupType.Equals("Differential Backup"))
            {
                if (BackupDAO.Instance.DifferentialBackup())
                {
                    MessageBox.Show("Backup Differential thành công");
                    LoadData();
                    return;
                }
            }
            else
            {
                if (BackupDAO.Instance.TransactionLogBackup())
                {
                    MessageBox.Show("Backup Log thành công");
                    LoadData();
                    return;
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.SetConnectionStrRestore();
            string restoreType = cmbRestoreType.SelectedValue.ToString();
            if (restoreType.Equals("Full Restore"))
            {
                //full
                if (BackupDAO.Instance.FullRestore())
                {
                    MessageBox.Show("Restore Full thành công");
                }
            }
            else if (restoreType.Equals("Differential Restore"))
            {
                //diff
                if (BackupDAO.Instance.DifferentialRestore())
                {
                    MessageBox.Show("Restore Differential thành công");
                }
            }
            else
            {
                //log
                FormRestoreLog formLog = new FormRestoreLog();
                formLog.ShowDialog();
            }
            DataProvider.Instance.SetConnectionStrNhanVien();
        }
    }
}
