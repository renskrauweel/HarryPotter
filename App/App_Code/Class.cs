using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

public class Class
{
    private int class_id;
    private string classname;
    private int teacher_id;

	public Class(int class_id, string classname, int teacher_id)
	{
        this.class_id = class_id;
        this.classname = classname;
        this.teacher_id = teacher_id;
	}

    // Getters
    public int GetClassId()
    {
        return this.class_id;
    }
    public string GetClassname()
    {
        return this.classname;
    }
    public User GetTeacher()
    {
        var db = Database.Open("HarryPotter");

        if (this.teacher_id != 0)
        {
            User user = new User();
            return user.GetUser(this.teacher_id);
        }
        return new User();
    }

    // Fetch all the classes from the database
    public static List<Class> GetClasses()
    {
        var db = Database.Open("HarryPotter");
        List<Class> classes = new List<Class>();

        var rows = db.Query("SELECT * FROM classes");

        foreach (var row in rows)
        {
            int teacherId = 0;
            if (row["teacher_id"] != null)
            {
                teacherId = (int)row["teacher_id"];
            }
            int classId = (int)row["class_id"];
            classes.Add(new Class(classId, row["classname"], teacherId));
        }

        return classes;
    }

    // Participate on class
    public static void ParticipateOnClass(int classId, int userId)
    {
        var db = Database.Open("HarryPotter");

        var row = db.QuerySingle("SELECT * FROM classes_users WHERE user_id = @0 AND class_id = @1", userId, classId);

        if (row == null)
        {
            db.Execute("INSERT INTO classes_users (user_id, class_id) VALUES (@0, @1)", userId, classId);
        }

        db.Dispose();
    }
}