using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace GymLog.API.Utilities
{
    public class KebabCaseTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            if (value == null) return null;

            // Convert PascalCase to kebab-case
            return string.Concat(value.ToString()!
                .Select((ch, i) => i > 0 && char.IsUpper(ch) ? "-" + ch : ch.ToString()))
                .ToLower();
        }
    }
}
