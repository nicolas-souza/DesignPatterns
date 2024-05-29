namespace PrototypeEnemy.Interface;

public interface IPrototype<T>
{
    T ShallowCopy();
    T DeepCopy();    
}
