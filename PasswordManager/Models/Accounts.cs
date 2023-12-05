using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace PasswordManager.Models
{
    [Serializable, TableName("Accounts")]
    public class Accounts
    {
        #region Main
        [Key]
        public Guid SysId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? WebsiteId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? EmailId { get; set; }
        public Guid? PhoneId { get; set; }
        public SecurityType SecurityType { get; set; }
        public string Comments { get; set; }
        public bool Closed { get; set; }
        #endregion

        #region Navigations
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        [ForeignKey("EmailId")]
        public Emails Emails { get; set; }
        [ForeignKey("PhoneId")]
        public Phones Phones { get; set; }
        [ForeignKey("WebsiteId")]
        public Websites Websites { get; set; }

        #endregion
    }
}