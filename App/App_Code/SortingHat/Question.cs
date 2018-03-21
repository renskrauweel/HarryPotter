using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Question
{
    private int question_id;
    private string question;

    public Question(int question_id, string question)
    {
        this.question_id = question_id;
        this.question = question;
    }

    // Getters
    public int GetQuestionId()
    {
        return this.question_id;
    }
    public string GetQuestion()
    {
        return this.question;
    }
}