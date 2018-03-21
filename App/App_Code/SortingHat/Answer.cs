using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Answer
{
    private int question_id;
    private string answer;
    private string house;
    private int points;

    public Answer(int question_id, string answer, string house, int points)
    {
        this.question_id = question_id;
        this.answer = answer;
        this.house = house;
        this.points = points;
    }

    // Getters
    public int GetQuestionId()
    {
        return this.question_id;
    }
    public string GetAnswer()
    {
        return this.answer;
    }
    public string GetHouse()
    {
        return this.house;
    }
    public int GetPoints()
    {
        return this.points;
    }
}