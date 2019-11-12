using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Product // представляє інформацію про один товар, який зберігається на складі
    {
        // змінні
        public string Name { set; get; } // назва товару
        public double Price { set; get; } // вартість одиниці товару
        public int Quantity { set; get; } // кількість наявних товарів на складі
        public string Producer { set; get; } // назва компанії-виробника
        public double Weight { set; get; } // вага одиниці товару
        public Currency Cost { set; get; } // грошова одиниця, у якій вимірюється вартість

        // конструктори
        public Product() { }
        public Product(Product previousProduct)
        {
            this.Name = previousProduct.Name;
            this.Price = previousProduct.Price;
            this.Cost = previousProduct.Cost;
            this.Quantity = previousProduct.Quantity;
            this.Producer = previousProduct.Producer;
            this.Weight = previousProduct.Weight;
        }
        public Product(Currency cost)
        {
            this.Cost = cost;
        }
        public Product(string name, double price, int quantity, string producer, double weight, Currency cost) : this(cost)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Producer = producer;
            this.Weight = weight;
        }

        // методи
        public double getPriceInUAH() // повертає ціну одиниці товару в гривнях
        {
            return Price * Cost.ExRate;
        }
        public double GetTotalPriceInUAH() // повертає загальну вартість усіх наявних на складі товарів даного виду
        {
            return getPriceInUAH()*Quantity;
        }
        public double GetTotalWeight() // повертає загальну вагу усіх товарів на складі даного виду
        {
            return Weight * Quantity;
        }
    }
}
