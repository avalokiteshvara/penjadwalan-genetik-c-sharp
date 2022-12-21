namespace penjadwalan.Form
{
    partial class FrmDateTime
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
            this.cbAktif = new System.Windows.Forms.CheckBox();
            this.btnBatalHari = new System.Windows.Forms.Button();
            this.dtGridViewHari = new System.Windows.Forms.DataGridView();
            this.btnBaruHari = new System.Windows.Forms.Button();
            this.btnSimpanHari = new System.Windows.Forms.Button();
            this.txtNamaHari = new System.Windows.Forms.TextBox();
            this.txtKodeHari = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRangeJam = new System.Windows.Forms.TextBox();
            this.btnBatalJam = new System.Windows.Forms.Button();
            this.dtGridViewJam = new System.Windows.Forms.DataGridView();
            this.btnBaruJam = new System.Windows.Forms.Button();
            this.btnSimpanJam = new System.Windows.Forms.Button();
            this.txtKodeJam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTutup = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHari)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewJam)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAktif);
            this.groupBox1.Controls.Add(this.btnBatalHari);
            this.groupBox1.Controls.Add(this.dtGridViewHari);
            this.groupBox1.Controls.Add(this.btnBaruHari);
            this.groupBox1.Controls.Add(this.btnSimpanHari);
            this.groupBox1.Controls.Add(this.txtNamaHari);
            this.groupBox1.Controls.Add(this.txtKodeHari);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Hari";
            // 
            // cbAktif
            // 
            this.cbAktif.AutoSize = true;
            this.cbAktif.Location = new System.Drawing.Point(72, 93);
            this.cbAktif.Name = "cbAktif";
            this.cbAktif.Size = new System.Drawing.Size(47, 17);
            this.cbAktif.TabIndex = 19;
            this.cbAktif.Text = "Aktif";
            this.cbAktif.UseVisualStyleBackColor = true;
            this.cbAktif.Visible = false;
            // 
            // btnBatalHari
            // 
            this.btnBatalHari.Location = new System.Drawing.Point(137, 116);
            this.btnBatalHari.Name = "btnBatalHari";
            this.btnBatalHari.Size = new System.Drawing.Size(75, 23);
            this.btnBatalHari.TabIndex = 18;
            this.btnBatalHari.Text = "Batal";
            this.btnBatalHari.UseVisualStyleBackColor = true;
            this.btnBatalHari.Click += new System.EventHandler(this.btnBatalHari_Click);
            // 
            // dtGridViewHari
            // 
            this.dtGridViewHari.AllowUserToAddRows = false;
            this.dtGridViewHari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewHari.Location = new System.Drawing.Point(6, 145);
            this.dtGridViewHari.Name = "dtGridViewHari";
            this.dtGridViewHari.ReadOnly = true;
            this.dtGridViewHari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridViewHari.Size = new System.Drawing.Size(287, 171);
            this.dtGridViewHari.TabIndex = 17;
            this.dtGridViewHari.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtGridViewHari_UserDeletingRow);
            this.dtGridViewHari.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtGridViewHari_UserDeletedRow);
            this.dtGridViewHari.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridViewHari_CellClick);
            this.dtGridViewHari.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridViewHari_CellContentClick);
            // 
            // btnBaruHari
            // 
            this.btnBaruHari.Location = new System.Drawing.Point(16, 116);
            this.btnBaruHari.Name = "btnBaruHari";
            this.btnBaruHari.Size = new System.Drawing.Size(69, 23);
            this.btnBaruHari.TabIndex = 16;
            this.btnBaruHari.Text = "Data Baru";
            this.btnBaruHari.UseVisualStyleBackColor = true;
            this.btnBaruHari.Click += new System.EventHandler(this.btnDtBaruHari_Click);
            // 
            // btnSimpanHari
            // 
            this.btnSimpanHari.Location = new System.Drawing.Point(218, 116);
            this.btnSimpanHari.Name = "btnSimpanHari";
            this.btnSimpanHari.Size = new System.Drawing.Size(75, 23);
            this.btnSimpanHari.TabIndex = 15;
            this.btnSimpanHari.Text = "Simpan";
            this.btnSimpanHari.UseVisualStyleBackColor = true;
            this.btnSimpanHari.Click += new System.EventHandler(this.btnSimpanHari_Click);
            // 
            // txtNamaHari
            // 
            this.txtNamaHari.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaHari.Location = new System.Drawing.Point(72, 61);
            this.txtNamaHari.Name = "txtNamaHari";
            this.txtNamaHari.Size = new System.Drawing.Size(150, 26);
            this.txtNamaHari.TabIndex = 14;
            this.txtNamaHari.Text = "AAAAAA";
            // 
            // txtKodeHari
            // 
            this.txtKodeHari.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeHari.Location = new System.Drawing.Point(72, 30);
            this.txtKodeHari.Name = "txtKodeHari";
            this.txtKodeHari.Size = new System.Drawing.Size(91, 26);
            this.txtKodeHari.TabIndex = 13;
            this.txtKodeHari.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "KODE";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRangeJam);
            this.groupBox2.Controls.Add(this.btnBatalJam);
            this.groupBox2.Controls.Add(this.dtGridViewJam);
            this.groupBox2.Controls.Add(this.btnBaruJam);
            this.groupBox2.Controls.Add(this.btnSimpanJam);
            this.groupBox2.Controls.Add(this.txtKodeJam);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(345, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 322);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Jam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "format : 00:00-00:00";
            // 
            // txtRangeJam
            // 
            this.txtRangeJam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeJam.Location = new System.Drawing.Point(88, 62);
            this.txtRangeJam.Name = "txtRangeJam";
            this.txtRangeJam.Size = new System.Drawing.Size(117, 26);
            this.txtRangeJam.TabIndex = 25;
            this.txtRangeJam.Text = "00:00-00:00";
            // 
            // btnBatalJam
            // 
            this.btnBatalJam.Location = new System.Drawing.Point(140, 116);
            this.btnBatalJam.Name = "btnBatalJam";
            this.btnBatalJam.Size = new System.Drawing.Size(75, 23);
            this.btnBatalJam.TabIndex = 24;
            this.btnBatalJam.Text = "Batal";
            this.btnBatalJam.UseVisualStyleBackColor = true;
            this.btnBatalJam.Click += new System.EventHandler(this.btnBatalJam_Click);
            // 
            // dtGridViewJam
            // 
            this.dtGridViewJam.AllowUserToAddRows = false;
            this.dtGridViewJam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewJam.Location = new System.Drawing.Point(6, 145);
            this.dtGridViewJam.Name = "dtGridViewJam";
            this.dtGridViewJam.ReadOnly = true;
            this.dtGridViewJam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridViewJam.Size = new System.Drawing.Size(290, 171);
            this.dtGridViewJam.TabIndex = 23;
            this.dtGridViewJam.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtGridViewJam_UserDeletingRow);
            this.dtGridViewJam.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtGridViewJam_UserDeletedRow);
            this.dtGridViewJam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridViewJam_CellClick);
            // 
            // btnBaruJam
            // 
            this.btnBaruJam.Location = new System.Drawing.Point(24, 116);
            this.btnBaruJam.Name = "btnBaruJam";
            this.btnBaruJam.Size = new System.Drawing.Size(69, 23);
            this.btnBaruJam.TabIndex = 22;
            this.btnBaruJam.Text = "Data Baru";
            this.btnBaruJam.UseVisualStyleBackColor = true;
            this.btnBaruJam.Click += new System.EventHandler(this.btnDtBaruJam_Click);
            // 
            // btnSimpanJam
            // 
            this.btnSimpanJam.Location = new System.Drawing.Point(221, 116);
            this.btnSimpanJam.Name = "btnSimpanJam";
            this.btnSimpanJam.Size = new System.Drawing.Size(75, 23);
            this.btnSimpanJam.TabIndex = 21;
            this.btnSimpanJam.Text = "Simpan";
            this.btnSimpanJam.UseVisualStyleBackColor = true;
            this.btnSimpanJam.Click += new System.EventHandler(this.btnSimpanJam_Click);
            // 
            // txtKodeJam
            // 
            this.txtKodeJam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeJam.Location = new System.Drawing.Point(88, 27);
            this.txtKodeJam.Name = "txtKodeJam";
            this.txtKodeJam.Size = new System.Drawing.Size(91, 26);
            this.txtKodeJam.TabIndex = 17;
            this.txtKodeJam.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Jam Ke - ";
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(566, 360);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 7;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // FrmDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 395);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDateTime";
            this.Text = "Form Hari & Jam";
            this.Load += new System.EventHandler(this.FrmDateTime_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHari)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewJam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.TextBox txtNamaHari;
        private System.Windows.Forms.TextBox txtKodeHari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKodeJam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBaruHari;
        private System.Windows.Forms.Button btnSimpanHari;
        private System.Windows.Forms.Button btnBaruJam;
        private System.Windows.Forms.Button btnSimpanJam;
        private System.Windows.Forms.DataGridView dtGridViewHari;
        private System.Windows.Forms.DataGridView dtGridViewJam;
        private System.Windows.Forms.Button btnBatalHari;
        private System.Windows.Forms.Button btnBatalJam;
        private System.Windows.Forms.TextBox txtRangeJam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAktif;
    }
}