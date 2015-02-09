using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationModel_CodeFirst.Models
{
    public class Members
    {
        [Key]
        public int MemberID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }//string 本來就可以空值
        public Nullable<int> Age { get; set; }//int本來不允許空值, 加Nullable or int? 才可以null
        public string CellPhone { get; set; } 
        public string Blog { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}