using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Post class
/// </summary>
public class Post
{
    private int post_id;
    private int user_id;
    private int class_id;
    private string content;
    private DateTime date;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="post_id"></param>
    /// <param name="user_id"></param>
    /// <param name="class_id"></param>
    /// <param name="content"></param>
    /// <param name="date"></param>
    public Post(int post_id, int user_id, int class_id, string content, DateTime date)
    {
        this.post_id = post_id;
        this.user_id = user_id;
        this.class_id = class_id;
        this.content = content;
        this.date = date;
    }
    /// <summary>
    /// Empty constructor
    /// </summary>
    public Post()
    {

    }

    // Getters
    /// <summary>
    /// Return post_id
    /// </summary>
    /// <returns>int post_id</returns>
    public int GetPostId()
    {
        return this.post_id;
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
    /// Return class_id
    /// </summary>
    /// <returns>int class_id</returns>
    public int GetClassId()
    {
        return this.class_id;
    }
    /// <summary>
    /// Return content
    /// </summary>
    /// <returns>string content</returns>
    public string GetContent()
    {
        return this.content;
    }
    /// <summary>
    /// Return author
    /// </summary>
    /// <returns>User author</returns>
    public User GetAuthor()
    {
        User user = new User();
        return user.GetUser(this.user_id);
    }
    /// <summary>
    /// Return date
    /// </summary>
    /// <returns>Datetime date</returns>
    public DateTime GetDate()
    {
        return this.date;
    }

    /// <summary>
    /// Insert post into DB
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="class_id"></param>
    /// <param name="content"></param>
    public void AddPost(int user_id, int class_id, string content)
    {
        var db = Database.Open("HarryPotter");

        db.Execute("INSERT INTO posts (user_id, class_id, content) VALUES (@0, @1, @2)", user_id, class_id, content);

        db.Dispose();
    }
}