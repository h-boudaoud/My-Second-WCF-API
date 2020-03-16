using SOAP_WCF_Solution.DataAccess;
using SOAP_WCF_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private EFContexte efContexte = new EFContexte(); 
        
        public string DoWork()
        {
            return "Service1";
        }

        public string GetData(int id)
        {
            string message="";
            try
            {
                Account account = efContexte.Accounts.Find(id);
                message = (account != null)
                    ? $"Id -> {account.Id}" +
                        $" -- Name ->{account.Name}" +
                        $" -- Date_creation ->{account.DateCreated}" +
                        $" -- Initial_balance ->{account.InitialBalance}" +
                        $" -- Operations ->{account.Operations.Count}"
                    : $"the account with id = {id} cannot be found ";
                //throw new Exception($"teste erreur : {System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath}");
            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"GetData");
            }
            return string.Format(message);
        }


        public decimal? GetBalance(int id)
        {
            Account account = new Account();
            try
            {
                account = efContexte.Accounts.Where(a => a.Id == id).FirstOrDefault();
                if (account != null)
                {
                    decimal sumOp = account.InitialBalance + ((account.Operations.Count > 0) ? account.Operations.Sum(o => o.Amount) : 0);
                    return sumOp;
                }

            }
            catch(Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"GetBalance - {id}");
            }
            return null;
        }

        public Account GetAccountById(int id)
        {
            Account getAccount = new Account();
            try
            {
                Account account = efContexte.Accounts.Where(a => a.Id == id).FirstOrDefault();
                if (account != null)
                {
                    getAccount.Id = account.Id;
                    getAccount.Name = account.Name;
                    getAccount.DateCreated = account.DateCreated;
                    getAccount.InitialBalance = account.InitialBalance;
                    if (account.Operations.Count > 0)
                    {
                        foreach (Operation operation in account.Operations)
                        {
                            Operation getOperation = new Operation()
                            {
                                Id = operation.Id,
                                DateCreated = operation.DateCreated,
                                Amount = operation.Amount,
                                AccountId = operation.AccountId,
                                //Account = getAccount
                            };
                            getAccount.Operations.Add(getOperation);
                        }
                    }

                }
            }
            catch(Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"GetAccountById - {id}");
            }

            return getAccount;
        }
        public List<Account> GetAccountsList()
        {
            List<Account> accountsList = new List<Account>();
            try
            {
                foreach (Account account in efContexte.Accounts)
                {
                    Account getAccount = new Account()
                    {
                        Id = account.Id,
                        Name = account.Name,
                        DateCreated = account.DateCreated,
                        InitialBalance = account.InitialBalance
                    };
                    if (account.Operations.Count > 0)
                    {
                        foreach (Operation operation in account.Operations)
                        {
                            Operation getOperation = new Operation()
                            {
                                Id = operation.Id,
                                DateCreated = operation.DateCreated,
                                Amount = operation.Amount,
                                AccountId = operation.AccountId,
                                //Account = getAccount
                            };
                            getAccount.Operations.Add(getOperation);
                        }
                    }
                    accountsList.Add(getAccount);
                }

            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"GetAccountsList");
            }

            return accountsList;
        }
        public List<Operation> GetOperatiosList()
        {
            List<Operation> operationsList = new List<Operation>();
            try
            {
                foreach (Operation operation in efContexte.Operations)
                {
                    Operation getOperation = new Operation()
                    {
                        Id = operation.Id,
                        DateCreated = operation.DateCreated,
                        Amount = operation.Amount,
                        AccountId = operation.AccountId,
                        //Account = getAccount
                    };
                    operationsList.Add(getOperation);
                }
            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"GetOperatiosList");
            }

            return operationsList;
        }

        public List<Operation> GetOperationsListOfAccount(int id)
        {
            List<Operation> operationsList = new List<Operation>();
            List<Operation> setOperations = new List<Operation>();
            try
            {
                Account account = efContexte.Accounts.Find(id);

                if (account != null && account.Operations.Count > 0)
                {
                    foreach (Operation operation in account.Operations)
                    {
                        Operation setOperation = new Operation()
                        {
                            Id = operation.Id,
                            DateCreated = operation.DateCreated,
                            Amount = operation.Amount,
                            AccountId = operation.AccountId,
                        };
                        setOperations.Add(setOperation);

                        Operation getOperation = new Operation()
                        {
                            Id = operation.Id,
                            DateCreated = operation.DateCreated,
                            Amount = operation.Amount,
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
                        operationsList.Add(getOperation);
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"GetOperationsListOfAccount - {id}");
            }
            return operationsList;
        }

        public List<Account> AddAccount(string name, decimal initialBalance)
        {
            List<Account> accountsList = new List<Account>();
            try
            {
                Account account = new Account()
                {
                    Name = name,
                    DateCreated = DateTime.Now,
                    InitialBalance = initialBalance

                };
                    efContexte.Accounts.Add(account);
                    efContexte.SaveChanges();


                foreach (Account item in efContexte.Accounts)
                {
                    Account getAccount = new Account() {
                            Id = item.Id,
                            Name = item.Name,
                            DateCreated = item.DateCreated,
                            InitialBalance = item.InitialBalance
                    };
                    accountsList.Add(getAccount);

                }

            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"AddAccount - {name}, {initialBalance}");
            }

            return accountsList;
        }
        public List<Operation> AddOperation(int id, decimal amount)
        {
            List<Operation> operationsList = new List<Operation>();
            try
            {
                Account account = efContexte.Accounts.Find(id);
                if (account != null)
                {
                    Operation newOperation = new Operation()
                    {
                        DateCreated = DateTime.Now,
                        Amount = amount,
                        AccountId = id,
                        Account = account
                    };
                    efContexte.Operations.Add(newOperation);
                    efContexte.SaveChanges();
                }


                foreach (Operation operation in efContexte.Operations)
                {
                    Operation getOperation = new Operation()
                    {
                        Id = operation.Id,
                        DateCreated = operation.DateCreated,
                        Amount = operation.Amount,
                        AccountId = operation.AccountId,
                        Account = new Account()
                        {
                            Id = operation.Account.Id,
                            Name = operation.Account.Name,
                            DateCreated = operation.Account.DateCreated,
                            InitialBalance = operation.Account.InitialBalance
                        }

                    };
                    operationsList.Add(getOperation);

                }

            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"AddOperation - {id}, {amount}");
            }

            return operationsList;
        }


        public List<Operation> TransferMoney(int debitAccountId, int creditAccountId, decimal amount)
        {

            List<Operation> operationsList = new List<Operation>();
            try
            {
                Account debitAccount = efContexte.Accounts.Find(debitAccountId);
                Account creditAccount = efContexte.Accounts.Find(creditAccountId);
                if (debitAccount != null && creditAccount != null)
                {
                    Operation debitOperation = new Operation()
                    {
                        DateCreated = DateTime.Now,
                        Amount = -amount,
                        AccountId = debitAccountId,
                        Account = debitAccount
                    };
                    Operation creditOperation = new Operation()
                    {
                        DateCreated = DateTime.Now,
                        Amount = amount,
                        AccountId = creditAccountId,
                        Account = creditAccount
                    };
                    efContexte.Operations.Add(debitOperation);
                    efContexte.Operations.Add(creditOperation);
                    efContexte.SaveChanges();
                    creditOperation.Account = new Account()
                    {
                        Id = creditOperation.Account.Id,
                        DateCreated = creditOperation.Account.DateCreated,
                        InitialBalance = creditOperation.Account.InitialBalance,
                        Name = creditOperation.Account.Name
                    };
                    debitOperation.Account = new Account()
                    {
                        Id = debitOperation.Account.Id,
                        DateCreated = debitOperation.Account.DateCreated,
                        InitialBalance = debitOperation.Account.InitialBalance,
                        Name = debitOperation.Account.Name
                    };

                    operationsList.Add(debitOperation);
                    operationsList.Add(creditOperation);
                }

            }
            catch (Exception e)
            {
                LogHelper.WriteToFile(e.Message, $"TransferMoney - {debitAccountId}, {creditAccountId}, {amount}");
            }

            return operationsList;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        
    }
}
