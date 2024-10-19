using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Password harus diisi")]
        [StringLength(100, ErrorMessage = "Password tidak boleh lebih dari 100 karakter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email harus diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        [StringLength(100, ErrorMessage = "Email tidak boleh lebih dari 100 karakter")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role ID harus diisi")]
        public int RoleId { get; set; }

        public Role Role { get; set; }  // Navigasi ke Role
    }
}
