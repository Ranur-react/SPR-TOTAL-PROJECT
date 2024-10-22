using System.ComponentModel.DataAnnotations;
using api.BaseModels;

namespace api.Models
{
    public class LogSPR : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();

        [StringLength(20, ErrorMessage = "Kode SPR tidak boleh lebih dari 20 karakter")]
        public string? SPRId { get; set; }

        public Guid UserApproverId { get; set; }

        [StringLength(50, ErrorMessage = "Action tidak boleh lebih dari 50 karakter")]
        public string Action { get; set; }  // Action types: 'Buat', 'Ubah', 'Hapus', 'Setujui', 'Tolak'

        [Required(ErrorMessage = "Tanggal action harus diisi")]
        public DateTime TanggalAction { get; set; }

        [StringLength(200, ErrorMessage = "Keterangan tidak boleh lebih dari 200 karakter")]
        public string Keterangan { get; set; }
    }
}
