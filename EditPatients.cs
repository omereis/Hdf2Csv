/*****************************************************************************\
|                                EditPatients.cs                              |
\*****************************************************************************/
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public partial class dlgEditPatients : Form {
		private MySqlCommand m_cmd = null;
		private string m_strErr = "";
//-----------------------------------------------------------------------------
		public dlgEditPatients() {
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
			TPatientInfo[] aPatients = null;
			m_cmd = cmd;

			gridPatients.RowCount = 0;
			if(TPatientInfo.LoadFromDB(cmd, ref aPatients, ref m_strErr)) {
				if(aPatients != null) {
					gridPatients.RowCount += aPatients.Length;
					for(int n = 0; n < aPatients.Length; n++)
						SetPatientRow(n, aPatients[n]);
				}
			}
		}
//-----------------------------------------------------------------------------
		private void SetPatientRow(int nRow, TPatientInfo patient) {
			gridPatients.Rows[nRow].Cells[0].Tag = patient;
			gridPatients.Rows[nRow].Cells[0].Value = patient.Code;
			gridPatients.Rows[nRow].Cells[1].Value = patient.GetCurrentAge();
			gridPatients.Rows[nRow].Cells[2].Value = patient.GetGenderName();
			gridPatients.Rows[nRow].Cells[3].Value = patient.GetHeight();//Height.ToString();
			gridPatients.Rows[nRow].Cells[4].Value = patient.GetWeight();
			gridPatients.Rows[nRow].Cells[5].Value = patient.FuglMeyerScale();
		}
//-----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, EventArgs e) {
			TPatientInfo patient = new TPatientInfo();
			if(patient.InsertAsNew(m_cmd, ref m_strErr)) {
				int nRow = gridPatients.Rows.Add();
				SetPatientRow(nRow, patient);
				if(EditPatientAtRow(nRow)) {
					SetPatientRow(nRow, patient);
				} else {
					gridPatients.Rows.RemoveAt(nRow);
					if(!patient.DeleteFromDB(m_cmd, ref m_strErr))
						MessageBox.Show("Error deleting patient:\n" + m_strErr);
				}
			} else
				MessageBox.Show("Error inserting new patient:\n" + m_strErr);
		}
//-----------------------------------------------------------------------------
		private bool EditPatientAtRow(int nRow) {
			bool f = false;
			if((nRow >= 0) && (nRow < gridPatients.Rows.Count)) {
				TPatientInfo patient = (TPatientInfo)gridPatients.Rows[nRow].Cells[0].Tag;
				if((f = EditPatient(patient)) == true) {
					SetPatientRow(nRow, patient);
				}
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private bool EditPatient(TPatientInfo patient) {
			bool f = false;
			dlgEditPatient dlg = new dlgEditPatient();
			TPatientInfo patientEdit = new TPatientInfo(patient);
			if(dlg.Execute(m_cmd, patientEdit)) {
				patient.AssignAll(patientEdit);
				f = patient.UpdateInDB(m_cmd, ref m_strErr);
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private void btnEdit_Click(object sender, EventArgs e) {
			EditPatient();
		}
//-----------------------------------------------------------------------------
		private void EditPatient() {
			if(gridPatients.CurrentRow != null) {
				int nRow = gridPatients.CurrentRow.Index;
				EditPatientAtRow(nRow);
			}
		}
//-----------------------------------------------------------------------------
		private void gridPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			EditPatient();
		}
//-----------------------------------------------------------------------------
		private void btnDel_Click(object sender, EventArgs e) {
			if(gridPatients.CurrentRow != null) {
				int nRow = gridPatients.CurrentRow.Index;
				TPatientInfo patient = (TPatientInfo) gridPatients.Rows[nRow].Cells[0].Tag;
				if (patient != null) {
					if (MessageBox.Show ("Delete Patient " + patient.Code + " ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
						if (patient.DeleteFromDB (m_cmd, ref m_strErr))
							gridPatients.Rows.RemoveAt(nRow);
						else
							MessageBox.Show (m_strErr);
					}
				}
			}
		}
	}
}
