using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections;

namespace RateMyRecipeWebServices
{
    /// <summary>
    /// Summary description for UserServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class UserServices : System.Web.Services.WebService
    {
        dbHandler dbhandler = new dbHandler();

        [WebMethod]
        public bool RegisterUserService(string username, string password, string email, string name, string surname, string security_qestion, string security_answer)
        {
            if (dbhandler.InsertUser(username, password, email, name, surname, security_qestion, security_answer) == false)
            {
                return false;
            };

            return true;

        }
        [WebMethod]
        public bool userLogin(string username, string password)
        {
            if (dbhandler.AuthUser(username, password) == null)
            {
                return false;
            }

            return true;
        }

        [WebMethod]
        public bool InsertRecipeService(string name, string intgredients, string method, int ownerID, int totalRatings, int rating, decimal avgRating)
        {
            if (dbhandler.insertRecipe(name, intgredients, method, ownerID, totalRatings, rating, avgRating) == false)
            {
                return false;
            }

            return true;

        }

        [WebMethod]
        public int getUserID(string username)
        {
            return dbhandler.getUserID(username);
        }


        // Change Recipe Details
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [WebMethod]
        public void updateRecipeName(int recipeId, string RecipeName)
        {
            dbhandler.updateRecipeName(recipeId, RecipeName);
        }

        [WebMethod]
        public void updateRecipeEngredients(int recipeId, string recipeEngredients)
        {
            dbhandler.updateRecipeIngredients(recipeId, recipeEngredients);
        }

        [WebMethod]
        public void updateRecipeMethod(int recipeId, string recipeEngredients)
        {
            dbhandler.updateRecipeMethod(recipeId, recipeEngredients);
        }
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // update User profile Methods
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [WebMethod]
        public void updateUsername(int userId, string username)
        {
            dbhandler.updateRecipeMethod(userId, username);
        }

        [WebMethod]
        public void updatePassword(int userId, string password)
        {
            dbhandler.updatePassword(userId, password);
        }

        [WebMethod]
        public void updateFirstname(int userId, string firstname)
        {
            dbhandler.updateFirstname(userId, firstname);
        }

        [WebMethod]
        public void updateLastname(int userId, string lastname)
        {
            dbhandler.updateLastname(userId, lastname);
        }

        [WebMethod]
        public void updateEmail(int userId, string email)
        {
            dbhandler.updateEmail(userId, email);
        }


        [WebMethod]
        public string getSecurityQuestuion(string username)
        {
            return dbhandler.getSecurityQuestion(username);

        }

        [WebMethod]
        public string validateSecurityQuestion(string username)
        {
            return dbhandler.validateSecurityQuestion(username);
        }

        [WebMethod]
        public void changePasswordByUsername(string username, string password)
        {
            dbhandler.changePasswordByUsername(username, password);
        }

        [WebMethod]
        public string retrievePassword(int userId)
        {
            return dbhandler.retrievePassword(userId);
        }

        [WebMethod]
        public bool changeSecurityInfo(string question, string answer, int userId)
        {
            return dbhandler.changeSecurityInfo(question, answer, userId);
        }

        // Other recipe related Methods

        [WebMethod]
        public ArrayList get_recipe(string recipe_name)
        {
            return dbhandler.get_recipe(recipe_name);
        }

        [WebMethod]
        public ArrayList get_recipes()
        {
            return dbhandler.get_recipes();
        }


        [WebMethod]
        public bool rate_recipe(string recipe_name, int rating, int UserId)
        {
            return dbhandler.rate_recipe(recipe_name, rating, UserId);
        }

        [WebMethod]
        public string getEmail(int userId)
        {
            return dbhandler.getEmail(userId);
        }


    }
}

