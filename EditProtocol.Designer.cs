namespace Hdf2Csv {
	partial class dlgEditProtocol {
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
			label1 = new Label();
			txtID = new TextBox();
			txtName = new TextBox();
			label2 = new Label();
			txtDesc = new TextBox();
			button1 = new Button();
			panel1 = new Panel();
			btnAddSection = new Button();
			btnUp = new Button();
			btnDown = new Button();
			groupBox1 = new GroupBox();
			button3 = new Button();
			button2 = new Button();
			gridQstneers = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			Column4 = new DataGridViewTextBoxColumn();
			treeSections = new TreeView();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridQstneers).BeginInit();
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(397, 557);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 11;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(293, 558);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 10;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(11, 53);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.TabIndex = 12;
			label1.Text = "Name";
			// 
			// txtID
			// 
			txtID.Location = new Point(214, 12);
			txtID.Name = "txtID";
			txtID.ReadOnly = true;
			txtID.Size = new Size(100, 23);
			txtID.TabIndex = 13;
			txtID.TextAlign = HorizontalAlignment.Center;
			// 
			// txtName
			// 
			txtName.Location = new Point(84, 53);
			txtName.Name = "txtName";
			txtName.Size = new Size(257, 23);
			txtName.TabIndex = 14;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(11, 97);
			label2.Name = "label2";
			label2.Size = new Size(67, 15);
			label2.TabIndex = 15;
			label2.Text = "Description";
			// 
			// txtDesc
			// 
			txtDesc.AcceptsReturn = true;
			txtDesc.Location = new Point(84, 97);
			txtDesc.Multiline = true;
			txtDesc.Name = "txtDesc";
			txtDesc.Size = new Size(257, 218);
			txtDesc.TabIndex = 16;
			// 
			// button1
			// 
			button1.Location = new Point(352, 15);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 17;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// panel1
			// 
			panel1.Location = new Point(417, 53);
			panel1.Name = "panel1";
			panel1.Size = new Size(446, 262);
			panel1.TabIndex = 18;
			// 
			// btnAddSection
			// 
			btnAddSection.Location = new Point(6, 22);
			btnAddSection.Name = "btnAddSection";
			btnAddSection.Size = new Size(62, 23);
			btnAddSection.TabIndex = 20;
			btnAddSection.Text = "Add...";
			btnAddSection.UseVisualStyleBackColor = true;
			btnAddSection.Click += btnAddSection_Click;
			// 
			// btnUp
			// 
			btnUp.Location = new Point(135, 362);
			btnUp.Name = "btnUp";
			btnUp.Size = new Size(40, 23);
			btnUp.TabIndex = 21;
			btnUp.Text = "Up";
			btnUp.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			btnDown.Location = new Point(135, 391);
			btnDown.Name = "btnDown";
			btnDown.Size = new Size(40, 23);
			btnDown.TabIndex = 22;
			btnDown.Text = "Down";
			btnDown.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.Silver;
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(btnAddSection);
			groupBox1.Location = new Point(12, 321);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(85, 119);
			groupBox1.TabIndex = 23;
			groupBox1.TabStop = false;
			groupBox1.Text = "Sections";
			// 
			// button3
			// 
			button3.Location = new Point(6, 80);
			button3.Name = "button3";
			button3.Size = new Size(62, 23);
			button3.TabIndex = 24;
			button3.Text = "Delete...";
			button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(6, 51);
			button2.Name = "button2";
			button2.Size = new Size(62, 23);
			button2.TabIndex = 24;
			button2.Text = "Edit...";
			button2.UseVisualStyleBackColor = true;
			// 
			// gridQstneers
			// 
			gridQstneers.AllowUserToAddRows = false;
			gridQstneers.AllowUserToDeleteRows = false;
			gridQstneers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gridQstneers.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
			gridQstneers.EditMode = DataGridViewEditMode.EditProgrammatically;
			gridQstneers.Location = new Point(674, 426);
			gridQstneers.MultiSelect = false;
			gridQstneers.Name = "gridQstneers";
			gridQstneers.RowHeadersVisible = false;
			gridQstneers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			gridQstneers.Size = new Size(189, 138);
			gridQstneers.TabIndex = 24;
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
			// treeSections
			// 
			treeSections.Location = new Point(229, 321);
			treeSections.Name = "treeSections";
			treeSections.Size = new Size(274, 177);
			treeSections.TabIndex = 25;
			// 
			// dlgEditProtocol
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(875, 592);
			Controls.Add(treeSections);
			Controls.Add(gridQstneers);
			Controls.Add(groupBox1);
			Controls.Add(btnDown);
			Controls.Add(btnUp);
			Controls.Add(panel1);
			Controls.Add(button1);
			Controls.Add(txtDesc);
			Controls.Add(label2);
			Controls.Add(txtName);
			Controls.Add(txtID);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dlgEditProtocol";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Questionnaire Information";
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gridQstneers).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
		private Label label1;
		private TextBox txtID;
		private TextBox txtName;
		private Label label2;
		private TextBox txtDesc;
		private Button button1;
		private Panel panel1;
		private Button btnAddSection;
		private Button btnUp;
		private Button btnDown;
		private GroupBox groupBox1;
		private Button button3;
		private Button button2;
		private DataGridView gridQstneers;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private TreeView treeSections;
	}
}