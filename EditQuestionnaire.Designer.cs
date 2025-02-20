namespace Hdf2Csv {
	partial class dlgEditQuestionnaire {
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
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(266, 364);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 11;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(162, 365);
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
			txtName.Size = new Size(362, 23);
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
			txtDesc.Size = new Size(362, 218);
			txtDesc.TabIndex = 16;
			// 
			// dlgEditQuestionnaire
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(875, 398);
			Controls.Add(txtDesc);
			Controls.Add(label2);
			Controls.Add(txtName);
			Controls.Add(txtID);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dlgEditQuestionnaire";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Questionnaire Information";
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
	}
}