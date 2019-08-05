using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace WebServiceDB
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return DateTime.Now.ToString();
        }
        
        [WebMethod]
        public void AddUserPermissionByPhoneAndPName(string uPhone, string pName, string pTime)
        {
            
            User s=new User();
            Permission p=new Permission();
            string SQL = "SELECT * FROM UserTable WHERE UPhone LIKE '%" + uPhone + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s.uID = int.Parse(reader["UID"].ToString());
                s.uname = reader["Uname"].ToString();
                s.uPass = reader["UPass"].ToString();
                s.uPhone = reader["UPhone"].ToString();
                
            }
            conn.Close();

            SQL = "SELECT * FROM PermissionTable WHERE PName LIKE '%" + pName + "%'";
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p.pID = int.Parse(reader["PID"].ToString());
                p.pName = reader["PName"].ToString();
                
            }
            // Connect to DB

            conn.Close();
            // Write some SQL INSERT statement
            SQL = "INSERT INTO UPTable VALUES ('" + s.uID.ToString() + "', " + p.pID.ToString() + ",'" + pTime + "')";

            // Connect to DB
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
       
        [WebMethod]
        public void UpdateUserPermissionByPhoneAndPname(string uPhone, string pName, string pTime)
        {
            User s = new User();
            Permission p = new Permission();
            string SQL = "SELECT * FROM UserTable WHERE UPhone LIKE '%" + uPhone + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s.uID = int.Parse(reader["UID"].ToString());
                s.uname = reader["Uname"].ToString();
                s.uPass = reader["UPass"].ToString();
                s.uPhone = reader["UPhone"].ToString();

            }
            conn.Close();

            SQL = "SELECT * FROM PermissionTable WHERE PName LIKE '%" + pName + "%'";
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p.pID = int.Parse(reader["PID"].ToString());
                p.pName = reader["PName"].ToString();

            }
            SQL = "UPDATE UPTable SET Ptimes = '" + pTime + "' WHERE UID = '" + s.uID + "' AND PID=" + "'" + p.pID + "'";

            // Connect to DB
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
        
        [WebMethod]
        public List<User> UpdateUserNameByPhone(string uPhone, string newName)
        {
            // Write some SQL INSERT statement
            string SQL = "UPDATE UserTable SET Uname = '" + newName + "' WHERE UPhone = '" + uPhone + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
            List<User> UserList = new List<User>();

            // Write some SQL statement
            SQL = "select * from UserTable Where UPhone='" + uPhone + "'";

            // Connect to DB
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
                    s.uID = int.Parse(reader["UID"].ToString());
                    s.uname = reader["Uname"].ToString();
                    s.uPass = reader["UPass"].ToString();
                    s.uPhone = reader["UPhone"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }
        [WebMethod]
        public List<User> UpdateUserPassByPhone(string uPhone, string newPass)
        {
            // Write some SQL INSERT statement
            string SQL = "UPDATE UserTable SET UPass = '" + newPass + "' WHERE UPhone = '" + uPhone + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
            List<User> UserList = new List<User>();

            // Write some SQL statement
            SQL = "select * from UserTable Where UPhone='" + uPhone + "'";

            // Connect to DB
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
                    s.uID = int.Parse(reader["UID"].ToString());
                    s.uname = reader["Uname"].ToString();
                    s.uPass = reader["UPass"].ToString();
                    s.uPhone = reader["UPhone"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }
        [WebMethod]
        public void UpdateUserName(string uID, string newName)
        {
            // Write some SQL INSERT statement
            string SQL = "UPDATE UserTable SET Uname = '" + newName + "' WHERE UID = '" + uID + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
        [WebMethod]
        public void UpdateUserPass(string uID,string newPass)
        {
            // Write some SQL INSERT statement
            string SQL = "UPDATE UserTable SET UPass = '" + newPass + "' WHERE UID = '" + uID + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
        
        [WebMethod]
        public void AddUserPermission(string uID, string pID, string pTime)
        {
            // Write some SQL INSERT statement
            string SQL = "INSERT INTO UPTable VALUES ('" + uID + "', " + pID + ",'" + pTime + "')";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
        [WebMethod]
        public void UpdateUserPermission(string uID, string pID, string pTime)
        {
            // Write some SQL INSERT statement
            string SQL = "UPDATE UPTable SET Ptimes = '"+pTime+"' WHERE UID = '"+uID+"' AND PID="+"'"+pID+"'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
        
        [WebMethod]
        public void InsertUserDetails(string uname,string uPass,string uPhone)
        {
            // Write some SQL INSERT statement
            string SQL = "INSERT INTO UserTable VALUES ('" + uname + "', " + uPass + ",'" + uPhone +"')";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
        
        [WebMethod]
        public void InsertPermissionDetails( string pName)
        {
            // Write some SQL INSERT statement
            string SQL = "INSERT INTO PermissionTable VALUES ('" + pName +  "')";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);
            // Execute SQL command
            cmd.ExecuteNonQuery();

            // Close & Disconnect from DB
            conn.Close();
        }
       
        
        [WebMethod]
        public List<User> GetAllUser()
        {
            List<User> UserList = new List<User>();

            // Write some SQL statement
            string SQL = "select * from UserTable";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
                    s.uID = int.Parse(reader["UID"].ToString());
                    s.uname = reader["Uname"].ToString();
                    s.uPass = reader["UPass"].ToString();
                    s.uPhone = reader["UPhone"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }
        
        [WebMethod]
        public List<Permission> GetAllPermission()
        {
            List<Permission> PermissionList = new List<Permission>();

            // Write some SQL statement
            string SQL = "select * from PermissionTable";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Permission p = new Permission();
                    p.pID = int.Parse(reader["PID"].ToString());
                    p.pName = reader["PName"].ToString();
                    PermissionList.Add(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return PermissionList;
        }
        [WebMethod]
        public List<User> FindUserByName(string searchstring)
        {
            List<User> UserList = new List<User>();

            // Write some SQL statement
            string SQL = "SELECT * FROM UserTable WHERE Uname LIKE '%" + searchstring + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
           
                    s.uID = int.Parse(reader["UID"].ToString());
                    s.uname = reader["Uname"].ToString();
                    s.uPass = reader["UPass"].ToString();
                    s.uPhone = reader["UPhone"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }
        [WebMethod]
        public List<User> FindUserByPhone(string searchstring)
        {
            List<User> UserList = new List<User>();

            // Write some SQL statement
            string SQL = "SELECT * FROM UserTable WHERE UPhone LIKE '%" + searchstring + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    User s = new User();
           
                    s.uID = int.Parse(reader["UID"].ToString());
                    s.uname = reader["Uname"].ToString();
                    s.uPass = reader["UPass"].ToString();
                    s.uPhone = reader["UPhone"].ToString();
                    UserList.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UserList;
        }
        [WebMethod]
        public List<Permission> FindPermissionByName(string searchstring)
        {
            List<Permission> PermissionList = new List<Permission>();

            // Write some SQL statement
            string SQL = "SELECT * FROM PermissionTable WHERE PName LIKE '%" + searchstring + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Permission p = new Permission();

                    p.pID = int.Parse(reader["PID"].ToString());
                    p.pName = reader["PName"].ToString();
                    PermissionList.Add(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return PermissionList;
        }
        [WebMethod]
        public string DeleteUserByPhone(string uPhone)
        {
            User s = new User();
            string SQL = "SELECT * FROM UserTable WHERE UPhone LIKE '%" + uPhone + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {

                    s.uID = int.Parse(reader["UID"].ToString());
                    s.uname = reader["Uname"].ToString();
                    s.uPass = reader["UPass"].ToString();
                    s.uPhone = reader["UPhone"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();
            SQL = "DELETE FROM UserTable WHERE UPhone LIKE '%" + uPhone + "%'";

            // Connect to DB
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            reader = cmd.ExecuteReader();
            
            reader.Close();
            conn.Close();
            SQL = "DELETE FROM UPTable WHERE UID = '" + s.uID + "'";

            // Connect to DB
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
            return "已删除 Name:" + s.uname + ",Phone:" + s.uPhone;
        }

        [WebMethod]
        public string DeletePermission(string PName)
        {
            Permission p = new Permission();
            string SQL = "SELECT * FROM PermissionTable WHERE Pname LIKE '%" + PName + "%'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    p.pID = int.Parse(reader["PID"].ToString());
                    p.pName = reader["PName"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();
            SQL = "DELETE FROM PermissionTable WHERE PName LIKE '%" + PName + "%'";

            // Connect to DB
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            reader = cmd.ExecuteReader();
            
            reader.Close();
            conn.Close();
            SQL = "DELETE FROM UPTable WHERE PID = '" + p.pID + "'";

            // Connect to DB
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            cmd = new SqlCommand(SQL, conn);

            reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
            return "已删除 Name:" + p.pID + ",Phone:" + p.pName;
        }
        [WebMethod]
        public List<UP> FindUserPermission(string uID)
        {
            List<UP> UPList = new List<UP>();

            // Write some SQL statement
            string SQL = "SELECT * FROM UPTable WHERE UID= '" + uID + "'";

            // Connect to DB
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebServiceDB.Properties.Settings.Setting"].ToString());
            // Open DB
            conn.Open();

            SqlCommand cmd = new SqlCommand(SQL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    UP p = new UP();
                    p.pID = int.Parse(reader["PID"].ToString());
                    p.uID = int.Parse(reader["UID"].ToString());
                    p.pTimes = int.Parse(reader["Ptimes"].ToString());
                    p.details = "pID" + p.pID + "uID" + p.uID + "pTimes" + p.pTimes;
                    UPList.Add(p);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            reader.Close();
            conn.Close();

            return UPList;
        }
       
        
    }
    


}