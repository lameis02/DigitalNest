using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Views
{
    public class DateValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime selectedDate;

            if (DateTime.TryParse(value?.ToString(), out selectedDate))
            {
                // Hier kannst du weitere Validierungen durchführen, wenn nötig
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Ungültiges Datumsformat. Verwende das Format TT.MM.JJJJ.");
            }
        }
    }
}
