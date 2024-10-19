using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel
{
    public class FormRegister
    {
        [Required(ErrorMessage = "it must have a value")]
        public String Name { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public String UserName { get; set; }
        [EmailAddress(ErrorMessage = "it's must as Email value, please rechek your typing value, use @ symbol for representations domain after mailName")]
        public String Email { get; set; }
        [Required(ErrorMessage = "it must have a value")]
        public virtual String Password { get; set; }
    }
}
