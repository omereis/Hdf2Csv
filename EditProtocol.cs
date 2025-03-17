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
	public partial class dlgEditProtocol : Form {
//-----------------------------------------------------------------------------
		public dlgEditProtocol() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------
		public bool Execute(TProtocolInfo protocol) {
			Download(protocol);
			bool f = ShowDialog() == DialogResult.OK;
			if(f)
				Upload(protocol);
			return (f);
		}
//-----------------------------------------------------------------------------
		private void Download(TProtocolInfo protocol) {
			txtID.Text = protocol.ID.ToString();
			txtName.Text = protocol.Name;
			txtDesc.Text = protocol.Description;
			treeSections.Nodes.Clear();
			for (int n=0 ; n < protocol.SectionsCount() ; n++) {
				DownloadSection (protocol.Sections[n]);
			}
		}
//-----------------------------------------------------------------------------
		private void DownloadSection (TProtocolSection section) {
			TreeNode node = treeSections.Nodes.Add (section.Title);
			for (int n=0 ; n < section.TasksCount() ; n++) {
				node.Nodes.Add (section.Tasks[n].ToString());
			}
			node.Tag = section;
		}
//-----------------------------------------------------------------------------
		private void Upload(TProtocolInfo protocol) {
			protocol.ID = TMisc.ToIntDef(txtID.Text);
			protocol.Name = txtName.Text.Trim();
			protocol.Description = txtDesc.Text.Trim();
		}
//-----------------------------------------------------------------------------
		private void button1_Click(object sender, EventArgs e) {
			WebBrowser web = new WebBrowser();
			TProtocolInfo protocol = new TProtocolInfo();
			Upload(protocol);
			web.Parent = panel1;
			web.Location = new Point(0, 0);
			web.Size = new Size(panel1.Size.Width, panel1.Size.Height);
			//web.DocumentText = "<html><h2>hello</h2></html>";
			web.DocumentText = protocol.ToHtml();
		}
//-----------------------------------------------------------------------------
		private void btnAddSection_Click(object sender, EventArgs e) {
			TProtocolSection section = new TProtocolSection();
			dlgEditSection dlg = new dlgEditSection();
			dlg.Execute(section);
		}
//-----------------------------------------------------------------------------
	}
}
