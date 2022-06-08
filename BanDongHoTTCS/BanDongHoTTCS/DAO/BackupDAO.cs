using BanDongHoTTCS.DTO;
using DangTinThueTro.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanDongHoTTCS.DAO
{
    class BackupDAO
    {
        public string fullBKPath = MyFormat.PATH_BACKUP + "BanDongHo.bak";
        public string diffBKPath = MyFormat.PATH_BACKUP + "BanDongHoDiff.bak";
        public string logBKPath = MyFormat.PATH_BACKUP + "BanDongHo.trn";

        private static BackupDAO instance;
        public static BackupDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BackupDAO();
                return instance;
            }
        }

        public List<BackupHistory> GetListBackupHistory()
        {
            string query = "SELECT * FROM FN_GET_BACKUP_HISTORY()";
            string backupBatDau;
            string backupXong;
            string loai;
            try
            {
                List<BackupHistory> list = new List<BackupHistory>();
                DataTable dt = DataProvider.Instance.ExecuteQuerry(query);
                foreach (DataRow dr in dt.Rows)
                {
                    backupBatDau = String.Format("{0:F}", (DateTime)dr["BackupBatDau"]);
                    backupXong = String.Format("{0:F}", (DateTime)dr["BackupXong"]);
                    loai = (string)dr["Loai"];
                    list.Add(new BackupHistory(backupBatDau, backupXong, loai));
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi lấy lịch sử back up. " + e.Message);
                return null;
            }
        }
        
        //BACK UP
        public bool FullBackup()
        {
            string query = "EXEC SP_FULLBACKUP @DISKPATH";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query, new object[]{this.fullBKPath});
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thực hiện Full Backup. " + e.Message);
                return false;
            }
        }

        public bool DifferentialBackup()
        {
            string queryCheckFullBK = "EXEC SP_CHECK_HAS_FULLBACKUP";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(queryCheckFullBK);
                string queryDifferentialBackup = "EXEC SP_DIFF_BACKUP @DISKPATH";
                DataProvider.Instance.ExecuteNonQuerry(queryDifferentialBackup, 
                    new object[] { this.diffBKPath });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thực hiện Differential Backup. " + e.Message);
                return false;
            }
        }

        public bool TransactionLogBackup()
        {
            string queryCheckFullBK = "EXEC SP_CHECK_HAS_FULLBACKUP";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(queryCheckFullBK);
                string queryDifferentialBackup = "EXEC SP_LOG_BACKUP @DISKPATH";
                DataProvider.Instance.ExecuteNonQuerry(queryDifferentialBackup,
                    new object[] { this.logBKPath });
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thực hiện Log Backup. " + e.Message);
                return false;
            }
        }

        //RESTORE
        private bool SetSingleUser()
        {
            string query = "alter database BanDongHo set single_user with rollback immediate;";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query);
                return true;
            }
            catch
            {
                MessageBox.Show("ERROR: Không thể set single user");
                return false;
            }
        }
        private bool SetMultiUsers()
        {
            string query = "alter database BanDongHo set multi_user;";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query);
                return true;
            }
            catch
            {
                MessageBox.Show("ERROR: Không thể set multi user");
                return false;
            }
        }
        public bool FullRestore()
        {
            if (!SetSingleUser())
                return false;
            string query =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.fullBKPath + "' WITH REPLACE;";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(query);
                SetMultiUsers();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thực hiện Full Restore. " + e.Message);
                return false;
            }
            finally
            {
                SetMultiUsers();
            }
        }

        public bool DifferentialRestore()
        {
            if (!SetSingleUser())
                return false;
            string queryFull =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.fullBKPath + "' WITH REPLACE, NORECOVERY;";
            string queryDiff =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.diffBKPath + "' ";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(queryFull);
                DataProvider.Instance.ExecuteNonQuerry(queryDiff);
                SetMultiUsers();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thực hiện Differential Restore. " + e.Message);
                //Full Restore
                string query =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.fullBKPath + "' WITH REPLACE;";
                try
                {
                    DataProvider.Instance.ExecuteNonQuerry(query);
                    SetMultiUsers();
                    return false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("ERROR: Có lỗi khi thực hiện Full Restore. " + exc.Message);
                    return false;
                }
                finally
                {
                    SetMultiUsers();
                }
            }
            finally
            {
                SetMultiUsers();
            }
        }

        public bool TransactionLogRestore(string date)
        {
            if (!SetSingleUser())
                return false;
            string queryFull =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.fullBKPath + "' WITH REPLACE, NORECOVERY;";
            string queryLog =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.logBKPath + "' WITH STOPAT = '" + date + "'";
            try
            {
                DataProvider.Instance.ExecuteNonQuerry(queryFull);
                DataProvider.Instance.ExecuteNonQuerry(queryLog);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Có lỗi khi thực hiện Transaction Log Restore. " + e.Message);
                //Full Restore
                string query =
                "RESTORE DATABASE BanDongHo FROM DISK = '" + this.fullBKPath + "' WITH REPLACE;";
                try
                {
                    DataProvider.Instance.ExecuteNonQuerry(query);
                    SetMultiUsers();
                    return false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("ERROR: Có lỗi khi thực hiện Full Restore. " + exc.Message);
                    return false;
                }
                finally
                {
                    SetMultiUsers();
                }
            }
            finally
            {
                SetMultiUsers();
            }
        }
    }
}
