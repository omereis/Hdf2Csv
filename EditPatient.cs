/*****************************************************************************\
|                                 EditPatient.cs                              |
\*****************************************************************************/
using MySql.Data.MySqlClient;
using OmerEisCommon;
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
	public partial class dlgEditPatient : Form {
		private MySqlCommand m_cmd = null;
		private string m_strErr = "";
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		public dlgEditPatient() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd, TPatientInfo patient) {
			Download(cmd, patient);
			bool f = ShowDialog() == DialogResult.OK;
			if(f)
				Upload(patient);
			return (f);
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void Download(MySqlCommand cmd, TPatientInfo patient) {
			m_cmd = cmd;
			txtID.Text = patient.PatientID.ToString();
			txtCode.Text = patient.Code;
			txtYOB.Text = patient.YOB.ToString();
			txtHeight.Text = (patient.Height > 0 ? patient.Height.ToString() : "");
			txtWeight.Text = (patient.Weight > 0 ? patient.Weight.ToString() : "");
			DownloadGender (patient.Gender);
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void DownloadGender (int nGender) {
			if (nGender > 0)
				comboGender.SelectedIndex = nGender - 1;
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void Upload(TPatientInfo patient) {
			patient.PatientID = TMisc.ToIntDef (txtID.Text);
			patient.Code = txtCode.Text.Trim().ToUpper();
			patient.YOB = TMisc.ToIntDef (txtYOB.Text);
			patient.Height = TMisc.ToDoubleDef (txtHeight.Text);
			patient.Weight = TMisc.ToDoubleDef (txtWeight.Text);
			patient.Gender = comboGender.SelectedIndex;
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void OnIdle(object sender, EventArgs e) {
			UpdateStandardHeight();
			UpdateStandardWeight();
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void dlgEditPatient_Load(object sender, EventArgs e) {
			Application.Idle += OnIdle;
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void dlgEditPatient_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Idle -= OnIdle;
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void UpdateStandardHeight() {
			string str = txtHeight.Text.Trim();
			if(str.Length > 0) {
				double dHeight = TMisc.ToDoubleDef(str);
				if(dHeight < 3)
					dHeight *= 100;
				double dFeet = (dHeight / 2.54) / 12;
				int iFeet = (int)dFeet;
				double inches = (dFeet - (double)iFeet) * 12;
				txtHeightStd.Text = String.Format("{0}' {1}\"", iFeet, inches);
			}
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void UpdateStandardWeight() {
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------//-----------------------------------------------------------------------------
	}
}
