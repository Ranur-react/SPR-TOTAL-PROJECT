using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.BaseModels;


namespace api.Models
{
    public class DetilSPR : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        [ForeignKey("SPR")]
        [Required(ErrorMessage = "SPR ID harus diisi")]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public string? SPRId { get; set; }
        [ForeignKey("Material")]
        [Required(ErrorMessage = "Material ID harus diisi")]
        public Guid MaterialId { get; set; }
 
        [Required(ErrorMessage = "Volume material harus diisi")]
        [Range(1, int.MaxValue, ErrorMessage = "Volume material harus lebih dari 0")]
        public int Volume { get; set; }

        [Required(ErrorMessage = "Unit harus diisi")]
        [StringLength(10, ErrorMessage = "Unit tidak boleh lebih dari 10 karakter")]
        public string? Unit { get; set; }

        [Required(ErrorMessage = "Tanggal rencana terima harus diisi")]
        public DateTime TanggalRencanaTerima { get; set; }

        public bool StatusDisetujui { get; set; }  // 0 = Belum Disetujui, 1 = Disetujui

        public virtual Material? Material { get; set; }  // Navigasi ke Material
        [JsonIgnore]
        public virtual SPR? SPR { get; set; }  // Navigasi ke SPR

    }
}
