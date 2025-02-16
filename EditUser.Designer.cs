namespace Hdf2Csv {
	partial class dlgEditUser {
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
			label7 = new Label();
			txtID = new TextBox();
			txtFirst = new TextBox();
			txtLast = new TextBox();
			txtUsername = new TextBox();
			txtPasswd = new TextBox();
			txtEmail = new TextBox();
			txtPhone = new TextBox();
			pictureBox1 = new PictureBox();
			btnTestUser = new Button();
			cboxActive = new CheckBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(194, 325);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(90, 326);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 7;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(43, 18);
			label1.Name = "label1";
			label1.Size = new Size(44, 15);
			label1.TabIndex = 4;
			label1.Text = "User ID";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(23, 51);
			label2.Name = "label2";
			label2.Size = new Size(64, 15);
			label2.TabIndex = 5;
			label2.Text = "First Name";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(20, 85);
			label3.Name = "label3";
			label3.Size = new Size(63, 15);
			label3.TabIndex = 6;
			label3.Text = "Last Name";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(26, 195);
			label4.Name = "label4";
			label4.Size = new Size(60, 15);
			label4.TabIndex = 7;
			label4.Text = "Username";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(26, 235);
			label5.Name = "label5";
			label5.Size = new Size(57, 15);
			label5.TabIndex = 8;
			label5.Text = "Password";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(38, 123);
			label6.Name = "label6";
			label6.Size = new Size(41, 15);
			label6.TabIndex = 9;
			label6.Text = "Phone";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(43, 160);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.TabIndex = 10;
			label7.Text = "Email";
			// 
			// txtID
			// 
			txtID.Location = new Point(98, 15);
			txtID.Name = "txtID";
			txtID.ReadOnly = true;
			txtID.Size = new Size(100, 23);
			txtID.TabIndex = 11;
			// 
			// txtFirst
			// 
			txtFirst.Location = new Point(98, 48);
			txtFirst.Name = "txtFirst";
			txtFirst.Size = new Size(157, 23);
			txtFirst.TabIndex = 0;
			// 
			// txtLast
			// 
			txtLast.Location = new Point(98, 82);
			txtLast.Name = "txtLast";
			txtLast.Size = new Size(157, 23);
			txtLast.TabIndex = 1;
			// 
			// txtUsername
			// 
			txtUsername.Location = new Point(98, 195);
			txtUsername.Name = "txtUsername";
			txtUsername.Size = new Size(157, 23);
			txtUsername.TabIndex = 4;
			// 
			// txtPasswd
			// 
			txtPasswd.Location = new Point(98, 235);
			txtPasswd.Name = "txtPasswd";
			txtPasswd.Size = new Size(157, 23);
			txtPasswd.TabIndex = 6;
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(98, 160);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(157, 23);
			txtEmail.TabIndex = 3;
			// 
			// txtPhone
			// 
			txtPhone.Location = new Point(98, 120);
			txtPhone.Name = "txtPhone";
			txtPhone.Size = new Size(157, 23);
			txtPhone.TabIndex = 2;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(272, 36);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(179, 147);
			pictureBox1.TabIndex = 18;
			pictureBox1.TabStop = false;
			// 
			// btnTestUser
			// 
			btnTestUser.Location = new Point(272, 195);
			btnTestUser.Name = "btnTestUser";
			btnTestUser.Size = new Size(75, 23);
			btnTestUser.TabIndex = 5;
			btnTestUser.Text = "Test...";
			btnTestUser.UseVisualStyleBackColor = true;
			// 
			// cboxActive
			// 
			cboxActive.AutoSize = true;
			cboxActive.Location = new Point(100, 274);
			cboxActive.Name = "cboxActive";
			cboxActive.Size = new Size(59, 19);
			cboxActive.TabIndex = 19;
			cboxActive.Text = "Active";
			cboxActive.UseVisualStyleBackColor = true;
			// 
			// dlgEditUser
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(468, 401);
			Controls.Add(cboxActive);
			Controls.Add(btnTestUser);
			Controls.Add(pictureBox1);
			Controls.Add(txtEmail);
			Controls.Add(txtPhone);
			Controls.Add(txtPasswd);
			Controls.Add(txtUsername);
			Controls.Add(txtLast);
			Controls.Add(txtFirst);
			Controls.Add(txtID);
			Controls.Add(label7);
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
			Name = "dlgEditUser";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "User Info";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
		private Label label7;
		private TextBox txtID;
		private TextBox txtFirst;
		private TextBox txtLast;
		private TextBox txtUsername;
		private TextBox txtPasswd;
		private TextBox txtEmail;
		private TextBox txtPhone;
		private PictureBox pictureBox1;
		private Button btnTestUser;
		private CheckBox cboxActive;
	}
}