using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemAPI.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}