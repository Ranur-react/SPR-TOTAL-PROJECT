using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class LogSPR
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();

        [Required(ErrorMessage = "SPR ID harus diisi")]
        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public string SPRId { get; set; }
        public virtual SPR SPR { get; set; }  // Navigasi ke SPR

        [Required(ErrorMessage = "User Approver ID harus diisi")]
        public Guid UserApproverId { get; set; }
        public virtual User User { get; set; }  // Navigasi ke User

        [Required(ErrorMessage = "Action harus diisi")]
        [StringLength(50, ErrorMessage = "Action tidak boleh lebih dari 50 karakter")]
        public string Action { get; set; }  // Action types: 'Buat', 'Ubah', 'Hapus', 'Setujui', 'Tolak'

        [Required(ErrorMessage = "Tanggal action harus diisi")]
        public DateTime TanggalAction { get; set; }

        [StringLength(200, ErrorMessage = "Keterangan tidak boleh lebih dari 200 karakter")]
        public string Keterangan { get; set; }
    }
}
