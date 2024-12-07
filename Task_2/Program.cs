using System;
using System.Collections.Generic;

// Інтерфейс для з'єднання
public interface IConnectable
{
    void Connect(IConnectable device);
    void Disconnect();
    void SendData(string data, IConnectable recipient);
}

// Базовий клас Комп'ютер
public abstract class Computer : IConnectable
{
    public string IpAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }

    protected Computer(string ipAddress, int power, string operatingSystem)
    {
        IpAddress = ipAddress;
        Power = power;
        OperatingSystem = operatingSystem;
    }

    public abstract void Connect(IConnectable device);
    public abstract void Disconnect();
    public abstract void SendData(string data, IConnectable recipient);

    public override string ToString()
    {
        return $"{GetType().Name} (IP: {IpAddress}, OS: {OperatingSystem})";
    }
}

// Клас Сервер
public class Server : Computer
{
    public int StorageCapacity { get; set; }

    public Server(string ipAddress, int power, string operatingSystem, int storageCapacity)
        : base(ipAddress, power, operatingSystem)
    {
        StorageCapacity = storageCapacity;
    }

    public override void Connect(IConnectable device)
    {
        Console.WriteLine($"{this} підключився до {device}.");
    }

    public override void Disconnect()
    {
        Console.WriteLine($"{this} відключився.");
    }

    public override void SendData(string data, IConnectable recipient)
    {
        Console.WriteLine($"{this} відправив дані '{data}' до {recipient}.");
    }
}

// Клас Робоча станція
public class Workstation : Computer
{
    public string User { get; set; }

    public Workstation(string ipAddress, int power, string operatingSystem, string user)
        : base(ipAddress, power, operatingSystem)
    {
        User = user;
    }

    public override void Connect(IConnectable device)
    {
        Console.WriteLine($"{this} підключився до {device}.");
    }

    public override void Disconnect()
    {
        Console.WriteLine($"{this} відключився.");
    }

    public override void SendData(string data, IConnectable recipient)
    {
        Console.WriteLine($"{this} відправив дані '{data}' до {recipient}.");
    }
}

// Клас Маршрутизатор
public class Router : Computer
{
    public int MaxConnections { get; set; }

    public Router(string ipAddress, int power, string operatingSystem, int maxConnections)
        : base(ipAddress, power, operatingSystem)
    {
        MaxConnections = maxConnections;
    }

    public override void Connect(IConnectable device)
    {
        Console.WriteLine($"{this} підключився до {device}.");
    }

    public override void Disconnect()
    {
        Console.WriteLine($"{this} відключився.");
    }

    public override void SendData(string data, IConnectable recipient)
    {
        Console.WriteLine($"{this} відправив дані '{data}' до {recipient}.");
    }
}

// Клас Мережа
public class Network
{
    private List<IConnectable> Devices = new List<IConnectable>();

    public void AddDevice(IConnectable device)
    {
        Devices.Add(device);
        Console.WriteLine($"Пристрій {device} доданий до мережі.");
    }

    public void RemoveDevice(IConnectable device)
    {
        Devices.Remove(device);
        Console.WriteLine($"Пристрій {device} видалений з мережі.");
    }

    public void SendData(string data, IConnectable sender, IConnectable recipient)
    {
        Console.WriteLine($"Мережа: {sender} відправляє дані '{data}' до {recipient}.");
        sender.SendData(data, recipient);
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        // Створення пристроїв
        var server = new Server("192.144.1.1", 500, "Linux", 1000);
        var workstation = new Workstation("192.168.1.2", 300, "Windows", "User1");
        var router = new Router("192.144.1.254", 100, "CiscoOS", 10);

        // Створення мережі
        var network = new Network();

        // Додавання пристроїв до мережі
        network.AddDevice(server);
        network.AddDevice(workstation);
        network.AddDevice(router);

        // Передача даних
        network.SendData("Hello, World!", workstation, server);

        // Відключення пристрою
        workstation.Disconnect();
    }
}
