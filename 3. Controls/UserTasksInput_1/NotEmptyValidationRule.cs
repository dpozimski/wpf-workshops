using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDo.WPF.Core
{
    class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = (string)value;
            if (string.IsNullOrEmpty(str?.Trim()))
            {
                return new ValidationResult(false, "Input cannot be empty");
            }

            return ValidationResult.ValidResult;
        }
    }

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
