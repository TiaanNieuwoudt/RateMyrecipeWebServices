//------------------------------------------------------
// Author: Tiaan Nieuwoudt
// Date: 15 March 2021
// File: dbHandler.aspx.cs
//-------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.IO;


/// <summary>
namespace RateMyRecipeWebServices
{
    public class dbHandler
    {
        SqlConnection sqlConn;

        public void ConnectToDatabase()
        {
            sqlConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\rate_my_recipe.mdf;Integrated Security=True");
            sqlConn.Open();

        }

        // Method which disconnects from the database.
        public void DisconnectDatabase()
        {
            sqlConn.Close();
        }

        // Authenication used for Logging In
        public SqlDataReader AuthUser(string user, string password)
        {
            ConnectToDatabase();
            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM [Users] WHERE username = '{user}' AND password = '{password}'";

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.Read());
                    return reader;
                }
            }

            catch (SqlException)
            {
                return null;
            }

            return null;
        }

        // INSERT new user
        public bool InsertUser(string user, string password, string email, string name, string surname, string security_question, string security_answer)
        {

            ConnectToDatabase();

            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"INSERT INTO [Users] ([username], [password], [firstname], [lastname], [email], " +
                    $"[securityQuestion], [securityAnswer]) VALUES ('{user}', '{password}', '{name}', '{surname}', '{email}', '{security_question}', '{security_answer}');";


                try
                {
                    cmd.ExecuteReader();
                    return true;
                }

                catch (System.Data.SqlClient.SqlException)
                {
                    return false;
                }


            }

            return true;


        }

        // Insert new recipe
        public bool insertRecipe(string name, string intgredients, string method, int ownerID, int totalRatings, int rating, decimal avgRating)
        {
            ConnectToDatabase();

            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = $"INSERT INTO [Recipes] ([name], [ingredients], [method], [ownerID], [totalRatings], [rating], [avgRating]) VALUES ('{name}', '{intgredients}', '{method}', '{ownerID}', '{totalRatings}', '{rating}', '{avgRating}');";

                cmd.ExecuteReader();

            }

            return true;

        }


        // getUserID via known username
        public int getUserID(string username)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"SELECT Id from Users WHERE username = '{username}'";

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int returnedUser = (int)reader["Id"];
                        return returnedUser;
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return 9999;
                }

                DisconnectDatabase();
            }
            return 9999;
        }


