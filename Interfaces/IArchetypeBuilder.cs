using Voyage.Operation;
namespace Voyage;

internal interface IArchetypeBuilder<TBuilder> where TBuilder : class
{
      public TBuilder Initialize(int typeCount, uint initialCapacity); 
      public Archetype Finalize(int archetypeID);
}