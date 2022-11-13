using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract int GetPrice(int type);
    }

    public class Abonnement : Creator
    {
        public override int GetPrice(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: { Price _price = new PriceWithTrainer(); return _price.ThisPrice(); }
                //повертає об'єкт B, якщо type==2  
                case 2: { Price _price = new PriceWithoutTrainer(); return _price.ThisPrice(); }
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Price { public abstract int ThisPrice(); } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class PriceWithTrainer : Price { public override int ThisPrice() { return 7; } }

    public class PriceWithoutTrainer : Price { public override int ThisPrice() { return 3; } }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator abonnement = new Abonnement();
            Console.WriteLine("To show price with trainer write 1 , without trainer write 2");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Price is {0}",abonnement.GetPrice(type));
            Console.ReadKey();
        }
    }
}
