using System.Runtime.CompilerServices;
namespace Voyage.Operation;

public partial class Archetype : IHasID<ushort>, IUpdatable
{
    public ref TComp GetComponent<TComp>(int columnIndex)
    {
        ushort compID = ComponentMetadata<TComp>.ID;
        byte rowIndex = _indexMap[compID];
        var module = (Module<TComp>)_dataMatrix[rowIndex];

        return ref module[columnIndex];
    }

    public ref TComp GetComponentUnsafe<TComp>(int columnIndex)
    {
        ushort compID = ComponentMetadata<TComp>.ID;
        byte rowIndex = _indexMap[compID];
        var module = Unsafe.As<Module<TComp>>(this[rowIndex]);

        return ref Unsafe.AsRef(ref module[columnIndex]);
    }

    public ushort GetID() => ArchetypeID;
    object IHasID.GetID() => GetID();

    // entity indicing

    public bool Increment(ref Entity entity)
    {
        var index = _entityPosition++;
        
        if (index > Capacity - 1) throw new ArgumentException($"Archetype has reached maximum amount of entities.");
        else if (entity.IsNull()) throw new ArgumentNullException($"{entity} can not be null.");

        if (entity.Queue > _entityMap.Length - 1) goto exit_success;
        else if (_entityMap[entity.Queue] == entity.EntityID) return false;
        
        exit_success:
        _entityMap[index] = entity.EntityID;
        entity = new Entity(entity.EntityID, ArchetypeID, index);
        
        return true;
    }

    // Updating
    public void UpdateComponents<TComp>(UpdateAction<TComp> updater)
    {
        ushort compID = ComponentMetadata<TComp>.ID;
        byte rowIndex = _indexMap[compID];
        var module = (Module<TComp>)this[rowIndex];

        var denseSet = module.GetDenseSet();
        var denseSetLength = denseSet.Length;
        
        if (denseSetLength == 0) return;

        for(int i = 0; i < denseSetLength; i++)
        {
            ref TComp component = ref module[denseSet[i]];
            updater(ref component);
        }
    }

    public void Update()
    {
        for(int i = 0; i < Capacity; i++) _archetypeAction(i);
    }

    public void ResizeModules(int newLength)
    {
        Capacity = newLength;
        _archetypeResizer(newLength);
    }

    public static void UpdateComponents<T>(Archetype archetype, UpdateAction<T> _updateAction)
    {
        if (archetype.ArchetypeID == 0) return;
        archetype.UpdateComponents(_updateAction);
    }

    public void SetUpdater(Action<int> newUpdater) => _archetypeAction = newUpdater;
}