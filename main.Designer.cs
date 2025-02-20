namespace Hdf2Csv
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			btnBrowse = new Button();
			gridFiles = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			dlgOpenHDF5 = new OpenFileDialog();
			btnParse = new Button();
			menuMain = new MenuStrip();
			popupFile = new ToolStripMenuItem();
			loginToolStripMenuItem = new ToolStripMenuItem();
			logoutToolStripMenuItem = new ToolStripMenuItem();
			miSep2 = new ToolStripSeparator();
			miDatabase = new ToolStripMenuItem();
			miSep1 = new ToolStripSeparator();
			miExit = new ToolStripMenuItem();
			popupInformation = new ToolStripMenuItem();
			miUsers = new ToolStripMenuItem();
			miPatients = new ToolStripMenuItem();
			miQuestionnaires = new ToolStripMenuItem();
			popupHelp = new ToolStripMenuItem();
			miAbout = new ToolStripMenuItem();
			status_bar = new StatusStrip();
			statusDB = new ToolStripStatusLabel();
			btnConnect = new Button();
			button1 = new Button();
			textBox1 = new TextBox();
			((System.ComponentModel.ISupportInitialize)gridFiles).BeginInit();
			menuMain.SuspendLayout();
			status_bar.SuspendLayout();
			SuspendLayout();
			// 
			// btnBrowse
			// 
			btnBrowse.Location = new Point(531, 193);
			btnBrowse.Name = "btnBrowse";
			btnBrowse.Size = new Size(75, 23);
			btnBrowse.TabIndex = 0;
			btnBrowse.Text = "Browse...";
			btnBrowse.UseVisualStyleBackColor = true;
			btnBrowse.Click += btnBrowse_Click;
			// 
			// gridFiles
			// 
			gridFiles.AllowUserToAddRows = false;
			gridFiles.AllowUserToDeleteRows = false;
			gridFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gridFiles.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
			gridFiles.EditMode = DataGridViewEditMode.EditProgrammatically;
			gridFiles.Location = new Point(12, 82);
			gridFiles.MultiSelect = false;
			gridFiles.Name = "gridFiles";
			gridFiles.RowHeadersVisible = false;
			gridFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			gridFiles.Size = new Size(467, 277);
			gridFiles.TabIndex = 1;
			// 
			// Column1
			// 
			Column1.HeaderText = "File";
			Column1.Name = "Column1";
			// 
			// Column2
			// 
			Column2.HeaderText = "Rows";
			Column2.Name = "Column2";
			// 
			// Column3
			// 
			Column3.HeaderText = "Columns";
			Column3.Name = "Column3";
			// 
			// dlgOpenHDF5
			// 
			dlgOpenHDF5.Filter = "HDF5 Files (*.HDF5)|*.HDF5|All Files (*.*)|*.*";
			dlgOpenHDF5.Multiselect = true;
			// 
			// btnParse
			// 
			btnParse.Location = new Point(642, 193);
			btnParse.Name = "btnParse";
			btnParse.Size = new Size(75, 23);
			btnParse.TabIndex = 2;
			btnParse.Text = "Parse";
			btnParse.UseVisualStyleBackColor = true;
			btnParse.Click += btnParse_Click;
			// 
			// menuMain
			// 
			menuMain.Items.AddRange(new ToolStripItem[] { popupFile, popupInformation, popupHelp });
			menuMain.Location = new Point(0, 0);
			menuMain.Name = "menuMain";
			menuMain.Size = new Size(800, 24);
			menuMain.TabIndex = 3;
			menuMain.Text = "menuStrip1";
			// 
			// popupFile
			// 
			popupFile.DropDownItems.AddRange(new ToolStripItem[] { loginToolStripMenuItem, logoutToolStripMenuItem, miSep2, miDatabase, miSep1, miExit });
			popupFile.Name = "popupFile";
			popupFile.Size = new Size(37, 20);
			popupFile.Text = "&File";
			// 
			// loginToolStripMenuItem
			// 
			loginToolStripMenuItem.Name = "loginToolStripMenuItem";
			loginToolStripMenuItem.Size = new Size(131, 22);
			loginToolStripMenuItem.Text = "Login...";
			// 
			// logoutToolStripMenuItem
			// 
			logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			logoutToolStripMenuItem.Size = new Size(131, 22);
			logoutToolStripMenuItem.Text = "Logout...";
			// 
			// miSep2
			// 
			miSep2.Name = "miSep2";
			miSep2.Size = new Size(128, 6);
			// 
			// miDatabase
			// 
			miDatabase.Name = "miDatabase";
			miDatabase.Size = new Size(131, 22);
			miDatabase.Text = "Database...";
			miDatabase.Click += miDatabase_Click;
			// 
			// miSep1
			// 
			miSep1.Name = "miSep1";
			miSep1.Size = new Size(128, 6);
			// 
			// miExit
			// 
			miExit.Name = "miExit";
			miExit.Size = new Size(131, 22);
			miExit.Text = "E&xit";
			miExit.Click += miExit_Click;
			// 
			// popupInformation
			// 
			popupInformation.DropDownItems.AddRange(new ToolStripItem[] { miUsers, miPatients, miQuestionnaires });
			popupInformation.Name = "popupInformation";
			popupInformation.Size = new Size(82, 20);
			popupInformation.Text = "&Information";
			// 
			// miUsers
			// 
			miUsers.Name = "miUsers";
			miUsers.Size = new Size(180, 22);
			miUsers.Text = "&Users...";
			miUsers.Click += miUsers_Click;
			// 
			// miPatients
			// 
			miPatients.Name = "miPatients";
			miPatients.Size = new Size(180, 22);
			miPatients.Text = "&Patients...";
			miPatients.Click += miPatients_Click;
			// 
			// miQuestionnaires
			// 
			miQuestionnaires.Name = "miQuestionnaires";
			miQuestionnaires.Size = new Size(180, 22);
			miQuestionnaires.Text = "Questionnaires";
			miQuestionnaires.Click += miQuestionnaires_Click;
			// 
			// popupHelp
			// 
			popupHelp.DropDownItems.AddRange(new ToolStripItem[] { miAbout });
			popupHelp.Name = "popupHelp";
			popupHelp.Size = new Size(44, 20);
			popupHelp.Text = "&Help";
			// 
			// miAbout
			// 
			miAbout.Name = "miAbout";
			miAbout.Size = new Size(116, 22);
			miAbout.Text = "&About...";
			// 
			// status_bar
			// 
			status_bar.Items.AddRange(new ToolStripItem[] { statusDB });
			status_bar.Location = new Point(0, 428);
			status_bar.Name = "status_bar";
			status_bar.Size = new Size(800, 22);
			status_bar.TabIndex = 5;
			status_bar.Text = "statusStrip1";
			// 
			// statusDB
			// 
			statusDB.Name = "statusDB";
			statusDB.Size = new Size(61, 17);
			statusDB.Text = "Database: ";
			// 
			// btnConnect
			// 
			btnConnect.Location = new Point(531, 251);
			btnConnect.Name = "btnConnect";
			btnConnect.Size = new Size(75, 23);
			btnConnect.TabIndex = 6;
			btnConnect.Text = "Connect";
			btnConnect.UseVisualStyleBackColor = true;
			btnConnect.Click += btnConnect_Click;
			// 
			// button1
			// 
			button1.Location = new Point(531, 43);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 7;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(517, 72);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(100, 23);
			textBox1.TabIndex = 8;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textBox1);
			Controls.Add(button1);
			Controls.Add(btnConnect);
			Controls.Add(status_bar);
			Controls.Add(btnParse);
			Controls.Add(gridFiles);
			Controls.Add(btnBrowse);
			Controls.Add(menuMain);
			MainMenuStrip = menuMain;
			Name = "frmMain";
			Text = "HDF5 to CSV";
			FormClosed += frmMain_FormClosed;
			Load += frmMain_Load;
			((System.ComponentModel.ISupportInitialize)gridFiles).EndInit();
			menuMain.ResumeLayout(false);
			menuMain.PerformLayout();
			status_bar.ResumeLayout(false);
			status_bar.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnBrowse;
		private DataGridView gridFiles;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private OpenFileDialog dlgOpenHDF5;
		private Button btnParse;
		private MenuStrip menuMain;
		private ToolStripMenuItem popupFile;
		private ToolStripMenuItem miExit;
		private ToolStripMenuItem loginToolStripMenuItem;
		private ToolStripMenuItem logoutToolStripMenuItem;
		private ToolStripSeparator miSep1;
		private ToolStripSeparator miSep2;
		private ToolStripMenuItem miDatabase;
		private ToolStripMenuItem popupInformation;
		private ToolStripMenuItem miUsers;
		private ToolStripMenuItem miPatients;
		private ToolStripMenuItem popupHelp;
		private ToolStripMenuItem miAbout;
		private StatusStrip status_bar;
		private ToolStripStatusLabel statusDB;
		private Button btnConnect;
		private Button button1;
		private TextBox textBox1;
		private ToolStripMenuItem miQuestionnaires;
	}
}
