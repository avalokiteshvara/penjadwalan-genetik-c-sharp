//#define SHOW_LOG
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;



namespace penjadwalan.Class
{

    internal class ClassGenetik
    {
        //TODO:NEED INTENSIVE ATTENTIONS
        #region Variables
        readonly ClassDbConnect _dbConnect = new ClassDbConnect();

        //
        private const string PRAKTIKUM = "PRAKTIKUM";
        private const string TEORI = "TEORI";
        private const string LABORATORIUM = "LABORATORIUM";


        private readonly int jenis_semester;
        private readonly string tahun_akademik;
        private readonly int populasi;
        private readonly float crossOver;
        private readonly float mutasi;

        private int[] mata_kuliah;
        private int[, ,] individu;
        private int[] sks; //sks terikat pada tabel pengampu
        private int[] dosen;//dosen terikat pada tabel pengampu

        private int[] jam;
        private int[] hari;
        private int[] iDosen;

        //waktu keinginan dosen
        private string[,] waktu_dosen;

        private string[] jenis_mk;//reguler or praktikum

        private int[] ruangLaboratorium;
        private int[] ruangReguler;

        private string logAmbilData;
        private string logInisialisasi;

        private string log;
        private int[] induk;


        //jumat
        private readonly int _kodeJumat;
        private readonly int[] _rangeJumat;

        private readonly int _kodeDhuhur;
        #endregion

        #region Constructor
        public ClassGenetik(
            int jenis_semester, string tahun_akademik, int populasi,
            float crossOver, float mutasi,
            int kodeJumat, int[] rangeJumat, int kodeDhuhur)
        {
            this.jenis_semester = jenis_semester;
            this.tahun_akademik = tahun_akademik;
            this.populasi = populasi;
            this.crossOver = crossOver;
            this.mutasi = mutasi;
            this._kodeJumat = kodeJumat;
            this._rangeJumat = rangeJumat;
            this._kodeDhuhur = kodeDhuhur;
        }
        #endregion

