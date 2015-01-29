using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventNetUsageDemo1
{
    class  PubEventArgs:System.EventArgs
    {
        private readonly string m_magazinename;
        private readonly DateTime m_dt;

        public PubEventArgs(string magazineName, DateTime dt)
        {
            this.m_magazinename = magazineName;
            this.m_dt = dt;
        }


        public string Magazinename
        {
            get { return m_magazinename; }
        }

        public DateTime MDt
        {
            get { return m_dt; }
        }
    }

    internal class Publisher
    {
        public delegate void PubComputerEventHandle(object  sender, PubEventArgs e);
        public delegate void PubLifeEventhandle(object sender, PubEventArgs e);

        public event PubComputerEventHandle PubCoomputerEvent;
        public event PubLifeEventhandle PubLifeEvent;

        public void OnpubCoomputerEvent(PubEventArgs e)
        {
            PubComputerEventHandle handle = PubCoomputerEvent;
            if (PubCoomputerEvent!=null)
            {
                handle(this, e);
            }
        }

        public void IssueComputer(string  magazineName, DateTime issueDate)
        {
            Console.WriteLine("Issue title : "+magazineName);
            PubEventArgs e=new PubEventArgs(magazineName,issueDate);
            OnpubCoomputerEvent(e);
        }

        public void OnpubLifeEvent(PubEventArgs e)
        {
            PubLifeEventhandle handle = PubLifeEvent;
            if (handle != null)
            {
                handle(this, e);
            }
        }

        public void IssueLife(string magazinename, DateTime issueDate)
        {
            Console.WriteLine("Issue title : " + magazinename);
            PubEventArgs e = new PubEventArgs(magazinename, issueDate);
            OnpubLifeEvent(e);
        }

    }

    class Subscriber
    {
        private string _name;

        public Subscriber(string name)
        {
            this._name = name;
        }

        public void ReceiveMagazine(object sender,PubEventArgs e)
        {
            Console.WriteLine(e.MDt+"  ---  "+_name+" has receive:   "+e.Magazinename);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Publisher  pb=new Publisher();

            Subscriber  zs=new Subscriber("zhangsan");
            pb.PubCoomputerEvent += zs.ReceiveMagazine;
            pb.PubLifeEvent += zs.ReceiveMagazine;

            Subscriber  ls=new Subscriber("lishi");
            pb.PubCoomputerEvent += ls.ReceiveMagazine;
            pb.PubLifeEvent += ls.ReceiveMagazine;

            Subscriber  ww=new Subscriber("wangwu");
            pb.PubLifeEvent += ww.ReceiveMagazine;

            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++");
            Console.WriteLine("2011");
            Console.WriteLine("+++++++++++++++++++++++++");
            Console.WriteLine();
                pb.IssueComputer("Computer Magazine",Convert.ToDateTime("2011-05-01"));
            pb.IssueLife("Life Magazine",Convert.ToDateTime("2011-05-01"));


            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++");
            Console.WriteLine("2012");
            Console.WriteLine("+++++++++++++++++++++++++");
            Console.WriteLine();

            pb.PubCoomputerEvent -= zs.ReceiveMagazine;
            pb.PubLifeEvent -= ls.ReceiveMagazine;

            pb.IssueComputer("Computer Magazine", Convert.ToDateTime("2012-05-01"));
            pb.IssueLife("Life Magazine", Convert.ToDateTime("2012-05-01"));

            Console.ReadKey();

        }
    }
}
