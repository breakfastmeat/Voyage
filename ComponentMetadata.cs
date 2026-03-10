namespace Voyage;

internal static class ComponentCounter 
{
  internal static uint _totalTypesCounted = 0;
}

public static class ComponentMetadata<T> 
{
  public static readonly uint ID = ComponentCounter._totalTypesCounted++;
  public static readonly Type Type = typeof(T);
  public static readonly object[] Attributes = typeof(T).GetCustomAttributes(false);
}
