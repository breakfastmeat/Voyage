using Voyage.Operation;
namespace Voyage;

public interface IArchetypeBuilder
{
      public Archetype Finalize(uint archetypeID);
      public Archetype Return();
}