using System.Reflection;

using Firell.Toolkit.Common.Extensions;

namespace Firell.Toolkit.Common.Helpers;

public static class AssemblyHelper
{
    /// <summary>
    /// Gets the informational version of the entry assembly.
    /// 
    /// <para>
    /// <Version>1.0.0-xyz</Version>
    /// </para>
    /// </summary>
    public static string? GetVersion()
    {
        return Assembly.GetEntryAssembly()?.GetVersion();
    }

    /// <summary>
    /// Gets the Win32 file version of the entry assembly.
    /// 
    /// <para>s
    /// <FileVersion>1.0.0.0</FileVersion>
    /// </para>
    /// </summary>
    public static string? GetFileVersion()
    {
        return Assembly.GetEntryAssembly()?.GetFileVersion();
    }

    /// <summary>
    /// Gets the assembly version of the entry assembly.
    /// 
    /// <para>
    /// <AssemblyVersion>1.0.0.0</AssemblyVersion>
    /// </para>
    /// </summary>
    public static string? GetAssemblyVersion()
    {
        return Assembly.GetEntryAssembly()?.GetAssemblyVersion();
    }

    public static Type? GetType(string name)
    {
        return GetTypes()?.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public static IEnumerable<Type>? GetTypes()
    {
        Assembly? entryAssembly = Assembly.GetEntryAssembly();

        IEnumerable<Assembly>? referencedAssemblies = entryAssembly?.GetReferencedAssembliesWithRelatedName().Select(x => Assembly.Load(x));
        IEnumerable<Type>? type = referencedAssemblies?.SelectMany(x => x.GetTypes());

        return type;
    }
}
