using SOAP_WCF_Solution.Models;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;

namespace WCF_Service.Services
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IBankingService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IBankingService
    {
        [OperationContract]
        string DoWork();

        [OperationContract]
        List<Account> GetAccounts();

        [OperationContract]
        List<Operation> GetOperationsByAccount(int aId);

        [OperationContract]
        decimal? GetBalance(int aId);

        [OperationContract]
        void withdrawMoney(int aId, decimal amount);

        [OperationContract]
        void depositMoney(int aId, decimal amount);

        [OperationContract]        
        void transferMoney(int fromId, int toId, decimal amount);
    }
}
