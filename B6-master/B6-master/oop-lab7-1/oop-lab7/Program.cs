using System;
using ClassLibrary;

namespace oop_lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            People p1 = new People("Палійчук", "Яна", "18/01/2001");
            p1.ShowInfo();
            Console.Write("\nPress enter to continue");
            Console.ReadKey();
            Abiturient a1 = new Abiturient(100, 50, "Tulukiv School", p1);
            p1 = a1;
            p1.ShowInfo();
            Console.Write("\nPress enter to continue");
            Console.ReadKey();
            Student s1 = new Student(4, "P-41", "Programming", "KPK NU LP", a1);
            p1 = s1;
            p1.ShowInfo();
            Console.Write("\nPress enter to continue");
            Console.ReadKey();

            People p2 = new People("Олександра", "Бриндзак", "29/05/1970");
            p2.ShowInfo();
            Console.Write("\nPress enter to continue");
            Console.ReadKey();
            Vykladach v1 = new Vykladach("Vchutel", "Полiтологiя", "KPK NU LP", p2);
            p2 = v1;
            p2.ShowInfo();
            Console.Write("\nPress enter to continue");
            Console.ReadKey();

            KorystuvachBiblioteku k1 = new KorystuvachBiblioteku(5, "03/11/2019", 15, s1);
            p1 = k1;
            p1.ShowInfo();
        }
    }
}
