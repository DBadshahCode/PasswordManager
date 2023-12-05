using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace PasswordManager.Models
{
    [Serializable, TableName("Pins")]
    public class Pins
    {
        #region Main
        [Key]
        public Guid SysId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? AccountId { get; set; }
        public int Pin { get; set; }
        public int Length { get; set; }
        public bool Generated { get; set; }
        public Status Status { get; set; }
        #endregion

        #region Navigations
        [ForeignKey("AccountId")]
        public Accounts Accounts { get; set; }
        #endregion
    }
}