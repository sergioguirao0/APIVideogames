using APIVideogames.Resources.Strings;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Validations
{
    public class FirstCharUpperCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstChar = value.ToString()![0].ToString();

            if (firstChar != firstChar.ToUpper())
            {
                return new ValidationResult(ApiStrings.FirstCharValidation);
            }

            return ValidationResult.Success;
        }
    }
}
