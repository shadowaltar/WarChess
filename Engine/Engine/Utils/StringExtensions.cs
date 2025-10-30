using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utils;
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this ReadOnlySpan<char> span) => span == null || span.IsEmpty;

    public static bool ContainsIgnoreCase(this IEnumerable<string> collection, string str)
    {
        foreach (var item in collection)
        {
            if (item.Equals(str, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}
