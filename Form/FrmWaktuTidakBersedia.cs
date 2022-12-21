using System;
using System.Data;
using System.Windows.Forms;
using penjadwalan.Class;

namespace penjadwalan.Form
{
    public partial class FrmWaktuTidakBersedia : System.Windows.Forms.Form
    {
        //waktu_tidak_bersedia:kode,kode_dosen,kode_jam,kode_hari
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();

        private void CreateDbGridColumn()
        {
            //Nama hari
            var dgvHari = new DataGridViewTextBoxColumn { HeaderText = "Hari", Name = "dgvHari", ReadOnly = true };
            dtGridView.Columns.Add(dgvHari);

            //Nama Range Jam
            var dgvJam = new DataGridViewTextBoxColumn { HeaderText = "Jam", Name = "dgvJam", ReadOnly = true };
            dtGridView.Columns.Add(dgvJam);

            var dgvTidakBersedia = new DataGridViewCheckBoxColumn { HeaderText = "Tidak Bersedia", Name = "dgvTidakBersedia", ReadOnly = false };
            dtGridView.Columns.Add(dgvTidakBersedia);

            //Nama hari
            var dgvHariKode = new DataGridViewTextBoxColumn { HeaderText = "Hari", Name = "dgvHariKode", ReadOnly = true, Visible = false };
            dtGridView.Columns.Add(dgvHariKode);

            //Nama Range Jam
            var dgvJamKode = new DataGridViewTextBoxColumn { HeaderText = "Jam", Name = "dgvJamKode", ReadOnly = true, Visible = false };
            dtGridView.Columns.Add(dgvJamKode);
        }

        public FrmWaktuTidakBersedia()
        {
            InitializeComponent();
            CreateDbGridColumn();

            //load dosen
            var dosen_dt = _dbConnect.GetRecord("SELECT * FROM dosen " +
                                                "ORDER BY nama");
            cmbDosen.DataSource = dosen_dt;
            cmbDosen.DisplayMember = "nama";
            cmbDosen.ValueMember = "kode";
        }



        private void LoadData(int kode_dosen)
        {
            dtGridView.Rows.Clear();

            //load hari
            var dtHari = _dbConnect.GetRecord(
                string.Format("SELECT nama,kode " +
                              "FROM hari " +
                              "WHERE aktif = '{0}'" +
                              "ORDER BY kode", "True"));
            //load jam
            var dtJam = _dbConnect.GetRecord("SELECT range_jam,kode " +
                                             "FROM jam");

            var dt = _dbConnect.GetRecord(string.Format("SELECT kode_hari,kode_jam " +
                                                        "FROM waktu_tidak_bersedia " +
                                                        "WHERE kode_dosen = {0}", kode_dosen));

            for (var i = 0; i < dtHari.Rows.Count; i++)
            {
                for (int j = 0; j < dtJam.Rows.Count; j++)
                {
                    dtGridView.Rows.Add(
                        dtHari.Rows[i][0].ToString(),
                        dtJam.Rows[j][0].ToString(),
                        "False",
                        dtHari.Rows[i][1].ToString(),
                        dtJam.Rows[j][1].ToString()
                        );

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        if (
                            dtHari.Rows[i][1].ToString() == dt.Rows[k][0].ToString() &&
                            dtJam.Rows[j][1].ToString() == dt.Rows[k][1].ToString()
                            )
                        {
                            dtGridView[2, dtGridView.Rows.Count - 1].Value = "True";
                        }
                    }
                }
            }
        }


        private void FrmKeinginanDosenLoad(object sender, EventArgs e)
        {
            LoadData(GetCmbKodeDosen());
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }


        private int GetCmbKodeDosen()
        {
            var rowDosen = ((DataTable)cmbDosen.DataSource).Rows[cmbDosen.SelectedIndex];
            var kodeDosen = (int)rowDosen["kode"];
            return kodeDosen;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var kodeDosen = GetCmbKodeDosen();

            _dbConnect.ExecuteNonQuery(string.Format("DELETE FROM waktu_tidak_bersedia " +
                                                     "WHERE kode_dosen = {0}", kodeDosen));
            for (var i = 0; i < dtGridView.Rows.Count; i++)
            {
                //dtGridView[5, dtGridView.SelectedRows[0].Index].Value.ToString();
                if (dtGridView[2, i].Value.ToString() == "True")
                {
                    //MessageBox.Show("YA");
                    _dbConnect.ExecuteNonQuery(string.Format("INSERT INTO waktu_tidak_bersedia(kode_dosen,kode_hari, kode_jam) " +
                                                             "VALUES ({0},{1},{2})",
                                                             kodeDosen, dtGridView[3, i].Value, dtGridView[4, i].Value));
                }
            }
            MessageBox.Show("Data telah tersimpan","Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }



        private void cmbDosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(GetCmbKodeDosen());
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {

        }
    }
}
