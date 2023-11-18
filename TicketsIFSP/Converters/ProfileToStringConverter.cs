using System.Globalization;
using TicketsIFSP.Models;

namespace TicketsIFSP.Converters
{
    public class ProfileToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            var profile = (GuestProfile)value;
            return profile switch
            {
                GuestProfile.STUDENT => "Estudante",
                GuestProfile.EX_STUDENT => "Ex-estudante",
                GuestProfile.EXTERNAL_PUBLIC => "Público externo",
                GuestProfile.EMPLOYEE => "Servidor público",
                _ => "Convidado Indeterminado",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            return value switch
            {
                "Estudante" => GuestProfile.STUDENT,
                "Ex-estudante" => GuestProfile.EX_STUDENT,
                "Público externo" => GuestProfile.EXTERNAL_PUBLIC,
                "Servidor público" => GuestProfile.EMPLOYEE,
                _ => null,
            };
        }
    }
}
