﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;

namespace PasswordManager.Models
{
    [Serializable, TableName("Emails")]
    public class Emails
    {
        #region Main
        [Key]
        public Guid SysId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string EmailAddress { get; set; }
        public Status Status { get; set; }
        #endregion
    }
}