using System.Runtime.CompilerServices;
namespace Voyage.Operation;

public partial class Archetype : IHasID<ushort>
{
    public ref TComp GetComponent<TComp>(int columnIndex)
    {
        ushort compID = ComponentMetadata<TComp>.ID;
        ref readonly byte rowIndex = ref _indexMap[compID];
        var module = (Module<TComp>)_dataMatrix[rowIndex];

        return ref module[columnIndex];
    }

    public ref TComp GetComponentUnsafe<TComp>(int columnIndex)
    {
        ushort compID = ComponentMetadata<TComp>.ID;
        ref readonly byte rowIndex = ref _indexMap[compID];
        var module = Unsafe.As<Module<TComp>>(this[rowIndex]);

        return ref Unsafe.AsRef(ref module[columnIndex]);
    }

    public ushort GetID() => ArchetypeID;
    object IHasID.GetID() => GetID();

    // entity indicing
}