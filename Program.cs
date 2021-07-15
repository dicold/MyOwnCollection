using System;

namespace TaskProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // создание
            MyOwnColl<int> collect = new MyOwnColl<int>();

            // добавление элементов
            collect.Add(1);
            collect.Add(2);
            collect.Add(3);
            collect.Add(4);
            collect.Add(5);
            collect.Add(6);
            collect.Add(7);

            // 7
            var max_el = collect.Max();

            collect.Insert(2, 16);

            // 16
            max_el = collect.Max();

            collect.RemoveAt(2);

            collect.Remove(7);

            // 6
            max_el = collect.Max();

            foreach (var item in collect)
            {
                Console.WriteLine($"In foreach item is {item}");
            }

            MyOwnColl<bool> xx = new MyOwnColl<bool>();
            xx.Add(true);
        }
    }
}
