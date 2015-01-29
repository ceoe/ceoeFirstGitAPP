using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUsageDemo1
{
     class Publisher
    {
        public delegate void PublishMagazine(string MagazineName);

        public delegate void PublishSicence(string SicenceName);

        public event PublishMagazine OnPublishMagazine;
        public event PublishSicence OnPublishSicence;

        public void IssuseMagazine()
        {
            if (OnPublishMagazine!=null)
            {
                Console.WriteLine("<生活杂志>出版了!");
                OnPublishMagazine("生活杂志");
            }

        }
        public void IssuseSicence()
        {
            if (OnPublishSicence != null)
            {
                Console.WriteLine("<科学周刊>出版了!");
                OnPublishSicence("科学周刊");
            }

        }



    }

    class Subscriber
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void ReceiverRetureMsg(string MagazineName)
        {
            Console.WriteLine(this.name+"已经收到了:  "+MagazineName);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Publisher pb = new Publisher();

            Subscriber  ls=new Subscriber("李四");
            Subscriber zs=new Subscriber("张三");
            Subscriber  ww=new Subscriber("王五");

            pb.OnPublishMagazine += ls.ReceiverRetureMsg;
            pb.OnPublishMagazine+=zs.ReceiverRetureMsg;
            pb.OnPublishMagazine+=ww.ReceiverRetureMsg;


            pb.OnPublishSicence +=zs.ReceiverRetureMsg;
            pb.OnPublishSicence += ww.ReceiverRetureMsg;

            pb.IssuseMagazine();
            pb.IssuseSicence();


            Console.ReadKey();


        }
    }
}
