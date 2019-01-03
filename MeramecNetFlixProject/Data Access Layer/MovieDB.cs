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

    public static class MovieDB
    {
        
        //Instructions: 
        //Replace all ???TableNameHere phrases with the name of your specific SQL Server Database Table Name
        //Replace yourCustomeObject phrase with the name of the business object (represents database table name) you are referencing or returning
        //Replace datatype phrase with the appropriate C# data type or custom data type based on Project #2 CRUD specs
        //Replace parameter phrase with the appropriate input parameter based on Project #2 CRUD specs
        //Refer to the ADO.Net Demo for method examples below
        
        
        public static List<Movie> GetMovies()
        {
            
            //Change the MyCustomObject name to your customer business object that is returning data from the specific table
            List<Movie> objTemp = new List<Movie>();
            string SQLStatement = "select movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, " +
                                           " media_type, movie_retail_cost, copies_on_hand, image, trailer " +
                                    "from movie order by movie_number";
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
                                Movie objMovie = new Movie();
                                objMovie.movie_number = objReader["movie_number"].ToString();
                                objMovie.movie_title = objReader["movie_title"].ToString();
                                objMovie.description = objReader["description"].ToString();
                                objMovie.movie_year_made = objReader["movie_year_made"].ToString();
                                objMovie.genre_id = objReader["genre_id"].ToString();
                                objMovie.movie_rating = objReader["movie_rating"].ToString();
                                objMovie.media_type = objReader["media_type"].ToString();
                                objMovie.movie_retail_cost = Convert.ToDecimal(objReader["movie_retail_cost"].ToString());
                                objMovie.copies_on_hand = objReader["copies_on_hand"].ToString();
                                objMovie.image = objReader["image"].ToString();
                                objMovie.trailer = objReader["trailer"].ToString();

                                //Add the movie to the collection
                                objTemp.Add(objMovie);
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

        public static List<Movie> GetMoviesByGenre(int genreID)
        {

            //Change the MyCustomObject name to your customer business object that is returning data from the specific table
            List<Movie> objTemp = new List<Movie>();
            string SQLStatement = "select movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, " +
                                           " media_type, movie_retail_cost, copies_on_hand, image, trailer " +
                                           " from movie " +
                                           " where genre_id = @genreid order by movie_number";
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
                        objCommand.Parameters.AddWithValue("@genreid", genreID);
                        //Execute the SQL and return a DataReader Object
                        using (objReader = objCommand.ExecuteReader())
                        {
                            while (objReader.Read())
                            {
                                Movie objMovie = new Movie();
                                objMovie.movie_number = objReader["movie_number"].ToString();
                                objMovie.movie_title = objReader["movie_title"].ToString();
                                objMovie.description = objReader["description"].ToString();
                                objMovie.movie_year_made = objReader["movie_year_made"].ToString();
                                objMovie.genre_id = objReader["genre_id"].ToString();
                                objMovie.movie_rating = objReader["movie_rating"].ToString();
                                objMovie.media_type = objReader["media_type"].ToString();
                                objMovie.movie_retail_cost = Convert.ToDecimal(objReader["movie_retail_cost"].ToString());
                                objMovie.copies_on_hand = objReader["copies_on_hand"].ToString();
                                objMovie.image = objReader["image"].ToString();
                                objMovie.trailer = objReader["trailer"].ToString();

                                //Add the movie to the collection
                                objTemp.Add(objMovie);
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
                if (objConn != null)
                {
                    objConn.Close();
                }

            }

            return objTemp;
        }

        public static Movie GetMovie(string movieName)
        {
            //Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
            string SQLStatement = String.Empty;

            //Change the MyCustomObject references  to your customer business object
            //Movie objTemp = new Movie();

            string sqlString = "Select movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, " +
                                           " media_type, movie_retail_cost, copies_on_hand, image, trailer " +
                                 "from movie where upper(movie_title) = upper(@movieName) ";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader movieReader = null;
            Movie objMovie = null;
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
                        objCommand.Parameters.AddWithValue("@movieName", movieName);
                        //Execute the SQL and return a DataReader
                        using (movieReader = objCommand.ExecuteReader())
                        {
                            while (movieReader.Read())
                            {
                                objMovie = new Movie();
                                //Fill the customer object if found

                                objMovie.movie_number = movieReader["movie_number"].ToString();
                                objMovie.movie_title = movieReader["movie_title"].ToString();
                                objMovie.description = movieReader["description"].ToString();
                                objMovie.movie_year_made = movieReader["movie_year_made"].ToString();
                                objMovie.genre_id = movieReader["genre_id"].ToString();
                                objMovie.movie_rating = movieReader["movie_rating"].ToString();
                                objMovie.media_type = movieReader["media_type"].ToString();
                                objMovie.movie_retail_cost = Convert.ToDecimal(movieReader["movie_retail_cost"].ToString());
                                objMovie.copies_on_hand = movieReader["copies_on_hand"].ToString();
                                objMovie.image = movieReader["image"].ToString();
                                objMovie.trailer = movieReader["trailer"].ToString();
                            }
                        }
                    }
                    return objMovie;
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
      
               
        public static Movie GetMovie(int movieID)
        {
            //Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
            string SQLStatement = String.Empty;

            //Change the MyCustomObject references  to your customer business object
            //Movie objTemp = new Movie();

            string sqlString = "Select movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, " +
                                           " media_type, movie_retail_cost, copies_on_hand, image, trailer " +
                                 "from movie where movie_number = @movie_id ";
            SqlCommand objCommand = null;
            SqlConnection objConn = null;
            SqlDataReader movieReader = null;
            Movie objMovie = null;
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
                        objCommand.Parameters.AddWithValue("@movie_id", movieID);
                        //Execute the SQL and return a DataReader
                        using (movieReader = objCommand.ExecuteReader())
                        {
                            while (movieReader.Read())
                            {
                                objMovie = new Movie();
                                //Fill the customer object if found

                                objMovie.movie_number = movieReader["movie_number"].ToString();
                                objMovie.movie_title = movieReader["movie_title"].ToString();
                                objMovie.description = movieReader["description"].ToString();
                                objMovie.movie_year_made = movieReader["movie_year_made"].ToString();
                                objMovie.genre_id = movieReader["genre_id"].ToString();
                                objMovie.movie_rating = movieReader["movie_rating"].ToString();
                                objMovie.media_type = movieReader["media_type"].ToString();
                                objMovie.movie_retail_cost = Convert.ToDecimal(movieReader["movie_retail_cost"].ToString());
                                objMovie.copies_on_hand = movieReader["copies_on_hand"].ToString();
                                objMovie.image = movieReader["image"].ToString();
                                objMovie.trailer = movieReader["trailer"].ToString();
                            }
                        }
                    }
                    return objMovie;
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

        public static bool AddMovie(Movie objMovie)
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
                    sqlString = "INSERT into Movie (movie_number, movie_title, description, movie_year_made, genre_id, " +
                                        "movie_rating, media_type, movie_retail_cost, copies_on_hand, image, trailer) values (@movie_number, @movie_title, @description, @movie_year_made," +
                                        " @genre_id, @movie_rating, @media_type, @movie_retail_cost, @copies_on_hand," +
                                        " @image, @trailer)";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@movie_number", objMovie.movie_number);
                        objCommand.Parameters.AddWithValue("@movie_title", objMovie.movie_title);
                        objCommand.Parameters.AddWithValue("@description", objMovie.description);
                        objCommand.Parameters.AddWithValue("@movie_year_made",objMovie.movie_year_made);
                        objCommand.Parameters.AddWithValue("@genre_id", objMovie.genre_id);
                        objCommand.Parameters.AddWithValue("@movie_rating", objMovie.movie_rating);
                        objCommand.Parameters.AddWithValue("@media_type", objMovie.media_type);
                        objCommand.Parameters.AddWithValue("@movie_retail_cost", objMovie.movie_retail_cost);
                        objCommand.Parameters.AddWithValue("@copies_on_hand", objMovie.copies_on_hand);
                        objCommand.Parameters.AddWithValue("@image", objMovie.image);
                        objCommand.Parameters.AddWithValue("@trailer", objMovie.trailer);

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

        public static bool UpdateMovie(Movie objMovie)
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
                    sqlString = "UPDATE Movie " + Environment.NewLine +
                                "set movie_title = @movie_title, " + Environment.NewLine +
                                "description = @description, " + Environment.NewLine +
                                "movie_year_made = @movie_year_made, " + Environment.NewLine +
                                "genre_id = @genre_id, " + Environment.NewLine +
                                "movie_rating = @movie_rating, " + Environment.NewLine +
                                "media_type = @media_type, " + Environment.NewLine +
                                "movie_retail_cost = @movie_retail_cost, " + Environment.NewLine +
                                "copies_on_hand = @copies_on_hand, " + Environment.NewLine +
                                "image = @image, " + Environment.NewLine +
                                "trailer = @trailer " + Environment.NewLine +
                                "where movie_number = @movie_number ";
                    
                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@movie_number", objMovie.movie_number);
                        objCommand.Parameters.AddWithValue("@movie_title", objMovie.movie_title);
                        objCommand.Parameters.AddWithValue("@description", objMovie.description);
                        objCommand.Parameters.AddWithValue("@movie_year_made", objMovie.movie_year_made);
                        objCommand.Parameters.AddWithValue("@genre_id", objMovie.genre_id);
                        objCommand.Parameters.AddWithValue("@movie_rating", objMovie.movie_rating);
                        objCommand.Parameters.AddWithValue("@media_type", objMovie.media_type);
                        objCommand.Parameters.AddWithValue("@movie_retail_cost", objMovie.movie_retail_cost);
                        objCommand.Parameters.AddWithValue("@copies_on_hand", objMovie.copies_on_hand);
                        objCommand.Parameters.AddWithValue("@image", objMovie.image);
                        objCommand.Parameters.AddWithValue("@trailer", objMovie.trailer);
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

        public static bool DeleteMovie(Movie objMovie)
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
                    sqlString = "Delete Movie where movie_number = @movie_number";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@movie_number", objMovie.movie_number);

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
