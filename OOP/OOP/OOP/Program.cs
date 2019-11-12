using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // Для кожного класу реалізувати конструктори:
    //- по замовчуванню;
    //- не менше двох конструкторів з параметрами;
    //- конструктор копіювання.
    // Реалізувати Set- та Get- методи для кожного поля.

    class Program
    {
        static Product[] ReadProductsArray() // читає з клавіатури дані і повертає масив об’єктів типу Product(n штук)
        {
            string temp;
            bool isValid;

            int n;
            Console.WriteLine("Кiлькiсть продуктiв: ");

            temp = Console.ReadLine();
            isValid = Int32.TryParse( temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out int _);
            if (!isValid)
            {
                Console.WriteLine("Ви ввели не число");
                return null; // - вихід із процедури або Return
            }
            n = Convert.ToInt32(temp);
            Product[] product = new Product[n];
            for(int i = 0; i < n; i++)
            {
                product[i] = new Product();
                product[i].Cost = new Currency();
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nProduct {i+1}:");

                Console.WriteLine("Назва товару: ");
                product[i].Name = Console.ReadLine();

                Console.WriteLine("Варiсть одиницi товару: ");
                temp = Console.ReadLine();
                isValid = Double.TryParse( temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out double _);
                if (!isValid)
                {
                    Console.WriteLine("Помилка вводу\n");
                    i--;
                    continue;
                }
                product[i].Price = Convert.ToDouble(temp);

                Console.WriteLine("Кiлькiсть наявних товарiв на складi: ");
                temp = Console.ReadLine();
                isValid = Int32.TryParse(temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out int _);
                if (!isValid)
                {
                    Console.WriteLine("Помилка вводу\n");
                    i--;
                    continue;
                }
                product[i].Quantity = Convert.ToInt32(temp);

                Console.WriteLine("Назва компанiї виробника: ");
                product[i].Producer = Console.ReadLine();

                Console.WriteLine("Вага одиницi товару: ");
                temp = Console.ReadLine();
                isValid = Double.TryParse(temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out double _);
                if (!isValid)
                {
                    Console.WriteLine("Помилка вводу\n");
                    i--;
                    continue;
                }
                product[i].Weight = Convert.ToDouble(temp);

                Console.WriteLine("(Грошова одиниця, у якiц вимирюється вартiсть) Назва: ");
                product[i].Cost.Name = Console.ReadLine();

                Console.WriteLine("(Грошова одиниця, у якiц вимирюється вартiсть) Кiлькiсть гривень та копiйок, що дають за одиницю валюти: ");
                temp = Console.ReadLine();
                isValid = Double.TryParse(temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out double _);
                if (!isValid)
                {
                    Console.WriteLine("Помилка вводу\n");
                    i--;
                    continue;
                }
                product[i].Cost.ExRate = Convert.ToDouble(temp);
            }
            return product;
        }
        static void PrintProduct(Product product) //приймає об’єкт типу Product і виводить його на екран
        {
            Console.WriteLine($"Назва товару: {product.Name}");
            Console.WriteLine($"Варiсть одиницi товару: {product.Price}");
            Console.WriteLine($"Кiлькiсть наявних товарiв на складi: {product.Quantity}");
            Console.WriteLine($"Назва компанiї виробника: {product.Producer}");
            Console.WriteLine($"Вага одиницi товару: {product.Weight}");
            Console.WriteLine($"(Грошова одиниця, у якiц вимирюється вартiсть) Назва: {product.Cost.Name}");
            Console.WriteLine($"(Грошова одиниця, у якiц вимирюється вартiсть) Кiлькiсть гривень та копiйок, що дають за одиницю валюти: {product.Cost.ExRate}");
            Console.WriteLine($"Цiна одиницi товару в гривнях: {product.getPriceInUAH()}");
            Console.WriteLine($"Загальна вартiсть всiх товарiв даного виду в гривнях: {product.GetTotalPriceInUAH()}");
            Console.WriteLine($"Загальна вага всiх товарiв даного виду: {product.GetTotalWeight()}");
            
        }
        static void PrintProducts(Product[] product) //приймає масив об’єктів типу Product і виводить його на екран
        {
            foreach(Product p in product)
            {
                Console.WriteLine($"Назва товару: {p.Name}");
                Console.WriteLine($"Варiсть одиницi товару: {p.Price}");
                Console.WriteLine($"Кiлькiсть наявних товарiв на складi: {p.Quantity}");
                Console.WriteLine($"Назва компанiї виробника: {p.Producer}");
                Console.WriteLine($"Вага одиницi товару: {p.Weight}");
                Console.WriteLine($"(Грошова одиниця, у якiц вимирюється вартiсть) Назва: {p.Cost.Name}");
                Console.WriteLine($"(Грошова одиниця, у якiц вимирюється вартiсть) Кiлькiсть гривень та копiйок, що дають за одиницю валюти: {p.Cost.ExRate}");
                Console.WriteLine($"Цiна одиницi товару в гривнях: {p.getPriceInUAH()}");
                Console.WriteLine($"Загальна вартiсть всiх товарiв даного виду в гривнях: {p.GetTotalPriceInUAH()}");
                Console.WriteLine($"Загальна вага всiх товарiв даного виду: {p.GetTotalWeight()}");
                Console.WriteLine(new string('-', 50));
            }
        }
        static void GetProductsInfo(Product[] product, out Product minPriceProduct, out Product maxPriceProduct) // приймає масив об’єктів типу Product і повертає через out-параметри найдешевший та найдорожчий товар
        {
            double minPrice = product[0].Price;
            int minIndex = 0;
            double maxPrice = product[0].Price;
            int maxIndex = 0;

            for(int i = 0; i < product.Count(); i++)
            {
                if(product[i].Price > maxPrice)
                {
                    maxPrice = product[i].Price;
                    maxIndex = i;
                }
                if(product[i].Price < minPrice)
                {
                    minPrice = product[i].Price;
                    minIndex = i;
                }
            }

            minPriceProduct = product[minIndex];
            maxPriceProduct = product[maxIndex];
        }
        static void SortProductsByPrice(Product[] product) // приймає масив об’єктів типу Product і сортує його за зростанням ціни
        {
            Array.Sort(product, (p1, p2) => p1.Price.CompareTo(p2.Price));
        }
        static void SortProductsByCount(Product[] product) // приймає масив об’єктів типу Product і сортує його за кількістю товарів на складі 
        {
            Array.Sort(product, (p1, p2) => p1.Quantity.CompareTo(p2.Quantity));
        }
        static void Main(string[] args)
        {
            bool isExit = false;
            int n;
            int n2;

            string temp;
            bool isValid;

            Console.WriteLine("Створення масиву продуктiв");

            Product[] product = ReadProductsArray();

            while(!isExit)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Меню");
                Console.WriteLine("1. Вивести один продукт");
                Console.WriteLine("2. Вивести масив продуктiв");
                Console.WriteLine("3. Вивести найдешевший та найдорожчий товар");
                Console.WriteLine("4. Посортувати за зростанням цiн");
                Console.WriteLine("5. Посортувати за кiлькiстю товарiв");
                Console.WriteLine("6. Exit");
                Console.WriteLine(new string('-', 50));

                temp = Console.ReadLine();
                isValid = Int32.TryParse(temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out int _);
                if (!isValid)
                {
                    Console.WriteLine("Помилка вводу\n");
                    continue;
                }
                n = Convert.ToInt32(temp);

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Номер продукту, який виводити: ");
                        temp = Console.ReadLine();
                        isValid = Int32.TryParse(temp, System.Globalization.NumberStyles.Number, System.Globalization.NumberFormatInfo.CurrentInfo, out int _);
                        if (!isValid)
                        {
                            Console.WriteLine("Помилка вводу\n");
                            continue;
                        }
                        n2 = Convert.ToInt32(temp);

                        if (n2 < 0 || n2 - 1 > product.Count())
                        {
                            Console.WriteLine("Такого елементу нема");
                            break;
                        }

                        PrintProduct(product[n2-1]);
                        break;
                    case 2:     
                        PrintProducts(product);
                        break;
                    case 3:
                        Product minPriceProduct;
                        Product maxPriceProduct;
                        GetProductsInfo(product, out minPriceProduct, out maxPriceProduct);
                        Console.WriteLine("Найдешевший товар: ");
                        PrintProduct(minPriceProduct);
                        Console.WriteLine("\nНайдорожчий товар: ");
                        PrintProduct(maxPriceProduct);
                        break;
                    case 4:
                        SortProductsByPrice(product);
                        break;
                    case 5:
                        SortProductsByCount(product);
                        break;
                    case 6:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Нема такого варiанту");
                        break;
                }
            }

            //Console.Write(new string('-', 50)); // виведе 50 рисок
        }
    }
}
