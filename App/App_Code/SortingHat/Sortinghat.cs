using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

public class Sortinghat
{
    public Sortinghat()
    {
        
    }

    // Sort user by housepoint pair's
    public string Sort(Dictionary<string, int> housePointPair, int userId)
    {
        string house = housePointPair.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        int houseId = 0;
        switch (house)
        {
            case "Gryffindor":
                houseId = 1;
                break;
            case "Hufflepuff":
                houseId = 2;
                break;
            case "Ravenclaw":
                houseId = 3;
                break;
            case "Slytherin":
                houseId = 4;
                break;
        }
        if (houseId != 0)
        {
            var db = Database.Open("HarryPotter");
            
            db.Execute("UPDATE users SET house_id = @0 WHERE user_id = @1", houseId, userId);
        }

        return house;
    }
}