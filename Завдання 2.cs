using System;

// Інтерфейс для графіків
interface IGraph
{
    void Draw();
}

// Конкретні класи графіків
class LineGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Відображення лінійного графіка");
    }
}

class BarGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Відображення стовпчикового графіка");
    }
}

class PieChart : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Відображення кругової діаграми");
    }
}

// Фабрика для створення графіків
abstract class GraphFactory
{
    public abstract IGraph CreateGraph();
}

// Конкретні фабрики для різних типів графіків
class LineGraphFactory : GraphFactory
{
    public override IGraph CreateGraph()
    {
        return new LineGraph();
    }
}

class BarGraphFactory : GraphFactory
{
    public override IGraph CreateGraph()
    {
        return new BarGraph();
    }
}

class PieChartFactory : GraphFactory
{
    public override IGraph CreateGraph()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть тип графіка: 1 - лінійний, 2 - стовпчиковий, 3 - кругова діаграма");
        int choice = int.Parse(Console.ReadLine());

        GraphFactory factory = null;

        switch (choice)
        {
            case 1:
                factory = new LineGraphFactory();
                break;
            case 2:
                factory = new BarGraphFactory();
                break;
            case 3:
                factory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Введено невірний тип графіка");
                return;
        }

        IGraph graph = factory.CreateGraph();
        graph.Draw();

        Console.ReadLine();
    }
}
