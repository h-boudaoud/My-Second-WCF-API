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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string DoWork();

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        decimal? GetBalance(int id);

        [OperationContract]
        Account GetAccountById(int id);

        [OperationContract]
        List<Account> GetAccountsList();

        [OperationContract]
        List<Operation> GetOperatiosList();

        [OperationContract]
        List<Operation> GetOperationsListOfAccount(int AccountId);

        [OperationContract]
        List<Account> AddAccount(string Name, decimal InitialBalance);

        [OperationContract]
        List<Operation> AddOperation(int accountId, decimal amount);

        [OperationContract]
        List<Operation> TransferMoney(int debitAccountId, int creditAccountId, decimal amount);


        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
