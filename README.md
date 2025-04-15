# csharp-lksmart

Aplikasi **Windows Forms** berbasis C# untuk mengelola operasi administrasi, gudang, dan kasir.

## Fitur

- **Modul Admin**: Mengelola log pengguna, membuat laporan, dan mengatur akun pengguna.
- **Modul Gudang**: Mengelola data inventaris dan stok barang.
- **Modul Kasir**: Menangani transaksi dan interaksi dengan pelanggan.
- **Helpers**: Kelas-kelas utilitas untuk operasi database, interaksi UI, dan lainnya.
- **Models**: Model data untuk entitas seperti `Barang`, `Laporan`, `Log`, `Pelanggan`, `User`, dan `Transaksi`.

## Struktur Proyek

```
.
├── Forms/
│   ├── FLogin.cs
│   ├── Admin/
│   │   ├── FAdminLog.cs
│   │   ├── FAdminLaporan.cs
│   ├── Gudang/
│   │   ├── FGudangBarang.cs
│   ├── Kasir/
│       ├── FKasirTransaksi.cs
├── Helpers/
│   ├── DBHelpers.cs
│   ├── GlobalConfig.cs
│   ├── MessageBoxHelper.cs
│   ├── TimerHelper.cs
├── Models/
│   ├── MBarang.cs
│   ├── MLaporan.cs
│   ├── MLog.cs
│   ├── MPelanggan.cs
│   ├── MUser.cs
│   ├── MTransaksi.cs
├── Resources/
│   ├── Logo.png
│   ├── Icons/
│       ├── Eye Outline.png
│       ├── Eye Disable Outline.png
│       ├── Administrator.png
│       ├── Cashier.png
│       ├── Gudang.png
├── Exported PDF/
│   ├── ExportedDataKeranjang.pdf
├── Program.cs
├── App.config
├── csharp-lksmart.csproj
├── csharp-lksmart.sln
```

## Kebutuhan

- **.NET Framework 4.8.1**
- **Visual Studio 2022 atau versi yang lebih baru**

## Memulai Proyek

1. Clone repositori:
   ```bash
   git clone https://github.com/your-repo/csharp-lksmart.git
   ```
2. Buka file solusi `csharp-lksmart.sln` menggunakan Visual Studio.
3. Build solusi untuk mengunduh paket NuGet dan meng-compile proyek.
4. Jalankan aplikasi.

## Penggunaan

- **Login**: Masuk ke aplikasi melalui form login.
- **Admin**: Mengelola log, laporan, dan akun pengguna.
- **Gudang**: Mengelola data stok dan inventaris barang.
- **Kasir**: Memproses transaksi dan mengatur data pelanggan.
