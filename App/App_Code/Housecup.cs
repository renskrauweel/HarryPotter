using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

public class Housecup
{
    private int year;
    private int house_id;
    private int points;

    public Housecup(int year, int house_id, int points)
    {
        this.year = year;
        this.house_id = house_id;
        this.points = points;
    }

    // Getters
    public int GetYear()
    {
        return this.year;
    }
    public int GetHouseId()
    {
        return this.house_id;
    }
    public int GetPoints()
    {
        return this.points;
    }

    public static bool LastYearExists()
    {
        var db = Database.Open("HarryPotter");
        var row = db.QueryValue("SELECT COUNT(*) FROM housecup WHERE year = @0", (DateTime.Now.Year - 1));
        db.Dispose();

        if ((int)row > 0)
        {
            return true;
        }
        return false;
    }

    // Run the housecup
    public static void RunHousecup(Dictionary<int, int> housePointPair)
    {
        int houseId = housePointPair.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        var db = Database.Open("HarryPotter");
        db.Execute("INSERT INTO housecup (year, house_id, points) VALUES (@0, @1, @2)", (DateTime.Now.Year - 1), houseId, housePointPair[houseId]);
        db.Dispose();
    }

    // Get all housecups
    public static List<Housecup> GetHousecups()
    {
        var db = Database.Open("HarryPotter");
        var rows = db.Query("SELECT * FROM housecup ORDER BY year DESC");
        db.Dispose();

        List<Housecup> housecups = new List<Housecup>();
        foreach (var row in rows)
        {
            int year = (int)row["year"];
            int houseId = (int)row["house_id"];
            int points = (int)row["points"];
            housecups.Add(new Housecup(year, houseId, points));
        }

        return housecups;
    }

    // Fetch house name
    public string GetHouseName()
    {
        var db = Database.Open("HarryPotter");
        string housename = db.QueryValue("SELECT house_name FROM houses WHERE house_id = @0", this.house_id);
        db.Dispose();

        return housename;
    }
}