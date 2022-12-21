#define SAVE_AS_XL

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using penjadwalan.Class;
using IniParser;
using Excel = Microsoft.Office.Interop.Excel;

namespace penjadwalan.Form
{
    public partial class FrmBuildJadwal : System.Windows.Forms.Form
    {

        private int maxIterasi;
        private int populasi;
        ClassGenetik genetik;
        private readonly int kode_jumat;
        private readonly int kode_dhuhur;
        private readonly int[] range_jumat;

        readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        static readonly FileIniDataParser parser = new FileIniDataParser();
        readonly IniData data = parser.LoadFile("config.ini");

        //solution
        private int[,] jadwal_kuliah;


        public FrmBuildJadwal()
        {
            InitializeComponent();

            //load config
            txtJumlahPopulasi.Text = data["genetik"]["populasi"];
            numCrossover.Text = data["genetik"]["crossover"];
            numMutasi.Text = data["genetik"]["mutasi"];
            txtIterasi.Text = data["genetik"]["max_iterasi"];

            kode_jumat = int.Parse(data["genetik"]["kode_jumat"]);
            kode_dhuhur = int.Parse(data["genetik"]["kode_dhuhur"]);
            range_jumat = data["genetik"]["range_jumat"].Split('-').ToIntArray();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            const int GANJIL = 1;
            const int GENAP = 0;


            int jenis_semester = cmbSemester.Text == "GANJIL" ? GANJIL : GENAP;
            string tahun_akademik = cmbTahunAkademik.Text;
            populasi = int.Parse(txtJumlahPopulasi.Text);

            if (populasi % 2 != 0)
            {
                MessageBox.Show("Populasi harus kelipatan 2");
                return;
            }

            float crossOver = float.Parse(numCrossover.Text);
            float mutasi = float.Parse(numMutasi.Text);
            maxIterasi = int.Parse(txtIterasi.Text);


            genetik = new ClassGenetik(
               jenis_semester, tahun_akademik,
               populasi, crossOver, mutasi,
               kode_jumat, range_jumat, kode_dhuhur);

            genetik.AmbilData();
            genetik.Inisialisasi();


            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
                btnProses.Enabled = false;
                DisableAllParamComponent(true);
                btnStop.Enabled = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Kenapa? \n" +
                "Karena prinsip yang digunakan adalah pernikahan Monogami\n" +
                "jadi satu istri (mungkin) lebih baik :)");
        }

        private void DisableAllParamComponent(bool disabled)
        {
            cmbSemester.Enabled = cmbTahunAkademik.Enabled = txtJumlahPopulasi.Enabled =
                numCrossover.Enabled = numMutasi.Enabled = txtIterasi.Enabled = !disabled;
        }

