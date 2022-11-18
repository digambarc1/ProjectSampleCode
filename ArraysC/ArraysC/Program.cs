using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysC
{
    internal class Program
    {

        static void Main(string[] args)
        {


            string[] my_array = new string[5];

            my_array[0] = "adi";
            my_array[1] = "digambar";
            my_array[2] = "aditya";
            my_array[3] = "xhima";
            my_array[4] = "raju";


            foreach (var a in my_array)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }
    }
}
