using System.Text.RegularExpressions;

namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static string Interpolate(this string self, params string[] interpolateValue)
        {
            var placeholders = Regex.Matches(self, @"\{(.*?)\}");

            var counter = 0;
            foreach (Match placeholder in placeholders)
            {
                var placeholderValue = placeholder.Value;
                self = self.Replace(placeholderValue, interpolateValue[counter] ?? placeholderValue);
                counter++;
            }

            return self;
        }
    }
}
