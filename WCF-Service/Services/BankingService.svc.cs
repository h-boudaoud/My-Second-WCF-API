using SOAP_WCF_Solution.BankingService;
using SOAP_WCF_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WCF_Service.Services
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "BankingService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez BankingService.svc ou BankingService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class BankingService : IBankingService
    {
        private DataManager<Account> accountManager = new DataManager<Account>();
        private DataManager<Operation> operationManager = new DataManager<Operation>();
        public string DoWork()
        {
            return "Services/BankingService";
        }

        public void depositMoney(int aId, decimal Amount)
        {
            if (accountManager.Get(aId)!=null)
            {
                Operation op = new Operation
                {
                    Amount = Math.Abs(Amount),
                    AccountId = aId,
                    DateCreated = DateTime.Now
                };
                operationManager.Create(op);
                operationManager.Commit();
            }
            //else
            //{
            //    string errorMessage = "Le compte doit être créer avant de réaliser cette opération";
            //    throw new FaultException<string>(errorMessage);
            //}
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            foreach (Account account in accountManager.List())
            {
                Account getAccount = new Account()
                {
                    Id = account.Id,
                    Name = account.Name,
                    DateCreated = account.DateCreated,
                    InitialBalance = account.InitialBalance,
                };
                foreach (Operation operation in account.Operations)
                {
                    Operation getOperation = new Operation()
                    {
                        Id = operation.Id,
                        Amount = operation.Amount,
                        DateCreated = operation.DateCreated,
                        //Account_id = operation.Account_id
                    };
                    getAccount.Operations.Add(getOperation);
                }
                accounts.Add(getAccount);
            }
            return accounts;
        }

        public decimal? GetBalance(int aId)
        {
            Account account = accountManager.Get(aId);
            if (account != null)
            {
                decimal sumOp = account.Operations.Sum(o => o.Amount);
                return sumOp + account.InitialBalance;
            }
            //else
            //{
            //    string errorMessage = "Le compte doit être créer avant de réaliser cette opération";
            //    throw new FaultException<string>(errorMessage);
            //}
            return null;
        }


        public List<Operation> GetOperationsByAccount(int aId)
        {
            List<Operation> setOperations = new List<Operation>();
            List<Operation> operations = new List<Operation>();
            Account account = accountManager.Get(aId);
            if (account != null)
            {
                foreach (Operation operation in account.Operations)
                {
                    Operation setOperation = new Operation()
                    {
                        Id = operation.Id,
                        Amount = operation.Amount,
                        DateCreated = operation.DateCreated,
                        AccountId = operation.AccountId,
                    };
                    setOperations.Add(setOperation);

                    Operation getOperation = new Operation()
                    {
                        Id = operation.Id,
                        Amount = operation.Amount,
                        DateCreated = operation.DateCreated,
                        AccountId = operation.AccountId,
                        Account = new Account()
                        {
                            Id = account.Id,
                            Name = account.Name,
                            DateCreated = account.DateCreated,
                            InitialBalance = account.InitialBalance,
                            Operations = setOperations,
                        }
                    };
                    operations.Add(getOperation);
                }
            }
            return operations;
        }

        public void transferMoney(int fromId, int toId, decimal Amount)
        {
            Operation opFrom = new Operation
            {
                Amount = -1 * Math.Abs(Amount),
                AccountId = fromId,
                DateCreated = DateTime.Now
            };
            Operation opTo = new Operation
            {
                Amount = Math.Abs(Amount),
                AccountId = toId,
                DateCreated = DateTime.Now
            };
            if (
                fromId != toId
                && accountManager.Get(fromId) != null
                && accountManager.Get(toId) != null
                )
            {
                operationManager.Create(opFrom);
                operationManager.Create(opTo);
                operationManager.Commit();
            }
            //else
            //{
            //    string errorMessage = (fromId == toId)
            //        ? "Impossible de faire un fransfaire vers le même compte"
            //        : "un des deux compte doit être créer avant de réaliser se transfère"
            //        ;
            //    throw new FaultException<string>(errorMessage);
            //}
        }

        public void withdrawMoney(int aId, decimal amount)
        {
            if (accountManager.Get(aId) != null)
            {
                Operation op = new Operation
                {
                    Amount = -1 * Math.Abs(amount),
                    AccountId = aId,
                    DateCreated = DateTime.Now
                };
                operationManager.Create(op);
                operationManager.Commit();
            }
            //else
            //{
            //    string errorMessage = "Le compte doit être créer avant de réaliser cette opération";
            //    throw new FaultException<string>(errorMessage);
            //}
        }

    }
}
