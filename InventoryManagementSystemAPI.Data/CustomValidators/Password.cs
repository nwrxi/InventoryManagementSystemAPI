using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace InventoryManagementSystemAPI.Data.CustomValidators
{
    public class Password : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = (string) value;

            if (password.Length < 6)
                return new ValidationResult("Password must be at least 6 characters.");

            if(!new Regex("[A-Z]").IsMatch(password))
                return new ValidationResult("Password must contain at least 1 uppercase character.");

            if (!new Regex("[a-z]").IsMatch(password))
                return new ValidationResult("Password must contain at least 1 lowercase character.");

            if (!new Regex("[0-9]").IsMatch(password))
                return new ValidationResult("Password must contain at least 1 number.");

            if (!new Regex("[^a-zA-Z0-9]").IsMatch(password))
                return new ValidationResult("Password must contain at least 1 non alphanumeric character.");

            return ValidationResult.Success;
        }
    }
}