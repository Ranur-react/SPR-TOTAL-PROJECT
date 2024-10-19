using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Material
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nama material harus diisi")]
        [StringLength(100, ErrorMessage = "Nama material tidak boleh lebih dari 100 karakter")]
        public string NamaMaterial { get; set; }

        [Required(ErrorMessage = "Tipe material harus diisi")]
        public Type TipeMaterial { get; set; } // 0 = Pokok, 1 = Non Pokok

    }
}

public enum Type { 
    pokok,
    nonPokok
}
