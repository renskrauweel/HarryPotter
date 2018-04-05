using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// User class
/// </summary>
public class User
{
    private int user_id;
    private string username;
    private string firstname;
    private string lastname;
    private string email;
    private int role_id;
    private int house_id;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="username"></param>
    /// <param name="firstname"></param>
    /// <param name="lastname"></param>
    /// <param name="email"></param>
    /// <param name="role_id"></param>
    /// <param name="house_id"></param>
    public User(int user_id, string username, string firstname, string lastname, string email, int role_id, int house_id = 0)
    {
        this.user_id = user_id;
        this.username = username;
        this.firstname = firstname;
        this.lastname = lastname;
        this.email = email;
        this.role_id = role_id;
        this.house_id = house_id;
    }
    /// <summary>
    /// Empty constructor
    /// </summary>
    public User()
    {

    }

    /// <summary>
    /// Return house_id
    /// </summary>
    /// <returns>int house_id</returns>
    public int GetHouseId()
    {
        return this.house_id;
    }

    /// <summary>
    /// Return user_id
    /// </summary>
    /// <returns>int user_id</returns>
    public int GetUserId()
    {
        return this.user_id;
    }

    /// <summary>
    /// Get the full name of a user
    /// </summary>
    /// <returns>string fullname</returns>
    public string GetFullName()
    {
        return this.firstname + " " + this.lastname;
    }

    /// <summary>
    /// Fetch a user from the DB by user_id
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns>User user</returns>
    public User GetUser(int user_id)
    {
        var db = Database.Open("HarryPotter");

        var row = db.QuerySingle("SELECT user_id, username, firstname, lastname, email, house_id, role_id FROM users WHERE user_id = @0", user_id);

        db.Dispose();

        if (row != null)
        {
            int userId = row["user_id"];
            int houseId = 0;
            if (row["house_id"] != null)
                houseId = row["house_id"];

            return new User(userId, row["username"], row["firstname"], row["lastname"], row["email"], (int)row["role_id"], houseId);
        }

        return new User();
    }

    /// <summary>
    /// Fetch house name
    /// </summary>
    /// <returns>string housename</returns>
    public string GetHouseName()
    {
        var db = Database.Open("HarryPotter");

        string housename = db.QueryValue("SELECT house_name FROM houses WHERE house_id = @0", this.house_id);

        db.Dispose();

        return housename;
    }

    /// <summary>
    /// Fetch role
    /// </summary>
    /// <returns>string role</returns>
    public string GetRole()
    {
        var db = Database.Open("HarryPotter");
        string role = db.QueryValue("SELECT role_name FROM roles WHERE role_id = @0", this.role_id);
        db.Dispose();

        return role;
    }

    /// <summary>
    /// Fetch house_id by user_id
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns>int house_id</returns>
    public int GetHouseIdByUserId(int user_id)
    {
        var db = Database.Open("HarryPotter");
        var houseId = db.QueryValue("SELECT house_id FROM users WHERE user_id = @0", user_id);
        db.Dispose();

        return (int)houseId;
    }

    /// <summary>
    /// Return list of users by role
    /// </summary>
    /// <param name="role_id"></param>
    /// <returns>List<User> users</returns>
    public List<User> GetUsersByRole(int role_id)
    {
        List<User> users = new List<User>();
        var db = Database.Open("HarryPotter");
        var rows = db.Query("SELECT * FROM users WHERE role_id = @0", role_id);
        db.Dispose();

        foreach (var row in rows)
        {
            users.Add(new User((int)row["user_id"], row["username"], row["firstname"],
                row["lastname"], row["email"], (int)row["role_id"], (int)row["house_id"]));
        }

        return users;
    }

    /// <summary>
    /// Assign user
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="role_id"></param>
    public void AssignUser(int user_id, int role_id)
    {
        var db = Database.Open("HarryPotter");
        db.Execute("UPDATE users SET role_id = @0 WHERE user_id = @1", role_id, user_id);
        db.Dispose();
    }

    /// <summary>
    /// Return if user has house
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns>bool has house</returns>
    public bool HasHouse(int user_id)
    {
        var db = Database.Open("HarryPotter");
        var row = db.QueryValue("SELECT house_id FROM users WHERE user_id = @0", user_id);
        db.Dispose();

        int houseId = (int)row;

        if (houseId > 0)
        {
            return true;
        }
        return false;
    }
}