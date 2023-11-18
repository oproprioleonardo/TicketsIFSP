using System.Globalization;
using TicketsIFSP.Utils;

namespace TicketsIFSP.Converters
{
    public class StringToPhoneNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string phoneNumber) { 
                try
                {
                    return Formatters.FormatPhoneNumberBrazilian(phoneNumber);
                }
                catch (ArgumentException)
                {
                    return phoneNumber;
                }
            }
            else return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new string(((string)value).Where(char.IsDigit).ToArray());
        }
    }
}
