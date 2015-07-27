using System;

namespace GreetPeopleExampleTest
{
    public delegate void GreetPeopleDelegate(string name);

    public class GreetPeopleManager
    {
        public event GreetPeopleDelegate MakeGreetPeopleDelegate;

        public void DoGreetPeople(string name)
        {
            if (MakeGreetPeopleDelegate != null)
            {
                MakeGreetPeopleDelegate(name);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            GreetPeopleManager gm = new GreetPeopleManager();
            gm.MakeGreetPeopleDelegate += ChineseGreeting;
            gm.MakeGreetPeopleDelegate += EnglishGreeting;
            gm.DoGreetPeople("Bob Lee");
            Console.ReadKey();
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine(name + "  你好！");
        }

        private static void EnglishGreeting(string name)
        {
            Console.WriteLine(name + "  How are you！");
        }
    }
}