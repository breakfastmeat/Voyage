using System.Collections.Immutable;
namespace Voyage.Operation;

/// <summary>
/// the Archetype class for storing components. initialization requires an archetype builder or null.
/// </summary>
public partial class Archetype
{
      internal HashSet<Type> _typeSet;

      internal string _collectedTypes;
      internal object[] _dataMatrix;
      internal sbyte[] _indexMap;

      public ImmutableHashSet<Type> TypeSet => _typeSet.ToImmutableHashSet();
      public int ArchetypeID { get; internal set; }
      public int TypeCount { get; internal set; }

      public override string ToString() => _collectedTypes ?? string.Empty;

      public static Archetype Null => new();

      internal Archetype()
      {
            _collectedTypes = null!;
            _dataMatrix = null!;
            _indexMap = null!;
            _typeSet = null!;
            ArchetypeID = -1;
            TypeCount = 0;
      }

}