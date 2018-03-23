using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Data
{
    private static List<Question> questions = new List<Question>
    {
        /*
         * Parameter order:
         * int question_id | Unique, Auto increment
         * string question
         */
        new Question(1, "What animal do you associate yourself with the most?"),
        new Question(2, "A Student went into the Dark Woods, because there is a tale about a mystical sword being there. You just heared that she has been gone now for the past 2 hours. What will you do?"),
        new Question(4, "Who of these people do you trust the most?"),
    };

    private static List<Answer> answers = new List<Answer>
    {
        /*
         * Parameter order:
         * int answer_id | Unique, Auto increment
         * int question_id | Belonging question
         * string answer | The answer
         * dictionary housePointsPair | Dictionary containing all houses with the points of the answer to go to that house
         * int points | Number of points
         */
        new Answer(1, 1, "Lion", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", -1} }),
        new Answer(2, 1, "Badger", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(3, 1, "Eagle", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 1} }),
        new Answer(4, 1, "Snake", new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),

        new Answer(5, 2, "You will go in the Dark Forest with 2 of your friends and try find the mystical sword for yourself to keep.", 
            new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", -1}, {"Slytherin", 3} }),
        new Answer(6, 2, "You decide with a group of friends to go and find the student in the Dark Forest.", 
            new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", -1}, {"Slytherin", 0} }),
        new Answer(7, 2, "You will go in on your own eventhough people call you mad for doing it. You mainly want to find the lost girl, but hopefully you will find the mystical sword as well as the girl.",
            new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", -2}, {"Slytherin", -1} }),
        new Answer(8, 2, "There is no way you will go in the Dark Forest. You will get the teachers as quick as you can and tell them what is happening.",
            new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 2}, {"Ravenclaw", 4}, {"Slytherin", -1} }),

        new Answer(13, 4, "Pomona Sprout", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(14, 4, "Minerva McGonagall", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", -1} }),
        new Answer(15, 4, "Severus Snape", new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),
        new Answer(16, 4, "Filius Flitwick", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 1} }),
    };

    // Get all questions
    public static List<Question> GetQuestions()
    {
        return Data.questions;
    }

    // Get question's answers by question_id
    public static List<Answer> GetAnswers(int question_id)
    {
        List<Answer> answers = new List<Answer>();
        foreach (Answer answer in Data.answers)
        {
            if (answer.GetQuestionId() == question_id)
            {
                answers.Add(answer);
            }
        }

        return answers;
    }

    // Get single answer by answer_id
    public static Answer GetAnswer(int answerId)
    {
        foreach (Answer answer in Data.answers)
        {
            if (answer.GetAnswerId() == answerId)
            {
                return answer;
            }
        }
        return new Answer();
    }
}