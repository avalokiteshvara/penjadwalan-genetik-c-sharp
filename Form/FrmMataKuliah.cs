using System;
using System.Windows.Forms;
using penjadwalan.Class;

namespace penjadwalan.Form
{
    //tablename = mata_kuliah
    //kode,kode_mk,nama,sks,semester,aktif,jenis

    public partial class FrmMataKuliah : System.Windows.Forms.Form
    {
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        private int _selectedkode = -1;


        private void CreateDtGridViewColumn()
        {
            var dgvKode = new DataGridViewTextBoxColumn { HeaderText = "Kode", Name = "dgvKode" };
            dtGridView.Columns.Add(dgvKode);

            var dgvKodeMK = new DataGridViewTextBoxColumn { HeaderText = "KodeMK", Name = "dgvKodeMK" };
            dtGridView.Columns.Add(dgvKodeMK);

            var dgvNama = new DataGridViewTextBoxColumn { HeaderText = "Nama", Name = "dgvNama" };
            dtGridView.Columns.Add(dgvNama);

            var dgvSKS = new DataGridViewTextBoxColumn { HeaderText = "SKS", Name = "dgvSKS" };
            dtGridView.Columns.Add(dgvSKS);

            var dgvSemester = new DataGridViewTextBoxColumn { HeaderText = "Semester", Name = "dgvSemester" };
            dtGridView.Columns.Add(dgvSemester);

            var dgvAktif = new DataGridViewCheckBoxColumn { HeaderText = "Aktif", Name = "dgvAktif" };
            dtGridView.Columns.Add(dgvAktif);
            dgvAktif.Visible = false;

            var dgvJenis = new DataGridViewComboBoxColumn { HeaderText = "Jenis", Name = "dgvJenis" };
            dgvJenis.Items.Add("TEORI");
            dgvJenis.Items.Add("PRAKTIKUM");
            dtGridView.Columns.Add(dgvJenis);

        }


        private void LoadData()
        {
            dtGridView.Rows.Clear();
            ClassHelper.ClearTextBox(this);
            var datatable =
                _dbConnect.GetRecord("SELECT kode as id," +
                                     "       kode_mk as Kode," +
                                     "       nama as Nama," +
                                     "       sks as SKS," +
                                     "       semester as Semester," +
                                     "       aktif as Aktif," + //checkbox
                                     "       jenis as Jenis " + //combobox
                                     "FROM mata_kuliah ORDER BY nama");

            for (var count = 0; count <= datatable.Rows.Count - 1; count++)
            {
                dtGridView.Rows.Add(
                    datatable.Rows[count][0].ToString(),//kode                     
                    datatable.Rows[count][1].ToString(),//kodeMK
                    datatable.Rows[count][2].ToString(),//nama
                    datatable.Rows[count][3].ToString(),//SKS
                    datatable.Rows[count][4].ToString(),//Semester
                    datatable.Rows[count][5].ToString(),//Aktif
                    datatable.Rows[count][6].ToString()//Jenis

                    );
            }

            dtGridView.Columns[0].Visible = false;

        }

        private void SetEnabledOnBtn(bool btnNewEnable, bool btnCancelEnable, bool btnSaveEnable)
        {
            btnBaru.Enabled = btnNewEnable;
            btnBatal.Enabled = btnCancelEnable;
            btnSimpan.Enabled = btnSaveEnable;
            cmbKategori.Enabled = btnSaveEnable;
            cbAktif.Enabled = btnSaveEnable;
            ClassHelper.SetReadOnlyOnTextBox(this, btnNewEnable);
        }

        public FrmMataKuliah()
        {
            InitializeComponent();
            CreateDtGridViewColumn();
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(false, true, true);
            _selectedkode = -1;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //tablename = mata_kuliah
            //kode,nama,sks,semester,aktif,jenis


            if (txtKode.Text.Trim() == "" || txtNama.Text.Trim() == "" ||
                txtSKS.Text.Trim() == "" || txtSemester.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
                return;
            }


            const string _aktif = "True"; //cbAktif.Checked ? "True" : "False";
            var _sks = int.Parse(txtSKS.Text);
            var _semester = int.Parse(txtSemester.Text);



            if (_selectedkode != -1)
            {//update data
                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM mata_kuliah " +
                                          "WHERE (kode_mk='{0}' OR nama='{1}') AND kode <> {2}",
                                          txtKode.Text,txtNama.Text,_selectedkode);
                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode Atau Nama ini sudah ada!");
                    return;
                }

                var q =
                    string.Format(
                        "UPDATE mata_kuliah " +
                        "set kode_mk = '{0}', " +
                        "    nama = '{1}', " +
                        "    sks = {2}, " +
                        "    semester = {3}," +
                        "    aktif ='{4}'," +
                        "    jenis = '{5}' " +
                        "where kode = {6}",
                        txtKode.Text, txtNama.Text, _sks, _semester, _aktif, cmbKategori.Text, _selectedkode);
                _dbConnect.ExecuteNonQuery(q);

            }
            else
            {//new data

                var check = string.Format("SELECT CAST(COUNT(*) AS CHAR(1)) " +
                                          "FROM mata_kuliah " +
                                          "WHERE kode_mk ='{0}' OR nama='{1}'",
                                          txtKode.Text, txtNama.Text);

                var i = int.Parse(_dbConnect.ExecuteScalar(check));

                if (i != 0)
                {
                    MessageBox.Show("Kode Atau Nama ini sudah ada!");
                    return;
                }

                var q = string.Format("INSERT INTO mata_kuliah(kode_mk,nama,sks,semester,aktif,jenis) " +
                                      "VALUES('{0}','{1}',{2},{3},'{4}','{5}')",
                    txtKode.Text, txtNama.Text, _sks, _semester, _aktif, cmbKategori.Text);
                _dbConnect.ExecuteNonQuery(q);
            }

            _selectedkode = -1; //set to "-1" agar disign sebagai databaru

            ClassHelper.ClearTextBox(this);
            SetEnabledOnBtn(true, false, false);
            LoadData();
        }

        private void FrmMataKuliah_Load(object sender, EventArgs e)
        {
            LoadData();
            SetEnabledOnBtn(true, false, false);
        }

        private void btnBatal_Click(object sender, EventArgs e)
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
            //delete mata_kuliah
            var q = string.Format("DELETE FROM mata_kuliah where kode = ({0})", kode);
            _dbConnect.ExecuteNonQuery(q);
            //delete pengampu
            var q_1 = string.Format("DELETE FROM pengampu where kode_mk = ({0})", kode);
            _dbConnect.ExecuteNonQuery(q_1);


        }

        private void dtGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadData();
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetEnabledOnBtn(false, true, true);

            //kode,nama,sks,semester,aktif,jenis
            _selectedkode = int.Parse(dtGridView[0, dtGridView.SelectedRows[0].Index].Value.ToString());
            txtKode.Text = dtGridView[1, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtNama.Text = dtGridView[2, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtSKS.Text = dtGridView[3, dtGridView.SelectedRows[0].Index].Value.ToString();
            txtSemester.Text = dtGridView[4, dtGridView.SelectedRows[0].Index].Value.ToString();
            var _checked = dtGridView[5, dtGridView.SelectedRows[0].Index].Value.ToString();
            cbAktif.Checked = _checked == "True";
            cmbKategori.Text = dtGridView[6, dtGridView.SelectedRows[0].Index].Value.ToString();
        }


        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
