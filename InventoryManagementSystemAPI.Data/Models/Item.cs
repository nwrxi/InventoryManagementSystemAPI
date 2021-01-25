using System;
using System.ComponentModel.DataAnnotations;
using InventoryManagementSystemAPI.Data.CustomValidators;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Data.Models
{
    [Index(nameof(Barcode), IsUnique = true)]
    public class Item
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Barcode("Invalid Barcode. Supported formats: GTIN-8, GTIN-12, GTIN-13, GTIN-14")]
        public string Barcode { get; set; }
        [Required]
        public int? UserId { get; set; }
    }
}