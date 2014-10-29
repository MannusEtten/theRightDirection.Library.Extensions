using System;
using System.ComponentModel;

namespace theRightDirection.Library.Extensions
{
    internal class Converter
    {
        public static bool TryConvert<T>(object value, out T result)
        {
            //Typenspezifischer default Wert wird auf jeden Fall als resultat
            //der Konvertierung verwendet.
            result = default(T);

            //result = default(T);

            if (value == null || value == DBNull.Value) return false;

            //falls der ZielTyp gleich dem Quelltyp ist, führe direkt die Konvertierung durch
            if (typeof(T) == value.GetType())
            {
                result = (T)value;
                return true;
            }

            string typeName = typeof(T).Name;

            try
            {
                //sollte der Typ Nullable oder ein Enum sein
                //verwende den TypeDescriptor und den TypeConverter
                if (typeName.IndexOf(typeof(System.Nullable).Name,
                                    StringComparison.Ordinal) > -1 ||
                                    typeof(T).BaseType.Name.IndexOf(typeof(System.Enum).Name,
                                            StringComparison.Ordinal) > -1)
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)tc.ConvertFrom(value);
                }
                else
                {
                    result = (T)Convert.ChangeType(value, typeof(T));
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}