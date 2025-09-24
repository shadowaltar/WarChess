using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroParagon.Utils;
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this ReadOnlySpan<char> span) => span == null || span.IsEmpty;
}
