using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemAPI.Data.Models.DTOs
{
    public class UserItemDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}