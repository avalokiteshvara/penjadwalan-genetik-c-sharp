using System;
using System.Windows.Forms;
using penjadwalan.Class;

namespace penjadwalan.Form
{
    public partial class FrmDateTime : System.Windows.Forms.Form
    {
        private const int HARI = 0;
        private const int JAM = 1;
        private const int SEMUA = 2;
        private readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private int _selectedkodeHr = -1;
        private int _selectedkodeJm = -1;

        public FrmDateTime()
        {
            InitializeComponent();
        }

        private void ClearTxt(int tipe)
        {
            if (tipe == HARI)
            {
                txtKodeHari.Clear();
                txtNamaHari.Clear();
            }
            else
            {
                txtKodeJam.Clear();
                txtRangeJam.Clear();
            }
        }

        private void LoadData(int tipe)
        {
            //hari:kode,nama
            //jam:kode,range
            //ClassHelper.ClearTextBox(this);

            if (tipe != HARI)
            {
                ClearTxt(JAM);
                var dttblJam = _dbConnect.GetRecord("SELECT * FROM jam");
                dtGridViewJam.DataSource = dttblJam;
                dtGridViewJam.Columns[2].Visible = false;
            }
            else
            {
                ClearTxt(HARI);
                var dttblHari = _dbConnect.GetRecord("SELECT kode,nama as Hari,aktif " +
                                                     "FROM hari");
                dtGridViewHari.DataSource = dttblHari;
                dtGridViewHari.Columns[2].Visible = false;
            }
        }

        private void SetEnabledOnBtn(int tipe, bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            switch (tipe)
            {
                case HARI:
                    btnBaruHari.Enabled = 
                        txtKodeHari.ReadOnly = 
                        txtNamaHari.ReadOnly = btnNewEnable;
                    
                    btnBatalHari.Enabled = btnCancelEnable;
                    btnSimpanHari.Enabled = btnSaveEnable;
                    cbAktif.Enabled = btnSaveEnable;
                    break;
                case JAM:
                    btnBaruJam.Enabled = 
                        txtKodeJam.ReadOnly = 
                        txtRangeJam.ReadOnly = btnNewEnable;

                    btnBatalJam.Enabled = btnCancelEnable;
                    btnSimpanJam.Enabled = btnSaveEnable;
                    break;
                default:
                    btnBaruHari.Enabled = btnNewEnable;
                    btnBatalHari.Enabled = btnBatalJam.Enabled = btnCancelEnable;
                    btnSimpanHari.Enabled = btnSimpanJam.Enabled = btnSaveEnable;
                    cbAktif.Enabled = btnSaveEnable;

                    txtKodeHari.ReadOnly = 
                        txtNamaHari.ReadOnly =
                        btnBaruJam.Enabled = 
                        txtKodeJam.ReadOnly = 
                        txtRangeJam.ReadOnly =
                        btnNewEnable;
                    break;
            }
        }


        private void btnDtBaruHari_Click(object sender, EventArgs e)
        {
            //ClassHelper.ClearTextBox(this);
            ClearTxt(HARI);
            SetEnabledOnBtn(HARI, false, true, true);
            _selectedkodeHr = -1;
        }

        private void FrmDateTime_Load(object sender, EventArgs e)
        {
            LoadData(HARI);
            LoadData(JAM);
            SetEnabledOnBtn(SEMUA, true, false, false);
        }

        private void btnDtBaruJam_Click(object sender, EventArgs e)
        {
            ClearTxt(JAM);
            SetEnabledOnBtn(JAM, false, true, true);
            _selectedkodeJm = -1;
        }

        private void btnSimpanHari_Click(object sender, EventArgs e)
        {

            if(txtKodeHari.Text.Trim() == "" || txtNamaHari.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
                return;
            }

            const string _aktif = "True"; //cbAktif.Checked ? "True" : "False";

            if (_selectedkodeHr != -1)
            {
//update data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM hari " +
                                          "WHERE (kode='{0}' OR nama='{1}') AND kode <> {2}",
                                          txtKodeHari.Text, txtNamaHari.Text, _selectedkodeHr);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode Atau Nama ini sudah ada!");
                    return;
                }

                string q =
                    string.Format(
                        "UPDATE hari " +
                        "SET kode = {0}, " +
                        "    nama = '{1}'," +
                        "    aktif = '{2}' " +
                        "WHERE kode = {3}",
                        txtKodeHari.Text,
                        txtNamaHari.Text,
                        _aktif,
                        _selectedkodeHr
                        );
                _dbConnect.ExecuteNonQuery(q);

