
namespace AbstractClass
{
    using System;
   
    //Abstract method doesnot have body
    //concrete->the one who have body
    //if the method is abstract then the complusory class must be abstract
    //if one of them is abstract then other must also be abstract
    abstract class Person
    {
        //student and teacher have same proper/fields
        public string FirstName;
        public string LastName;
        public int age;
        public double phoneNumber;
        public string myname;
        public string lastname;
        public abstract void details();

        public abstract void d();
       
    }
    //Hierarchal Inheritance is perfomed here

    class derived :Person
    {

        public new string myname;
        public new string lastname;

        public override void d()
        {
            Console.WriteLine("void");
        }

        public override void details()
        {
            Console.WriteLine("nothing" );
            Console.WriteLine(this.myname);
            Console.WriteLine(this.lastname);
        }



       
    }
    class Student:Person
    {
        public int rollno;
        public int fees;

        public override void d()
        {
            Console.WriteLine("void");
        }

        public override void details()
        {


            string name = this.FirstName + " " + this.LastName;
            Console.WriteLine(" Student Name is "+ name);
            Console.WriteLine(" Student Age is " + this.age);
            Console.WriteLine(" Student PhoneNumber is " + this.phoneNumber);
            Console.WriteLine(" Student RollNo is "+ this.rollno);
            Console.WriteLine(" Student Fees is " + this.fees);
            

        }
    }

    class Teacher:Person
    {
        public int id;
        public int salary;
        public string Qualification;

        public override void d()
        {
            Console.WriteLine("void");
        }

        public override void details()
        {
            string name = this.FirstName + " " + this.LastName;
            Console.WriteLine(" Teacher Name is " + name);
            Console.WriteLine(" Teacher Age is " + this.age);
            Console.WriteLine(" Teacher PhoneNumber is " + this.phoneNumber);
            Console.WriteLine(" Teacher ID is " + this.id);
            Console.WriteLine(" Teacher Name salary " + this.salary);
            Console.WriteLine(" Teacher Qualification is " + this.Qualification);

        }
    }
    public class Program
    {

        static void Main(string[] args)
        {

            Student ac = new Student();
            ac.FirstName = "Aditya";
            ac.LastName = "chaudhary";
            ac.age = 25;
            ac.phoneNumber = 8698574138;
            ac.rollno = 10;
            ac.fees = 50000;
            ac.details();
            ac.d();

            Console.WriteLine(" ______________________________________ ");

            Teacher tc = new Teacher();
            tc.id = 1;
            tc.FirstName = "digambar";
            tc.LastName = "chaudhary";
            tc.phoneNumber = 9096903609;
            tc.age = 25;
            tc.Qualification = "Nothing";
            tc.salary = 500000;
            tc.details();
            tc.d();

            Console.WriteLine("____________________________________________________________");

            Console.WriteLine("the details are following");

            derived d = new derived();
            d.myname = "aditya";
            d.lastname = "digambar";
            d.d();
            Console.ReadLine();


        }
    }
}
