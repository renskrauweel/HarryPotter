using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Housecup class
/// </summary>
public class Housecup
{
    private int year;
    private int house_id;
    private int points;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="year"></param>
    /// <param name="house_id"></param>
    /// <param name="points"></param>
    public Housecup(int year, int house_id, int points)
    {
        this.year = year;
        this.house_id = house_id;
        this.points = points;
    }

    // Getters
    /// <summary>
    /// Return year
    /// </summary>
    /// <returns>int year</returns>
    public int GetYear()
    {
        return this.year;
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
    /// Return points
    /// </summary>
    /// <returns>int points</returns>
    public int GetPoints()
    {
        return this.points;
    }

    /// <summary>
    /// Return is last year exists in housecup
    /// </summary>
    /// <returns>bool last year exists in housecup</returns>
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

    /// <summary>
    /// Run the housecup
    /// </summary>
    /// <param name="housePointPair"></param>
    public static void RunHousecup(Dictionary<int, int> housePointPair)
    {
        int houseId = housePointPair.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        var db = Database.Open("HarryPotter");
        db.Execute("INSERT INTO housecup (year, house_id, points) VALUES (@0, @1, @2)", (DateTime.Now.Year - 1), houseId, housePointPair[houseId]);
        db.Dispose();
    }

    /// <summary>
    /// Get all housecups
    /// </summary>
    /// <returns>List<Housecup> housecups</returns>
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
    /// Return housename by house_id
    /// </summary>
    /// <param name="house_id"></param>
    /// <returns>string housename</returns>
    public static string GetHouseNameByHouseId(int house_id)
    {
        var db = Database.Open("HarryPotter");
        string housename = db.QueryValue("SELECT house_name FROM houses WHERE house_id = @0", house_id);
        db.Dispose();

        return housename;
    }
}