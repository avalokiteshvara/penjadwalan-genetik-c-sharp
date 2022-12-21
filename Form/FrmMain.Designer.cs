namespace penjadwalan.Form
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dosenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mataKuliahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hariJamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kesediaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prosesPenjadwalanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prosesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pengampuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikasiToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.pengampuToolStripMenuItem1,
            this.prosesPenjadwalanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aplikasiToolStripMenuItem
            // 
            this.aplikasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keluarToolStripMenuItem});
            this.aplikasiToolStripMenuItem.Name = "aplikasiToolStripMenuItem";
            this.aplikasiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.aplikasiToolStripMenuItem.Text = "Aplikasi";
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.keluarToolStripMenuItem.Text = "Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosenToolStripMenuItem,
            this.mataKuliahToolStripMenuItem,
            this.ruangToolStripMenuItem,
            this.hariJamToolStripMenuItem,
            this.kesediaanToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // dosenToolStripMenuItem
            // 
            this.dosenToolStripMenuItem.Name = "dosenToolStripMenuItem";
            this.dosenToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.dosenToolStripMenuItem.Text = "Dosen";
            this.dosenToolStripMenuItem.Click += new System.EventHandler(this.DosenToolStripMenuItemClick);
            // 
            // mataKuliahToolStripMenuItem
            // 
            this.mataKuliahToolStripMenuItem.Name = "mataKuliahToolStripMenuItem";
            this.mataKuliahToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mataKuliahToolStripMenuItem.Text = "Mata Kuliah";
            this.mataKuliahToolStripMenuItem.Click += new System.EventHandler(this.MataKuliahToolStripMenuItemClick);
            // 
            // ruangToolStripMenuItem
            // 
            this.ruangToolStripMenuItem.Name = "ruangToolStripMenuItem";
            this.ruangToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.ruangToolStripMenuItem.Text = "Ruang";
            this.ruangToolStripMenuItem.Click += new System.EventHandler(this.RuangToolStripMenuItemClick);
            // 
            // hariJamToolStripMenuItem
            // 
            this.hariJamToolStripMenuItem.Name = "hariJamToolStripMenuItem";
            this.hariJamToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.hariJamToolStripMenuItem.Text = "Hari && Jam";
            this.hariJamToolStripMenuItem.Click += new System.EventHandler(this.HariJamToolStripMenuItemClick);
            // 
            // kesediaanToolStripMenuItem
            // 
            this.kesediaanToolStripMenuItem.Name = "kesediaanToolStripMenuItem";
            this.kesediaanToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.kesediaanToolStripMenuItem.Text = "Waktu Tidak Bersedia";
            this.kesediaanToolStripMenuItem.Click += new System.EventHandler(this.KesediaanToolStripMenuItemClick);
            // 
            // prosesPenjadwalanToolStripMenuItem
            // 
            this.prosesPenjadwalanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prosesToolStripMenuItem});
            this.prosesPenjadwalanToolStripMenuItem.Name = "prosesPenjadwalanToolStripMenuItem";
            this.prosesPenjadwalanToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.prosesPenjadwalanToolStripMenuItem.Text = "Penjadwalan";
            this.prosesPenjadwalanToolStripMenuItem.Click += new System.EventHandler(this.ProsesPenjadwalanToolStripMenuItemClick);
            // 
            // prosesToolStripMenuItem
            // 
            this.prosesToolStripMenuItem.Name = "prosesToolStripMenuItem";
            this.prosesToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.prosesToolStripMenuItem.Text = "Proses";
            this.prosesToolStripMenuItem.Click += new System.EventHandler(this.prosesToolStripMenuItem_Click);
            // 
            // pengampuToolStripMenuItem1
            // 
            this.pengampuToolStripMenuItem1.Name = "pengampuToolStripMenuItem1";
            this.pengampuToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
            this.pengampuToolStripMenuItem1.Text = "Pengampu";
            this.pengampuToolStripMenuItem1.Click += new System.EventHandler(this.pengampuToolStripMenuItem1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 470);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Penjadwalan Kuliah v0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dosenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mataKuliahToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hariJamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kesediaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prosesPenjadwalanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prosesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aplikasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pengampuToolStripMenuItem1;

    }
}

