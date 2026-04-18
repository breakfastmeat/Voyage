using System.Reflection;
namespace Voyage;

internal static class ComponentCounter 
{
  internal static ushort _totalTypesCounted = 0;
}

public static class ComponentMetadata<T> 
{
  public static readonly ushort ID = ComponentCounter._totalTypesCounted++;
  public static readonly object[] Attributes = typeof(T).GetCustomAttributes(false);
}

public static class ComponentRuntime<T>
{
  public static readonly bool IsReference = ComponentRuntimeInitializer.IsRef(typeof(T));
  public static readonly bool ContainsReferences = ComponentRuntimeInitializer.ContainsReferences(typeof(T));
  public static bool IsRefOrContainsRefs() => IsReference || ContainsReferences;
}

internal static class ComponentRuntimeInitializer
{
  internal static bool IsRef(Type type)
  {
    return type.IsArray || type.IsClass;
  }

  internal static bool ContainsReferences(Type type)
  {
    foreach(var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic))
    {
      if (IsRef(field.GetType())) return true;
    }

    foreach(var prop in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public))
    {
      if (IsRef(prop.GetType())) return true;
    }

    return false;
  }
}
