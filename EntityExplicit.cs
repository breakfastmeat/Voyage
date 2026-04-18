using Voyage;
namespace Voyage.Marshals;

public static class EntityMarshal
{
    public static Entity CreateEntity(int id, ushort arch, ushort queue)
    {
        return new(id, arch, queue);
    }

    public static int SetID(ref Entity entity, int newID)
    {
        int previousID = entity.EntityID;

        entity.EntityID = newID;
        return previousID;
    }

    public static ushort SetArchetypeID(ref Entity entity, ushort newID)
    {
        ushort previousID = entity.ArchetypeID;
        entity.ArchetypeID = newID;
        return previousID;
    }

    public static ushort SetQueue(ref Entity entity, ushort newQueue)
    {
        ushort previousQueue = entity.Queue;
        entity.Queue = newQueue;
        return previousQueue;
    }
}