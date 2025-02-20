/*****************************************************************************\
|                           EditQuestionnaires.cs                             |
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
	public partial class dlgEditQuestionnaires : Form {
		private MySqlCommand m_cmd = null;
		private string m_strErr = "";
//-----------------------------------------------------------------------------
		public dlgEditQuestionnaires() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd) {
			Download(cmd);
			return (ShowDialog() == DialogResult.OK);
		}
//-----------------------------------------------------------------------------
		private void Download(MySqlCommand cmd) {
			TQuestionairInfo[] aQustn = null;
			m_cmd = cmd;
			if(TQuestionairInfo.LoadFromDB(m_cmd, ref aQustn, ref m_strErr))
				DownloadQuest(aQustn);
			else
				MessageBox.Show(m_strErr);
		}
//-----------------------------------------------------------------------------
		private void DownloadQuest(TQuestionairInfo[] aQustn) {
			gridQstneers.RowCount = 0;
			if(aQustn != null) {
				gridQstneers.RowCount = aQustn.Length;
				for(int n = 0; n < aQustn.Length; n++)
					SetGridRow(n, aQustn[n]);
			}
		}
//-----------------------------------------------------------------------------
		private void SetGridRow(int nRow, TQuestionairInfo qstnr) {
			gridQstneers.Rows[nRow].Cells[0].Tag = qstnr;
			gridQstneers.Rows[nRow].Cells[0].Value = qstnr.Name;
			gridQstneers.Rows[nRow].Cells[1].Value = qstnr.Description;
		}
//-----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, EventArgs e) {
			TQuestionairInfo qstnr = new TQuestionairInfo();
			if(qstnr.InsertAsNew(m_cmd, ref m_strErr)) {
				int nRow = gridQstneers.Rows.Add();
				SetGridRow(nRow, qstnr);
				if(!EditQstnrRow(nRow)) {
					if(!qstnr.DeleteFromDB(m_cmd, ref m_strErr))
						MessageBox.Show(m_strErr);
				}
			}
		}
//-----------------------------------------------------------------------------
		private bool EditQstnrRow(int nRow) {
			TQuestionairInfo qstnr = (TQuestionairInfo)gridQstneers.Rows[nRow].Cells[0].Tag;
			bool f;
			dlgEditQuestionnaire dlg = new dlgEditQuestionnaire();
			if((f = dlg.Execute(qstnr)) == true) {
				if(qstnr.UpdateInDB(m_cmd, ref m_strErr))
					SetGridRow(nRow, qstnr);
				else
					MessageBox.Show(m_strErr);
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private void btnEdit_Click(object sender, EventArgs e) {
			if(gridQstneers.CurrentRow != null)
				EditQstnrRow(gridQstneers.CurrentRow.Index);
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
	}
}
