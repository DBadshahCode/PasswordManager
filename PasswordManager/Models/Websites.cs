﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace PasswordManager.Models
{
    [Serializable, TableName("Websites")]
    public class Websites
    {
        [Key]
        public Guid SysId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Status Status { get; set; }
    }
}