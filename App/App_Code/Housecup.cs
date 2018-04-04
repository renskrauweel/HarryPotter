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
}