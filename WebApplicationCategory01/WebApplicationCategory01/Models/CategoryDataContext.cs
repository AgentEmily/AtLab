using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationCategory01.Models
{
    public class CategoryDataContext
    {
        static string connstr = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;
        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            using(SqlConnection conn=new SqlConnection(connstr))
            {
                string commstr = "select CategoryID, CategoryName, Description from Categories";
                using (SqlCommand comm=new SqlCommand(commstr, conn))
                {
                    conn.Open();
                    SqlDataReader dr = comm.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        Category _category = new Category();
                        _category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        _category.CategoryName = dr["CategoryName"].ToString();
                        _category.Description = dr["Description"].ToString();
                        categories.Add(_category);
                    }
                    dr.Close();
                    conn.Close();
                }
            }
            return categories;
        }

        public static void InsertCategory(Category category)
        {
            string commstr = "insert into Categories (CategoryName, Description) values(@CategoryName, @Description)";
            using (SqlConnection conn=new SqlConnection(connstr))
            {
                using (SqlCommand comm = new SqlCommand(commstr, conn))
            {
                conn.Open();
                comm.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                comm.Parameters.AddWithValue("@Description", category.Description);
                comm.ExecuteNonQuery();

                
                
                conn.Close();
            }
            }
            
        }

        public static Category LoadCategorieByID(int? CategoryID)//讀取一筆資料
        {
            Category _category = new Category();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string commstr = "select CategoryID, CategoryName, Description from Categories where CategoryID=@CategoryID";
                using (SqlCommand comm = new SqlCommand(commstr, conn))
                {
                    conn.Open();
                    comm.Parameters.AddWithValue("@CategoryID", CategoryID);
                    SqlDataReader dr = comm.ExecuteReader();

                    while (dr.Read())
                    {
                        
                        _category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        _category.CategoryName = dr["CategoryName"].ToString();
                        _category.Description = dr["Description"].ToString();
                        
                    }
                    dr.Close();
                    conn.Close();
                }
            }
            return _category;
        }

        public static void EditCategory(Category category)//修改資料庫該筆資料
        {
            
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string commstr = "update Categories set CategoryName=@CategoryName, Description=@Description where CategoryID=@CategoryID";
                using (SqlCommand comm = new SqlCommand(commstr, conn))
                {
                    
                    comm.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    comm.Parameters.AddWithValue("@Description", category.Description);
                    comm.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    conn.Open();
                   comm.ExecuteNonQuery();

                  
                    conn.Close();
                }
            }
            
        }

        public static void DeleteCategory(int id)//修改資料庫該筆資料
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string commstr = "delete from Categories where CategoryID=@CategoryID";
                using (SqlCommand comm = new SqlCommand(commstr, conn))
                {

                    
                    comm.Parameters.AddWithValue("@CategoryID", id);
                    conn.Open();
                    comm.ExecuteNonQuery();


                    conn.Close();
                }
            }

        }

    }
}