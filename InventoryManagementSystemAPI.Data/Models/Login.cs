using System.ComponentModel.DataAnnotations;
using InventoryManagementSystemAPI.Data.CustomValidators;

namespace InventoryManagementSystemAPI.Data.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Password]
        //todo: require a valid password
        public string Password { get; set; }
    }
}