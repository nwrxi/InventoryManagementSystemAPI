using System.Collections.Generic;

namespace InventoryManagementSystemAPI.Data.Models
{
    public class PublicUserViewModel
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}