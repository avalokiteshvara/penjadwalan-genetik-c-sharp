namespace penjadwalan.Form
{
    partial class FrmBuildJadwal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIterasi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numMutasi = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numCrossover = new System.Windows.Forms.NumericUpDown();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbTahunAkademik = new System.Windows.Forms.ComboBox();
            this.btnProses = new System.Windows.Forms.Button();
            this.txtJumlahPopulasi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTutup = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dtGridView = new System.Windows.Forms.DataGridView();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRata2Fitness = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtIterasi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.numMutasi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numCrossover);
            this.groupBox1.Controls.Add(this.cmbSemester);
            this.groupBox1.Controls.Add(this.cmbTahunAkademik);
            this.groupBox1.Controls.Add(this.btnProses);
            this.groupBox1.Controls.Add(this.txtJumlahPopulasi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 170);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build Jadwal";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(574, 141);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(159, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "*Populasi harus bernilai kelipatan 2";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtIterasi
            // 
            this.txtIterasi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIterasi.Location = new System.Drawing.Point(655, 90);
            this.txtIterasi.Name = "txtIterasi";
            this.txtIterasi.Size = new System.Drawing.Size(60, 26);
            this.txtIterasi.TabIndex = 22;
            this.txtIterasi.Text = "100000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(492, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "Iterasi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::penjadwalan.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // numMutasi
            // 
            this.numMutasi.DecimalPlaces = 2;
            this.numMutasi.Location = new System.Drawing.Point(655, 66);
            this.numMutasi.Name = "numMutasi";
            this.numMutasi.Size = new System.Drawing.Size(60, 20);
            this.numMutasi.TabIndex = 19;
            this.numMutasi.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(492, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Probabilitas Mutasi";
            // 
            // numCrossover
            // 
            this.numCrossover.DecimalPlaces = 2;
            this.numCrossover.Location = new System.Drawing.Point(655, 38);
            this.numCrossover.Name = "numCrossover";
            this.numCrossover.Size = new System.Drawing.Size(60, 20);
            this.numCrossover.TabIndex = 17;
            this.numCrossover.Value = new decimal(new int[] {
            70,
            0,
            0,
            131072});
            // 
            // cmbSemester
            // 
            this.cmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "GANJIL",
            "GENAP"});
            this.cmbSemester.Location = new System.Drawing.Point(287, 62);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(121, 21);
            this.cmbSemester.TabIndex = 16;
            this.cmbSemester.Text = "GANJIL";
            // 
            // cmbTahunAkademik
            // 
            this.cmbTahunAkademik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.cmbTahunAkademik.Location = new System.Drawing.Point(287, 34);
            this.cmbTahunAkademik.Name = "cmbTahunAkademik";
            this.cmbTahunAkademik.Size = new System.Drawing.Size(121, 21);
            this.cmbTahunAkademik.TabIndex = 15;
            this.cmbTahunAkademik.Text = "2012/2013";
            // 
            // btnProses
            // 
            this.btnProses.Location = new System.Drawing.Point(655, 141);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(75, 23);
            this.btnProses.TabIndex = 13;
            this.btnProses.Text = "PROSES";
            this.btnProses.UseVisualStyleBackColor = true;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // txtJumlahPopulasi
            // 
            this.txtJumlahPopulasi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlahPopulasi.Location = new System.Drawing.Point(287, 93);
            this.txtJumlahPopulasi.Name = "txtJumlahPopulasi";
            this.txtJumlahPopulasi.Size = new System.Drawing.Size(41, 26);
            this.txtJumlahPopulasi.TabIndex = 12;
            this.txtJumlahPopulasi.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(492, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Probabilitas Crossover";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(158, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jumlah Populasi*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Semester";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tahun Akademik";
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(908, 516);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 17;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.progressBar.Location = new System.Drawing.Point(12, 493);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(117, 6);
            this.progressBar.TabIndex = 22;
            this.progressBar.Value = 50;
            // 
            // dtGridView
            // 
            this.dtGridView.AllowUserToAddRows = false;
            this.dtGridView.AllowUserToDeleteRows = false;
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Location = new System.Drawing.Point(12, 188);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.ReadOnly = true;
            this.dtGridView.Size = new System.Drawing.Size(744, 299);
            this.dtGridView.TabIndex = 23;
            // 
            // worker
            // 
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(762, 15);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(14, 13);
            this.lblPosition.TabIndex = 24;
            this.lblPosition.Text = "#";
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(762, 31);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(221, 456);
            this.lv.TabIndex = 25;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Individu Ke - ";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fitness";
            this.columnHeader2.Width = 100;
            // 
            // lblRata2Fitness
            // 
            this.lblRata2Fitness.AutoSize = true;
            this.lblRata2Fitness.Location = new System.Drawing.Point(773, 490);
            this.lblRata2Fitness.Name = "lblRata2Fitness";
            this.lblRata2Fitness.Size = new System.Drawing.Size(90, 13);
            this.lblRata2Fitness.TabIndex = 26;
            this.lblRata2Fitness.Text = "Rata-rata Fitness:";
            // 
            // FrmBuildJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 539);
            this.Controls.Add(this.lblRata2Fitness);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.dtGridView);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmBuildJadwal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Build Jadwal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBuildJadwal_FormClosing);
            this.Load += new System.EventHandler(this.FrmBuildJadwal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbTahunAkademik;
        private System.Windows.Forms.Button btnProses;
        private System.Windows.Forms.TextBox txtJumlahPopulasi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMutasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCrossover;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIterasi;
        private System.Windows.Forms.DataGridView dtGridView;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblRata2Fitness;
    }
}