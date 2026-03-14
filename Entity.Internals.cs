namespace Voyage;

public partial struct Entity
{
      internal int EntityID;
      internal ushort ArchetypeID;
      internal ushort Queue;

      public ref struct EntityReader
      {
            public readonly int EntityID;
            public readonly ushort ArchetypeID;
            public readonly ushort Queue;

            public EntityReader(Entity entity)
            {
                  EntityID = entity.EntityID;
                  ArchetypeID = entity.ArchetypeID;
                  Queue = entity.Queue;
            }

            public static EntityReader GetInfo(Entity entity) => new(entity);
      }

      public EntityReader Read() => new(this);
}