        private void Export2Excel()
        {
            object misValue = System.Reflection.Missing.Value;

            var xlApp = new Excel.ApplicationClass();
            var xlWorkBook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            //export header
            for (i = 1; i <= dtGridView.Columns.Count; i++)
            {
                xlWorkSheet.Cells[1, i] = dtGridView.Columns[i - 1].HeaderText;
            }

            //export data
            for (i = 1; i <= dtGridView.RowCount; i++)
            {
                for (j = 1; j <= dtGridView.Columns.Count; j++)
                {
                    xlWorkSheet.Cells[i + 1, j] = dtGridView.Rows[i - 1].Cells[j - 1].Value;
                }
            }

            //set font Khmer OS System to data range
            Excel.Range myRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dtGridView.RowCount + 1, dtGridView.Columns.Count]);
            Excel.Font x = myRange.Font;
            x.Name = "Arial";
            x.Size = 10;

            //set bold font to column header
            myRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, dtGridView.Columns.Count]);
            x = myRange.Font;
            x.Bold = true;
            //autofit all columns
            myRange.EntireColumn.AutoFit();

            xlApp.DisplayAlerts = false;
            xlWorkBook.SaveAs(
                Path.GetDirectoryName(Application.ExecutablePath) + "\\report",
#if(SAVE_AS_XL)
 Excel.XlFileFormat.xlWorkbookNormal,
#else
                Excel.XlFileFormat.xlHtml, 
#endif
 misValue,
                misValue,
                misValue,
                misValue,
                Excel.XlSaveAsAccessMode.xlExclusive,
                misValue,
                misValue,
                misValue,
                misValue,
                misValue);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //loop here
            for (int i = 0; i < maxIterasi; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                float[] fitness = genetik.HitungFitness();
                genetik.Seleksi(fitness);
                genetik.StartCrossOver();

                float[] fitnessAfterMutation = genetik.Mutasi();

                for (var j = 0; j < fitnessAfterMutation.Length; j++)
                {
                    if (ClassHelper.AlmostEquals(fitnessAfterMutation[j], 1.0, 0))
                    {
                        jadwal_kuliah = genetik.GetIndividu(j);
                        UpdateUI(i, maxIterasi, fitnessAfterMutation, true);
                        
						stopwatch.Stop();
                        TimeSpan ts = stopwatch.Elapsed;


                        MessageBox.Show(string.Format("Solusi ditemukan\n" +
                                                      "Waktu yang diperlukan: " +
                                                      "{0:00} Jam, {1:00} Menit,\n{2:00} Detik dan {3:00} Milidetik\n" +
                                                      "Report disimpan di report.xls",
                                                      ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10),
                                                      "Informasi", MessageBoxButtons.OK,
                                                      MessageBoxIcon.Information);
                        Export2Excel();
                        genetik.WriteLog2Disk();
                        return;
                    }
                }
                //genetik.WriteLog2Disk();
                UpdateUI(i, maxIterasi, fitnessAfterMutation, false);
            }
            //end loop here

            MessageBox.Show("Solusi TIDAK ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //save last log
            genetik.WriteLog2Disk();
        }

        private delegate void UpdateUIDelegate(int i, int max, float[] fitnessAfterMutation, bool found);
        private void UpdateUI(int i, int max, float[] fitnessAfterMutation, bool found)
        {
            if (lblPosition.InvokeRequired)
            {
                lv.Invoke(new UpdateUIDelegate(UpdateUI), i, max, fitnessAfterMutation, found);
            }
            else
            {
                progressBar.Value = (int)((i + 1f) * 100 / max);
                lblPosition.Text = string.Format("Generasi ke {0}", (i + 1).ToString(CultureInfo.InvariantCulture));


                //if(i == 0) lv.Items.Clear();
                float Rata2Fitness = 0;

                ListViewItem[] lvItems = new ListViewItem[populasi];
                for (int j = 0; j < populasi; j++)
                {
                    var lvItem = new ListViewItem((j + 1).ToString(CultureInfo.InvariantCulture));
                    lvItem.SubItems.Add(fitnessAfterMutation[j].ToString(CultureInfo.InvariantCulture));
                    lvItems[j] = lvItem;
                    Rata2Fitness += fitnessAfterMutation[j];
                }

                //lv.BeginUpdate();
                lv.Items.Clear();
                lv.Items.AddRange(lvItems);
                //lv.EndUpdate();

                lblRata2Fitness.Text = string.Format(
                    "Rata-rata Fitness: {0}",
                    (Rata2Fitness / populasi).ToString(CultureInfo.InvariantCulture));


                if (found)
                {
                    btnProses.Enabled = true;
                    DisableAllParamComponent(false);
                    btnStop.Enabled = false;

                    _dbConnect.ExecuteNonQuery("TRUNCATE TABLE jadwal_kuliah");

                    for (var k = 0; k < jadwal_kuliah.GetLength(0); k++)
                    {
                        var q = string.Format("INSERT INTO jadwal_kuliah(kode_pengampu,kode_jam,kode_hari,kode_ruang) " +
                                                  "VALUES({0},{1},{2},{3})",
                                                  jadwal_kuliah[k, 0], jadwal_kuliah[k, 1],
                                                  jadwal_kuliah[k, 2], jadwal_kuliah[k, 3]);

                        _dbConnect.ExecuteNonQuery(q);

                    }
                    //}

                    //tampilkan
                    const string query = "SELECT  e.nama as Hari," +
                                         "          Concat_WS('-',  concat('(', g.kode), concat( (SELECT kode" +  
                                         "                                  FROM jam " + 
                                         "                                  WHERE kode = (SELECT jm.kode " +
                                         "                                                FROM jam jm  " +
                                         "                                                WHERE MID(jm.range_jam,1,5) = MID(g.range_jam,1,5)) + (c.sks - 1)),')')) as SESI, " + 
                                         " 		  Concat_WS('-', MID(g.range_jam,1,5)," +
                                         "                (SELECT MID(range_jam,7,5) " +
                                         "                 FROM jam " +
                                         "                 WHERE kode = (SELECT jm.kode " +
                                         "                               FROM jam jm " +
                                         "                               WHERE MID(jm.range_jam,1,5) = MID(g.range_jam,1,5)) + (c.sks - 1))) as Jam_Kuliah, " +
                        
                                         "        c.nama as `Nama MK`," +
                                         "        c.sks as SKS," +
                                         "        c.semester as Smstr," +
                                         "        b.kelas as Kelas," +
                                         "        d.nama as Dosen," +
                                         "        f.nama as Ruang " +
                                         "FROM jadwal_kuliah a " +
                                         "LEFT JOIN pengampu b " +
                                         "ON a.kode_pengampu = b.kode " +
                                         "LEFT JOIN mata_kuliah c " +
                                         "ON b.kode_mk = c.kode " +
                                         "LEFT JOIN dosen d " +
                                         "ON b.kode_dosen = d.kode " +
                                         "LEFT JOIN hari e " +
                                         "ON a.kode_hari = e.kode " +
                                         "LEFT JOIN ruang f " +
                                         "ON a.kode_ruang = f.kode " +
                                         "LEFT JOIN jam g " +
                                         "ON a.kode_jam = g.kode " +
                                         "order by e.nama desc,Jam_Kuliah asc;";

                    var dt = _dbConnect.GetRecord(query);
                    dtGridView.DataSource = dt;
                }
            }

            if (i == max - 1)
            {
                btnProses.Enabled = true;
                DisableAllParamComponent(false);
                btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!worker.WorkerSupportsCancellation) return;
            worker.CancelAsync();
            btnProses.Enabled = true;
            DisableAllParamComponent(false);
            btnStop.Enabled = false;
        }

        private void FrmBuildJadwal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!worker.IsBusy) return;
            MessageBox.Show("Matikan dulu proses yang sedang berjalan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }

        private void FrmBuildJadwal_Load(object sender, EventArgs e)
        {

        }


    }
}
