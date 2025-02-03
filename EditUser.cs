/*****************************************************************************\
|                                EditUser.cs                                  |
\*****************************************************************************/
using Microsoft.VisualBasic.ApplicationServices;
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
using OmerEisGlobal;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public partial class dlgEditUser : Form {
//-----------------------------------------------------------------------------
		public dlgEditUser() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------
		public bool Execute (TUserInfo user) {
			Download (user);
			bool f = ShowDialog () == DialogResult.OK;
			if (f)
				Upload (user);
			return (f);
		}
//-----------------------------------------------------------------------------
		private void Download (TUserInfo user) {
			txtID.Text = user.UserID.ToString();
			txtFirst.Text = user.FirstName;
			txtLast.Text = user.LastName;
			txtPhone.Text = user.Phone;
			txtEmail.Text = user.Email;
			txtUsername.Text = user.Username;
			txtPasswd.Text = user.Passwd;
		}
//-----------------------------------------------------------------------------
		private void Upload (TUserInfo user) {
			user.UserID = TMisc.ToIntDef (txtID.Text);
			user.FirstName = txtFirst.Text;
			user.LastName = txtLast.Text;
			user.Phone = txtPhone.Text;
			user.Email = txtEmail.Text;
			user.Username = txtUsername.Text;
			user.Passwd = txtPasswd.Text;
		}
	}
}
