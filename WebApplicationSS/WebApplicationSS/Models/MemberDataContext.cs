using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplicationSS.Models
{
    public class MemberDataContext
    {
        static string connstr = ConfigurationManager.ConnectionStrings["SmartShoppingConnectionString"].ConnectionString;
        public static void InsertMember(Member member)
        {
            string commstr = "insert into Members (MemberName, Username, Password, Salt, Email) values(@MemberName, @Username, @Password, @Salt, @Email)";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand comm = new SqlCommand(commstr, conn))
                {
                    
                    //username是否已存在  密碼規則
                    conn.Open();
                    comm.Parameters.AddWithValue("@MemberName", member.MemberName);
                    comm.Parameters.AddWithValue("@Username", member.UserName);
                    comm.Parameters.AddWithValue("@Email", member.Email);
                   
                    //先做一個salt再存Password
                    System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                    byte[] buf = new byte[15];
                    rng.GetBytes(buf); 
                    string salt = Convert.ToBase64String(buf);
                    comm.Parameters.AddWithValue("@Salt", salt);
                    string Password = member.Password;
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password + salt, "sha1");
                    comm.Parameters.AddWithValue("@Password", Password);

                    comm.ExecuteNonQuery();

                    conn.Close();
                }
            }

        }
    }
}