using System.ComponentModel.DataAnnotations;

namespace DepartmentStore.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]
        //[RegularExpression (@"^[a - zA - Z]([a - zA - Z0 - 9]){2,20}$", ErrorMessage = "Name must be 3 characters long") ]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",ErrorMessage ="Please provide vaild email") ]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide password")]
        //[RegularExpression(@"([a - zA - Z0 - 9]){7,20}$",ErrorMessage ="Password Must be 8 character long")]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The Password and Repassword didn't matched")]
        public string Repassword { get; set; }
    }
}
