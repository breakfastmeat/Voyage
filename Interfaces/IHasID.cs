namespace Voyage;

public interface IHasID<TReturn> where TReturn : struct
{
      public TReturn GetID();
}