namespace Hdf2Csv {
	partial class dlgEditProtocols {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			btnCancel = new Button();
			btnOK = new Button();
			btnDel = new Button();
			btnEdit = new Button();
			btnAdd = new Button();
			gridProtocols = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			Column4 = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)gridProtocols).BeginInit();
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(389, 334);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 9;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(285, 335);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 8;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// btnDel
			// 
			btnDel.Location = new Point(13, 206);
			btnDel.Name = "btnDel";
			btnDel.Size = new Size(75, 23);
			btnDel.TabIndex = 15;
			btnDel.Text = "Delete...";
			btnDel.UseVisualStyleBackColor = true;
			// 
			// btnEdit
			// 
			btnEdit.Location = new Point(12, 102);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(75, 23);
			btnEdit.TabIndex = 14;
			btnEdit.Text = "Edit...";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(12, 59);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 13;
			btnAdd.Text = "Add...";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// gridProtocols
			// 
			gridProtocols.AllowUserToAddRows = false;
			gridProtocols.AllowUserToDeleteRows = false;
			gridProtocols.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gridProtocols.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
			gridProtocols.EditMode = DataGridViewEditMode.EditProgrammatically;
			gridProtocols.Location = new Point(94, 24);
			gridProtocols.MultiSelect = false;
			gridProtocols.Name = "gridProtocols";
			gridProtocols.RowHeadersVisible = false;
			gridProtocols.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			gridProtocols.Size = new Size(620, 277);
			gridProtocols.TabIndex = 12;
			// 
			// Column1
			// 
			Column1.HeaderText = "Name";
			Column1.Name = "Column1";
			// 
			// Column2
			// 
			Column2.HeaderText = "Description";
			Column2.Name = "Column2";
			Column2.Width = 300;
			// 
			// Column3
			// 
			Column3.HeaderText = "Creator";
			Column3.Name = "Column3";
			// 
			// Column4
			// 
			Column4.HeaderText = "Date";
			Column4.Name = "Column4";
			// 
			// dlgEditProtocols
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(775, 381);
			Controls.Add(btnDel);
			Controls.Add(btnEdit);
			Controls.Add(btnAdd);
			Controls.Add(gridProtocols);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dlgEditProtocols";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Protocols & Questionnaires";
			((System.ComponentModel.ISupportInitialize)gridProtocols).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
		private Button btnDel;
		private Button btnEdit;
		private Button btnAdd;
		private DataGridView gridProtocols;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
	}
}