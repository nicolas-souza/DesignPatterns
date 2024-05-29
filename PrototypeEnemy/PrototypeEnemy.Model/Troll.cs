using System.Text;
using PrototypeEnemy.Model;

namespace PrototypeEnemy.Model;

public class Troll : Enemy
{
    public override Enemy ShallowCopy()
    {
        return (Enemy)this.MemberwiseClone();
    }

    public override Enemy DeepCopy()
    {
        Enemy enemy = ShallowCopy();
        enemy.Weapon = new Weapon(Weapon.Type, Weapon.Damage);

        return enemy;
    }

    public override string ToString()
    {
        var Str = new StringBuilder();

        Str.AppendLine($"Name: {this.Name}");
        Str.AppendLine($"Description: {this.Description}");
        Str.AppendLine($"Weapon: {Weapon.Type} ({Weapon.Damage})");

        return Str.ToString();
    }
}