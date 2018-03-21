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
        new Question(1, "Which house do you prefer?"),
        new Question(2, "What's your favorite fruit?"),
        new Question(3, "Who is the bad guy?"),
    };

    private static List<Answer> answers = new List<Answer>
    {
        /*
         * Parameter order:
         * int answer_id | Unique, Auto increment
         * int question_id | Belonging question
         * string answer | The answer
         * string house | House where the points of the answer go to
         * int points | Number of points
         * string question
         */
        new Answer(1, 1, "Gryffindor", "Gryffindor", 5),
        new Answer(2, 1, "Hufflepuff", "Hufflepuff", 5),
        new Answer(3, 1, "Ravenclaw", "Ravenclaw", 5),
        new Answer(4, 1, "Slytherin", "Slytherin", 5),

        new Answer(5, 2, "Apples", "Gryffindor", 5),
        new Answer(6, 2, "Banana's", "Hufflepuff", 3),
        new Answer(7, 2, "Kiwi's", "Ravenclaw", -2),
        new Answer(8, 2, "Grapes", "Slytherin", 1),

        new Answer(9, 3, "Hagrid", "Gryffindor", 5),
        new Answer(10, 3, "Snape", "Hufflepuff", 5),
        new Answer(11, 3, "Dumbledore", "Ravenclaw", 5),
        new Answer(12, 3, "Voldemort", "Slytherin", 5),
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
}