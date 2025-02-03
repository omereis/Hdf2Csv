/*****************************************************************************\
|                                  main.cs                                     |
\*****************************************************************************/

/*
datbase: emg
username: emg_dba
password: emg
*/
using MySql.Data.MySqlClient;
using OmerEisCommon;
using OmerEisGlobal;
//using WorkHours;

namespace Hdf2Csv
{
	public partial class frmMain : Form {
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private MySqlConnection m_database;
		private MySqlCommand m_cmd;
		private string m_strErr = "";
		private string m_strTitle = "";
		public frmMain() {
			InitializeComponent();
			m_database = null;
			m_cmd = null;
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void btnBrowse_Click(object sender, EventArgs e) {
			if(dlgOpenHDF5.ShowDialog() == DialogResult.OK) {
				gridFiles.Rows.Clear();
				gridFiles.RowCount = dlgOpenHDF5.FileNames.Length;
				for(int n = 0; n < gridFiles.Rows.Count; n++) {
					gridFiles.Rows[n].Cells[0].Value = Path.GetFileName(dlgOpenHDF5.FileNames[n]);
					gridFiles.Rows[n].Cells[0].Tag = dlgOpenHDF5.FileNames[n];
				}
			}
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void btnParse_Click(object sender, EventArgs e) {
			try {
				ConnectToDB();
			} catch(Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void miExit_Click(object sender, EventArgs e) {
			Close();
		}
		//----------------------------------------------------------------------------
		private bool IsDatabaseConnected(MySqlConnection database) {
			bool fOpen = false;

			if(database != null)
				if(database.State == System.Data.ConnectionState.Open)
					fOpen = true;
			return (fOpen);
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void OnIdle(object sender, EventArgs e) {
			UpdateStatusBar();
			miUsers.Enabled = IsDatabaseConnected (m_database);
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void UpdateStatusBar() {
			string str = "";
			if(m_database == null)
				str = "NULL";
			else
				if(IsDatabaseConnected(m_database))
				str = "Connected";
			else
				str = "Disconnected";
			status_bar.Items[0].Text = m_strTitle + str;
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void frmMain_Load(object sender, EventArgs e) {
			Application.Idle += OnIdle;
			m_strTitle = status_bar.Items[0].Text;
			ConnectToDB ();
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void frmMain_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Idle -= OnIdle;
			if(m_database != null)
				m_database.Close();
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void miDatabase_Click(object sender, EventArgs e) {
			bool fParams = false;
			TDBParams db_params = new TDBParams();
			TIniFile ini = new TIniFile(TMisc.GetIniName());
			string strJsonConn = ini.ReadString("Database", "Production");
			if(strJsonConn.Length > 0)
				fParams = db_params.FromJson(strJsonConn);
			if(!fParams) {
				db_params.Database = "emg";
				db_params.Server = "127.0.0.1";
				db_params.Username = "emg_dba";
				db_params.Password = "emg";
			}
			//string strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}'", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");

			EditDB dlg = new EditDB();
			if(dlg.Execute(db_params)) {
				ini = new TIniFile(TMisc.GetIniName());
				ini.WriteString("Database", "Production", db_params.ToJson());// .GetConnectionString());
			}
		}
		//----------------------------------------------------------------------------
		private void ConnectToDB() {
			if(m_database == null) {
				TIniFile ini = new TIniFile(TMisc.GetIniName());
				string strDB = ini.ReadString("Database", "Production");
				string strConn;
				if(strDB.Length > 0) {
					TDBParams db_params = new TDBParams();
					db_params.FromJson(strDB);
					strConn = db_params.GetConnectionString();
				} else
					//strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}',CharSet=utf8", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");
					strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}'", "127.0.0.1", "emg", "emg_dba", "emg");
				try {
					m_database = new MySqlConnection(strConn);
				} catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}
				try {
					m_database.Open();
					m_cmd = new MySqlCommand();
					m_cmd.Connection = m_database;

					//MessageBox.Show("Connected");
				} catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void miUsers_Click(object sender, EventArgs e) {
			dlgUsers users = new dlgUsers();
			users.Execute (m_cmd);
		}

		private void btnConnect_Click(object sender, EventArgs e) {
			ConnectToDB();
		}
		//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
	}
}
