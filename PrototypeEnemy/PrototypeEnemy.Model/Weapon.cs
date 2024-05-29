using PrototypeEnemy.Interface;

namespace PrototypeEnemy.Model;

public class Weapon : IPrototype<Weapon>
{
    public string Type;
    public int Damage;

    public Weapon(string type, int damage)
    {
        this.Type = type;
        this.Damage = damage;
    }
    public Weapon ShallowCopy()
    {
        return (Weapon)this.MemberwiseClone();
    }

    public Weapon DeepCopy()
    {
        return new Weapon(Type, Damage);
    }
}