namespace Hdf2Csv {
	partial class dlgEditSection {
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
			txtSection = new TextBox();
			txtTitle = new TextBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(265, 276);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(161, 277);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// txtSection
			// 
			txtSection.AcceptsReturn = true;
			txtSection.Location = new Point(27, 49);
			txtSection.Multiline = true;
			txtSection.Name = "txtSection";
			txtSection.Size = new Size(489, 211);
			txtSection.TabIndex = 1;
			// 
			// txtTitle
			// 
			txtTitle.Location = new Point(170, 11);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new Size(131, 23);
			txtTitle.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(106, 14);
			label1.Name = "label1";
			label1.Size = new Size(29, 15);
			label1.TabIndex = 14;
			label1.Text = "Title";
			// 
			// dlgEditSection
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(544, 316);
			Controls.Add(label1);
			Controls.Add(txtTitle);
			Controls.Add(txtSection);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dlgEditSection";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "EditSection";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
		private TextBox txtSection;
		private TextBox txtTitle;
		private Label label1;
	}
}