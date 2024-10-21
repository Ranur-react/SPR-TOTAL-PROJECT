using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Material
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(100, ErrorMessage = "Nama material tidak boleh lebih dari 100 karakter")]
        [Required(ErrorMessage = "Nama material harus diisi")]
        public String NamaMaterial { get; set; }

        [Required(ErrorMessage = "Tipe material harus diisi")]
        public Type TipeMaterial { get; set; } // 0 = Pokok, 1 = Non Pokok
        public int StokMaterial { get; set; }
        // stok material akan berkurang jika material insert kedalam DetilMaterial, Pengurangan akan terjadi oleh Trigger SQL dengan Formua (Maerial.Stock - Detil.Volume)
        // Begitupun sebaliknya, Trigger akan menambahkan Stock kedalam Material jika Material didalam Detil dihapus
        // kedepannya Trigger ini juga akan dapat dibuat jika Material didalam detil sudah di approved, jika belum di approved maka tidak akan berkurang, 
        [JsonIgnore]
        public virtual ICollection<DetilSPR>? DetilSPRs { get; set; }
    }
}

public enum Type { 
    pokok,
    nonPokok
}
