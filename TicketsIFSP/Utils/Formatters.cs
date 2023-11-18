namespace TicketsIFSP.Utils
{
    public static class Formatters
    {

        public static string FormatPhoneNumberBrazilian(string phoneNumber)
        {
            phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());
            if (phoneNumber.Length != 11)
                throw new ArgumentException("Número de telefone inválido! Deve conter 11 dígitos (incluindo o DDD).");
            return string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 2), phoneNumber.Substring(2, 5), phoneNumber.Substring(7, 4));
        }

    }
}
