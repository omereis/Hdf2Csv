/*****************************************************************************\
|                             EditProtocols.cs                                |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
//-----------------------------------------------------------------------------
using OmerEisCommon;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public partial class dlgEditSection : Form {
//-----------------------------------------------------------------------------
		public dlgEditSection() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		public bool Execute(TProtocolSection section) {
			Download(section);
			bool f = ShowDialog() == DialogResult.OK;
			if(f)
				Upload(section);
			return (f);
		}
//-----------------------------------------------------------------------------
		private void Download(TProtocolSection section) {
			txtTitle.Text = section.Title;
			txtSection.Text = section.Description;
		}
//-----------------------------------------------------------------------------
		private void Upload(TProtocolSection section) {
			section.Title = txtTitle.Text;
			section.Description = txtSection.Text;
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------
	}
}