//Below follows statements that deal with the Recipes Table
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//Update Recipe Name
        public void updateRecipeName(int recipeId, string recipeName)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Recipes SET name = '{recipeName}' WHERE Id = '{recipeId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }

        }
        // Update Recipe Method
        public void updateRecipeMethod(int recipeId, string recipeMethod)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Recipes SET name = '{recipeMethod}' WHERE Id = '{recipeId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }

        //Update Recipe Ingredients
        public void updateRecipeIngredients(int recipeId, string recipeIngredients)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Recipes SET name = '{recipeIngredients}' WHERE Id = '{recipeId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // Below follow statements that deal with the Users table

        // update username
        public void updateUsername(int userId, string username)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Users SET username = '{username}' WHERE Id = '{userId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }

        // Update Password
        public void updatePassword(int userId, string password)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Users SET password = '{password}' WHERE Id = '{userId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }

        // Update Firstname
        public void updateFirstname(int userId, string firstname)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Users SET firstname = '{firstname}' WHERE Id = '{userId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }


        // Update Lastname
        public void updateLastname(int userId, string lastname)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Users SET lastname = '{lastname}' WHERE Id = '{userId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }


        // Update Email
        public void updateEmail(int userId, string email)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();
                cmd.CommandText = $"UPDATE Users SET email = '{email}' WHERE Id = '{userId}'";
                cmd.ExecuteNonQuery();
                DisconnectDatabase();
            }
        }

        // Return an array with the values of a secified recipe
        public ArrayList get_recipe(string recipe_name)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"SELECT Recipes.method, Recipes.ingredients, Recipes.avgRating, " +
                    $"Users.Username from Recipes LEFT JOIN Users ON Recipes.OwnerId = Users.Id WHERE name = '{recipe_name}'";


                SqlDataReader reader = cmd.ExecuteReader();
                ArrayList recipe_array = new ArrayList();

                while (reader.Read())
                {

                    recipe_array.Add(recipe_name);


                    string method = (string)reader["method"];
                    recipe_array.Add(method);

                    string ingredients = (string)reader["ingredients"];
                    recipe_array.Add(ingredients);

                    decimal rating = (decimal)reader["avgRating"];
                    recipe_array.Add(rating);

                    string username = (string)reader["username"];
                    recipe_array.Add(username);


                }

                DisconnectDatabase();

                return recipe_array;

            }
            return null;
        }

        // return an array list of recipes
        public ArrayList get_recipes()
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"SELECT * from Recipes";


                SqlDataReader reader = cmd.ExecuteReader();
                ArrayList recipe_array = new ArrayList();

                while (reader.Read())
                {
                    Hashtable data_entry = new Hashtable();

                    string name = (string)reader["name"];
                    data_entry.Add("name", name);

                    string ingredients = (string)reader["ingredients"];
                    data_entry.Add("ingredients", ingredients);

                    string method = (string)reader["method"];
                    data_entry.Add("method", method);

                    recipe_array.Add(data_entry);
                }

                return recipe_array;

            }
            return null;
        }

        // Get specified Recipe
        public bool rate_recipe(string recipe_name, int rating, int UserId)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"SELECT * FROM Recipes WHERE name = '{recipe_name}' AND ownerId != {UserId}";
                SqlDataReader reader = cmd.ExecuteReader();


                int _totalRating = 0;
                int _rating = 0;
                int _recipeId = 0;

                while (reader.Read())
                {
                    _recipeId = (int)reader["Id"];
                    _totalRating = (int)reader["totalRatings"];
                    _rating = (int)reader["rating"];

                }

                reader.Close();

                cmd.CommandText = $"INSERT INTO [ratedRecipes] ([userId], [recipeId], [rating]) VALUES ({UserId}, {_recipeId}, {rating});";
                try
                {
                    reader = cmd.ExecuteReader();
                    _totalRating = _totalRating + 1;
                    _rating = _rating + rating;
                    decimal _avg_rating = (decimal)_rating / (_totalRating * 5);
                    reader.Close();

                    cmd.CommandText = $"UPDATE Recipes SET totalRatings = {_totalRating}, rating = {_rating}, avgRating = {_avg_rating} WHERE name = '{recipe_name}'";
                    reader = cmd.ExecuteReader();
                    reader.Close();
                    return true;

                }
                catch (System.Data.SqlClient.SqlException)
                {
                    

                }

                DisconnectDatabase();
                return false;
            }
            return false;
        }

        public string getSecurityQuestion(string username)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"SELECT securityQuestion FROM users WHERE username = '{username}'";

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string question = (string)reader["securityQuestion"];
                        return question;

                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return null;
                }

            }

            return null;
        }

        public string validateSecurityQuestion(string username)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();


                cmd.CommandText = $"SELECT securityAnswer FROM Users WHERE username = '{username}'";


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine(reader.Read());
                    string answer = (string)reader["securityAnswer"];
                    return answer;
                }
                else
                {
                    return "norows";
                }



            }
            else
            {
                return "";
            }

        }

        public void changePasswordByUsername(string username, string password)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = $"UPDATE Users SET password = '{password}' WHERE username = '{username}'";
                cmd.ExecuteReader();

            }

        }
        public string retrievePassword(int userId)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = $"SELECT password FROM Users WHERE Id = '{userId}'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string password = (string)reader["password"];
                    return password;
                }

            }
            return null;
        }

        public bool changeSecurityInfo(string question, string answer, int userId)
        {

            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = $"UPDATE Users SET securityQuestion = '{question}', securityAnswer = '{answer}' WHERE Id = '{userId}'";

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    return true;
                }

                catch (System.Data.SqlClient.SqlException)
                {
                    return false;
                }

            }
            return false;

        }

        public string getEmail(int userId)
        {
            ConnectToDatabase();
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = sqlConn.CreateCommand();

                cmd.CommandText = $"SELECT email FROM Users WHERE Id = '{userId}''";

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string email = (string)reader["email"];
                        return email;
                    }
                }

                catch (System.Data.SqlClient.SqlException)
                {
                    return null;
                }

            }
            return null;
        }
    }
}
/// </summary>
