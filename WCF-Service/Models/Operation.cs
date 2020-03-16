namespace SOAP_WCF_Solution.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("Operation")]
    public partial class Operation
    {
        [Key]
        //[DataMember]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DataMember]
        [Display(Name = "Date d'insertion")]
        [Column("Date_insertion")]
        public DateTime DateCreated { get; set; }

        //[DataMember]
        [Display(Name = "Account id")]
        [Column("Account_id")]
        public int AccountId { get; set; }

        [ForeignKey("Account_id")]
        public virtual Account Account { get; set; }
    }
}
