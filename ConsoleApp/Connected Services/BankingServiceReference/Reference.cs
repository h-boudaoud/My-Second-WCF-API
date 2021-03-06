﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp.BankingServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BankingServiceReference.IBankingService")]
    internal interface IBankingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/DoWork", ReplyAction="http://tempuri.org/IBankingService/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/DoWork", ReplyAction="http://tempuri.org/IBankingService/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/GetAccounts", ReplyAction="http://tempuri.org/IBankingService/GetAccountsResponse")]
        SOAP_WCF_Solution.Models.Account[] GetAccounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/GetAccounts", ReplyAction="http://tempuri.org/IBankingService/GetAccountsResponse")]
        System.Threading.Tasks.Task<SOAP_WCF_Solution.Models.Account[]> GetAccountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/GetOperationsByAccount", ReplyAction="http://tempuri.org/IBankingService/GetOperationsByAccountResponse")]
        SOAP_WCF_Solution.Models.Operation[] GetOperationsByAccount(int aId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/GetOperationsByAccount", ReplyAction="http://tempuri.org/IBankingService/GetOperationsByAccountResponse")]
        System.Threading.Tasks.Task<SOAP_WCF_Solution.Models.Operation[]> GetOperationsByAccountAsync(int aId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/GetBalance", ReplyAction="http://tempuri.org/IBankingService/GetBalanceResponse")]
        System.Nullable<decimal> GetBalance(int aId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/GetBalance", ReplyAction="http://tempuri.org/IBankingService/GetBalanceResponse")]
        System.Threading.Tasks.Task<System.Nullable<decimal>> GetBalanceAsync(int aId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/withdrawMoney", ReplyAction="http://tempuri.org/IBankingService/withdrawMoneyResponse")]
        void withdrawMoney(int aId, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/withdrawMoney", ReplyAction="http://tempuri.org/IBankingService/withdrawMoneyResponse")]
        System.Threading.Tasks.Task withdrawMoneyAsync(int aId, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/depositMoney", ReplyAction="http://tempuri.org/IBankingService/depositMoneyResponse")]
        void depositMoney(int aId, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/depositMoney", ReplyAction="http://tempuri.org/IBankingService/depositMoneyResponse")]
        System.Threading.Tasks.Task depositMoneyAsync(int aId, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/transferMoney", ReplyAction="http://tempuri.org/IBankingService/transferMoneyResponse")]
        void transferMoney(int fromId, int toId, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankingService/transferMoney", ReplyAction="http://tempuri.org/IBankingService/transferMoneyResponse")]
        System.Threading.Tasks.Task transferMoneyAsync(int fromId, int toId, decimal amount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IBankingServiceChannel : ConsoleApp.BankingServiceReference.IBankingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class BankingServiceClient : System.ServiceModel.ClientBase<ConsoleApp.BankingServiceReference.IBankingService>, ConsoleApp.BankingServiceReference.IBankingService {
        
        public BankingServiceClient() {
        }
        
        public BankingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public SOAP_WCF_Solution.Models.Account[] GetAccounts() {
            return base.Channel.GetAccounts();
        }
        
        public System.Threading.Tasks.Task<SOAP_WCF_Solution.Models.Account[]> GetAccountsAsync() {
            return base.Channel.GetAccountsAsync();
        }
        
        public SOAP_WCF_Solution.Models.Operation[] GetOperationsByAccount(int aId) {
            return base.Channel.GetOperationsByAccount(aId);
        }
        
        public System.Threading.Tasks.Task<SOAP_WCF_Solution.Models.Operation[]> GetOperationsByAccountAsync(int aId) {
            return base.Channel.GetOperationsByAccountAsync(aId);
        }
        
        public System.Nullable<decimal> GetBalance(int aId) {
            return base.Channel.GetBalance(aId);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<decimal>> GetBalanceAsync(int aId) {
            return base.Channel.GetBalanceAsync(aId);
        }
        
        public void withdrawMoney(int aId, decimal amount) {
            base.Channel.withdrawMoney(aId, amount);
        }
        
        public System.Threading.Tasks.Task withdrawMoneyAsync(int aId, decimal amount) {
            return base.Channel.withdrawMoneyAsync(aId, amount);
        }
        
        public void depositMoney(int aId, decimal amount) {
            base.Channel.depositMoney(aId, amount);
        }
        
        public System.Threading.Tasks.Task depositMoneyAsync(int aId, decimal amount) {
            return base.Channel.depositMoneyAsync(aId, amount);
        }
        
        public void transferMoney(int fromId, int toId, decimal amount) {
            base.Channel.transferMoney(fromId, toId, amount);
        }
        
        public System.Threading.Tasks.Task transferMoneyAsync(int fromId, int toId, decimal amount) {
            return base.Channel.transferMoneyAsync(fromId, toId, amount);
        }
    }
}
