using System;
using System.Collections.Generic;

// SOAL 1
class Agen
{
    public string idAgen;
    public string namaAgen;
    public int stokAgen;

    public void TampilInfo()
    {
        Console.WriteLine("ID Agen   : " + idAgen);
        Console.WriteLine("Nama Agen : " + namaAgen);
        Console.WriteLine("Stok Agen : " + stokAgen);
    }
}

// SOAL 2
abstract class ProdukGalon
{
    private string idProduk;
    private string namaProduk;
    private int stokGudang;

    public string IdProduk
    {
        get { return idProduk; }
        set { idProduk = value; }
    }

    public string NamaProduk
    {
        get { return namaProduk; }
        set { namaProduk = value; }
    }

    public int StokGudang
    {
        get { return stokGudang; }
        private set { stokGudang = value; }
    }

    public ProdukGalon(string id, string nama, int stok)
    {
        if (stok < 0)
        {
            throw new ArgumentException(
                "Stok tidak boleh negatif!"
            );
        }

        idProduk = id;
        namaProduk = nama;
        stokGudang = stok;
    }

    public bool KurangiStok(int jumlah)
    {
        if (jumlah <= 0)
        {
            return false;
        }

        if (jumlah > stokGudang)
        {
            return false;
        }

        stokGudang -= jumlah;
        return true;
    }

    // ABSTRACT CLASS
    public abstract int HitungBiaya(int jumlah);
}


// SOAL 3
class GalonAkua : ProdukGalon
{
    public GalonAkua(string id, string nama, int stok)
        : base(id, nama, stok)
    {
    }

    // SOAL 4 (POLYMORPHISM)
    public override int HitungBiaya(int jumlah)
    {
        return jumlah * 20000;
    }
}

class GalonBerkeran : ProdukGalon
{
    public string JenisKeran { get; set; }

    public GalonBerkeran(
        string id,
        string nama,
        int stok,
        string jenisKeran
    ) : base(id, nama, stok)
    {
        JenisKeran = jenisKeran;
    }

    // SOAL 4 (POLYMORPHISM)
    public override int HitungBiaya(int jumlah)
    {
        return jumlah * 12000;
    }
}


// SOAL 6
interface DapatDidistribusikan
{
    void KirimPaket();
}


class DistribusiGalon : DapatDidistribusikan
{
    private Agen agenTujuan;
    private ProdukGalon produk;
    private int jumlah;

    public DistribusiGalon(
        Agen agen,
        ProdukGalon produk,
        int jumlah
    )
    {
        agenTujuan = agen;
        this.produk = produk;
        this.jumlah = jumlah;
    }

    public void KirimPaket()
    {
        Console.WriteLine("\n=== PROSES DISTRIBUSI ===");

        if (jumlah <= 0)
        {
            Console.WriteLine(
                "Gagal: Jumlah harus lebih dari 0."
            );
            return;
        }

        if (jumlah > produk.StokGudang)
        {
            Console.WriteLine(
                "Gagal: Stok gudang tidak mencukupi."
            );
            return;
        }

        bool berhasil = produk.KurangiStok(jumlah);

        if (berhasil)
        {
            agenTujuan.stokAgen += jumlah;

            Console.WriteLine(
                "Paket berhasil dikirimkan ke agen "
                + agenTujuan.namaAgen
            );

            Console.WriteLine(
                "Jumlah dikirim: " + jumlah
            );

            Console.WriteLine(
                "Sisa stok gudang: " + produk.StokGudang
            );

            Console.WriteLine(
                "Stok agen sekarang: " + agenTujuan.stokAgen
            );
        }
    }
}

// SOAL 7 (OPSIONAL)
class SindikatGalon
{
    private List<Agen> daftarAgen = new List<Agen>();

    private List<ProdukGalon> daftarProduk =
        new List<ProdukGalon>();

    public void TambahAgen(Agen agen)
    {
        daftarAgen.Add(agen);
    }

    public void TambahProduk(ProdukGalon produk)
    {
        daftarProduk.Add(produk);
    }

    public void TampilkanSindikat()
    {
        Console.WriteLine("\n=== DATA ASET SINDIKAT ===");

        Console.WriteLine("\n--- DAFTAR AGEN ---");

        foreach (Agen agen in daftarAgen)
        {
            agen.TampilInfo();
            Console.WriteLine();
        }

        Console.WriteLine("--- DAFTAR PRODUK ---");

        foreach (ProdukGalon produk in daftarProduk)
        {
            Console.WriteLine("ID Produk   : " + produk.IdProduk);
            Console.WriteLine("Nama Produk : " + produk.NamaProduk);
            Console.WriteLine("Stok Gudang : " + produk.StokGudang);

            if (produk is GalonBerkeran)
            {
                GalonBerkeran keran = (GalonBerkeran)produk;

                Console.WriteLine(
                    "Jenis Keran : " + keran.JenisKeran
                );
            }

            Console.WriteLine();
        }
    }
}



// MAIN PROGRAM
class Program
{
    static void Main(string[] args)
    {
        // SOAL 1
        Agen agen1 = new Agen();
        agen1.idAgen = "AG001";
        agen1.namaAgen = "Agen Banyuwangi";
        agen1.stokAgen = 50;

        Agen agen2 = new Agen();
        agen2.idAgen = "AG002";
        agen2.namaAgen = "Agen Jember";
        agen2.stokAgen = 30;

        Console.WriteLine("\n=== DATA AGEN ===");

        agen1.TampilInfo();

        Console.WriteLine();

        agen2.TampilInfo();


        // SOAL 2 DAN 5
        ProdukGalon produk1 = new GalonAkua(
            "P001", "Galon Akua", 100
        );

        ProdukGalon produk2 = new GalonBerkeran(
            "P002", "Galon Berkeran", 100, "Keran Putar"
        );

        Console.WriteLine("\n=== DATA PRODUK ===");

        Console.WriteLine("ID Produk: " + produk1.IdProduk);
        Console.WriteLine("Nama Produk: " + produk1.NamaProduk);
        Console.WriteLine("Stok Gudang: " + produk1.StokGudang);

        Console.WriteLine();

        Console.WriteLine("ID Produk: " + produk2.IdProduk);
        Console.WriteLine("Nama Produk: " + produk2.NamaProduk);
        Console.WriteLine("Stok Gudang: " + produk2.StokGudang);


        // SOAL 4
        Console.WriteLine("\n=== PERHITUNGAN BIAYA ===");

        Console.WriteLine(
            "Galon Akua (5 galon): Rp"
            + produk1.HitungBiaya(5)
        );

        Console.WriteLine(
            "Galon Berkeran (5 galon): Rp"
            + produk2.HitungBiaya(5)
        );


        // SOAL 6
        DistribusiGalon distribusi = new DistribusiGalon(
            agen1, produk1, 10
        );

        distribusi.KirimPaket();


        // SOAL 7
        SindikatGalon sindikat = new SindikatGalon();

        sindikat.TambahAgen(agen1);
        sindikat.TambahAgen(agen2);

        sindikat.TambahProduk(produk1);
        sindikat.TambahProduk(produk2);

        sindikat.TampilkanSindikat();

        Console.ReadLine();
    }
}
