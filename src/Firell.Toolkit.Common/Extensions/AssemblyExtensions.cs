using System.Reflection;

namespace Firell.Toolkit.Common.Extensions;

public static class AssemblyExtensions
{
    /// <summary>
    /// Gets the informational version of the assembly.
    /// 
    /// <para>
    /// <Version>1.0.0-xyz</Version>
    /// </para>
    /// </summary>
    public static string? GetVersion(this Assembly assembly)
    {
        return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    }

    /// <summary>
    /// Gets the Win32 file version of the assembly.
    /// 
    /// <para>
    /// <FileVersion>1.0.0.0</FileVersion>
    /// </para>
    /// </summary>
    public static string? GetFileVersion(this Assembly assembly)
    {
        return assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
    }

    /// <summary>
    /// Gets the assembly version of the assembly.
    /// 
    /// <para>
    /// <AssemblyVersion>1.0.0.0</AssemblyVersion>
    /// </para>
    /// </summary>
    public static string? GetAssemblyVersion(this Assembly assembly)
    {
        return assembly.GetName()?.Version?.ToString();
    }

    /// <summary>
    /// Gets the <see cref="AssemblyName"/> objects for the current assembly and all assemblies that reference it using a similar root name.
    /// </summary>
    public static IEnumerable<AssemblyName> GetReferencedAssembliesWithRelatedName(this Assembly assembly)
    {
        List<AssemblyName> assemblies = new List<AssemblyName>() {
            assembly.GetName()
        };

        string rootAssemblyName = assembly.FullName?.Split('.').FirstOrDefault() ?? string.Empty;

        IEnumerable<AssemblyName> referencedAssemblies = assembly.GetReferencedAssemblies().Where(x => x.Name?.Contains(rootAssemblyName) ?? false);
        assemblies.AddRange(referencedAssemblies);

        return assemblies;
    }
}
