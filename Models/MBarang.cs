using System;

namespace csharp_lksmart
{
    public class MBarang
    {
        public int id_barang { get; set; }
        public string kode_barang { get; set; }
        public string nama_barang { get; set; }
        public DateTime expired_date { get; set; }
        public long jumlah_barang { get; set; }
        public string satuan { get; set; }
        public long harga_satuan { get; set; }
    }
}
