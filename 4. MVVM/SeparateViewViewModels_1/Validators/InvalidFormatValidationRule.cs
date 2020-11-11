using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace ToDo.WPF.Core.Validators
{
    class InvalidFormatValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = (string)value;
            var spliited = str.Split(", ");

            if(spliited.Any(c => c == string.Empty))
            {
                return new ValidationResult(false, "Cannot parse multiple tasks");
            }

            return ValidationResult.ValidResult;
        }
    }
}