        #region Ambil data
        public void AmbilData()
        {
            //Fill  Array of mata kuliah and SKS Variables

#if(SHOW_LOG)
            logAmbilData += string.Format("\r===========================[{0}] => Ambil Data....\n", DateTime.Now.ToString("HH:mm:ss.fff tt"));
#endif
            var dtMK_Pengampu = _dbConnect.GetRecord(string.Format(
                "SELECT a.kode," +
                "       b.sks," +
                "       a.kode_dosen," +
                "       b.jenis " +
                "FROM pengampu a " +
                "LEFT JOIN mata_kuliah b " +
                "ON a.kode_mk = b.kode " +
                "WHERE b.semester%2 = {0} AND a.tahun_akademik = '{1}'",
                jenis_semester, tahun_akademik));
            mata_kuliah = new int[dtMK_Pengampu.Rows.Count];
            sks = new int[dtMK_Pengampu.Rows.Count];
            dosen = new int[dtMK_Pengampu.Rows.Count];
            jenis_mk = new string[dtMK_Pengampu.Rows.Count];

            for (var i = 0; i < dtMK_Pengampu.Rows.Count; i++)
            {
                mata_kuliah[i] = (int)dtMK_Pengampu.Rows[i][0];
                sks[i] = (int)dtMK_Pengampu.Rows[i][1];
                dosen[i] = (int)dtMK_Pengampu.Rows[i][2];
                jenis_mk[i] = dtMK_Pengampu.Rows[i][3].ToString();//reguler or praktikum
            }

            //Fill Array of Jam Variables 
            var dtJam = _dbConnect.GetRecord("SELECT kode " +
                                             "FROM jam");
            jam = new int[dtJam.Rows.Count];
            for (var i = 0; i < dtJam.Rows.Count; i++)
            {
                jam[i] = (int)dtJam.Rows[i][0];
            }

            //Fill Array of Hari Variables 
            var dtHari = _dbConnect.GetRecord("SELECT kode " +
                                              "FROM hari " +
                                              "WHERE aktif = 'True'");
            hari = new int[dtHari.Rows.Count];
            for (var i = 0; i < dtHari.Rows.Count; i++)
            {
                hari[i] = (int)dtHari.Rows[i][0];
            }

            var dtRuangReguler = _dbConnect.GetRecord(
                string.Format("SELECT kode " +
                              "FROM ruang " +
                              "WHERE jenis = '{0}'", TEORI));
            ruangReguler = new int[dtRuangReguler.Rows.Count];
            for (int i = 0; i < dtRuangReguler.Rows.Count; i++)
            {
                ruangReguler[i] = (int)dtRuangReguler.Rows[i][0];
            }

            var dtRuangLaboratorium = _dbConnect.GetRecord(
                string.Format("SELECT kode " +
                              "FROM ruang " +
                              "WHERE jenis = '{0}'", LABORATORIUM));
            ruangLaboratorium = new int[dtRuangLaboratorium.Rows.Count];
            for (int i = 0; i < dtRuangLaboratorium.Rows.Count; i++)
            {
                ruangLaboratorium[i] = (int)dtRuangLaboratorium.Rows[i][0];
            }

            var dtWaktuDosen = _dbConnect.GetRecord("SELECT kode_dosen, " +
                                                    "CONCAT_WS(':',kode_hari,kode_jam) " +
                                                    "FROM waktu_tidak_bersedia");
            waktu_dosen = new string[dtWaktuDosen.Rows.Count, 2];
            iDosen = new int[dtWaktuDosen.Rows.Count];

            for (var i = 0; i < dtWaktuDosen.Rows.Count; i++)
            {
                iDosen[i] = (int)dtWaktuDosen.Rows[i][0];
                waktu_dosen[i, 0] = dtWaktuDosen.Rows[i][0].ToString(); //kode dosen
                waktu_dosen[i, 1] = dtWaktuDosen.Rows[i][1].ToString(); //CONCAT_WS(':',kode_hari,kode_jam)
            }

#if(SHOW_LOG)
            logAmbilData += string.Format(
                   "Jumlah MataKuliah: {0}\n" +
                   "Jumlah Jam: {1}\n" +
                   "Jumlah Hari: {2}\n" +
                   "Jumlah Ruang: {3}\n",
                   dtMK_Pengampu.Rows.Count, dtJam.Rows.Count,
                   dtHari.Rows.Count, dtRuangReguler.Rows.Count + dtRuangLaboratorium.Rows.Count);
#endif
        }
        #endregion

        #region WriteLog2Disk

        public void WriteLog2Disk()
        {
            var filepath = string.Format("{0}\\log.txt", Path.GetDirectoryName(Application.ExecutablePath));
            if (true) File.WriteAllText(filepath, logAmbilData + logInisialisasi + log);
        }

        #endregion

        #region Inisialisasi
        public void Inisialisasi()
        {
            var random = new Random();
            individu = new int[populasi, mata_kuliah.Length, 4];

#if(SHOW_LOG)
            logInisialisasi += string.Format("\r===========================[{0}] => Ambil Nilai Parameter....\n", DateTime.Now.ToString("HH:mm:ss.fff tt"));
            logInisialisasi += string.Format("Populasi: {0}\n" +
                                 "Crossover: {1}\n" +
                                 "Mutasi: {2}", populasi, crossOver, mutasi);

#endif

            for (var i = 0; i < populasi; i++)
            {
#if(SHOW_LOG)
                logInisialisasi += string.Format(
                    "\r\n\n[{0}] => Individu Ke-{1} #MK,JAM,HARI,RUANG",
                    DateTime.Now.ToString("HH:mm:ss.fff tt"), (i + 1));
#endif

                for (var j = 0; j < mata_kuliah.Length; j++)
                {
                    //  Perulangan untuk pembangkitan jadwal 
                    individu[i, j, 0] = j; // Penentuan matakuliah dan kelas 

                    if (sks[j] == 1)// Penentuan jam secara acak ketika 1 sks 
                    { individu[i, j, 1] = random.Next(jam.Length); }
                    if (sks[j] == 2) // Penentuan jam secara acak ketika 2 sks 
                    { individu[i, j, 1] = random.Next(jam.Length - 1); }
                    if (sks[j] == 3) // Penentuan jam secara acak ketika 3 sks 
                    { individu[i, j, 1] = random.Next(jam.Length - 2); }
                    if (sks[j] == 4) // Penentuan jam secara acak ketika 4 sks 
                    { individu[i, j, 1] = random.Next(jam.Length - 3); }
                    //System.Threading.Thread.Sleep(1);
                    individu[i, j, 2] = random.Next(hari.Length); // Penentuan hari secara acak 
                    //TODO: jika kuliah reguler => ruang reguler
                    //TODO: jika kuliah praktikum => ruang lab 

                    //individu[i, j, 3] = random.Next(ruang.Length); // Penentuan ruang secara acak 
                    if (jenis_mk[j] == TEORI)
                    {
                        individu[i, j, 3] = ruangReguler[random.Next(ruangReguler.Length)];
                    }
                    else
                    {
                        individu[i, j, 3] = ruangLaboratorium[random.Next(ruangLaboratorium.Length)];
                    }

#if(SHOW_LOG)
                    logInisialisasi += "\r\nKromosom " + (j + 1) + " = " +
                           mata_kuliah[individu[i, j, 0]] + "," +
                           jam[individu[i, j, 1]] + "," +
                           hari[individu[i, j, 2]] + "," +
                           individu[i, j, 3];
#endif

                }
            }
        }
        #endregion

