using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using UserRegistration.Interface;
using UserRegistration.Models;

namespace UserRegistration.Database
{
    public class DBContext : IDBContext
    {
        IConfiguration _configuration;
        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public void UserRegister(UserModel user)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetValue<string>("connectionString"));
                string query = "Insert INTO [ProjectKuchela].[dbo].[UserRegistration](UserName,FirstName,LastName,Address,Mobile,Password,Email,Salt,HashedPassword)" +
                    "VALUES(@UserName,@FirstName,@LastName,@Address,@Mobile,@Password,@Email,@Salt,@HashedPassword)";
                
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                //cmd.Parameters.AddWithValue("@DOB", user.DOB);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Mobile", user.Mobile);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Salt", user.Salt);
                cmd.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
        
        public void GetHashAndSalt(ref LoginModel login)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetValue<string>("connectionString"));
            string query = "SELECT * FROM [ProjectKuchela].[dbo].[UserRegistration] WHERE UserName=@UserName";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@UserName", login.UserName);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var val = sqlDataReader.HasRows;
               
            while(sqlDataReader.Read())
            {
                login.Salt = sqlDataReader["Salt"].ToString();
                login.HashedPassword = sqlDataReader["HashedPassword"].ToString();
                    
            }
            
            sqlConnection.Close();
            
        }
    }
}
