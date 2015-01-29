using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraceUsageDemo1
{
    interface IDriverLicenceB
    {
        void GetLicence();
    }

    interface IDriverLicenceA : IDriverLicenceB
    {
        new void GetLicence();
    }

    class Techer : IDriverLicenceA
    {
        void IDriverLicenceA.GetLicence()
        {
            Console.WriteLine("Techer has DriverLicenceA Authorization!");
        }
        void IDriverLicenceB.GetLicence()
        {
            Console.WriteLine("Techer has DriverLicenceB Authorization!");
        }


        public void GetLicence()
        {
            Console.WriteLine("This is not Interface mothod!");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Techer a=new Techer();
            a.GetLicence();

            IDriverLicenceB ib = a as IDriverLicenceA;
            ib.GetLicence();
           (( IDriverLicenceA)a).GetLicence();
           ((IDriverLicenceB)a).GetLicence();

            Console.ReadKey();




        }
    }
}
