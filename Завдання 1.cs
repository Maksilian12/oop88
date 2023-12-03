using System;
using System.Collections.Generic;

public sealed class ConfigurationManager
{
    private static ConfigurationManager instance = null;
    private static readonly object padlock = new object();

    private Dictionary<string, string> configurations;

    private ConfigurationManager()
    {
        configurations = new Dictionary<string, string>();
        // Додайте тут деякі початкові конфігураційні налаштування
        configurations.Add("logging", "enabled");
        configurations.Add("database", "localhost");
    }

    public static ConfigurationManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
                return instance;
            }
        }
    }

    public string GetConfiguration(string key)
    {
        if (configurations.ContainsKey(key))
        {
            return configurations[key];
        }
        return null;
    }

    public void SetConfiguration(string key, string value)
    {
        if (configurations.ContainsKey(key))
        {
            configurations[key] = value;
        }
        else
        {
            configurations.Add(key, value);
        }
    }

    public void ShowAllConfigurations()
    {
        foreach (var kvp in configurations)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
