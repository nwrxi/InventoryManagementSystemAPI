using System.Collections.Generic;

namespace InventoryManagementSystemAPI.Data.Models.DTOs
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IList<ItemDto> Items { get; set; }
    }
}