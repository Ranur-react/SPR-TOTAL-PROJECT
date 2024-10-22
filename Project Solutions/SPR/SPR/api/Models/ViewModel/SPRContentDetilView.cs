using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel
{
    public class SPRContentDetilView
    {



        //---------------------SPR Attribute
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public String? Id { get; set; }  // Menggunakan UUID otomatis

        [Required(ErrorMessage = "Tanggal permintaan harus diisi")]
        public DateTime TanggalMinta { get; set; }

        [Required(ErrorMessage = "Status SPR harus diisi")]
        [StringLength(50, ErrorMessage = "Status SPR tidak boleh lebih dari 50 karakter")]
        public String StatusSPR { get; set; }

        [Required(ErrorMessage = "Zona SPR harus diisi")]
        [StringLength(3, ErrorMessage = "Zona SPR harus memiliki panjang 3 karakter")]
        public String ZonaSPR { get; set; } = "000";

        [Required(ErrorMessage = "Tujuan SPR harus diisi")]
        [StringLength(200, ErrorMessage = "Tujuan SPR tidak boleh lebih dari 200 karakter")]
        public String TujuanSPR { get; set; }
        [ForeignKey("Proyek")]
        [Required(ErrorMessage = "Proyek ID harus diisi")]
        public int ProyekId { get; set; }
        [ForeignKey("UserPeminta")]
        [Required(ErrorMessage = "User Peminta ID harus diisi")]
        public Guid UserPemintaId { get; set; }  // Id User tetap menggunakan tipe int
        //------------------Detil Attribute
        [Required(ErrorMessage = "SPR ID harus diisi")]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public string? SPRId { get; set; }
        [Required(ErrorMessage = "Material ID harus diisi")]
        public Guid MaterialId { get; set; }

        [Required(ErrorMessage = "Volume material harus diisi")]
        [Range(1, int.MaxValue, ErrorMessage = "Volume material harus lebih dari 0")]
        public int Volume { get; set; }
        [Required(ErrorMessage = "Unit harus diisi")]
        [StringLength(10, ErrorMessage = "Unit tidak boleh lebih dari 10 karakter")]
        public string? Unit { get; set; }
        public DateTime TanggalRencanaTerima { get; set; }
        public bool StatusDisetujui { get; set; }  // 0 = Belum Disetujui, 1 = Disetujui

    }
}
