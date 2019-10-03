using System.ComponentModel;
using System.Reflection;

namespace Supermarket.API.Extensions
{
    public static class EnumExtensions
    {
        /*First, we defined a generic method (a method that can receive more than one type of argument, in this case, represented by the TEnum declaration) that receives a given enum as an argument.

Since enum is a reserved keyword in C#, we added an @ in front of the parameter’s name to make it a valid name.

The first execution step of this method is to get the type information (the class, interface, enum or struct definition) of the parameter using the GetType method.

Then, the method gets the specific enumeration value (for instance, Kilogram) using GetField(@enum.ToString()).

The next line finds all Description attributes applied over the enumeration value and stores their data into an array (we can specify multiple attributes for a same property in some cases).

The last line uses a shorter syntax to check if we have at least one description attribute for the enumeration type. If we have, we return the Description value provided by this attribute. If not, we return the enumeration as a string, using the default casting.

The ?. operator (a null-conditional operator) checks if the value is null before accessing its property.*/
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}