namespace penjadwalan.Form
{
    partial class FrmPengampu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPengampu));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.cmbTahunAkademik = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDosen = new System.Windows.Forms.ComboBox();
            this.cmbMataKuliah = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtKelas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 486);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(551, 486);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 10;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnBatal);
            this.groupBox1.Controls.Add(this.cmbTahunAkademik);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbDosen);
            this.groupBox1.Controls.Add(this.cmbMataKuliah);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.btnBaru);
            this.groupBox1.Controls.Add(this.btnSimpan);
            this.groupBox1.Controls.Add(this.txtKelas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 171);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Pengampu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(449, 142);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 20;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // cmbTahunAkademik
            // 
            this.cmbTahunAkademik.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTahunAkademik.FormattingEnabled = true;
            this.cmbTahunAkademik.Items.AddRange(new object[] {
            "2011/2012",
            "2012/2013",
            "2013/2014",
            "2014/2015",
            "2015/2016",
            "2016/2017",
            "2017/2018",
            "2018/2019",
            "2019/2020"});
            this.cmbTahunAkademik.Location = new System.Drawing.Point(471, 19);
            this.cmbTahunAkademik.Name = "cmbTahunAkademik";
            this.cmbTahunAkademik.Size = new System.Drawing.Size(82, 21);
            this.cmbTahunAkademik.TabIndex = 19;
            this.cmbTahunAkademik.Text = "2012/2013";
            this.cmbTahunAkademik.SelectedIndexChanged += new System.EventHandler(this.cmbTahunAkademik_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(354, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tahun Akademik";
            // 
            // cmbDosen
            // 
            this.cmbDosen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDosen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDosen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDosen.FormattingEnabled = true;
            this.cmbDosen.Location = new System.Drawing.Point(264, 74);
            this.cmbDosen.Name = "cmbDosen";
            this.cmbDosen.Size = new System.Drawing.Size(289, 21);
            this.cmbDosen.TabIndex = 17;
            // 
            // cmbMataKuliah
            // 
            this.cmbMataKuliah.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMataKuliah.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMataKuliah.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbMataKuliah.FormattingEnabled = true;
            this.cmbMataKuliah.Location = new System.Drawing.Point(264, 47);
            this.cmbMataKuliah.Name = "cmbMataKuliah";
            this.cmbMataKuliah.Size = new System.Drawing.Size(289, 21);
            this.cmbMataKuliah.TabIndex = 16;
            // 
            // cmbSemester
            // 
            this.cmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "GANJIL",
            "GENAP"});
            this.cmbSemester.Location = new System.Drawing.Point(264, 20);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(75, 21);
            this.cmbSemester.TabIndex = 15;
            this.cmbSemester.Text = "GANJIL";
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(264, 142);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 14;
            this.btnBaru.Text = "Data Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(530, 142);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 13;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtKelas
            // 
            this.txtKelas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKelas.Location = new System.Drawing.Point(264, 101);
            this.txtKelas.Name = "txtKelas";
            this.txtKelas.Size = new System.Drawing.Size(43, 26);
            this.txtKelas.TabIndex = 12;
            this.txtKelas.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(174, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kelas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(174, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dosen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mata Kuliah";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Semester";
            // 
            // dtGridView
            // 
            this.dtGridView.AllowUserToAddRows = false;
            this.dtGridView.AllowUserToOrderColumns = true;
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Location = new System.Drawing.Point(12, 189);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.ReadOnly = true;
            this.dtGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridView.Size = new System.Drawing.Size(614, 291);
            this.dtGridView.TabIndex = 12;
            this.dtGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellClick);
            this.dtGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellContentClick);
            this.dtGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtGridView_UserDeletedRow);
            this.dtGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtGridView_UserDeletingRow);
            // 
            // FrmPengampu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 521);
            this.Controls.Add(this.dtGridView);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPengampu";
            this.Text = "Form Pengampu";
            this.Load += new System.EventHandler(this.FrmPengampu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDosen;
        private System.Windows.Forms.ComboBox cmbMataKuliah;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtKelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTahunAkademik;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtGridView;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}