using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api.Models
{
    public class SPR
    
    {
        [Key]
        [Required(ErrorMessage = "Kode SPR harus diisi")]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public string Id { get; set; }  // Menggunakan UUID otomatis

        [Required(ErrorMessage = "Tanggal permintaan harus diisi")]
        public DateTime TanggalMinta { get; set; }

        [Required(ErrorMessage = "Status SPR harus diisi")]
        [StringLength(50, ErrorMessage = "Status SPR tidak boleh lebih dari 50 karakter")]
        public string StatusSPR { get; set; }

        [Required(ErrorMessage = "Zona SPR harus diisi")]
        [StringLength(3, ErrorMessage = "Zona SPR harus memiliki panjang 3 karakter")]
        public string ZonaSPR { get; set; } = "000";

        [Required(ErrorMessage = "Tujuan SPR harus diisi")]
        [StringLength(200, ErrorMessage = "Tujuan SPR tidak boleh lebih dari 200 karakter")]
        public string TujuanSPR { get; set; }
        [ForeignKey("Proyek")]
        [Required(ErrorMessage = "Proyek ID harus diisi")]
        public int ProyekId { get; set; }
        [JsonIgnore]
        public  virtual Proyek Proyek { get; set; }  // Navigasi ke Proyek
        [ForeignKey("UserPeminta")]
        [Required(ErrorMessage = "User Peminta ID harus diisi")]
        public Guid UserPemintaId { get; set; }  // Id User tetap menggunakan tipe int
        public virtual User UserPeminta { get; set; }  // Navigasi ke User Peminta
        public virtual ICollection<ApprovalSPR> ApprovalSPRs { get; set; }
        public virtual ICollection<DetilSPR> DetilSPRs { get; set; }

    }
}
