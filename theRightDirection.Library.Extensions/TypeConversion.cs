namespace theRightDirection.Library.Extensions
{
    public static class TypeConversion
    {
        public static T ConvertOrDefault<T>(this object value)
        {
            T result = default(T);
            Converter.TryConvert<T>(value, out result);

            return result;
        }

        public static bool TryConvert<T>(this object value, out T result)
        {
            return Converter.TryConvert<T>(value, out result);
        }
    }
}