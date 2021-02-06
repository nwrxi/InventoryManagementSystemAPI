using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemAPI.Data.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //todo: require a valid password
        public string Password { get; set; }
    }
}