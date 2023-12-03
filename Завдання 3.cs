using System;

// Абстрактні класи компонентів
abstract class Screen
{
    public abstract void DisplayInfo();
}

abstract class Processor
{
    public abstract void Process();
}

abstract class Camera
{
    public abstract void Capture();
}

// Конкретні класи компонентів
class SmartphoneScreen : Screen
{
    public override void DisplayInfo()
    {
        Console.WriteLine("Екран смартфона");
    }
}

class SmartphoneProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Процесор смартфона");
    }
}

class SmartphoneCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Камера смартфона");
    }
}

class LaptopScreen : Screen
{
    public override void DisplayInfo()
    {
        Console.WriteLine("Екран ноутбука");
    }
}

class LaptopProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Процесор ноутбука");
    }
}

class LaptopCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Камера ноутбука");
    }
}

// Абстрактна фабрика для створення компонентів
abstract class ProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретні фабрики для різних типів продуктів
class SmartphoneFactory : ProductFactory
{
    public override Screen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public override Camera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

class LaptopFactory : ProductFactory
{
    public override Screen CreateScreen()
    {
        return new LaptopScreen();
    }

    public override Processor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public override Camera CreateCamera()
    {
        return new LaptopCamera();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть тип продукту: 1 - смартфон, 2 - ноутбук");
        int choice = int.Parse(Console.ReadLine());

        ProductFactory factory = null;

        switch (choice)
        {
            case 1:
                factory = new SmartphoneFactory();
                break;
            case 2:
                factory = new LaptopFactory();
                break;
            default:
                Console.WriteLine("Введено невірний тип продукту");
                return;
        }

        Screen screen = factory.CreateScreen();
        Processor processor = factory.CreateProcessor();
        Camera camera = factory.CreateCamera();

        screen.DisplayInfo();
        processor.Process();
        camera.Capture();

        Console.ReadLine();
    }
}
