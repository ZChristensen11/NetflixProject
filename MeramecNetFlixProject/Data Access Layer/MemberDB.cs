using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//The System.Data.SqlClient reference is needed to access SQL Server database
using System.Data.SqlClient;
using MeramecNetFlixProject.Business_Objects;


namespace MeramecNetFlixProject.Data_Access_Layer
{
    //Instructions:
    //#1:Rename the SkeletonTableNameDB class to the Specific Database Table name. i.e. CustomerDB
    //#2:The SkeletonTableNameDB class should inherit the superclass called AccessDataSQLServer
    //#3: The AccessDataSQLServer static class GetConnection method must be created and used in all 
    //    SQLServer database calls for the open connection. See Project#2 Specs for class definition.

    public static class MemberDB
    {
        
        //Instructions: 
        //Replace all ???TableNameHere phrases with the name of your specific SQL Server Database Table Name
        //Replace yourCustomeObject phrase with the name of the business object (represents database table name) you are referencing or returning
        //Replace datatype phrase with the appropriate C# data type or custom data type based on Project #2 CRUD specs
        //Replace parameter phrase with the appropriate input parameter based on Project #2 CRUD specs
        //Refer to the ADO.Net Demo for method examples below
        
        
        public static List<Member> GetMembers()
        {
            
            //Change the MyCustomObject name to your customer business object that is returning data from the specific table
            List<Member> objTemp = new List<Member>();
            string SQLStatement = "select number, joindate, firstname, lastname, address, city, state, zipcode, phone, " +
                                        "member_status, login_name, password, email, contact_method, subscription_id, photo " +
                                    "from member order by number";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader objReader = null;
            

            try
            {
                //using (objConn = AccessDataSQLServer.GetConnection())
                using (objConn = AccessDataSQLServer.GetConnection())
                {
                    //Open the connection to the database
                    objConn.Open();
                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(SQLStatement, objConn))
                    {
                        //Execute the SQL and return a DataReader Object
                        using (objReader = objCommand.ExecuteReader())
                        {
                            while (objReader.Read())
                            {
                                Member objMember = new Member();
                                objMember.number = objReader["number"].ToString();
                                objMember.joindate = objReader["joindate"].ToString();
                                objMember.firstname = objReader["firstname"].ToString();
                                objMember.lastname = objReader["lastname"].ToString();
                                objMember.address = objReader["address"].ToString();
                                objMember.city = objReader["city"].ToString();
                                objMember.state = objReader["state"].ToString();
                                objMember.zipcode = objReader["zipcode"].ToString();
                                objMember.phone = objReader["phone"].ToString();
                                objMember.member_status = objReader["member_status"].ToString();
                                objMember.login_name = objReader["login_name"].ToString();
                                objMember.password = objReader["password"].ToString();
                                objMember.email = objReader["email"].ToString();
                                objMember.contact_method = objReader["contact_method"].ToString();
                                objMember.subscription_id = objReader["subscription_id"].ToString();
                                objMember.photo = objReader["photo"].ToString();

                                //Add the member to the collection
                                objTemp.Add(objMember);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (objConn !=null)
                {
                    objConn.Close();
                }

            }
                        
            return objTemp;
        }

        public static Member GetMember(int id)
        {
            //Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
            string SQLStatement = String.Empty;

            //Change the MyCustomObject references  to your customer business object
            //Member objTemp = new Member();

            string sqlString = "Select number, joindate, firstname, lastname, address, city, state, zipcode, phone, " +
                                    "member_status, login_name, password, email, contact_method, subscription_id, photo " +
                                 "from member where number = @id;";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader memberReader = null;
            Member objMember = null;
            try
            {
                using (objConn = AccessDataSQLServer.GetConnection())
                {
                    //Open the connection to the datbase
                    objConn.Open();
                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Set command parameter
                        objCommand.Parameters.AddWithValue("@id", id);
                        //Execute the SQL and return a DataReader
                        using (memberReader = objCommand.ExecuteReader())
                        {
                            while (memberReader.Read())
                            {
                                objMember = new Member();
                                //Fill the customer object if found

                                objMember.number = memberReader["number"].ToString();
                                objMember.joindate = memberReader["joindate"].ToString();
                                objMember.firstname = memberReader["firstname"].ToString();
                                objMember.lastname = memberReader["lastname"].ToString();
                                objMember.address = memberReader["address"].ToString();
                                objMember.city = memberReader["city"].ToString();
                                objMember.state = memberReader["state"].ToString();
                                objMember.zipcode = memberReader["zipcode"].ToString();
                                objMember.phone = memberReader["phone"].ToString();
                                objMember.member_status = memberReader["member_status"].ToString();
                                objMember.login_name = memberReader["login_name"].ToString();
                                objMember.password = memberReader["password"].ToString();
                                objMember.email = memberReader["email"].ToString();
                                objMember.contact_method = memberReader["contact_method"].ToString();
                                objMember.subscription_id = memberReader["subscription_id"].ToString();
                                objMember.photo = memberReader["photo"].ToString();

                            }
                        }
                    }
                    return objMember;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //Finally will always be called in a try..catch..statem. You can use to to close the connection
                //especially if an error is thrown
                if (objConn != null)
                {
                    objConn.Close();
                }
            }

        }

        public static Member GetMember(string member_login_name)
        {
            //Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
            string SQLStatement = String.Empty;

            //Change the MyCustomObject references  to your customer business object
            //Member objTemp = new Member();

            string sqlString = "Select number, joindate, firstname, lastname, address, city, state, zipcode, phone, " +
                                    "member_status, login_name, password, email, contact_method, subscription_id, photo " +
                                 "from member where upper(login_name) = upper(@member_login_name) ";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader memberReader = null;
            Member objMember = null;
            try
            {
                using (objConn = AccessDataSQLServer.GetConnection())
                {
                    //Open the connection to the datbase
                    objConn.Open();
                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Set command parameter
                        objCommand.Parameters.AddWithValue("@member_login_name", member_login_name);
                        //Execute the SQL and return a DataReader
                        using (memberReader = objCommand.ExecuteReader())
                        {
                            while (memberReader.Read())
                            {
                                objMember = new Member();
                                //Fill the customer object if found

                                objMember.number = memberReader["number"].ToString();
                                objMember.joindate = memberReader["joindate"].ToString();
                                objMember.firstname = memberReader["firstname"].ToString();
                                objMember.lastname = memberReader["lastname"].ToString();
                                objMember.address = memberReader["address"].ToString();
                                objMember.city = memberReader["city"].ToString();
                                objMember.state = memberReader["state"].ToString();
                                objMember.zipcode = memberReader["zipcode"].ToString();
                                objMember.phone = memberReader["phone"].ToString();
                                objMember.member_status = memberReader["member_status"].ToString();
                                objMember.login_name = memberReader["login_name"].ToString();
                                objMember.password = memberReader["password"].ToString();
                                objMember.email = memberReader["email"].ToString();
                                objMember.contact_method = memberReader["contact_method"].ToString();
                                objMember.subscription_id = memberReader["subscription_id"].ToString();
                                objMember.photo = memberReader["photo"].ToString();

                            }
                        }
                    }
                    return objMember;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //Finally will always be called in a try..catch..statem. You can use to to close the connection
                //especially if an error is thrown
                if (objConn != null)
                {
                    objConn.Close();
                }
            }
            
        }

        public static bool AddMember(Member objMember)
        {
            //Pre-step: Replace the general object parameter with the appropriate business class object that you are using to insert data in the underline database table 
            string SQLStatement = String.Empty;
            
            int rowsAffected = 0;

            SqlCommand objCommand = null;
            SqlConnection objConn = null;

            string sqlString;
            try
            {
                using (objConn = AccessDataSQLServer.GetConnection())
                {
                    //Open the connection to the datbase
                    objConn.Open();
                    sqlString = "INSERT into Member (joindate, firstname, lastname, address, " +
                                        "city, state, zipcode, phone, member_status, login_name, password, email, contact_method, subscription_id, photo) " +
                                        "values (@joindate, @firstname, @lastname," +
                                        " @address, @city, @state, @zipcode, @phone," +
                                        " @member_status, @login_name, @password, @email, @contact_method, @subscription_id, @photo)";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        //objCommand.Parameters.AddWithValue("@number", objMember.number);
                        objCommand.Parameters.AddWithValue("@joindate", objMember.joindate);
                        objCommand.Parameters.AddWithValue("@firstname", objMember.firstname);
                        objCommand.Parameters.AddWithValue("@lastname",objMember.lastname);
                        objCommand.Parameters.AddWithValue("@address", objMember.address);
                        objCommand.Parameters.AddWithValue("@city", objMember.city);
                        objCommand.Parameters.AddWithValue("@state", objMember.state);
                        objCommand.Parameters.AddWithValue("@zipcode", objMember.zipcode);
                        objCommand.Parameters.AddWithValue("@phone", objMember.phone);
                        objCommand.Parameters.AddWithValue("@member_status", objMember.member_status);
                        objCommand.Parameters.AddWithValue("@login_name", objMember.login_name);
                        objCommand.Parameters.AddWithValue("@password", objMember.password);
                        objCommand.Parameters.AddWithValue("@email", objMember.email);
                        objCommand.Parameters.AddWithValue("@contact_method", objMember.contact_method);
                        objCommand.Parameters.AddWithValue("@subscription_id", objMember.subscription_id);
                        objCommand.Parameters.AddWithValue("@photo", objMember.photo);


                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //Finally will always be called in a try..catch..statem. You can use to to close the connection
                //especially if an error is thrown
                if (objConn != null)
                {
                    objConn.Close();
                }
            }
        }

        public static bool UpdateMember(Member objMember)
        {
            string SQLStatement = String.Empty;
            
            int rowsAffected = 0;

            SqlCommand objCommand = null;
            SqlConnection objConn = null;

            string sqlString;
            try
            {
                using (objConn = AccessDataSQLServer.GetConnection())
                {
                    //Open the connection to the datbase
                    objConn.Open();
                    sqlString = "UPDATE Member " + Environment.NewLine +
                                "set joindate = @joindate, " + Environment.NewLine +
                                "firstname = @firstname, " + Environment.NewLine +
                                "lastname = @lastname, " + Environment.NewLine +
                                "address = @address, " + Environment.NewLine +
                                "city = @city, " + Environment.NewLine +
                                "state = @state, " + Environment.NewLine +
                                "zipcode = @zipcode, " + Environment.NewLine +
                                "phone = @phone, " + Environment.NewLine +
                                "member_status = @member_status, " + Environment.NewLine +
                                "login_name = @login_name, " + Environment.NewLine +
                                "password = @password, " + Environment.NewLine +
                                "email = @email, " + Environment.NewLine +
                                "contact_method = @contact_method, " + Environment.NewLine +
                                "subscription_id = @subscription_id, " + Environment.NewLine +
                                "photo = @photo " + Environment.NewLine +
                                "where number = @number; ";
                    
                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@number", objMember.number);
                        objCommand.Parameters.AddWithValue("@joindate", objMember.joindate);
                        objCommand.Parameters.AddWithValue("@firstname", objMember.firstname);
                        objCommand.Parameters.AddWithValue("@lastname", objMember.lastname);
                        objCommand.Parameters.AddWithValue("@address", objMember.address);
                        objCommand.Parameters.AddWithValue("@city", objMember.city);
                        objCommand.Parameters.AddWithValue("@state", objMember.state);
                        objCommand.Parameters.AddWithValue("@zipcode", objMember.zipcode);
                        objCommand.Parameters.AddWithValue("@phone", objMember.phone);
                        objCommand.Parameters.AddWithValue("@member_status", objMember.member_status);
                        objCommand.Parameters.AddWithValue("@login_name", objMember.login_name);
                        objCommand.Parameters.AddWithValue("@password", objMember.password);
                        objCommand.Parameters.AddWithValue("@email", objMember.email);
                        objCommand.Parameters.AddWithValue("@contact_method", objMember.contact_method);
                        objCommand.Parameters.AddWithValue("@subscription_id", objMember.subscription_id);
                        objCommand.Parameters.AddWithValue("@photo", objMember.photo);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw;
            }
            finally
            {
                //Finally will always be called in a try..catch..statem. You can use to to close the connection
                //especially if an error is thrown
                if (objConn != null)
                {
                    objConn.Close();
                }
            }

        }

        public static bool DeleteMember(Member objMember)
        {
            //Pre-step: Replace the general object parameter with the appropriate business class object that you are using to insert data in the underline database table 
            string SQLStatement = String.Empty;
            //Uncomment either Example #1 or #2 to use appropriate connection string
            //Example #1 for connecting to a remote SQL Server instance via IP address and SQL Server authenication..For Meramec
            //string connectionString = "Server=mc-sluggo.stlcc.edu;Database=IS253_251;User Id=csharp2;Password=csharp2;";

            //Example #2 for connecting to SQL Server locally with Windows Authenication. Change accordingly to your environment.
            //string connectionString = @"Data Source=STEVIE-LAPTOP\MSSQLSERVER1;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            int rowsAffected = 0;

            SqlCommand objCommand = null;
            SqlConnection objConn = null;

            string sqlString;
            try
            {
                using (objConn = AccessDataSQLServer.GetConnection())
                {
                    //Open the connection to the datbase
                    objConn.Open();
                    sqlString = "Delete Member where number = @number";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@number", objMember.number);

                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //Finally will always be called in a try..catch..statem. You can use to to close the connection
                //especially if an error is thrown
                if (objConn != null)
                {
                    objConn.Close();
                }
            }
        }

    }

  }
