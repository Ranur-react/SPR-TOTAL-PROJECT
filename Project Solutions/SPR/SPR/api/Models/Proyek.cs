using api.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Proyek : BaseEntity
    {
        [Key]
        public int Id { get; set; } //Sengaja nggak pakai UUID karena akan mengikuti requirement soal

        [StringLength(100, ErrorMessage = "Nama proyek tidak boleh lebih dari 100 karakter")]
        [Required(ErrorMessage = "Nama proyek harus diisi")]
        public String NamaProyek { get; set; }

        [StringLength(200, ErrorMessage = "Lokasi proyek tidak boleh lebih dari 200 karakter")]
        public String? LokasiProyek { get; set; }

        [Required(ErrorMessage = "Tanggal mulai proyek harus diisi")]
        public DateTime TanggalMulai { get; set; }

        [Required(ErrorMessage = "Tanggal selesai proyek harus diisi")]
        public DateTime TanggalSelesai { get; set; }
        //[JsonIgnore]
        public virtual ICollection<SPR>? SPRs { get; set; }

    }
}
