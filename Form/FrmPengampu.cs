using System.Data;
using System.Windows.Forms;
using penjadwalan.Class;


namespace penjadwalan.Form
{
    public partial class FrmPengampu : System.Windows.Forms.Form
    {
        //pengampu
        //kode,kode_mk,kode_dosen,kelas,tahun_akademik

        private const int GENAP = 0;
        private const int GANJIL = 1;
        


        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private int _selectedkode = -1;

        public FrmPengampu()
        {
            InitializeComponent();
        }

        private void LoadData(int tipe)
        {
            //kode,kode_mk,nama mk,kode dosen,nama dosen,kelas,tahun akademik

            ClassHelper.ClearTextBox(this);

            var dataTable = _dbConnect.GetRecord(
                string.Format(
                "SELECT a.kode as Kode," +
                "       b.kode as `Kode MK`," +
                "       b.nama as `Nama MK`," +
                "       c.kode as `Kode Dosen`," +
                "       c.nama as  `Nama Dosen`," +
                "       a.kelas as Kelas," +
                "       a.tahun_akademik as `Tahun Akademik` " +
                "FROM pengampu a " +
                "LEFT JOIN mata_kuliah b " +
                "ON a.kode_mk = b.kode " +
                "LEFT JOIN dosen c " +
                "ON a.kode_dosen = c.kode " +
                "WHERE b.semester%2={0} AND a.tahun_akademik = '{1}' " +                
                "ORDER BY b.nama,a.kelas",tipe,cmbTahunAkademik.Text));

            dtGridView.DataSource = dataTable;
            dtGridView.Columns[0].Visible = false;//kode
            dtGridView.Columns[1].Visible = false;//kode MK
            dtGridView.Columns[3].Visible = false;//kode dosen

            //load dosen
            //cbDosen.Items.Clear();
            var dosen_dt = _dbConnect.GetRecord(
                "SELECT kode,nama  " +
                "FROM dosen " +
                "ORDER BY nama");

            cmbDosen.DataSource = dosen_dt;
            cmbDosen.DisplayMember = "nama";
            cmbDosen.ValueMember = "kode";

            //load mata kuliah
            //cbMataKuliah.Items.Clear();
            var mk_dt = _dbConnect.GetRecord(string.Format(
                "SELECT * " +
                "FROM mata_kuliah " +
                "WHERE semester%2={0} " +
                "ORDER BY nama",tipe));

            cmbMataKuliah.DataSource = mk_dt;
            cmbMataKuliah.DisplayMember = "nama";
            cmbMataKuliah.ValueMember = "kode";
        }



        private void SetEnabledOnBtn(bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            btnBaru.Enabled = btnNewEnable;
            btnBatal.Enabled = btnCancelEnable;
            btnSimpan.Enabled = 
                cmbDosen.Enabled = 
                cmbMataKuliah.Enabled = 
                cmbTahunAkademik.Enabled = 
                cmbSemester.Enabled = btnSaveEnable;
            
            ClassHelper.SetReadOnlyOnTextBox(this, btnNewEnable);
        }

        private void btnSimpan_Click(object sender, System.EventArgs e)
        {
            //pengampu
            //kode,kode_mk,kode_dosen,kelas,tahun_akademik

            if(txtKelas.Text.Trim() == "")
            {
                MessageBox.Show("Data belum lengkap");
                return;
            }

            var rowDosen = ((DataTable)cmbDosen.DataSource).Rows[cmbDosen.SelectedIndex];
            var kodeDosen = (int)rowDosen["kode"];

            var rowMK = ((DataTable)cmbMataKuliah.DataSource).Rows[cmbMataKuliah.SelectedIndex];
            var kodeMK = (int)rowMK["kode"];

            if (_selectedkode != -1)
            {//update data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM pengampu " +
                                          "WHERE kode_mk='{0}' AND " +
                                          "      kode_dosen={1} AND " +
                                          "      kelas = '{2}' AND " +
                                          "      tahun_akademik='{3}' " +
                                          "      AND kode <> {4}",
                                          kodeMK, kodeDosen,txtKelas.Text,cmbTahunAkademik.Text, _selectedkode);
                
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Data ini sudah ada!");
                    return;
                }

                var q =
                    string.Format(
                        "UPDATE pengampu " +
                        "SET kode_mk = {0}," +
                        "    kode_dosen = {1}, " +
                        "    kelas = '{2}', " +
                        "    tahun_akademik = '{3}' " +
                        "WHERE kode = {4}",
                        kodeMK, kodeDosen, txtKelas.Text, cmbTahunAkademik.Text, _selectedkode);
                _dbConnect.ExecuteNonQuery(q);

            }
            else
            {//new data
                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM pengampu " +
                                          "WHERE kode_mk='{0}' AND " +
                                          "      kode_dosen={1} AND " +
                                          "      kelas = '{2}' AND " +
                                          "      tahun_akademik='{3}'",
                                          kodeMK, kodeDosen, txtKelas.Text, cmbTahunAkademik.Text);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Data ini sudah ada!");
                    return;
                }


                var q = string.Format(
                    "INSERT INTO pengampu(kode_mk,kode_dosen,kelas,tahun_akademik) " +
                    "VALUES({0},{1},'{2}','{3}')", 
                    kodeMK,kodeDosen, txtKelas.Text, cmbTahunAkademik.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkode = -1; //set to "-1" agar disign sebagai databaru

            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(true, false, false);
            LoadData(cmbSemester.Text == "GANJIL" ? GANJIL : GENAP);
        }


        private void FrmPengampu_Load(object sender, System.EventArgs e)
        {
            LoadData(cmbSemester.Text == "GANJIL" ? GANJIL : GENAP);
            SetEnabledOnBtn(true, false, false);
        }

        private void btnBaru_Click(object sender, System.EventArgs e)
        {
            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(false, true, true);
            _selectedkode = -1;
        }

        private void btnBatal_Click(object sender, System.EventArgs e)
        {
            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(true, false, false);
        }

        private void dtGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) !=
               DialogResult.Yes) return;
            if (dtGridView.SelectedRows.Count <= 0) return;

            var kode = int.Parse(dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString());
            var q = string.Format("DELETE FROM pengampu where kode = ({0})", kode);
            _dbConnect.ExecuteNonQuery(q);
        }

        private void dtGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadData(cmbSemester.Text == "GANJIL" ? GANJIL : GENAP);
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledOnBtn(false, true, true);

            //kode,kode_mk,nama mk,kode dosen,nama dosen,kelas,tahun akademik
            _selectedkode = int.Parse(dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString());
            cmbMataKuliah.Text = dtGridView[2, dtGridView.SelectedRows[0].Index].Value.ToString();
            cmbDosen.Text = dtGridView[4, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtKelas.Text = dtGridView[5, dtGridView.SelectedRows[0].Index].Value.ToString();
            cmbTahunAkademik.Text = dtGridView[6, dtGridView.SelectedRows[0].Index].Value.ToString();
        }

        private void btnTutup_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cmbSemester_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadData(cmbSemester.Text == "GANJIL" ? GANJIL : GENAP);
        }

        private void cmbTahunAkademik_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadData(cmbSemester.Text == "GANJIL" ? GANJIL : GENAP);
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
