using System;
namespace interf2
{
    public class Class1:Program
    {
        public void test()
        {
            Console.WriteLine("Test 1 called");
        }
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            string name;
            Console.WriteLine("student name is" + c.name);
            name = Console.ReadLine();
            Console.WriteLine("usernam" + name);

            //Console.WriteLine("student city is" + c.city);
            //Console.ReadLine();
            //Console.WriteLine("city" + c.city);
            //c.Student();
           
            Console.ReadLine();
        }
    }
}
