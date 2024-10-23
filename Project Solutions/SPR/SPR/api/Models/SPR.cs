using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using api.BaseModels;

namespace api.Models
{
    public class SPR : BaseEntity

    {
        [Key]
        [Required]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public String Id { get; set; }  // Menggunakan UUID otomatis

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
        public virtual User? UserPeminta { get; set; }  // Navigasi ke User Peminta
        public virtual Proyek Proyek { get; set; }  // Navigasi ke Proyek
        public virtual ICollection<ApprovalSPR>? ApprovalSPRs { get; set; }
        public virtual ICollection<DetilSPR>? DetilSPRs { get; set; }

    }
}
