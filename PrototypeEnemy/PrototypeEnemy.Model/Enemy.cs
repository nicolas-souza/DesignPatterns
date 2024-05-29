using PrototypeEnemy.Interface;

namespace PrototypeEnemy.Model;

public abstract class Enemy : IPrototype<Enemy>
{
    public string Name;
    public string Description;    
    public Weapon Weapon;
    public abstract Enemy ShallowCopy();
    public abstract Enemy DeepCopy();

}
