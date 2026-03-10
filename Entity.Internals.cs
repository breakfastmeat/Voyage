namespace Voyage;

public partial struct Entity : IEquatable<Entity> 
{
  internal int entityID;
  internal ushort entityVersion;
  internal ushort entityPosition;
}  
