﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

public class User
{
    private int user_id;
    private string username;
    private string firstname;
    private string lastname;
    private string email;
    private int role_id;
    private int house_id;

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
    public User()
    {

    }

    public string GetFullName()
    {
        return this.firstname + " " + this.lastname;
    }

    public User GetUser(int user_id)
    {
        var db = Database.Open("HarryPotter");

        var row = db.QuerySingle("SELECT user_id, username, firstname, lastname, email, house_id, role_id FROM users WHERE user_id = @0", user_id);
        if (row != null)
        {
            int userId = row["user_id"];
            int houseId = 0;
            if (row["house_id"] != null)
            {
                houseId = row["house_id"];
            }
            return new User(userId, row["username"], row["firstname"], row["lastname"], row["email"], (int)row["role_id"], houseId);
        }
        return new User();
    }

    public string GetHouseName()
    {
        var db = Database.Open("HarryPotter");

        return db.QueryValue("SELECT house_name FROM houses WHERE house_id = @0", this.house_id);
    }

    public string GetRole()
    {
        var db = Database.Open("HarryPotter");

        return db.QueryValue("SELECT role_name FROM roles WHERE role_id = @0", this.role_id);
    }
}