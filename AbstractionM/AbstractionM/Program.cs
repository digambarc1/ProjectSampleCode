
namespace AbstractionM
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Employee
    {
       public int Empid;
        public string EmpName;
        public double GrossSalary;
        public double Netpay;
        public double TaxDeduction=0.1;
       

        public Employee(int Eid,string EmNAme,double grosssalary)
        {
            this.Empid = Eid;
            this.EmpName = EmNAme;
            this.GrossSalary = grosssalary;
           

        }

       

        void calculatesalary()//internal details hide and if i want to call this method then
        {
            if(GrossSalary >= 30000)
            {
                Netpay = GrossSalary - (TaxDeduction * GrossSalary);  
                Console.WriteLine("your salary is "+ Netpay);
            }
            else
            {
                Console.WriteLine("your salary is "+ GrossSalary);
            }
        }
        public void ShowEmpDetalis()//i will call this method like this
        {
            this.calculatesalary();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee(1,"aditya",36000 );
            e.ShowEmpDetalis();
            Console.ReadLine();
            
        }
    }
}
