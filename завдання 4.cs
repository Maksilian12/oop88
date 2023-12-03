using System;

// Прототипи для форматів даних
interface IDataFormat
{
    IDataFormat Clone();
    void Load(string data);
    string Save();
}

class CSVFormat : IDataFormat
{
    private string csvData;

    public IDataFormat Clone()
    {
        return new CSVFormat();
    }

    public void Load(string data)
    {
        csvData = data;
        Console.WriteLine("Дані CSV завантажені");
    }

    public string Save()
    {
        Console.WriteLine("Дані збережені у форматі CSV");
        return csvData;
    }
}

class XMLFormat : IDataFormat
{
    private string xmlData;

    public IDataFormat Clone()
    {
        return new XMLFormat();
    }

    public void Load(string data)
    {
        xmlData = data;
        Console.WriteLine("Дані XML завантажені");
    }

    public string Save()
    {
        Console.WriteLine("Дані збережені у форматі XML");
        return xmlData;
    }
}

class JSONFormat : IDataFormat
{
    private string jsonData;

    public IDataFormat Clone()
    {
        return new JSONFormat();
    }

    public void Load(string data)
    {
        jsonData = data;
        Console.WriteLine("Дані JSON завантажені");
    }

    public string Save()
    {
        Console.WriteLine("Дані збережені у форматі JSON");
        return jsonData;
    }
}

// Адаптер для забезпечення сумісності форматів даних
class DataFormatAdapter : IDataFormat
{
    private readonly IDataFormat dataFormat;

    public DataFormatAdapter(IDataFormat format)
    {
        dataFormat = format;
    }

    public IDataFormat Clone()
    {
        return new DataFormatAdapter(dataFormat.Clone());
    }

    public void Load(string data)
    {
        dataFormat.Load(data);
    }

    public string Save()
    {
        return dataFormat.Save();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть формат даних: 1 - CSV, 2 - XML, 3 - JSON");
        int sourceFormat = int.Parse(Console.ReadLine());

        Console.WriteLine("Виберіть цільовий формат даних: 1 - CSV, 2 - XML, 3 - JSON");
        int targetFormat = int.Parse(Console.ReadLine());

        string sourceData = "Демо-дані для експорту та імпорту";

        IDataFormat source = GetFormat(sourceFormat);
        IDataFormat target = GetFormat(targetFormat);

        source.Load(sourceData);

        DataFormatAdapter adapter = new DataFormatAdapter(target);
        adapter.Load(source.Save());

        Console.ReadLine();
    }

    static IDataFormat GetFormat(int format)
    {
        switch (format)
        {
            case 1:
                return new CSVFormat();
            case 2:
                return new XMLFormat();
            case 3:
                return new JSONFormat();
            default:
                throw new ArgumentException("Невідомий формат даних");
        }
    }
}
