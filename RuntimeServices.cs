using System.Reflection;
using Voyage.Operation;
namespace Voyage.Helper;

public static class RuntimeServices
{
    
    public static bool IsReference<T>()
    {
        return ComponentRuntime<T>.IsReference;
    }

    public static bool IsReferenceOrContainsReferences<T>()
    {
        return ComponentRuntime<T>.IsRefOrContainsRefs();
    }
}