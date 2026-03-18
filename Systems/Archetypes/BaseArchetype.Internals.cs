namespace Voyage.Operation;

public partial class Archetype
{
      internal string _collectedTypes;
      internal readonly uint[] _indexMap;
      internal readonly HashSet<Type> _distinctTypes;
      public readonly int ArchetypeID;
      internal readonly IArchetypeBuilder _builder;
      internal Array[] Modules;
}