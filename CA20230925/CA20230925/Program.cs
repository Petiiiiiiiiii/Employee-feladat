using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CA20230925;
using System.Diagnostics;

namespace CA202309251330
{
    class Program
    {
        static double AtlagEletkor(List<dolgozo> dolgozok)
        {
            return dolgozok
                .Average(d => d.Age);
        }

        static void Budapestie(List<dolgozo> dolgozok)
        {
            int budapestiek = dolgozok
                .Count(b => b.City == "Budapest");
            Console.WriteLine("Ennyien élnek budapesten: " + budapestiek);
        }

        static void Legidosebb(List<dolgozo> dolgozok)
        {
            var legidosebb = dolgozok
                .OrderByDescending(b => b.Age)
                .First();

            Console.WriteLine(legidosebb);
        }

        static void OtvenFelett(List<dolgozo> dolgozok) 
        {
            var otven = dolgozok
                .Where(d => d.Age >= 50);

            if (otven.Count() >= 1)
            {
                Console.WriteLine("50 feletti ember/emberek neve: ");
                foreach (var d in otven)
                {
                    Console.WriteLine(d.Name);
                }
            }
            else 
            {
                Console.WriteLine("Nincs 50 feletti ember!");
            }
        }

        static void HarmincnalAlatt(List<dolgozo> dolgozok) 
        {
            var harmincAlatti = new dolgozo[dolgozok.Count(d => d.Age <= 29)];

            var Nevek = dolgozok
                .Where(d => d.Age <= 29);

            Console.WriteLine("30 alatti emberek neve: ");

            foreach (var d in Nevek) 
            {
                Console.WriteLine("\t" + d.Name);
            }

        }

        static int LegidosebbLegfiatalabb(List<dolgozo> dolgozok, List<dolgozo> dolgozokFO)
        {
            var legidoseb = dolgozok
                .Where(d => d.Age == dolgozok.Max(k => k.Age))
                .First();

            dolgozokFO.Add(legidoseb);

            var legfiatalab = dolgozok
                .Where(d => d.Age == dolgozok.Min(k => k.Age))
                .First();

            dolgozokFO.Add(legfiatalab);


            var dblegfiatalabb = dolgozok
                .Where(d => d.Age == dolgozok.Min(k => k.Age));

            return dblegfiatalabb.Count();

            
        }

        static void Kiiras(List<dolgozo> dolgozok) 
        {
            var sw = new StreamWriter(@"..\..\..\src\fizetesek.txt");

            var gazdagok = dolgozok.Where(d => d.YearlySalaryHUF >= 12000000);

            foreach (var g in gazdagok)
            {
                sw.WriteLine($"{g.Name};{g.YearlySalaryHUF}");
            }

            sw.Close();
        }

        static double AtlagFizetes(List<dolgozo> dolgozok) 
        {
            return dolgozok.Average(d => d.Salary);
        }

        static List<dolgozo> Developerek(List<dolgozo> dolgozok, List<dolgozo> dolgozoDevs) 
        { 
            var dolgozoDevList = new List<dolgozo>();

            var devs = dolgozok.Where(d => d.Position == "Developer");

            foreach (var dev in devs) 
            {
                dolgozoDevs.Add(dev);
            }

            return dolgozoDevs;
        }

        static void Main()
        {
            var dolgozok = new List<dolgozo>();
            var sr = new StreamReader(@"..\..\..\src\dolgozok.txt");

            while (!sr.EndOfStream)
            {
                dolgozok.Add(new dolgozo(sr.ReadLine()));
            }

            sr.Close();

            foreach (var d in dolgozok)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine();
            Console.WriteLine("Átlag életkor: " + AtlagEletkor(dolgozok));

            Console.WriteLine();
            Budapestie(dolgozok);

            Console.WriteLine();
            Console.WriteLine("Legidősebb adatai: ");
            Legidosebb(dolgozok);

            Console.WriteLine();
            OtvenFelett(dolgozok);

            Console.WriteLine();
            HarmincnalAlatt(dolgozok);

            var dolgozokFO = new List<dolgozo>();
            int dbLegfiatalabb = LegidosebbLegfiatalabb(dolgozok, dolgozokFO);

            Console.WriteLine();

            foreach (var d in dolgozokFO) 
            {
                Console.WriteLine($"{d.Name}, {d.Age}");
            }

            Console.WriteLine(dbLegfiatalabb + " db legfitalabb ember van");

            Kiiras(dolgozok);

            Console.WriteLine();
            Console.WriteLine($"Az átlag fizetés : {AtlagFizetes(dolgozok):0.00} euró");

            var dolgozoDevs = new List<dolgozo>();

            Developerek(dolgozok,dolgozoDevs);
            Console.WriteLine();
            Console.WriteLine($"A developerek átlag fizetése : {AtlagFizetes(dolgozoDevs):0.00} euró");

            double ferfiAtlag = dolgozok
                .Where(d => d.Gender)
                .Average(k => k.Salary);

            double noiAtlag = dolgozok
                .Where(d => !d.Gender)
                .Average(k => k.Salary);

            Console.WriteLine();
            Console.WriteLine($"A női átlag fizetés: {noiAtlag} euró");
            Console.WriteLine();
            Console.WriteLine($"A férfi átlag fizetés: {ferfiAtlag} euró");

            Console.ReadKey();
        }
    }
}
