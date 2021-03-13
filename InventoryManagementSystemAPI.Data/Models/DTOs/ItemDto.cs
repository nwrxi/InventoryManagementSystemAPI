using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystemAPI.Data.CustomValidators;

namespace InventoryManagementSystemAPI.Data.Models.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Barcode { get; set; }
        public UserItemDto User { get; set; }
    }
}
