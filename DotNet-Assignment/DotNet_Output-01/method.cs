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


class Dog : Animal
{
    public void Speak() => Console.WriteLine("Dog constructor");
}

class Cat : Animal

{
    public void Speak() => Console.WriteLine("Cat constructor");

}

class Bird : Animal
{
    public void Speak() => Console.WriteLine("Bird constructor");
}