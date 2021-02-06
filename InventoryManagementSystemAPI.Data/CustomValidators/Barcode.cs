using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace InventoryManagementSystemAPI.Data.CustomValidators
{
    public class Barcode : ValidationAttribute
    {
        private readonly string _errorMessage;
        //private readonly bool _isUnique;
        private readonly Regex _gtinRegex = new("^(\\d{8}|\\d{12,14})$");

        public Barcode(string errorMessage/*, bool isUnique = false*/)
        {
            _errorMessage = errorMessage;
            //_isUnique = isUnique;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (DataContext)validationContext
                .GetService(typeof(DataContext));

            var barcode = value.ToString();
            
            if (!(_gtinRegex.IsMatch(barcode!))) return new ValidationResult(_errorMessage); // check if all digits and with 8, 12, 13 or 14 digits
            
            barcode = barcode.PadLeft(14, '0'); // stuff zeros at start to guarantee 14 digits
            var multiplication = Enumerable.Range(0, 13).Select(i => ((int)(barcode[i] - '0')) * ((i % 2 == 0) ? 3 : 1)).ToArray(); // STEP 1: without check digit, "Multiply value of each position" by 3 or 1
            var sum = multiplication.Sum(); // STEP 2: "Add results together to create sum"
            
            if ((10 - (sum % 10)) % 10 == int.Parse(barcode[13].ToString())) // STEP 3 Equivalent to "Subtract the sum from the nearest equal or higher multiple of ten = CHECK DIGIT"
            {
                //if (_isUnique)
                //{
                //    if(context?.Items.FirstOrDefault(i => i.Barcode == value.ToString()) != null) return new ValidationResult("Not a unique barcode");
                //}
                return ValidationResult.Success; 
            }
            
            return new ValidationResult(_errorMessage);
        }
    }
}