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
    private string class_description;
    private List<Post> posts = new List<Post>();
    private List<Homework.Homework> homework = new List<Homework.Homework>();

	public Class(int class_id, string classname, int teacher_id, string class_description)
	{
        this.class_id = class_id;
        this.classname = classname;
        this.teacher_id = teacher_id;
        this.class_description = class_description;

        var db = Database.Open("HarryPotter");

        // Construct posts
        var posts = db.Query("SELECT * FROM posts WHERE class_id = @0 ORDER BY date", this.class_id);
        foreach (var row in posts)
        {
            this.posts.Add(new Post((int)row["post_id"], (int)row["user_id"], (int)row["class_id"], row["content"], row["date"]));
        }

        // Construct homework
        var homework = db.Query("SELECT * FROM homework WHERE class_id = @0 AND deadline > getdate()", this.class_id);
        foreach (var row in homework)
        {
            this.homework.Add(new Homework.Homework((int)row["homework_id"], row["homework_description"], (int)row["class_id"], (DateTime)row["deadline"]));
        }

        db.Dispose();
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

        db.Dispose();

        return new User();
    }
    public string GetClassdescription()
    {
        return this.class_description;
    }
    public List<Post> GetPosts()
    {
        return this.posts;
    }
    public List<Homework.Homework> GetHomework()
    {
        return this.homework;
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
                teacherId = (int)row["teacher_id"];

            int classId = (int)row["class_id"];
            classes.Add(new Class(classId, row["classname"], teacherId, row["class_description"]));
        }

        db.Dispose();

        return classes;
    }

    // Fetch my classes from the database
    public static List<Class> GetMyClasses(int userId)
    {
        var db = Database.Open("HarryPotter");
        List<Class> classes = new List<Class>();

        var rows = db.Query("SELECT * FROM classes where class_id in " +
            "(SELECT class_id FROM classes_users WHERE user_id = @0)", userId);

        foreach (var row in rows)
        {
            int teacherId = 0;
            if (row["teacher_id"] != null)
                teacherId = (int)row["teacher_id"];

            int classId = (int)row["class_id"];
            classes.Add(new Class(classId, row["classname"], teacherId, row["class_description"]));
        }

        db.Dispose();

        return classes;
    }

    // Participate on class
    public static void ParticipateOnClass(int classId, int userId)
    {
        var db = Database.Open("HarryPotter");

        var row = db.QuerySingle("SELECT * FROM classes_users WHERE user_id = @0 AND class_id = @1", userId, classId);

        if (row == null)
            db.Execute("INSERT INTO classes_users (user_id, class_id) VALUES (@0, @1)", userId, classId);

        db.Dispose();
    }

    // Return if the user is participating on class
    public static bool IsParticipating(int classId, int userId)
    {
        var db = Database.Open("HarryPotter");

        var row = db.QuerySingle("SELECT * FROM classes_users WHERE user_id = @0 AND class_id = @1", userId, classId);

        db.Dispose();

        if (row == null)
            return false;

        return true;
    }

    // Get class by id
    public static Class GetClass(int classId)
    {
        var db = Database.Open("HarryPotter");

        var row = db.QuerySingle("SELECT * FROM classes WHERE class_id = @0", classId);

        db.Dispose();

        int teacherId = 0;
        if (row["teacher_id"] != null)
            teacherId = (int)row["teacher_id"];

        return new Class((int)row["class_id"], row["classname"], teacherId, row["class_description"]);
    }
}