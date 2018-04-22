using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        private struct SHuman
        {
            public string Surname;          // фамилия
            public string Firstname;        // имя
            public string Patronymic;       // отчество
            public int Year;                // год рождения
            
            public SHuman(string surname, string firstname, string patronymic, int year)
            {
                Surname = surname;
                Firstname = firstname;
                Patronymic = patronymic;
                Year = year;
            }
        }
        
        public static void Main()
        {
            SHuman[] group = {
                new SHuman("Пушкин", "Александр", "Сергеевич", 1799),
                new SHuman("Ломоносов", "Михаил", "Васильевич", 1711),
                new SHuman("Тютчев", "Фёдор", "Иванович", 1803),
                new SHuman("Суворов", "Александр", "Васильевич", 1729),
                new SHuman("Менделеев", "Дмитрий", "Иванович", 1834),
                new SHuman("Ахматова", "Анна", "Андреевна", 1889),
                new SHuman("Володин", "Александр", "Моисеевич", 1919),
                new SHuman("Мухина", "Вера", "Игнатьевна", 1889),
            };
            
            WriteSHumans(MakeGroupRecursion(group));
        }

        private static List<int> _helpList;
        private static List<List<SHuman>> _answerList;

        private static List<List<SHuman>> MakeGroupRecursion(SHuman[] arrayHumans)
        {
            _answerList = new List<List<SHuman>>();
            _helpList = new List<int>();
            var counter = 0;
            for (var j = 0; j < arrayHumans.Length; j++)
                _helpList.Add(-1);
            for (var j = 0; j < arrayHumans.Length; j++)
            {
                if (_helpList[j] != -1) continue;
                _answerList.Add(new List<SHuman>());
                _answerList[counter].Add(arrayHumans[j]);
                _helpList[j] = counter++;
                Recursion(j, arrayHumans);
            }
            return _answerList;
        }

        private static void Recursion(int j, SHuman[] arrayHumans)
        {
            for (var k = 0; k < arrayHumans.Length; k++)
            {
                if (_helpList[k] != -1 || !Compare(arrayHumans[k], arrayHumans[j])) continue;
                _helpList[k] = _helpList[j];
                _answerList[_helpList[j]].Add(arrayHumans[k]);
                Recursion(k, arrayHumans);
            }
        }
        
        private static bool Compare(SHuman first, SHuman second)
        {
            return first.Firstname == second.Firstname || first.Surname == second.Surname 
                   || first.Patronymic == second.Patronymic || first.Year == second.Year;
        }
        
        private static void WriteSHumans(List<List<SHuman>> listList)
        {
            foreach (var list in listList)
            {
                foreach (var sHuman in list)
                {
                    Console.WriteLine(sHuman.Surname + " " 
                                                     + sHuman.Firstname + " " 
                                                     + sHuman.Patronymic + " " 
                                                     + sHuman.Year);
                }
                Console.WriteLine();
            }
        }
    }
}