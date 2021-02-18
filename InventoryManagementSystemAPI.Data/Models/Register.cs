using System.ComponentModel.DataAnnotations;
using InventoryManagementSystemAPI.Data.CustomValidators;

namespace InventoryManagementSystemAPI.Data.Models
{
    public class Register
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Password]
        public string Password { get; set; }
    }
}