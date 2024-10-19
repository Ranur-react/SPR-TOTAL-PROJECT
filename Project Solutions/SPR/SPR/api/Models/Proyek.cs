using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Proyek
    {
        [Key]
        public int Id { get; set; } //Sengaja nggak pakai UUID karena akan mengikuti requirement soal

        [Required(ErrorMessage = "Nama proyek harus diisi")]
        [StringLength(100, ErrorMessage = "Nama proyek tidak boleh lebih dari 100 karakter")]
        public string NamaProyek { get; set; }

        [StringLength(200, ErrorMessage = "Lokasi proyek tidak boleh lebih dari 200 karakter")]
        public string LokasiProyek { get; set; }

        [Required(ErrorMessage = "Tanggal mulai proyek harus diisi")]
        public DateTime TanggalMulai { get; set; }

        [Required(ErrorMessage = "Tanggal selesai proyek harus diisi")]
        public DateTime TanggalSelesai { get; set; }

    }
}
