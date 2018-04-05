using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Question class
/// </summary>
public class Question
{
    private int question_id;
    private string question;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="question_id"></param>
    /// <param name="question"></param>
    public Question(int question_id, string question)
    {
        this.question_id = question_id;
        this.question = question;
    }

    // Getters
    /// <summary>
    /// Return question_id
    /// </summary>
    /// <returns>int question_id</returns>
    public int GetQuestionId()
    {
        return this.question_id;
    }
    public string GetQuestion()
    {
        return this.question;
    }
}