using Newtonsoft.Json.Converters;

namespace PS.Web.UI.Helpers
{
    public class CamelCaseStringEnumConverter : StringEnumConverter
    {
        public CamelCaseStringEnumConverter()
        {
            CamelCaseText = true;
        }
    }
}