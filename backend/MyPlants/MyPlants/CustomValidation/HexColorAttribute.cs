using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyPlants.CustomValidation
{
    public class HexColorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string)
            {
                var regex = new Regex(@"^#[0-9A-Fa-f]{6}$");
                if (regex.IsMatch((string)value))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage = "Color must be in HEX format #RRGGBB.");
        }
    }
}
