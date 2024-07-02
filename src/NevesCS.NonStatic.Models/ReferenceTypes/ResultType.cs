using System.ComponentModel;

namespace NevesCS.NonStatic.Models
{
    public enum ResultType
    {
        [Description("Success")]
        Success,

        [Description("Failure")]
        Failure,

        [Description("Warning")]
        Warning,
    }
}
