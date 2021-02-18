using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemAPI.Data.Models.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IList<ItemDto> Items { get; set; }
    }
}