
using SingletonFootball;

var b1 = Ball.GetInstance();
var b2 = Ball.GetInstance();

if (b1 == b2)
    System.Console.WriteLine("A mesma instância foi atribuída aos dois objetos");
else
    System.Console.WriteLine("Instância diferentes foram atribuídas");




Thread process1 = new Thread(() => {
    TestSingleton("George");
});
Thread process2 = new Thread(() => {
    TestSingleton("Hamilton");
});

process1.Start();
process2.Start();

process1.Join();
process2.Join();

void TestSingleton(string value)
{
    Referee Referee = Referee.GetInstance(value);
    Console.WriteLine(Referee.Name);
} 