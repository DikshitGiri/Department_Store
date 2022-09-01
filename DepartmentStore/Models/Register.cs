using System.ComponentModel.DataAnnotations;

namespace DepartmentStore.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string Repassword { get; set; }
    }
}
