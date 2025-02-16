namespace Hdf2Csv {
	partial class dlgEditPatient {
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
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			txtID = new TextBox();
			txtCode = new TextBox();
			btnNewCode = new Button();
			txtYOB = new TextBox();
			txtHeight = new TextBox();
			label7 = new Label();
			txtHeightStd = new TextBox();
			label8 = new Label();
			label9 = new Label();
			txtWeightStd = new TextBox();
			label10 = new Label();
			txtWeight = new TextBox();
			comboGender = new ComboBox();
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(237, 267);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 6;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(133, 268);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 5;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(65, 21);
			label1.Name = "label1";
			label1.Size = new Size(18, 15);
			label1.TabIndex = 10;
			label1.Text = "ID";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.Red;
			label2.Location = new Point(48, 60);
			label2.Name = "label2";
			label2.Size = new Size(35, 15);
			label2.TabIndex = 11;
			label2.Text = "Code";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 100);
			label3.Name = "label3";
			label3.Size = new Size(71, 15);
			label3.TabIndex = 12;
			label3.Text = "Year of Birth";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(40, 138);
			label4.Name = "label4";
			label4.Size = new Size(43, 15);
			label4.TabIndex = 13;
			label4.Text = "Height";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(38, 179);
			label5.Name = "label5";
			label5.Size = new Size(45, 15);
			label5.TabIndex = 14;
			label5.Text = "Weight";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(38, 219);
			label6.Name = "label6";
			label6.Size = new Size(45, 15);
			label6.TabIndex = 15;
			label6.Text = "Gender";
			// 
			// txtID
			// 
			txtID.Location = new Point(99, 17);
			txtID.Name = "txtID";
			txtID.ReadOnly = true;
			txtID.Size = new Size(100, 23);
			txtID.TabIndex = 16;
			txtID.TextAlign = HorizontalAlignment.Center;
			// 
			// txtCode
			// 
			txtCode.Location = new Point(99, 56);
			txtCode.Name = "txtCode";
			txtCode.Size = new Size(100, 23);
			txtCode.TabIndex = 0;
			// 
			// btnNewCode
			// 
			btnNewCode.Location = new Point(250, 55);
			btnNewCode.Name = "btnNewCode";
			btnNewCode.Size = new Size(75, 23);
			btnNewCode.TabIndex = 18;
			btnNewCode.Text = "Suggest...";
			btnNewCode.UseVisualStyleBackColor = true;
			// 
			// txtYOB
			// 
			txtYOB.Location = new Point(99, 96);
			txtYOB.Name = "txtYOB";
			txtYOB.Size = new Size(100, 23);
			txtYOB.TabIndex = 1;
			// 
			// txtHeight
			// 
			txtHeight.Location = new Point(99, 134);
			txtHeight.Name = "txtHeight";
			txtHeight.Size = new Size(100, 23);
			txtHeight.TabIndex = 2;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(205, 138);
			label7.Name = "label7";
			label7.Size = new Size(32, 15);
			label7.TabIndex = 21;
			label7.Text = "(cm)";
			// 
			// txtHeightStd
			// 
			txtHeightStd.Location = new Point(250, 134);
			txtHeightStd.Name = "txtHeightStd";
			txtHeightStd.ReadOnly = true;
			txtHeightStd.Size = new Size(100, 23);
			txtHeightStd.TabIndex = 22;
			txtHeightStd.TextAlign = HorizontalAlignment.Center;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(364, 138);
			label8.Name = "label8";
			label8.Size = new Size(61, 15);
			label8.TabIndex = 23;
			label8.Text = "(standard)";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(364, 179);
			label9.Name = "label9";
			label9.Size = new Size(61, 15);
			label9.TabIndex = 27;
			label9.Text = "(standard)";
			// 
			// txtWeightStd
			// 
			txtWeightStd.Location = new Point(250, 175);
			txtWeightStd.Name = "txtWeightStd";
			txtWeightStd.ReadOnly = true;
			txtWeightStd.Size = new Size(100, 23);
			txtWeightStd.TabIndex = 26;
			txtWeightStd.TextAlign = HorizontalAlignment.Center;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(205, 179);
			label10.Name = "label10";
			label10.Size = new Size(32, 15);
			label10.TabIndex = 25;
			label10.Text = "(cm)";
			// 
			// txtWeight
			// 
			txtWeight.Location = new Point(99, 175);
			txtWeight.Name = "txtWeight";
			txtWeight.Size = new Size(100, 23);
			txtWeight.TabIndex = 3;
			// 
			// comboGender
			// 
			comboGender.DropDownStyle = ComboBoxStyle.DropDownList;
			comboGender.FormattingEnabled = true;
			comboGender.Items.AddRange(new object[] { "", "Female", "Male" });
			comboGender.Location = new Point(99, 215);
			comboGender.Name = "comboGender";
			comboGender.Size = new Size(121, 23);
			comboGender.TabIndex = 4;
			// 
			// dlgEditPatient
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(442, 316);
			Controls.Add(comboGender);
			Controls.Add(label9);
			Controls.Add(txtWeightStd);
			Controls.Add(label10);
			Controls.Add(txtWeight);
			Controls.Add(label8);
			Controls.Add(txtHeightStd);
			Controls.Add(label7);
			Controls.Add(txtHeight);
			Controls.Add(txtYOB);
			Controls.Add(btnNewCode);
			Controls.Add(txtCode);
			Controls.Add(txtID);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dlgEditPatient";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "EditPatient";
			FormClosed += dlgEditPatient_FormClosed;
			Load += dlgEditPatient_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private TextBox txtID;
		private TextBox txtCode;
		private Button btnNewCode;
		private TextBox txtYOB;
		private TextBox txtHeight;
		private Label label7;
		private TextBox txtHeightStd;
		private Label label8;
		private Label label9;
		private TextBox txtWeightStd;
		private Label label10;
		private TextBox txtWeight;
		private ComboBox comboGender;
	}
}