using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            LesLabos leslabs = new LesLabos(5);

            Console.WriteLine(leslabs.LePlusModerne().ViewLab());


            leslabs.Ajout(10);

            Console.WriteLine("yey");

            
        }
    }
}
