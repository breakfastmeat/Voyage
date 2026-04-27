using Voyage.Operation;
namespace Voyage;

public class World : IUpdatable
{
    internal readonly Query _query;
    internal readonly FastStack<Entity> _entities;
    public readonly int WorldID;

    public Entity this[int index] => _entities[index];
    
    public Archetype GetArchetype(Entity entity) => _query[entity.ArchetypeID];
    public Archetype GetArchetype(Entity.EntityLookup lookup) => _query[lookup.ArchetypeID];
    public Archetype GetArchetype(Entity.EntityReader reader) => _query[reader.ArchetypeID];
    public Archetype GetArchetype(int archetypeID) => _query[archetypeID];

    public World(int worldID)
    {
        WorldID = worldID;
        _query = new(this);
        _entities = FastStack<Entity>.Create(4);
    }

    public World(int worldID, int entityInitLength)
    {
        WorldID = worldID;
        _query = new(this);
        _entities = FastStack<Entity>.Create(entityInitLength);
    }

    public Entity.EntityReader ReadEntity(int index) => _entities[index].Read();
    public Entity.EntityLookup LookupEntity(int index) => _entities[index].GetEntityLookup();

    public void Update()
    {
        int len = _query._archetypes.Count;
        for(int i = 0; i < len; i++)
        {
            if (_query[i].GetID() == 0) continue;
            _query._archetypes[i].Update();
        }
    }

    public ushort CreateEntity(Archetype archetype)
    {
        ushort index = _entities.Push(Entity.Null);
        _entities[index].EntityID = index;

        archetype.Increment(ref _entities[index]);
        return index;
    }

    public ushort ConstructArchetype<TBuilder>(TBuilder builder) where TBuilder : IArchetypeBuilder => _query.CreateArchetype(builder); 
    public ushort ConstructArchetype(ArchetypeBuilder builder) => _query.CreateArchetype(builder);
}