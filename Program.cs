using System;

namespace Tugas2Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Mau cek gaji? Yuk pilih tipe karyawanmu dulu!");
            Console.WriteLine("\n1. Karyawan Tetap\n2. Karyawan Kontrak\n3. Karyawan Magang");

            string inputKaryawan = Validasi.ValidasiPilihanKaryawan();
            string nama = Validasi.ValidasiNama();
            string id = Validasi.ValidasiID();
            double inputGajiPokok = Validasi.ValidasiGajiPokok();

            Karyawan karyawan;

            switch (inputKaryawan)
            {
                case "1":
                    karyawan = new KaryawanTetap(nama, id, inputGajiPokok);
                    break;
                case "2":
                    karyawan = new KaryawanKontrak(nama, id, inputGajiPokok);
                    break;
                case "3":
                    karyawan = new KaryawanMagang(nama, id, inputGajiPokok);
                    break;
                default:
                    throw new InvalidOperationException("Pilihan karyawan tidak valid");
            }

            double gajiAkhir = karyawan.HitungGaji();
            Validasi.DetailGajiAkhir(inputKaryawan, nama, id, gajiAkhir);
        }
    }
}

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }
    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        Nama = nama;
        ID = id;
        GajiPokok = gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok - BonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok + PotonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.HitungGaji();
    }
}

class Validasi
{
    public static string ValidasiNama()
    {
        string inputNama;
        while (true)
        {
            Console.Write("Halo, ayo masukkan nama kamu disini: ");

            inputNama = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(inputNama))
            {
                if (inputNama.Length < 4)
                {
                    Console.WriteLine("\nYah, nama yang kamu masukkan terlalu pendek. Ayo coba lagi!");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nWaduh, nama yang kamu masukkan tidak boleh kosong!");
            }
        }
        return inputNama;
    }

    public static string ValidasiID()
    {
        string inputId;
        while (true)
        {
            Console.Write("Masukkan ID Karyawan kamu disini: ");
            inputId = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(inputId))
            {
                if (inputId.Length < 3)
                {
                    Console.WriteLine("\nID karyawan yang kamu masukkan terlalu pendek. Ayo coba lagi!");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nID karyawan yang kamu masukkan tidak boleh kosong!");
            }
        }

        return inputId;
    }

    public static string ValidasiPilihanKaryawan()
    {
        string pilihKaryawan;

        while (true)
        {
            Console.Write("Masukkan pilihan tipe karyawan kamu disini (1/2/3): ");
            pilihKaryawan = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(pilihKaryawan))
            {
                if (pilihKaryawan == "1" || pilihKaryawan == "2" || pilihKaryawan == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nWaduh, tipe karyawan yang kamu pilih tidak ada! Coba pilih lagi (1/2/3): ");
                }
            }
            else
            {
                Console.WriteLine("\nPilihan yang kamu masukkan tidak boleh kosong.");
            }
        }

        return pilihKaryawan;
    }

    public static double ValidasiGajiPokok()
    {
        double inputGaji;

        while (true)
        {
            Console.Write("Masukkan gaji pokok kamu disini: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out inputGaji))
            {
                if (inputGaji > 0 )
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nGaji tidak boleh kurang dari atau sama dengan 0!");
                }
            }
            else
            {
                Console.WriteLine("\nInput gaji tidak valid. Masukkan angka yang benar.");
            }
        }

        return inputGaji;
    }

    public static void DetailGajiAkhir(string tipeKaryawan, string nama, string id, double gajiAkhir)
    {
        Console.WriteLine($"Halo Kak {nama}!");
        Console.Write($"Kamu adalah ");
        if (tipeKaryawan == "1")
        {
            Console.Write("Karyawan Tetap\n");
        }
        else if (tipeKaryawan == "2")
        {
            Console.Write("Karyawan Kontrak\n");
        }
        else
        {
            Console.Write("Karyawan Magang\n");
        }
        Console.WriteLine($"ID Karyawan: {id}");
        Console.WriteLine($"Total Gaji Akhir: Rp. {gajiAkhir}");
    }
}
