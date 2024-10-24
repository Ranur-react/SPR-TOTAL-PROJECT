using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel
{
    public class DetilSPRView
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "SPR ID harus diisi")]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public string? SPRId { get; set; }
        [Required(ErrorMessage = "Material ID harus diisi")]
        public Guid MaterialId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Volume material harus lebih dari 0")]
        public int Volume { get; set; }

        [StringLength(10, ErrorMessage = "Unit tidak boleh lebih dari 10 karakter")]
        public string? Unit { get; set; }

        public DateTime TanggalRencanaTerima { get; set; }

        public bool StatusDisetujui { get; set; }  // 0 = Belum Disetujui, 1 = Disetujui
        //Material Attribut
        [StringLength(100, ErrorMessage = "Nama material tidak boleh lebih dari 100 karakter")]
        public String NamaMaterial { get; set; }
        public Type TipeMaterial { get; set; } // 0 = Pokok, 1 = Non Pokok
        public int StokMaterial { get; set; }

    }
}
