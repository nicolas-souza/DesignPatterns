using System;
using PrototypeEnemy.Model;

Enemy Boss = new Troll
{
 Name = "Boss",
 Description = "Tordoaldo is an evil troll, with a sharp intelligence and hidden strength, who lives in a forest cave adorned with treasures from his adventures.",
 Weapon = new Weapon("Sword", 500)
};

Enemy Boss_ShallowCopy = Boss.ShallowCopy();
Enemy Boss_DeepCopy = Boss.DeepCopy();

System.Console.WriteLine("First Run \n");
ConsoleInfo();

Boss.Name = "BossWithNewName";
Boss.Weapon.Type = "Other Sword";  

System.Console.WriteLine("Second Run \n");
ConsoleInfo();

void ConsoleInfo()
{
 Console.WriteLine("Boss");
 Console.WriteLine(Boss.ToString());
 Console.WriteLine("Boss Shallow Copy");
 Console.WriteLine(Boss_ShallowCopy.ToString());
 Console.WriteLine("Boss Deep Copy");
 Console.WriteLine(Boss_DeepCopy.ToString());
}