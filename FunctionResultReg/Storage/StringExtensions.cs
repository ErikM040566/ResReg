namespace ResultReg.Storage
{
    public static class StringExtensions
    {

        public static bool IsNotNullOrWhiteSpace(this string value) => !value.IsNullOrWhiteSpace();

        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsInteger(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return int.TryParse(value, out int number);
        }
      
    }
}
