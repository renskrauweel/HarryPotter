using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Answer class
/// </summary>
public class Answer
{
    private int answer_id;
    private int question_id;
    private string answer;
    private Dictionary<string, int> housePointPair;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="answer_id"></param>
    /// <param name="question_id"></param>
    /// <param name="answer"></param>
    /// <param name="housePointPair"></param>
    public Answer(int answer_id, int question_id, string answer, Dictionary<string, int> housePointPair)
    {
        this.answer_id = answer_id;
        this.question_id = question_id;
        this.answer = answer;
        this.housePointPair = housePointPair;
    }

    /// <summary>
    /// Empty constructor
    /// </summary>
    public Answer()
    {

    }

    // Getters
    /// <summary>
    /// Return answer_id
    /// </summary>
    /// <returns>int answer_id</returns>
    public int GetAnswerId()
    {
        return this.answer_id;
    }
    /// <summary>
    /// Return question_id
    /// </summary>
    /// <returns>int question_id</returns>
    public int GetQuestionId()
    {
        return this.question_id;
    }
    /// <summary>
    /// Return answer
    /// </summary>
    /// <returns>string answer</returns>
    public string GetAnswer()
    {
        return this.answer;
    }
    /// <summary>
    /// Return housepoint pair
    /// </summary>
    /// <returns>Dictionary<string, int> housepoint pair</returns>
    public Dictionary<string, int> GetHousePointPair()
    {
        return this.housePointPair;
    }
}