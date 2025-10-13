using System.Reflection;

namespace Engine.Utils;
public class AssemblyUtil
{
    public static IEnumerable<Assembly> GetUserAssemblies()
    {
        var userAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.Location.Contains("dotnet") &&
                !a.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase) &&
                !a.FullName.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase) &&
                !a.FullName.StartsWith("netstandard", StringComparison.OrdinalIgnoreCase) &&
                !a.FullName.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase)
            );
        return userAssemblies;
    }
}