                //update waktu_tidak_bersedia
                string q_1 =
                    string.Format(
                        "UPDATE waktu_tidak_bersedia " +
                        "SET kode_hari = {0} " +
                        "WHERE kode_hari = {1}",
                        txtKodeHari.Text,
                        _selectedkodeHr);
                _dbConnect.ExecuteNonQuery(q_1);

            }
            else
            {
//new data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM hari " +
                                          "WHERE kode='{0}' OR nama='{1}'",
                                          txtKodeHari.Text, txtNamaHari.Text);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode Atau Nama ini sudah ada!");
                    return;
                }

                string q = string.Format(
                    "INSERT INTO hari(kode,nama,aktif) " +
                    "VALUES({0},'{1}','{2}')",
                    txtKodeHari.Text,
                    txtNamaHari.Text,
                    _aktif);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkodeHr = -1; //set to "-1" agar disign sebagai databaru

            //ClassHelper.ClearTextBox(this);
            txtKodeHari.Clear();
            txtNamaHari.Clear();
            SetEnabledOnBtn(HARI, true, false, false);
            LoadData(HARI);
        }

        private void btnSimpanJam_Click(object sender, EventArgs e)
        {

            if (txtKodeJam.Text.Trim() == "")
            {
                MessageBox.Show("Data belum lengkap");
                return;
            }

            if (_selectedkodeJm != -1)
            {
//update data
                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM jam " +
                                          "WHERE kode={0} AND kode <> {1}",
                                          int.Parse(txtKodeJam.Text), _selectedkodeJm);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode ini sudah ada!");
                    return;
                }

                //update jam 
                string q =
                    string.Format(
                        "UPDATE jam " +
                        "SET kode = {0}, " +
                        "    range_jam = '{1}' " +
                        "WHERE kode = {2}",
                        txtKodeJam.Text,
                        txtRangeJam.Text,
                        _selectedkodeJm);
                _dbConnect.ExecuteNonQuery(q);

                //update waktu_tidak_bersedia
                string q_1 =
                    string.Format(
                        "UPDATE waktu_tidak_bersedia " +
                        "SET kode_jam = {0} " +
                        "WHERE kode_jam = {1}",
                        txtKodeJam.Text,
                        _selectedkodeJm);
                _dbConnect.ExecuteNonQuery(q_1);


            }
            else
            {
//new data
                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM jam " +
                                          "WHERE kode={0}",
                                          int.Parse(txtKodeJam.Text));
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode ini sudah ada!");
                    return;
                }

                string q = string.Format(
                    "INSERT INTO jam(kode,range_jam) " +
                    "VALUES({0},'{1}')",
                    txtKodeJam.Text,
                    txtRangeJam.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkodeJm = -1; //set to "-1" agar disign sebagai databaru

            //ClassHelper.ClearTextBox(this);
            txtKodeJam.Clear();
            txtRangeJam.Clear();
            SetEnabledOnBtn(JAM, true, false, false);
            LoadData(JAM);
        }

        private void dtGridViewHari_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;
            if (dtGridViewHari.SelectedRows.Count <= 0) return;

            string kode = dtGridViewHari[0, dtGridViewHari.SelectedRows[0].Index].Value.ToString();
            string q = string.Format("DELETE FROM hari WHERE kode = ('{0}')", kode);
            _dbConnect.ExecuteNonQuery(q);
        }

        private void dtGridViewJam_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;
            if (dtGridViewJam.SelectedRows.Count <= 0) return;

            string kode = dtGridViewJam[0, dtGridViewJam.SelectedRows[0].Index].Value.ToString();
            string q = string.Format("DELETE FROM jam WHERE kode = ('{0}')", kode);
            _dbConnect.ExecuteNonQuery(q);
        }

        private void dtGridViewHari_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadData(HARI);
        }

        private void dtGridViewJam_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadData(JAM);
        }

        private void btnBatalHari_Click(object sender, EventArgs e)
        {
            //ClassHelper.ClearTextBox(this);
            ClearTxt(HARI);
            SetEnabledOnBtn(HARI, true, false, false);
        }

        private void btnBatalJam_Click(object sender, EventArgs e)
        {
            ClearTxt(JAM);
            SetEnabledOnBtn(JAM, true, false, false);
        }

        private void dtGridViewHari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbAktif.Checked = false;

            SetEnabledOnBtn(HARI, false, true, true);
            _selectedkodeHr = int.Parse(dtGridViewHari[0, dtGridViewHari.SelectedRows[0].Index].Value.ToString());
            txtKodeHari.Text = dtGridViewHari[0, dtGridViewHari.SelectedRows[0].Index].Value.ToString();
            txtNamaHari.Text = dtGridViewHari[1, dtGridViewHari.SelectedRows[0].Index].Value.ToString();

            var _aktif = dtGridViewHari[2, dtGridViewHari.SelectedRows[0].Index].Value.ToString();
            if (_aktif == "True")
            {
                cbAktif.Checked = true;
            }
        }

        private void dtGridViewJam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            SetEnabledOnBtn(JAM, false, true, true);
            _selectedkodeJm = int.Parse(dtGridViewJam[0, dtGridViewJam.SelectedRows[0].Index].Value.ToString());
            txtKodeJam.Text = dtGridViewJam[0, dtGridViewJam.SelectedRows[0].Index].Value.ToString();
            txtRangeJam.Text = dtGridViewJam[1, dtGridViewJam.SelectedRows[0].Index].Value.ToString();
        

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtGridViewHari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}