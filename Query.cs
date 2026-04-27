using Voyage.Operation;
namespace Voyage;

public class Query
{
    internal readonly World _world;
    internal readonly FastStack<Archetype> _archetypes;
    internal Archetype this[int index] => _archetypes[index];

    internal Query(World world)
    {
        _world = world;
        _archetypes = FastStack<Archetype>.Create(4);
    }

    internal Query(World world, int initArchetypeCount)
    {
        _world = world;
        _archetypes = FastStack<Archetype>.Create(initArchetypeCount);
    }

    public ushort CreateArchetype<TBuilder>(TBuilder builder) where TBuilder : IArchetypeBuilder
    {
        ushort val = _archetypes.Push(builder.Return());
        _archetypes[val].ArchetypeID = val;
        return val;
    }

    public ushort CreateArchetype(ArchetypeBuilder builder)
    {
        ushort val = _archetypes.Push(builder.Return());
        _archetypes[val].ArchetypeID = val;
        return val;
    }

    
}