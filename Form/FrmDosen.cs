using System;
using System.Windows.Forms;
using penjadwalan.Class;

namespace penjadwalan.Form
{
    public partial class FrmDosen : System.Windows.Forms.Form
    {
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private int _selectedkode = -1;

        public FrmDosen()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            ClassHelper.ClearTextBox(this);
            var dataTable = _dbConnect.GetRecord(
                "SELECT kode," +
                "       nidn as NIDN," +
                "       nama as Nama," +
                "       alamat as Alamat," +
                "       telp as Telp " +
                "FROM dosen " +
                "ORDER BY kode");
            dtGridView.DataSource = dataTable;
            //dtGridView.Columns[0].Visible = false;
        }

        private void SetEnabledOnBtn(bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            btnBaru.Enabled = btnNewEnable;
            btnBatal.Enabled = btnCancelEnable;
            btnSimpan.Enabled = btnSaveEnable;
            ClassHelper.SetReadOnlyOnTextBox(this, btnNewEnable);
        }

        private void FrmDosenLoad(object sender, EventArgs e)
        {
            LoadData();
            SetEnabledOnBtn(true, false, false);
        }

        private void BtnSimpanClick(object sender, EventArgs e)
        {
            //kode,nip,nama,alamat,telp

            if(txtKode.Text.Trim() == "" || txtNIDN.Text.Trim() == "" || txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
                return;
            }


            if (_selectedkode != -1)
            {//update data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM dosen " +
                                          "WHERE (kode={0} OR nidn='{1}') AND kode <> {2}",
                                          int.Parse(txtKode.Text), txtNama.Text, _selectedkode);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode Atau NIDN ini sudah ada!");
                    return;
                }

                var q =
                    string.Format(
                        "UPDATE dosen " +
                        "SET kode = {0}," +
                        "    nidn = '{1}', " +
                        "    nama = '{2}', " +
                        "    alamat = '{3}', " +
                        "    telp = '{4}' " +
                        "WHERE kode = {5}",
                        txtKode.Text,txtNIDN.Text,
                        txtNama.Text,txtAlamat.Text,
                        txtTelp.Text,_selectedkode);
                _dbConnect.ExecuteNonQuery(q);


                //update waktu_tidak_bersedia
                string q_1 =
                    string.Format(
                        "UPDATE waktu_tidak_bersedia " +
                        "SET kode_dosen = {0} " +
                        "WHERE kode_dosen = {1}",
                        txtKode.Text,
                        _selectedkode);
                _dbConnect.ExecuteNonQuery(q_1);

            }else
            {//new data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM dosen " +
                                          "WHERE kode={0} OR nidn='{1}'",
                                          int.Parse(txtKode.Text), txtNIDN.Text);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode Atau NIDN ini sudah ada!");
                    return;
                }
                
                var q = string.Format(
                    "INSERT INTO dosen(kode,nidn,nama,alamat,telp) " +
                    "VALUES({0},'{1}','{2}','{3}','{4}')", 
                    txtKode.Text,txtNIDN.Text,
                    txtNama.Text, txtAlamat.Text, 
                    txtTelp.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkode = -1; //set to "-1" agar disign sebagai databaru

            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(true, false, false);
            LoadData();
        }

        private void DtGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;
            if (dtGridView.SelectedRows.Count <= 0) return;

            var kode = dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString();
            //delete dosen
            var q = string.Format("DELETE FROM dosen WHERE kode = ('{0}')", kode);
            _dbConnect.ExecuteNonQuery(q);

            //delete pengampu
            var q_1 = string.Format("DELETE FROM pengampu WHERE kode_dosen = ('{0}')", kode);
            _dbConnect.ExecuteNonQuery(q_1);
        }

        private void DtGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadData();
        }

        private void BtnBaruClick(object sender, EventArgs e)
        {
            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(false, true, true);
            _selectedkode = -1;
        }

        private void BtnPrintClick(object sender, EventArgs e)
        {
            //print
        }

        private void BtnBatalClick(object sender, EventArgs e)
        {
            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(true, false, false);
        }

        private void DtGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledOnBtn(false, true, true);
            
            _selectedkode = int.Parse(dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString());
            txtKode.Text = dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtNIDN.Text = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtNama.Text = dtGridView[2, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtAlamat.Text = dtGridView[3, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtTelp.Text = dtGridView[4, dtGridView.SelectedRows[0].Index].Value.ToString();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDosen_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
