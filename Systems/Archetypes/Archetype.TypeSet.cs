namespace Voyage.Operation;

public partial class Archetype
{
    public bool HasComponent<TComp>()
    {
        ushort compID = ComponentMetadata<TComp>.ID;
        return _typeSet.ToArray()[compID] == typeof(TComp);
    }

    public bool HasComponent<TComp>(out ushort componentID)
    {
        componentID = ComponentMetadata<TComp>.ID;
        return _typeSet.ToArray()[componentID] == typeof(TComp);
    }

    // Module Upfronts

    public void ToggleElement<T>(ushort index, bool toggle)
    {
        var module = GetModule<T>();
        module.ToggleElement(index, toggle);
    }

    public void ToggleElementSelection<T>(ushort[] indices, bool toggle)
    {
        var module = GetModule<T>();
        module.ToggleElementSelection(indices, toggle);
    }

    public bool IsElementValid<T>(ushort index)
    {
        var module = GetModule<T>();
        return module.IsElementValid(index);
    }

    public bool AnyElementsValid<T>(ushort[] indices)
    {
        var module = GetModule<T>();
        return module.AnyElementsValid(indices);
    }

    public bool AllElementsValid<T>(ushort[] indices)
    {
        var module = GetModule<T>();
        return module.AllElementsValid(indices);
    }
}