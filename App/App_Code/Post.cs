using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

public class Post
{
    private int post_id;
    private int user_id;
    private int class_id;
    private string content;
    private DateTime date;

    public Post(int post_id, int user_id, int class_id, string content, DateTime date)
    {
        this.post_id = post_id;
        this.user_id = user_id;
        this.class_id = class_id;
        this.content = content;
        this.date = date;
    }
    public Post()
    {

    }

    // Getters
    public int GetPostId()
    {
        return this.post_id;
    }
    public int GetUserId()
    {
        return this.user_id;
    }
    public int GetClassId()
    {
        return this.class_id;
    }
    public string GetContent()
    {
        return this.content;
    }
    public User GetAuthor()
    {
        User user = new User();
        return user.GetUser(this.user_id);
    }
    public DateTime GetDate()
    {
        return this.date;
    }

    // Insert post into DB
    public void AddPost(int user_id, int class_id, string content)
    {
        var db = Database.Open("HarryPotter");

        db.Execute("INSERT INTO posts (user_id, class_id, content) VALUES (@0, @1, @2)", user_id, class_id, content);

        db.Dispose();
    }
}