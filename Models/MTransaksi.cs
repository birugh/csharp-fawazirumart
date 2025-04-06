using System;

namespace csharp_lksmart
{
    public class MTransaksi
    {
        public int id_transaksi { get; set; }
        public string no_transaksi { get; set; }
        public DateTime tgl_transaksi { get; set; }
        public string nama_kasir { get; set; }
        public long total_bayar { get; set; }
        public int id_user { get; set; }
        public int id_pelanggan { get; set; }
        public int id_barang { get; set; }
    }
}
