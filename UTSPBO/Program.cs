using System;
using System.Collections.Generic;

//Soal 1
class Agen
{
    public string idAgen { get; set; }
    public string namaAgen { get; set; }
    public int stokAgen { get; private set; }

    public Agen(string idAgen, string namaAgen, int stokAgen)
    {
        idAgen = idAgen;
        namaAgen = namaAgen;
        stokAgen = stokAgen;
    }

    public void TambahStok(int jumlah)
    {
        if (jumlah > 0)
        {
            stokAgen += jumlah;
        }
    }

    public void TampilInfo()
    {
        Console.WriteLine("ID Agen :" + idAgen);
        Console.WriteLine("Nama Agen  : " + namaAgen);
        Console.WriteLine("Stok Agen :" + stokAgen + " galon");
    }
}


//Soal 2
abstract class ProdukGalon
{
    public string idProduk { get; private set; }
    public string namaProduk { get; private set; }
    public int stokGudang { get; private set; }

    public ProdukGalon(string idProduk, string namaProduk, int stokGudang)
    {
        this.idProduk = idProduk;
        this.namaProduk = namaProduk;
        this.stokGudang = stokGudang;
    }

    public void KurangiStok(int jumlah)
    {
        if (jumlah <= 0)
        {
        }

        if (jumlah > stokGudang)
        {
        }

        stokGudang -= jumlah;
    }

    public void TambahStok(int jumlah)
    {
        if (jumlah <= 0)
        {
        }
        stokGudang += jumlah;
    }
    public abstract decimal HitungBiaya(int jumlah);
}

//Soal 3
class produkGalon
{
    class galonAkua : produkGalon;
{
    public galonAkua(string id, string nama, int stok)
    {
    }
    public override decimal HitungBiaya(int jumlah)
    {
        return harga * 20000;
    }
}

class galonBerkeran : produkGalon
{
    public galonBerkeran(string id, string nama, int stok)
{
}
public override decimal HitungBiaya(int jumlah)
{
    return harga * 12000;
    }
}



//Soal 4
class produkGalon
{
    class galonAkua : produkGalon
    {
        public galonAkua(string id, string nama, int stok);
    }
    public override decimal HitungBiaya(int jumlah)
    {
        return jumlah * 20000;
    }
   class galonAkua : produkGalon
    {
      public galonAkua(string id, string nama, int stok)
    {
    }
    public override decimal HitungBiaya(int jumlah)
    {
    return jumlah * 12000;

    }
}

//Soal 5
abstract class produkGalon;
class galonAkua : produkGalon
{
    public galonAkua(string id, string nama, int stok)
{
}
public override decimal HitungBiaya(int jumlah)
{
        return harga = 20000;
    }
}

class galonBerkeran : produkGalon
{
    public galonBerkeran(string id, string nama, int stok)
{
}
public override decimal HitungBiaya(int jumlah)
{
    return harga=12000;
}
}


//Soal 6
interface DapatDidistribusikan
{
    void KirimPaket();
}

class DistribusiGalon : DapatDidistribusikan
{
    private Agen agenTujuan;
    private ProdukGalon produk;
    private int jumlah;

    public DistribusiGalon(Agen agen, ProdukGalon produk, int jumlah)
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
            Console.WriteLine("Gagal: Jumlah galon harus lebih dari 0.");
            return;
        }

        if (jumlah > produk.stokGudang)
        {
            Console.WriteLine("Gagal: Stok gudang tidak mencukupi.");
            Console.WriteLine("Stok gudang dan agen tidak berubah.");
            return;
        }

  
        produk.KurangiStok(jumlah);
        agenTujuan.TambahStok(jumlah);

        Console.WriteLine("Paket berhasil dikirimkan!");
        Console.WriteLine("Produk       : " + produk.namaProduk);
        Console.WriteLine("Tujuan Agen  : " + agenTujuan.namaAgen);
        Console.WriteLine("Jumlah       : " + jumlah + " galon");
        Console.WriteLine("Biaya        : Rp" +produk.HitungBiaya(jumlah).ToString("N0"));
        Console.WriteLine("Pesan: Paket berhasil dikirimkan ke agen.");
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("     MANAJEMEN SINDIKAT GALON");
            Console.WriteLine("=================================");

            Agen agen1 = new Agen("A001", "Agen Jember", 10);
            Agen agen2 = new Agen("A002", "Agen Surabaya", 5);


            ProdukGalon produk1 =
                new GalonAkua("P001", "Galon Aqua", 100);

            ProdukGalon produk2 =
                new GalonBerkeran("P002", "Galon Berkeran", 80);


            Console.WriteLine("\n--- INFORMASI AGEN ---");
            agen1.TampilInfo();
            Console.WriteLine();
            agen2.TampilInfo();


            Console.WriteLine("\n--- PERHITUNGAN BIAYA ---");

            ProdukGalon[] daftarProduk =
            {
            produk1,
            produk2
        };

            foreach (ProdukGalon produk in daftarProduk)
            {
                Console.WriteLine(
                    produk.namaProduk + " : Rp" +
                    produk.HitungBiaya(2).ToString("N0")
                );
            }

            DistribusiGalon kirim1 =
                new DistribusiGalon(agen1, produk1, 20);

            kirim1.KirimPaket();

            DistribusiGalon kirim2 =
                new DistribusiGalon(agen2, produk2, 100);

            kirim2.KirimPaket();


            SindikatGalon sindikat = new SindikatGalon();

            sindikat.TambahAgen(agen1);
            sindikat.TambahAgen(agen2);

            sindikat.TambahProduk(produk1);
            sindikat.TambahProduk(produk2);

            sindikat.TampilkanSindikat();

            Console.WriteLine("\nProgram selesai.");
        }
    }