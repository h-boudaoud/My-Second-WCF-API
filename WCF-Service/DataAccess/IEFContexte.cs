using SOAP_WCF_Solution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP_WCF_Solution.DataAccess
{
    interface IEFContexte
    {
        DbSet<Operation> Operations { get; set; }
        DbSet<Account> Accounts { get; set; }
    }
}
