using System.ComponentModel;

namespace NevesCS.Static.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
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
