namespace SOAP_WCF_Solution.DataAccess
{
    using SOAP_WCF_Solution.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Initializor : DropCreateDatabaseAlways<EFContexte>
    {

        protected override void Seed(EFContexte context)
        {
            base.Seed(context);

            //List<Account> NewAccounts = new List<Account>() 
            //{
            //    new Account (){Name = "Banque 1" , InitialBalance = 20.82M },
            //    new Account (){Name = "Banque 2" , InitialBalance = 320.15M},
            //    new Account (){Name = "Banque 3" , InitialBalance = 110.5M },
            //    new Account (){Name = "Banque 4" , InitialBalance = 200.75M},
            //    new Account (){Name = "Banque 5" , InitialBalance = 520.12M},
            //    new Account (){Name = "Banque 6" , InitialBalance = 520.12M},

            //}
            //;
            List<Account> NewAccounts = new List<Account>()
            {
                    new Account() { Name = "Banque 1", DateCreated = DateTime.Now, InitialBalance = 20.82M },
                new Account() { Name = "Banque 2", DateCreated = DateTime.Now, InitialBalance = 320.15M },
                new Account() { Name = "Banque 3", DateCreated = DateTime.Now, InitialBalance = 110.5M },
                new Account() { Name = "Banque 4", DateCreated = DateTime.Now, InitialBalance = 200.75M },
                new Account() { Name = "Banque 5", DateCreated = DateTime.Now, InitialBalance = 520.12M },
                new Account() { Name = "Banque 6", DateCreated = DateTime.Now, InitialBalance = 520.12M },

            }
            ;
            foreach (Account account in NewAccounts)
            {
                try
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.InnerException.InnerException.Message);
                }
            }

            List<Operation> newOperations = new List<Operation>() {
                new Operation (){ AccountId = NewAccounts[0].Id, DateCreated = DateTime.Now, Amount = 200.75M},
                new Operation (){ AccountId = NewAccounts[2].Id, DateCreated = DateTime.Now, Amount = 200.75M},
                new Operation (){ AccountId = NewAccounts[1].Id, DateCreated = DateTime.Now, Amount = 70.75M},
                new Operation (){ AccountId = NewAccounts[0].Id, DateCreated = DateTime.Now, Amount = 100.25M},
                new Operation (){ AccountId = NewAccounts[3].Id, DateCreated = DateTime.Now, Amount = 20.73M},
                new Operation (){ AccountId = NewAccounts[5].Id, DateCreated = DateTime.Now, Amount = 250.52M},
                new Operation (){ AccountId = NewAccounts[5].Id, DateCreated = DateTime.Now, Amount = 140},
                new Operation (){ AccountId = NewAccounts[1].Id, DateCreated = DateTime.Now, Amount = -10.41M}
            };

            foreach (Operation operation in newOperations)
            {
                try
                {
                    context.Operations.Add(operation);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.InnerException.InnerException.Message);
                }
            }

            //context.Configuration.ProxyCreationEnabled = false;


        }
    }
}
