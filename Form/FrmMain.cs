using System;
using System.Windows.Forms;
using penjadwalan.Class;

namespace penjadwalan.Form
{
    public partial class FrmMain : System.Windows.Forms.Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void ProsesPenjadwalanToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void FrmMainLoad(object sender, EventArgs e)
        {

        }

        //FrmDosen frmDosen;
        private void DosenToolStripMenuItemClick(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmDosen),this);

            //var frmDosen = new FrmDosen { MdiParent = this };
            //frmDosen.Show();

        }

        private void MataKuliahToolStripMenuItemClick(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmMataKuliah), this);
            //var frmMataKuliah = new FrmMataKuliah {MdiParent = this};
            //frmMataKuliah.Show();
        }

        private void RuangToolStripMenuItemClick(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmRuang), this);
            //var frmRuang = new FrmRuang { MdiParent = this };
            //frmRuang.Show();
        }

        private void HariJamToolStripMenuItemClick(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmDateTime), this);
            //var frmDateTime = new FrmDateTime { MdiParent = this };
            //frmDateTime.Show();
        }

        private void PengampuToolStripMenuItemClick(object sender, EventArgs e)
        {
            
        }

        private void KesediaanToolStripMenuItemClick(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmWaktuTidakBersedia), this);
            //var frmKesediaanDosen = new FrmWaktuTidakBersedia { MdiParent = this };
            //frmKesediaanDosen.Show();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void prosesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmBuildJadwal), this);
            //var frmBuildJadwal = new FrmBuildJadwal { MdiParent = this };
            //frmBuildJadwal.Show();
        }

        private void pengampuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MdiFormLoader.LoadFormType(typeof(FrmPengampu), this);
            //var frmPengampu = new FrmPengampu { MdiParent = this };
            //frmPengampu.Show();
        }
    }
}