        private float CekFitness(int indv)
        {
            //float[,] penalty = new float[populasi, 6];
            float penalty1 = 0, penalty2 = 0, penalty3 = 0, penalty4 = 0, penalty5 = 0;


            for (var i = 0; i < mata_kuliah.Length; i++)
            {
                for (var j = 0; j < mata_kuliah.Length; j++)//1.bentrok ruang dan waktu dan 3.bentrok dosen
                {
                    //ketika pemasaran matakuliah sama, maka langsung ke perulangan berikutnya
                    if (i == j) continue;

                    #region Bentrok Ruang dan Waktu
                    //Ketika jam,hari dan ruangnya sama, maka penalty + satu 
                    if (
                        (individu[indv, i, 1] == individu[indv, j, 1]) &&
                        (individu[indv, i, 2] == individu[indv, j, 2]) &&
                        (individu[indv, i, 3] == individu[indv, j, 3])
                        )
                    {
#if(SHOW_LOG)
                        log += string.Format("\nHardConstraint[1#A] => Individu ke-{0} ", (indv + 1));
                        log += string.Format(
                            "Kromosom {0} [{1},{2},{3},{4}] == Kromosom {5} [{6},{7},{8},{9}]",
                            (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                            (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3]
                            );
#endif
                        penalty1 += 1;
                    }

                    //Ketika sks lebih dari 1, 
                    //hari dan ruang sama, dan 
                    //jam kedua sama dengan jam pertama matakuliah yang lain, maka penalty + 1
                    if (sks[i] >= 2)
                    {
                        if (
                            (individu[indv, i, 1] + 1 == individu[indv, j, 1]) &&
                            (individu[indv, i, 2] == individu[indv, j, 2]) &&
                            (individu[indv, i, 3] == individu[indv, j, 3])
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[1#B] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                "Kromosom {0} [{1},{2},{3},{4}][SKS={10}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                sks[1], sks[j]
                                );
#endif

                            penalty1 += 1;
                        }
                    }

                    //Ketika sks lebih dari 2, 
                    //hari dan ruang sama dan 
                    //jam ketiga sama dengan jam pertama matakuliah yang lain, maka penalty + 1
                    if (sks[i] >= 3)
                    {
                        if (
                            (individu[indv, i, 1] + 2 == individu[indv, j, 1]) &&
                            (individu[indv, i, 2] == individu[indv, j, 2]) &&
                            (individu[indv, i, 3] == individu[indv, j, 3])
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[1#C] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                 "Kromosom {0} [{1},{2},{3},{4}][SKS={10}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                sks[1], sks[j]
                                );
#endif
                            penalty1 += 1;
                        }
                    }

                    //Ketika sks lebih dari 3, 
                    //hari dan ruang sama dan 
                    //jam keempat sama dengan jam pertama matakuliah yang lain, maka penalty + 1
                    if (sks[i] >= 4)
                    {
                        if (
                            (individu[indv, i, 1] + 3 == individu[indv, j, 1]) &&
                            (individu[indv, i, 2] == individu[indv, j, 2]) &&
                            (individu[indv, i, 3] == individu[indv, j, 3])
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[1#D] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                 "Kromosom {0} [{1},{2},{3},{4}][SKS={10}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                sks[1], sks[j]
                                );
#endif
                            penalty1 += 1;
                        }
                    }

                    #endregion
                    //______________________BENTROK DOSEN

                    #region Bentrok Dosen

                    if (
                        //ketika jam sama
                        individu[indv, i, 1] == individu[indv, j, 1] &&
                        //dan hari sama
                        individu[indv, i, 2] == individu[indv, j, 2] &&
                        //dan dosennya sama
                        dosen[i] == dosen[j]
                        )
                    {
                        //maka...
#if(SHOW_LOG)
                        log += string.Format("\nHardConstraint[3#A] => Individu ke-{0} ", (indv + 1));
                        log += string.Format(
                                 "Kromosom {0} [{1},{2},{3},{4}][SKS={10}][DOSEN={12}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}][DOSEN={13}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                sks[1], sks[j], dosen[i], dosen[j]
                                );
#endif
                        penalty3 += 1;
                    }

                    if (
                        //jika lebih dari 1 SKS
                        sks[i] >= 2
                        )
                    {
                        if (
                            //jam ke-2 == dengan jam ke-1 mk yang lain
                            (individu[indv, i, 1] + 1) == (individu[indv, j, 1]) &&
                            //dan hari sama
                            (individu[indv, i, 2]) == (individu[indv, j, 2]) &&
                            //dan dosen sama
                            dosen[i] == dosen[j]
                            )
                        {
                            //maka...
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[3#B] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                     "Kromosom {0} [{1},{2},{3},{4}][SKS={10}][DOSEN={12}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}][DOSEN={13}]",
                                    (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                    (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                    sks[1], sks[j], dosen[i], dosen[j]
                                    );
#endif
                            penalty3 += 1;
                        }
                    }

                    if (
                        //jika lebih dari 2 SKS
                        sks[i] >= 3
                        )
                    {
                        if (
                            //jam ke-3 == dengan jam ke-1 mk yang lain
                            (individu[indv, i, 1] + 2) == (individu[indv, j, 1]) &&
                            //dan hari sama
                            (individu[indv, i, 2]) == (individu[indv, j, 2]) &&
                            //dan dosen sama
                            dosen[i] == dosen[j]
                            )
                        {
                            //maka...
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[3#C] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                     "Kromosom {0} [{1},{2},{3},{4}][SKS={10}][DOSEN={12}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}][DOSEN={13}]",
                                    (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                    (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                    sks[1], sks[j], dosen[i], dosen[j]
                                    );
#endif
                            penalty3 += 1;
                        }
                    }

                    if (
                        //jika lebih dari 3 SKS
                        sks[i] >= 4
                        )
                    {
                        if (
                            //jam ke-4 == dengan jam ke-1 mk yang lain
                            (individu[indv, i, 1] + 3) == (individu[indv, j, 1]) &&
                            //dan hari sama
                            (individu[indv, i, 2]) == (individu[indv, j, 2]) &&
                            //dan dosen sama
                            dosen[i] == dosen[j]
                            )
                        {
                            //maka...
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[3#D] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                     "Kromosom {0} [{1},{2},{3},{4}][SKS={10}][DOSEN={12}] == Kromosom {5} [{6},{7},{8},{9}][SKS={11}][DOSEN={13}]",
                                    (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]], hari[individu[indv, i, 2]], individu[indv, i, 3],
                                    (j + 1), mata_kuliah[individu[indv, j, 0]], jam[individu[indv, j, 1]], hari[individu[indv, j, 2]], individu[indv, j, 3],
                                    sks[1], sks[j], dosen[i], dosen[j]
                                    );
#endif
                            penalty3 += 1;
                        }
                    }
                    #endregion
                }//end 1.bentrok ruang dan waktu dan 3.bentrok dosen

                #region Bentrok sholat Jumat
                if (individu[indv, i, 2] + 1 == (_kodeJumat)) //2.bentrok sholat jumat
                {
                    //int x = individu[indv, i, 2];
                    if (sks[i] == (1))
                    {
                        if (
                            individu[indv, i, 1] == (_rangeJumat[0] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[1] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[2] - 1)
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[2#SKS = 1] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                "Kromosom {0} [{1},{2},{3},{4}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]],
                                hari[individu[indv, i, 2]], individu[indv, i, 3]
                                );
#endif
                            penalty2 += 1;
                        }
                    }

                    if (sks[i] == (2))
                    {
                        if (
                            individu[indv, i, 1] == (_rangeJumat[0] - 2) ||
                            individu[indv, i, 1] == (_rangeJumat[0] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[1] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[2] - 1)
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[2#SKS = 2] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                "Kromosom {0} [{1},{2},{3},{4}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]],
                                hari[individu[indv, i, 2]], individu[indv, i, 3]
                                );
#endif
                            penalty2 += 1;
                        }
                    }

                    if (sks[i] == (3))
                    {
                        if (
                            individu[indv, i, 1] == (_rangeJumat[0] - 3) ||
                            individu[indv, i, 1] == (_rangeJumat[0] - 2) ||
                            individu[indv, i, 1] == (_rangeJumat[0] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[1] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[2] - 1)
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[2#SKS = 3] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                "Kromosom {0} [{1},{2},{3},{4}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]],
                                hari[individu[indv, i, 2]], individu[indv, i, 3]
                                );
#endif
                            penalty2 += 1;
                        }
                    }

                    if (sks[i] == (4))
                    {
                        if (
                            individu[indv, i, 1] == (_rangeJumat[0] - 4) ||
                            individu[indv, i, 1] == (_rangeJumat[0] - 3) ||
                            individu[indv, i, 1] == (_rangeJumat[0] - 2) ||
                            individu[indv, i, 1] == (_rangeJumat[0] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[1] - 1) ||
                            individu[indv, i, 1] == (_rangeJumat[2] - 1)
                            )
                        {
#if(SHOW_LOG)
                            log += string.Format("\nHardConstraint[2#SKS = 4] => Individu ke-{0} ", (indv + 1));
                            log += string.Format(
                                "Kromosom {0} [{1},{2},{3},{4}]",
                                (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]],
                                hari[individu[indv, i, 2]], individu[indv, i, 3]
                                );
#endif
                            penalty2 += 1;
                        }
                    }
                }
                #endregion

                #region Bentrok dengan Waktu Keinginan Dosen


                //Boolean penaltyForKeinginanDosen = false;
                for (int j = 0; j < iDosen.Length; j++)
                {
                    if (dosen[i] == iDosen[j])
                    {
                        string[] hari_jam = waktu_dosen[j, 1].Split(':');

                        if (
                            jam[individu[indv, i, 1]].ToString(CultureInfo.InvariantCulture) == hari_jam[1] &&
                            hari[individu[indv, i, 2]].ToString(CultureInfo.InvariantCulture) == hari_jam[0]
                            )
                        {
                            //penaltyForKeinginanDosen = true;
#if(SHOW_LOG)
                            log += string.Format(
                                "\nHardConstraint[4] => Individu ke {0} Kromosom {1}[{2},{3},{4},{5}][Dosen = {6}]",
                                (indv + 1), (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]],
                                hari[individu[indv, i, 2]], individu[indv, i, 3], iDosen[j]);
#endif
                            penalty4 += 1;

                        }
                    }
                }

                #endregion

                #region Bentrok waktu dhuhur
                if (individu[indv, i, 1] == (_kodeDhuhur - 1))
                {
#if(SHOW_LOG)
                    log += string.Format(
                                "\nHardConstraint[5] => Individu ke {0} Kromosom {1}[{2},{3},{4},{5}][Dosen = {6}]",
                                (indv + 1), (i + 1), mata_kuliah[individu[indv, i, 0]], jam[individu[indv, i, 1]],
                                hari[individu[indv, i, 2]], individu[indv, i, 3], dosen[i]);
#endif
                    penalty5 += 1;
                }


                #endregion
            }

#if(SHOW_LOG)
            log += string.Format("\nPenalty Individu ke-{0} : {1} \n", (indv + 1), penalty1 + penalty2 + penalty3 + penalty4 + penalty5);
#endif


            float fitness = 1 / (1 + (penalty1 + penalty2 + penalty3 + penalty4 + penalty5));

            return fitness;
        }

        #region Hitung Fitness

        public float[] HitungFitness()
        {
            //hard constraint
            //1.bentrok ruang dan waktu
            //2.bentrok sholat jumat
            //3.bentrok dosen
            //4.bentrok keinginan waktu dosen 
            //5.bentrok waktu dhuhur 
            //=>6.praktikum harus pada ruang lab {telah ditetapkan dari awal perandoman
            //    bahwa jika praktikum harus ada pada LAB dan mata kuliah reguler harus 
            //    pada kelas reguler


            //soft constraint //TODO

            log = null;

            float[] fitness = new float[populasi];

#if(SHOW_LOG)
            log += "\n\n=========================== HITUNG FITNESS";
            log += "\nRule:\n" +
                   "Hard Constraint:\n" +
                   "[1] => Bentrok ruang dan Waktu\n" +
                   "[1#A] => jam,hari dan ruangnya sama\n" +
                   "[1#B] => sks lebih dari 1 + hari dan ruang sama + jam kedua sama dengan jam pertama matakuliah yang lain\n" +
                   "[1#C] => sks lebih dari 2 + hari dan ruang sama + jam ketiga sama dengan jam pertama matakuliah yang lain\n" +
                   "[1#D] => sks lebih dari 3 + hari dan ruang sama + jam keempat sama dengan jam pertama matakuliah yang lain\n" +
                   "[2] => Bentrok sholat jumat\n" +
                   "[2#SKS = 1] => sks = 1\n" +
                   "[2#SKS = 2] => sks = 2\n" +
                   "[2#SKS = 3] => sks = 3\n" +
                   "[2#SKS = 4] => sks = 4\n" +
                   "[3] => Bentrok Dosen\n" +
                   "[3#SKS = 1] => sks = 1\n" +
                   "[3#SKS = 2] => sks = 2\n" +
                   "[3#SKS = 3] => sks = 3\n" +
                   "[3#SKS = 4] => sks = 4\n" +
                   "[4] => bentrok keinginan waktu dosen\n";
#endif

            for (var indv = 0; indv < populasi; indv++)
            {
                //Cek Fitness
                fitness[indv] = CekFitness(indv);
#if(SHOW_LOG)
                log += string.Format(
                    "Fitness Individu ke-{0} : {1} \n", (indv + 1), fitness[indv]);
#endif
            }

            //~~~~~buble sort~~~~~~
            string[] sort = new string[populasi];
            //fill the data
            //

#if(SHOW_LOG)
            log += "\nReview Penalty dan Fitness: (Best Fitness => Worst Fitness)";
#endif

            for (int i = 0; i < populasi; i++)
            {
                sort[i] = string.Format("\nIndividu {0} :Fitness {1}",
                    (i + 1), fitness[i]);
            }

            try
            {
                bool swapped = true;
                while (swapped)
                {
                    swapped = false;
                    for (int i = 0; i < populasi - 1; i++)
                    {
                        string[] strI = sort[i].Split('.');
                        float fitI = float.Parse(string.Format("0.{0}", strI[1]));

                        string[] strJ = sort[i + 1].Split('.');
                        float fitJ = float.Parse(string.Format("0.{0}", strJ[1]));

                        if (fitI < fitJ)
                        {
                            string sTmp = sort[i];
                            sort[i] = sort[i + 1];
                            sort[i + 1] = sTmp;
                            swapped = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kemungkinan data tidak ada untuk Tahun Akademik dan Semester yang terpilih!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

#if(SHOW_LOG)
            for (var i = 0; i < populasi; i++)
            {
                log += sort[i];
            }
#endif
            return fitness;
        }

        #endregion

        #region Seleksi
        public void Seleksi(float[] fitness)
        {
            var jumlah = 0;
            int[] rank = new int[populasi];
            induk = new int[populasi];

#if(SHOW_LOG)
            log += "\n\n";
#endif

            for (var i = 0; i < populasi; i++)
            {  //proses ranking berdasarkan nilai fitness
                rank[i] = 1;
                for (var j = 0; j < populasi; j++)
                {   //ketika nilai fitness jadwal sekarang lebih dari nilai fitness jadwal yang lain,
                    //ranking + 1;
                    //if (i == j) continue;

                    if (fitness[i] > fitness[j])
                    {
                        rank[i] += 1;
                    }
                }
#if(SHOW_LOG)
                log += string.Format("Ranking individu {0} = {1}\n", (i + 1), rank[i]);
#endif
                jumlah += rank[i];
            }
#if(SHOW_LOG)
            log += string.Format("[jumlah:{0}] ", jumlah);
#endif
            var random = new Random();

#if(SHOW_LOG)
            log += "\r\n\nProses Seleksi:\r\n" +
                   "Induk terpilih: ";
#endif

            for (var i = 0; i < induk.Length; i++)
            {
                //proses seleksi berdasarkan ranking yang telah dibuat
                //int nexRandom = random.Next(1, jumlah);
                //random = new Random(nexRandom);
                var target = random.Next(jumlah);
                var cek = 0;
                for (var j = 0; j < rank.Length; j++)
                {
                    cek += rank[j];
                    if (cek >= target)
                    {
                        induk[i] = j;
#if(SHOW_LOG)
                        log += string.Format("Individu {0} , ", (j + 1));
#endif
                        break;
                    }
                }
            }
        }
        #endregion

        public void StartCrossOver()
        {
#if(SHOW_LOG)
            log += string.Format("\r\n\r\n===========================PROSES CROSSOVER / PINDAH SILANG (CrossOver values = {0})", crossOver);
#endif

            int[, ,] individu_baru = new int[populasi, mata_kuliah.Length, 4];

            var random = new Random();

            for (int i = 0; i < populasi; i += 2) //perulangan untuk jadwal yang terpilih
            {
                int b = 0;
                int nexRandom = random.Next(1, 1000);
                random = new Random(nexRandom);
                double cr = random.NextDouble();

                if (cr < crossOver)
                {
                    //ketika nilai random kurang dari nilai probabilitas pertukaran
                    //maka jadwal mengalami prtukaran

                    int a = random.Next(mata_kuliah.Length - 1);
                    while (b <= a)
                    {
                        b = random.Next(mata_kuliah.Length);
                    }

                    //penentuan jadwal baru dari awal sampai titik pertama
                    for (int j = 0; j < a; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            individu_baru[i, j, k] = individu[induk[i], j, k];
                            individu_baru[i + 1, j, k] = individu[induk[i + 1], j, k];
                        }
                    }

                    //Penentuan jadwal baru dai titik pertama sampai titik kedua
                    for (int j = a; j < b; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            individu_baru[i, j, k] = individu[induk[i + 1], j, k];
                            individu_baru[i + 1, j, k] = individu[induk[i], j, k];
                        }
                    }

                    //penentuan jadwal baru dari titik kedua sampai akhir
                    for (int j = b; j < mata_kuliah.Length; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            individu_baru[i, j, k] = individu[induk[i], j, k];
                            individu_baru[i + 1, j, k] = individu[induk[i + 1], j, k];
                        }
                    }
#if(SHOW_LOG)
                    log += string.Format("\r\nNilai Random = {0}, maka CrossOver terjadi antara induk {1} dengan induk {2} pada titik {3} dan titik {4}", cr, (i + 1), (i + 2), (a + 1), (b + 1));
#endif
                }
                else
                {//Ketika nilai random lebih dari nilai probabilitas pertukaran, maka jadwal baru sama dengan jadwal terpilih
                    for (int j = 0; j < mata_kuliah.Length; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            individu_baru[i, j, k] = individu[induk[i], j, k];
                            individu_baru[i + 1, j, k] = individu[induk[i + 1], j, k];
                        }
                    }
#if(SHOW_LOG)
                    log += string.Format("\r\nNilai random = {0}, maka CrossOver TIDAK TERJADI antara induk {1} dengan induk {2}", cr, (i + 1), (i + 2));
#endif
                }
            }

            //tampilkan individu baru
#if(SHOW_LOG)
            for (int i = 0; i < populasi; i++)
            {

                log += string.Format(
                    "\r\n\n[{0}] => Individu Baru Ke-{1} #MK,JAM,HARI,RUANG",
                    DateTime.Now.ToString("HH:mm:ss.fff tt"), (i + 1));

                for (int j = 0; j < mata_kuliah.Length; j++)
                {
                    log += "\r\nKromosom " + (j + 1) + " = " +
                           mata_kuliah[individu_baru[i, j, 0]] + "," +
                           jam[individu_baru[i, j, 1]] + "," +
                           hari[individu_baru[i, j, 2]] + "," +
                           individu_baru[i, j, 3];
                }

            }
#endif

            individu = new int[populasi, mata_kuliah.Length, 4];
            Array.Copy(individu_baru, individu, individu_baru.Length);
        }


        public float[] Mutasi()
        {
            float[] fitness = new float[populasi];

#if(SHOW_LOG)
            log += "\r\n\r===========================PROSES MUTASI / PENGGANTIAN KOMPONEN PENJADWALAN SECARA ACAK:\n";
#endif


            var random = new Random();
            //proses perandoman atau penggantian komponen untuk tiap jadwal baru
            for (int i = 0; i < populasi; i++)
            {
                int nexRandom = random.Next(1, 1000);
                random = new Random(nexRandom);
                double r = random.NextDouble();
                //System.Threading.Thread.Sleep(20);
#if(SHOW_LOG)
                string msg = "TIDAK terjadi mutasi";
#endif
                //Ketika nilai random kurang dari nilai probalitas Mutasi, 
                //maka terjadi penggantian komponen
                if (r < mutasi)
                {
                    //Penentuan pada matakuliah dan kelas yang mana yang akan dirandomkan atau diganti
                    int krom = random.Next(mata_kuliah.Length);

                    switch (sks[krom])
                    {
                        case 1:
                            individu[i, krom, 1] = random.Next(jam.Length);
                            break;
                        case 2:
                            individu[i, krom, 1] = random.Next(jam.Length - 1);
                            break;
                        case 3:
                            individu[i, krom, 1] = random.Next(jam.Length - 2);
                            break;
                        case 4:
                            individu[i, krom, 1] = random.Next(jam.Length - 3);
                            break;
                    }
                    //Proses penggantian hari
                    individu[i, krom, 2] = random.Next(hari.Length);

                    //proses penggantian ruang
                    //individu[i, krom, 3] = random.Next(ruang.Length);

                    if (jenis_mk[krom] == TEORI)
                    {
                        individu[i, krom, 3] = ruangReguler[random.Next(ruangReguler.Length)];
                    }
                    else
                    {
                        individu[i, krom, 3] = ruangLaboratorium[random.Next(ruangLaboratorium.Length)];
                    }

#if(SHOW_LOG)
                    msg = string.Format("terjadi mutasi, pada kromosom ke {0}", (krom + 1));
#endif
                }
                fitness[i] = CekFitness(i);


#if(SHOW_LOG)
                log += string.Format("Individu {0}: Nilai Random = {1}, maka {2} (Fitness = {3})\n\n", (i + 1), r, msg, fitness[i]);
#endif
            }
            return fitness;
        }


        public int[,] GetIndividu(int indv)
        {
            //return individu;

            int[,] individu_solusi = new int[mata_kuliah.Length, 4];

            for (int j = 0; j < mata_kuliah.Length; j++)
            {
                individu_solusi[j, 0] = mata_kuliah[individu[indv, j, 0]];
                individu_solusi[j, 1] = jam[individu[indv, j, 1]];
                individu_solusi[j, 2] = hari[individu[indv, j, 2]];
                individu_solusi[j, 3] = individu[indv, j, 3];
               
            }

            return individu_solusi;
        }

    }
}
