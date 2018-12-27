using System;
using System.IO;

namespace fantasy_name_gen
{
    class Program
    {
        static void Main(string[] args)
        {
            LRU cache = new LRU(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine("expecting 1 got: " + cache.Get(1));
            cache.Put(3, 3);    // evicts key 2
            Console.WriteLine("expecting to get -1, got: " + cache.Get(2));
            cache.Put(4, 4);    // evicts key 1
            Console.WriteLine("expecting to get -1, got: " + cache.Get(1));
            Console.WriteLine("expecting to get 3, got: " + cache.Get(3));
            Console.WriteLine("expecting to get 4, got: " + cache.Get(4));
        }
    }
}