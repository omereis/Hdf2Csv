/*****************************************************************************\
|                           EditQuestionnaire.cs                              |
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
//-----------------------------------------------------------------------------
using OmerEisCommon;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public partial class dlgEditQuestionnaire : Form {
//-----------------------------------------------------------------------------
		public dlgEditQuestionnaire() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------
		public bool Execute (TQuestionairInfo qstnr) {
			Download (qstnr);
			bool f = ShowDialog() == DialogResult.OK;
			if (f)
				Upload (qstnr);
			return (f);
		}
//-----------------------------------------------------------------------------
		private void Download (TQuestionairInfo qstnr) {
			txtID.Text = qstnr.ID.ToString();
			txtName.Text = qstnr.Name;
			txtDesc.Text = qstnr.Description;
		}
//-----------------------------------------------------------------------------
		private void Upload (TQuestionairInfo qstnr) {
			qstnr.ID = TMisc.ToIntDef (txtID.Text);
			qstnr.Name = txtName.Text.Trim();
			qstnr.Description = txtDesc.Text.Trim();
		}
//-----------------------------------------------------------------------------
	}
}
