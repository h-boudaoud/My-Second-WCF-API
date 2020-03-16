using ConsoleApp.BankingServiceReference;
using ConsoleApp.Service1Reference;
using SOAP_WCF_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankingServiceClient bsr = new BankingServiceClient();
            Console.WriteLine($"DoWork() : {bsr.DoWork()}");
            Console.WriteLine($"GetBalance(1) : {bsr.GetBalance(1)}");
            Console.WriteLine($"GetBalance(0) : {((bsr.GetBalance(0) != null) ? bsr.GetBalance(0).ToString() : "null")}");
            foreach (Account account in bsr.GetAccounts())
            {
                Console.WriteLine(
                    $"Id : {account.Id}\t" +
                    $"Date creation : {account.DateCreated}\t" +
                    $"Nom : {account.Name}\t" +
                    $"Initial Balance : {account.InitialBalance}\t" +
                    $"NB operations : {account.Operations.Count()}\n"
                    );
                foreach (Operation operation in account.Operations)
                {
                    Console.WriteLine(
                        $"Id : {operation.Id}\t" +
                        $"Date creation : {operation.DateCreated}\t" +
                        $"Amout : {operation.Amount}\t" +
                        $"Account Id : {operation.AccountId}"
                        );
                }
            }
            bsr.Close();
            Console.WriteLine("\n-------------------------------------\n");

            Service1Client s1c = new Service1Client();
            Console.WriteLine($"DoWork() : {s1c.DoWork()}");
            Console.WriteLine($"GetBalance(1) : {s1c.GetBalance(1)}");
            Console.WriteLine($"GetBalance(0) : {((s1c.GetBalance(0) != null) ? s1c.GetBalance(0).ToString() : "null")}");
            foreach (Account account in s1c.GetAccountsList())
            {
                Console.WriteLine(
                    $"Id : {account.Id}\t" +
                    $"Date creation : {account.DateCreated}\t" +
                    $"Nom : {account.Name}\t" +
                    $"Initial Balance : {account.InitialBalance}\t" +
                    $"NB operations : {account.Operations.Count()}\n"
                    );
                foreach (Operation operation in account.Operations)
                {
                    Console.WriteLine(
                        $"Id : {operation.Id}\t" +
                        $"Date creation : {operation.DateCreated}\t" +
                        $"Amout : {operation.Amount}\t" +
                        $"Account Id : {operation.AccountId}"
                        );
                }
            }
            bsr.Close();
            Console.ReadLine();
        }
    }
}
