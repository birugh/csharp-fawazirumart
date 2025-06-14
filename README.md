# csharp-fawazirumart

Aplikasi POS sederhana berbasis Windows Forms (C#) untuk kebutuhan administrasi, gudang, dan kasir.

## Fitur

- 🔐 **Login Role-Based**: Admin, Gudang, dan Kasir
- 📊 **Manajemen Laporan & Log**
- 📦 **Manajemen Barang dan Stok**
- 💸 **Transaksi Kasir dengan Nomor Otomatis**
- 📁 **Struktur Modular**: `Forms`, `Models`, `Helpers`
- 🔧 **Trigger & Stored Procedure SQL Server**

## Struktur Proyek

```
.
├── Forms/
│   ├── FLogin.cs
│   ├── Admin/
│   │   ├── FAdminLog.cs
│   │   ├── FAdminLaporan.cs
│   │   ├── FAdminUsers.cs
│   │   ├── FAdminPelanggan.cs
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
├── Program.cs
├── App.config
├── csharp-lksmart.csproj
├── csharp-lksmart.sln
```

## Tech Stack

- C# Windows Forms
- SQL Server
- Stored Procedures & Triggers
- Visual Studio 2022
- .NET Framework 4.8.1

## Cara Instalasi

### 1. Clone Repository

```bash
git clone https://github.com/your-username/csharp-lksmart.git
```

### 2. Buka & Jalankan

- Buka `csharp-lksmart.sln` di **Visual Studio 2022**
- Pastikan target .NET Framework 4.8.1 sudah terpasang
- Tekan `Execute` untuk menjalankan aplikasi
