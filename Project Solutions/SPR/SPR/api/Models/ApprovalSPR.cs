using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ApprovalSPR
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        [Required(ErrorMessage = "SPR ID harus diisi")]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        [ForeignKey("SPR")]
        public string SPRId { get; set; }
        [JsonIgnore]
        public virtual SPR SPR { get; set; }  // Navigasi ke SPR
        [Required(ErrorMessage = "User Approver ID harus diisi")]
        public Guid UserApproverId { get; set; }
        [JsonIgnore]
        public virtual User UserApprover { get; set; }  // Navigasi ke User Approver

        [Required(ErrorMessage = "Tanggal approval harus diisi")]
        public DateTime TanggalApproval { get; set; }

        [Required(ErrorMessage = "Status approval harus diisi")]
        public bool StatusApproval { get; set; }  // 0 = Belum Disetujui, 1 = Disetujui

        [StringLength(200, ErrorMessage = "Komentar tidak boleh lebih dari 200 karakter")]
        public string Komentar { get; set; }
    }
}
