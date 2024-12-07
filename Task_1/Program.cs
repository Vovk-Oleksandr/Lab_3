using System;
using System.Collections.Generic;

namespace Task_1
{
    // Базовий клас "Живий організм"
    abstract class LivingOrganism
    {
        public double Energy { get; set; }
        public int Age { get; set; }
        public double Size { get; set; }

        public LivingOrganism(double energy, int age, double size)
        {
            Energy = energy;
            Age = age;
            Size = size;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Енергія: {Energy}, Вік: {Age}, Розмір: {Size}");
        }
    }

    // Інтерфейс для розмноження
    interface IReproducible
    {
        void Reproduce();
    }

    // Інтерфейс для хижаків
    interface IPredator
    {
        void Hunt(LivingOrganism prey);
    }

    // Клас "Тварина"
    class Animal : LivingOrganism, IReproducible, IPredator
    {
        public string Species { get; set; }

        public Animal(double energy, int age, double size, string species) : base(energy, age, size)
        {
            Species = species;
        }

        public void Reproduce()
        {
            Console.WriteLine($"{Species} розмножується...");
        }

        public void Hunt(LivingOrganism prey)
        {
            Console.WriteLine($"{Species} полює на жертву...");
            Energy += prey.Size * 0.5; // Енергія збільшується
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Вид: {Species}");
        }
    }

    // Клас "Рослина"
    class Plant : LivingOrganism, IReproducible
    {
        public string PlantType { get; set; }

        public Plant(double energy, int age, double size, string plantType) : base(energy, age, size)
        {
            PlantType = plantType;
        }

        public void Reproduce()
        {
            Console.WriteLine($"Рослина типу {PlantType} розмножується...");
        }
    }

    // Клас "Мікроорганізм"
    class Microorganism : LivingOrganism
    {
        public string Species { get; set; }

        public Microorganism(double energy, int age, double size, string species) : base(energy, age, size)
        {
            Species = species;
        }
    }

    // Клас "Екосистема"
    class Ecosystem
    {
        private List<LivingOrganism> organisms = new List<LivingOrganism>();

        public void AddOrganism(LivingOrganism organism)
        {
            organisms.Add(organism);
        }

        public void Simulate()
        {
            Console.WriteLine("Симуляція екосистеми почалася...");
            foreach (var organism in organisms)
            {
                organism.DisplayInfo();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ecosystem ecosystem = new Ecosystem();

            Animal lion = new Animal(100, 5, 50, "Лев");
            Plant tree = new Plant(50, 10, 100, "Дуб");
            Microorganism bacteria = new Microorganism(10, 1, 0.5, "Бактерія");

            ecosystem.AddOrganism(lion);
            ecosystem.AddOrganism(tree);
            ecosystem.AddOrganism(bacteria);

            lion.Hunt(bacteria);
            lion.Reproduce();

            tree.Reproduce();

            ecosystem.Simulate();
        }
    }
}
