using System.Windows.Forms;
using penjadwalan.Class;

namespace penjadwalan.Form
{
    public partial class FrmRuang : System.Windows.Forms.Form
    {
        //ruang:kode,nama,kapasitas,jenis
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private int _selectedkode = -1;

        private void CreateDtGridViewColumn()
        {
            var dgvKode = new DataGridViewTextBoxColumn { HeaderText = "Kode", Name = "dgvKode" };
            dtGridView.Columns.Add(dgvKode);

            var dgvNama = new DataGridViewTextBoxColumn { HeaderText = "Nama", Name = "dgvNama" };
            dtGridView.Columns.Add(dgvNama);

            var dgvKapasitas = new DataGridViewTextBoxColumn { HeaderText = "SKS", Name = "dgvSKS" };
            dtGridView.Columns.Add(dgvKapasitas);

            var dgvJenis = new DataGridViewComboBoxColumn { HeaderText = "Jenis", Name = "dgvJenis" };
            dgvJenis.Items.Add("TEORI");
            dgvJenis.Items.Add("LABORATORIUM");
            dtGridView.Columns.Add(dgvJenis);

        }

        private void LoadData()
        {
            dtGridView.Rows.Clear();
            
            ClassHelper.ClearTextBox(this);
            var dt = _dbConnect.GetRecord("SELECT * FROM ruang");

            
            for (var count = 0; count <= dt.Rows.Count - 1; count++)
            {
                dtGridView.Rows.Add(
                    dt.Rows[count][0].ToString(),//kode                     
                    dt.Rows[count][1].ToString(),//Nama
                    dt.Rows[count][2].ToString(),//Kapasitas
                    dt.Rows[count][3].ToString()//Jenis
                    );
            }

            dtGridView.Columns[0].Visible = false;
        }

        private void SetEnabledOnBtn(bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            btnBaru.Enabled = btnNewEnable;
            btnBatal.Enabled = btnCancelEnable;
            btnSimpan.Enabled = cmbJenis.Enabled = btnSaveEnable;
 
            ClassHelper.SetReadOnlyOnTextBox(this, btnNewEnable);
        }

        public FrmRuang()
        {
            InitializeComponent();
            CreateDtGridViewColumn();
        }

        private void btnSimpan_Click(object sender, System.EventArgs e)
        {
            //ruang:kode,nama,kapasitas,jenis

            if (txtNama.Text.Trim() == "" || txtKapasitas.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
                return;
            }

            var _kapasitas = int.Parse(txtKapasitas.Text);

            

            if (_selectedkode != -1)
            {//update data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM ruang " +
                                          "WHERE nama='{0}' AND kode <> {1}",
                                          txtNama.Text, _selectedkode);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Nama ini sudah ada!");
                    return;
                }

                var q =
                    string.Format(
                        "UPDATE ruang " +
                        "SET nama = '{0}', " +
                        "    kapasitas = {1}, " +
                        "    jenis = '{2}' " +
                        "WHERE kode = {3}",
                        txtNama.Text,
                        _kapasitas,
                        cmbJenis.Text,
                        _selectedkode);
                _dbConnect.ExecuteNonQuery(q);

            }
            else
            {//new data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM ruang " +
                                          "WHERE nama='{0}'",
                                          txtNama.Text);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Nama ini sudah ada!");
                    return;
                }

                var q = string.Format(
                    "INSERT INTO ruang(nama,kapasitas,jenis) " +
                    "VALUES('{0}',{1},'{2}')",
                    txtNama.Text, _kapasitas, cmbJenis.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkode = -1; //set to "-1" agar disign sebagai databaru

            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(true, false, false);
            LoadData();
        }

        private void btnTutup_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmRuang_Load(object sender, System.EventArgs e)
        {
            LoadData();
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
            var q = string.Format("DELETE FROM ruang where kode = ({0})", kode);
            _dbConnect.ExecuteNonQuery(q);
        }

        private void dtGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadData();
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledOnBtn(false, true, true);

            //ruang:kode,nama,kapasitas,jenis
            _selectedkode = int.Parse(dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString());
            txtNama.Text = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtKapasitas.Text = dtGridView[2, dtGridView.SelectedRows[0].Index].Value.ToString();
            cmbJenis.Text = dtGridView[3, dtGridView.SelectedRows[0].Index].Value.ToString();
        }

    }
}
