using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace PasswordManager.Models
{
    [Serializable, TableName("Passwords")]
    public class Passwords
    {
        #region Main
        [Key]
        public Guid SysId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? AccountId { get; set; }
        public string Password { get; set; }
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