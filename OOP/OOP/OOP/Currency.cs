using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Currency // валюта
    {
        // змінні
        public string Name { set; get; } // назва валюти
        public double ExRate { set; get; } // кількість гривень та копійок, що дають за одну одиницю валюти

        // конструктори
        public Currency() { }
        public Currency(Currency previousCurrency) {
            Name = previousCurrency.Name;
            ExRate = previousCurrency.ExRate;
        }
        public Currency(string name, double exRate)
        {
            this.Name = name;
            this.ExRate = exRate;
        }
    }
}
