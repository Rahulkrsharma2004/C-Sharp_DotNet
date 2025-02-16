using System
class CentralBank
{
    public virtual double InterestRate() => 5.0;
}
class NationalBank : CentralBank
{
    public override double InterestRate() => 4.5;
}
class LocalBank : NationalBank
{
    public override double InterestRate() => 4.0;
}

class Vehicle
{
    public virtual void Drive() => Console.WriteLine("Driving a vehicle...");
}
class ElectricCar : Vehicle
{
    public override void Drive() => Console.WriteLine("Driving an electric car...");
}
class GasCar : Vehicle
{
    public override void Drive() => Console.WriteLine("Driving a gas-powered car...");
}
class SelfDrivingCar : ElectricCar
{
    public override void Drive() => Console.WriteLine("Self-driving mode activated...");
}
class HybridCar : GasCar
{
    public override void Drive() => Console.WriteLine("Driving a hybrid car...");
}

class Employee
{
    public virtual double CalculateBonus(double salary) => salary * 0.1;
}
class Manager : Employee
{
    public override double CalculateBonus(double salary) => salary * 0.15;
}
class Director : Manager
{
    public override double CalculateBonus(double salary) => salary * 0.2;
}

class Message
{
    public virtual void Send(string content) => Console.WriteLine($"Sending message: {content}");
}
class EncryptedMessage : Message
{
    public override void Send(string content)
    {
        string encryptedContent = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(content));
        Console.WriteLine({ encryptedContent});
    }
}


class Program
{
    static void Main()
    {
        LocalBank lb = new();
        Console.WriteLine(lb.InterestRate() + "%");

        SelfDrivingCar sdc = new();
        sdc.Drive();

        Director dir = new();
        Console.WriteLine(dir.CalculateBonus(100000));

        EncryptedMessage em = new();
        em.Send("Hello, Secure World!");

        Laptop lp = new();
        Console.WriteLine(lp.GetDiscount() + "%");
    }
}
