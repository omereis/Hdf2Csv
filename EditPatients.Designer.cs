namespace Hdf2Csv {
	partial class dlgEditPatients {
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
			btnDel = new Button();
			btnEdit = new Button();
			btnAdd = new Button();
			gridPatients = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			Column4 = new DataGridViewTextBoxColumn();
			Column5 = new DataGridViewTextBoxColumn();
			Column6 = new DataGridViewTextBoxColumn();
			btnCancel = new Button();
			btnOK = new Button();
			((System.ComponentModel.ISupportInitialize)gridPatients).BeginInit();
			SuspendLayout();
			// 
			// btnDel
			// 
			btnDel.Location = new Point(9, 194);
			btnDel.Name = "btnDel";
			btnDel.Size = new Size(75, 23);
			btnDel.TabIndex = 11;
			btnDel.Text = "Delete...";
			btnDel.UseVisualStyleBackColor = true;
			btnDel.Click += btnDel_Click;
			// 
			// btnEdit
			// 
			btnEdit.Location = new Point(8, 90);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(75, 23);
			btnEdit.TabIndex = 10;
			btnEdit.Text = "Edit...";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(8, 47);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 9;
			btnAdd.Text = "Add...";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// gridPatients
			// 
			gridPatients.AllowUserToAddRows = false;
			gridPatients.AllowUserToDeleteRows = false;
			gridPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gridPatients.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
			gridPatients.EditMode = DataGridViewEditMode.EditProgrammatically;
			gridPatients.Location = new Point(90, 12);
			gridPatients.MultiSelect = false;
			gridPatients.Name = "gridPatients";
			gridPatients.RowHeadersVisible = false;
			gridPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			gridPatients.Size = new Size(660, 277);
			gridPatients.TabIndex = 8;
			gridPatients.CellDoubleClick += gridPatients_CellDoubleClick;
			// 
			// Column1
			// 
			Column1.HeaderText = "Code";
			Column1.Name = "Column1";
			// 
			// Column2
			// 
			Column2.HeaderText = "Age";
			Column2.Name = "Column2";
			// 
			// Column3
			// 
			Column3.HeaderText = "Gender";
			Column3.Name = "Column3";
			// 
			// Column4
			// 
			Column4.HeaderText = "Height";
			Column4.Name = "Column4";
			// 
			// Column5
			// 
			Column5.HeaderText = "Weight";
			Column5.Name = "Column5";
			// 
			// Column6
			// 
			Column6.HeaderText = "ARAT Scale";
			Column6.Name = "Column6";
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(407, 308);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(303, 309);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 6;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// dlgEditPatients
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(769, 345);
			Controls.Add(btnDel);
			Controls.Add(btnEdit);
			Controls.Add(btnAdd);
			Controls.Add(gridPatients);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dlgEditPatients";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Patients Details";
			((System.ComponentModel.ISupportInitialize)gridPatients).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnDel;
		private Button btnEdit;
		private Button btnAdd;
		private DataGridView gridPatients;
		private Button btnCancel;
		private Button btnOK;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column6;
	}
}