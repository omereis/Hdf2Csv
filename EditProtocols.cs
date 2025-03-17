/*****************************************************************************\
|                             EditProtocols.cs                                |
\*****************************************************************************/
using MySql.Data.MySqlClient;
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
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public partial class dlgEditProtocols : Form {
		private MySqlCommand m_cmd = null;
		private string m_strErr = "";
//-----------------------------------------------------------------------------
		public dlgEditProtocols() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd) {
			Download(cmd);
			return (ShowDialog() == DialogResult.OK);
		}
//-----------------------------------------------------------------------------
		private void Download(MySqlCommand cmd) {
			TProtocolInfo[] aProtocols = null;
			m_cmd = cmd;
			if(TProtocolInfo.LoadFromDB(m_cmd, ref aProtocols, ref m_strErr))
				DownloadProtocol(aProtocols);
			else
				MessageBox.Show(m_strErr);
		}
//-----------------------------------------------------------------------------
		private void DownloadProtocol(TProtocolInfo[] aProtocols) {
			gridProtocols.RowCount = 0;
			if(aProtocols != null) {
				gridProtocols.RowCount = aProtocols.Length;
				for(int n = 0; n < aProtocols.Length; n++)
					SetGridRow(n, aProtocols[n]);
			}
		}
//-----------------------------------------------------------------------------
		private void SetGridRow(int nRow, TProtocolInfo protocol) {
			gridProtocols.Rows[nRow].Cells[0].Tag = protocol;
			gridProtocols.Rows[nRow].Cells[0].Value = protocol.Name;
			gridProtocols.Rows[nRow].Cells[1].Value = protocol.Description;
		}
//-----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, EventArgs e) {
			bool fInsert = false;
			TProtocolInfo protocol = new TProtocolInfo();
			int nRow = -1;
			if ((fInsert = protocol.InsertAsNew(m_cmd, ref m_strErr)) == true) {
				nRow = gridProtocols.Rows.Add();
				SetGridRow(nRow, protocol);
				fInsert = EditProtocolRow(nRow);
			}
			if (!fInsert) {
				if (protocol.DeleteFromDB (m_cmd, ref m_strErr)) {
					if (nRow >= 0)
						gridProtocols.Rows.RemoveAt(nRow);
				}
				else
					MessageBox.Show(m_strErr);
			}
		}
//-----------------------------------------------------------------------------
		private bool EditProtocolRow(int nRow) {
			TProtocolInfo protocol = (TProtocolInfo)gridProtocols.Rows[nRow].Cells[nRow].Tag;
			bool f;
			if (protocol.LoadFromDB (m_cmd, ref m_strErr)) {
				dlgEditProtocol dlg = new dlgEditProtocol();
				if((f = dlg.Execute(protocol)) == true) {
					if(protocol.UpdateInDB(m_cmd, ref m_strErr))
						SetGridRow(nRow, protocol);
					else
						MessageBox.Show(m_strErr);
				}
			}
			else
				MessageBox.Show(m_strErr);
			return (f);
		}
//-----------------------------------------------------------------------------
		private void btnEdit_Click(object sender, EventArgs e) {
			if(gridProtocols.CurrentRow != null)
				EditProtocolRow(gridProtocols.CurrentRow.Index);
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
	}
}
