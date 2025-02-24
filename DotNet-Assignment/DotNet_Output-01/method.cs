sealed class Animal
{
    public void Speak() => Console.WriteLine("Animal constructor");
}

class Program
{
    static void Main()
    {
        Animal a = new Animal();
        a.Speak();
    }
}
