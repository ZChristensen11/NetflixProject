using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public static class ContactMethodDB 
    {
        
        //Instructions: 
        //Replace all ???TableNameHere phrases with the name of your specific SQL Server Database Table Name
        //Replace yourCustomeObject phrase with the name of the business object (represents database table name) you are referencing or returning
        //Replace datatype phrase with the appropriate C# data type or custom data type based on Project #2 CRUD specs
        //Replace parameter phrase with the appropriate input parameter based on Project #2 CRUD specs
        //Refer to the ADO.Net Demo for method examples below
        
        public static List<ContactMethod> GetContactMethods()
        {
            
            //Change the MyCustomObject name to your customer business object that is returning data from the specific table
            List<ContactMethod> objTemp = new List<ContactMethod>();
            string SQLStatement = "select id, name from contact_method order by id";
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
                                ContactMethod objContactMethod = new ContactMethod();
                                objContactMethod.ID = objReader["id"].ToString();
                                objContactMethod.Name = objReader["name"].ToString();

                                //Add the contactMethod to the collection
                                objTemp.Add(objContactMethod);
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
      
               
        public static ContactMethod GetContactMethod(int contactMethodID)
        {
            //Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
            string SQLStatement = String.Empty;

            //Change the MyCustomObject references  to your customer business object
            //ContactMethod objTemp = new ContactMethod();

            string sqlString = "Select id, name from contact_method where id = @contactMethod_id order by id";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader custReader = null;
            ContactMethod objContactMethod = null;
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
                        objCommand.Parameters.AddWithValue("@contactMethod_id", contactMethodID);
                        //Execute the SQL and return a DataReader
                        using (custReader = objCommand.ExecuteReader())
                        {
                            while (custReader.Read())
                            {
                                objContactMethod = new ContactMethod();
                                //Fill the customer object if found
                                objContactMethod.ID = custReader["id"].ToString();
                                objContactMethod.Name = custReader["name"].ToString();
                            }
                        }
                    }
                    return objContactMethod;
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

        public static bool AddContactMethod(ContactMethod objContactMethod)
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
                    sqlString = "INSERT into contact_method(id, name) values (@contactMethod_id, @contactMethod_name)";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@contactMethod_id", objContactMethod.ID);
                        objCommand.Parameters.AddWithValue("@contactMethod_name", objContactMethod.Name);
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

        public static bool UpdateContactMethod(ContactMethod objContactMethod)
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
                    sqlString = "UPDATE contact_method " + Environment.NewLine +
                                "set name = @contactMethod_name " + Environment.NewLine +
                                "where id = @contactMethod_id ";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@contactMethod_name", objContactMethod.Name);
                        objCommand.Parameters.AddWithValue("@contactMethod_id", objContactMethod.ID);
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

        public static bool DeleteContactMethod(ContactMethod objContactMethod)
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
                    sqlString = "Delete contact_method where id = @contactMethod_id";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@contactMethod_id", objContactMethod.ID);

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
