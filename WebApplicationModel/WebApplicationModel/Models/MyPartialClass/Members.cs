using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationModel.Models
{
    [MetadataType(typeof(MembersMetadata))]
    public partial class Members
    {
        public class MembersMetadata
        {
            [DisplayName("密碼")]
            [DataType(DataType.Password)]
            [Required]
            public string Password { get; set; }
            [DisplayName("帳號")]
            [Required]
            public string UserName { get; set; }
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }//string 本來就可以空值
            [DisplayName("年齡")]
            public Nullable<int> Age { get; set; }//int本來不允許空值, 加Nullable or int? 才可以null
            [DisplayName("手機")]
            public string CellPhone { get; set; }
            [DisplayName("部落格")]
            [DataType(DataType.Url)]
            public string Blog { get; set; }
            [DisplayName("建立日期")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
            public Nullable<System.DateTime> CreateDate { get; set; }
        }
    }
}