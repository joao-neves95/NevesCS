using System.ComponentModel;

namespace NevesCS.Abstractions.Clients.Web3.DexTools.Models
{
    public enum DexToolsV1CandleType
    {
        [Description("1m")]
        m1,

        [Description("3m")]
        m3,

        [Description("5m")]
        m5,

        [Description("15m")]
        m15,

        [Description("30m")]
        m30,

        [Description("1h")]
        h1,

        [Description("2h")]
        h2,

        [Description("4h")]
        h4,

        [Description("12h")]
        h12,

        [Description("1d")]
        d1,
    }
}
