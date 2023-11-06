using System.ComponentModel;

namespace NevesCS.Static.Utils
{
    public static class EnumUtils
    {
        public static string GetDescription(Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            if (field is null || Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is not DescriptionAttribute attribute)
            {
                throw new ArgumentException($"{nameof(DescriptionAttribute)} not found.", nameof(enumValue));
            }

            return attribute.Description;
        }
    }
}
