using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Answer
{
    private int answer_id;
    private int question_id;
    private string answer;
    private Dictionary<string, int> housePointPair;

    public Answer(int answer_id, int question_id, string answer, Dictionary<string, int> housePointPair)
    {
        this.answer_id = answer_id;
        this.question_id = question_id;
        this.answer = answer;
        this.housePointPair = housePointPair;
    }

    public Answer()
    {

    }

    // Getters
    public int GetAnswerId()
    {
        return this.answer_id;
    }
    public int GetQuestionId()
    {
        return this.question_id;
    }
    public string GetAnswer()
    {
        return this.answer;
    }
    public Dictionary<string, int> GetHousePointPair()
    {
        return this.housePointPair;
    }
}