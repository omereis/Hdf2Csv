/*****************************************************************************\
|                                EditUsers.cs                                 |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
//-----------------------------------------------------------------------------
using MySql.Data.MySqlClient;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public partial class dlgUsers : Form {
		private string m_strErr = "";
//-----------------------------------------------------------------------------
		private MySqlCommand m_cmd = null;
		public dlgUsers() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd) {
			Download(cmd);
			bool f = ShowDialog() == DialogResult.OK;
			return (f);
		}
//-----------------------------------------------------------------------------
		private void Download(MySqlCommand cmd) {
			m_cmd = cmd;
			TUserInfo[] aUsers = null;

			if(TUserInfo.LoadFromDB(cmd, ref aUsers, ref m_strErr)) {
				if(aUsers != null) {
					gridUsers.RowCount = aUsers.Length;
					for(int n = 0; n < aUsers.Length; n++)
						SetUserRow(n, aUsers[n]);
				}
			}
		}
//-----------------------------------------------------------------------------
		private void SetUserRow(int nRow, TUserInfo user) {
			if(user != null) {
				gridUsers.Rows[nRow].Cells[0].Value = user.GetFullName();
				gridUsers.Rows[nRow].Cells[1].Value = user.Phone;
				gridUsers.Rows[nRow].Cells[2].Value = user.Email;
				gridUsers.Rows[nRow].Cells[0].Tag = user;
			}
		}
//-----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, EventArgs e) {
			TUserInfo user = new TUserInfo();

			if (user.InsertAsNew (m_cmd, ref m_strErr)) {
				int nRow = gridUsers.Rows.Add();
				SetUserRow (nRow, user);
				if (!EditUserAtRow (nRow)) {
					gridUsers.Rows.RemoveAt(nRow);
					user.DeleteFromDB (m_cmd, ref m_strErr);
				}
			}
		}
//-----------------------------------------------------------------------------
		private bool EditUserAtRow (int nRow) {
			bool f = false;

			if ((nRow >= 0) && (nRow < gridUsers.Rows.Count)) {
				TUserInfo user = (TUserInfo) gridUsers.Rows[nRow].Cells[0].Tag;
				dlgEditUser dlg = new dlgEditUser();
				if (dlg.Execute (user)) {
					if (user.UpdateInDB (m_cmd, ref m_strErr)) {
						SetUserRow (nRow, user);
						f = true;
					}
					else
						MessageBox.Show (m_strErr);
				}
			}
			return (f);
		}
	}
}
