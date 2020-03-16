namespace SOAP_WCF_Solution.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SOAP_WCF_Solution.Models;

    public partial class EFContexte : DbContext, IEFContexte
    {
        public EFContexte()
            : base("name=EFContexte")
        {
            //Database.SetInitializer<EFContexte>(new Initializor());
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Operations)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.AccountId)
                .WillCascadeOnDelete(true);
        }
    }
}
