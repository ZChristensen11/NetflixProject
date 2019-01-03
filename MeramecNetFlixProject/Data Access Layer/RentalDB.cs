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

    public static class RentalDB
    {
        
        //Instructions: 
        //Replace all ???TableNameHere phrases with the name of your specific SQL Server Database Table Name
        //Replace yourCustomeObject phrase with the name of the business object (represents database table name) you are referencing or returning
        //Replace datatype phrase with the appropriate C# data type or custom data type based on Project #2 CRUD specs
        //Replace parameter phrase with the appropriate input parameter based on Project #2 CRUD specs
        //Refer to the ADO.Net Demo for method examples below
        
        
        public static List<Rental> GetRentals()
        {
            
            //Change the MyCustomObject name to your customer business object that is returning data from the specific table
            List<Rental> objTemp = new List<Rental>();
            string SQLStatement = "select movie_number, member_number, media_checkout_date, media_return_date " +
                                    "from rental order by movie_number";
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
                                Rental objRental = new Rental();
                                objRental.movie_number = objReader["movie_number"].ToString();
                                objRental.member_number = objReader["member_number"].ToString();
                                objRental.media_checkout_date = objReader["media_checkout_date"].ToString();
                                objRental.media_return_date = objReader["media_return_date"].ToString();

                                //Add the rental to the collection
                                objTemp.Add(objRental);
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
      
               
        public static Rental GetRental(int movie_number, int member_number, string media_checkout_date)
        {
            //Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
            string SQLStatement = String.Empty;

            //Change the MyCustomObject references  to your customer business object
            //Rental objTemp = new Rental();

            string sqlString = "Select movie_number, member_number, media_checkout_date, media_return_date " +
                                 "from rental where movie_number = @movie_number AND member_number = @member_number AND media_checkout_date = @media_checkout_date;";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader rentalReader = null;
            Rental objRental = null;
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
                        objCommand.Parameters.AddWithValue("@movie_number", movie_number);
                        objCommand.Parameters.AddWithValue("@member_number", member_number);
                        objCommand.Parameters.AddWithValue("@media_checkout_date", media_checkout_date);
                        //Execute the SQL and return a DataReader
                        using (rentalReader = objCommand.ExecuteReader())
                        {
                            while (rentalReader.Read())
                            {
                                objRental = new Rental();
                                //Fill the customer object if found

                                objRental.movie_number = rentalReader["movie_number"].ToString();
                                objRental.member_number = rentalReader["member_number"].ToString();
                                objRental.media_checkout_date = rentalReader["media_checkout_date"].ToString();
                                objRental.media_return_date = rentalReader["media_return_date"].ToString();
                            }
                        }
                    }
                    return objRental;
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

        public static bool AddRental(Rental objRental)
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
                    sqlString = "INSERT into Rental (movie_number, member_number, media_checkout_date) " +
                                        " values (@movie_number, @member_number, @media_checkout_date)";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@movie_number", objRental.movie_number);
                        objCommand.Parameters.AddWithValue("@member_number", objRental.member_number);
                        objCommand.Parameters.AddWithValue("@media_checkout_date", objRental.media_checkout_date);
                        //objCommand.Parameters.AddWithValue("@media_return_date",objRental.media_return_date);

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

        public static bool UpdateRental(Rental objRental)
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
                    sqlString = "UPDATE Rental " + Environment.NewLine +
                                "set member_number = @member_number, " + Environment.NewLine +
                                "movie_number = @movie_number, " + Environment.NewLine +
                                "media_checkout_date = @media_checkout_date, " + Environment.NewLine +
                                "media_return_date = @media_return_date " + Environment.NewLine +
                                "where member_number = @memeber_number AND movie_number = @movie_number AND media_checkout_date = @media_checkout_date;";
                    
                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@movie_number", objRental.movie_number);
                        objCommand.Parameters.AddWithValue("@member_number", objRental.member_number);
                        objCommand.Parameters.AddWithValue("@media_checkout_date", objRental.media_checkout_date);
                        objCommand.Parameters.AddWithValue("@media_return_date", objRental.media_return_date);
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

        public static bool DeleteRental(Rental objRental)
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
                    sqlString = "Delete Rental Where member_number = @member_number AND movie_number = @movie_number AND media_checkout_date = @media_checkout_date;";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@movie_number", objRental.movie_number);
                        objCommand.Parameters.AddWithValue("@member_number", objRental.member_number);
                        objCommand.Parameters.AddWithValue("@media_checkout_date", objRental.media_checkout_date);

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
