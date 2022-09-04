using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BennerTesteLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network(10);
            network.Connect(1, 2);
            network.Connect(1, 1);
            network.Connect(2, 9);
            network.Connect(9, 3);
            network.Connect(3, 7);
            network.Connect(5, 4);

            Console.WriteLine("1:");
            Console.WriteLine(network.Query(1, 2));
            Console.WriteLine(network.Query(1, 9));
            Console.WriteLine(network.Query(1, 3));
            Console.WriteLine(network.Query(1, 7));

            Console.WriteLine("2:");
            Console.WriteLine(network.Query(2, 9));
            Console.WriteLine(network.Query(2, 3));
            Console.WriteLine(network.Query(2, 7));

            Console.WriteLine("9:");
            Console.WriteLine(network.Query(9, 3));
            Console.WriteLine(network.Query(9, 7));

            Console.WriteLine("3:");
            Console.WriteLine(network.Query(3, 7));

            Console.WriteLine("7:");
            Console.WriteLine(network.Query(7, 1));
            Console.WriteLine(network.Query(7, 2));
            Console.WriteLine(network.Query(7, 9));
            Console.WriteLine(network.Query(7, 3));
            Console.WriteLine(network.Query(7, 10));

            Console.WriteLine("5:");
            Console.WriteLine(network.Query(5, 1));
            Console.WriteLine(network.Query(5, 2));
            Console.WriteLine(network.Query(5, 3));
            Console.WriteLine(network.Query(5, 4));
            Console.WriteLine(network.Query(5, 6));
            Console.WriteLine(network.Query(5, 7));
            Console.WriteLine(network.Query(5, 8));
            Console.WriteLine(network.Query(5, 9));
            Console.WriteLine(network.Query(5, 10));


            Console.Read();
        }
    }
}
