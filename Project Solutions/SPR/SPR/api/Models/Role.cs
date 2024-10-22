using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using api.BaseModels;

namespace api.Models
{
    public class Role : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "RoleName harus disi")]
        public string RoleName { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<User>? Users { get; set; }

    }
}
