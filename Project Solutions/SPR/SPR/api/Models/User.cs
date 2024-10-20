using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace api.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }=Guid.NewGuid();

        [Required(ErrorMessage = "Username harus diisi")]
        [StringLength(50, ErrorMessage = "Username tidak boleh lebih dari 50 karakter")]
        public string Username { get; set; }
        [StringLength(50, ErrorMessage = "Name tidak boleh lebih dari 50 karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password harus diisi")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email harus diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        [StringLength(100, ErrorMessage = "Email tidak boleh lebih dari 100 karakter")]
        public string Email { get; set; }

        [ForeignKey("Role")]
        [Required(ErrorMessage = "Role ID harus diisi")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }  // Navigasi ke Role

        //[JsonIgnore]
        //public virtual ICollection<ApprovalSPR>ApprovalSPRs { get; set; }
        //Saat migrasi ini dimatikan agar menghindari konfigurasi relasi ganda dengan  Eentity Framework
        
        [JsonIgnore]
        public virtual ICollection<SPR> SPRs { get; set; }
    }
}
