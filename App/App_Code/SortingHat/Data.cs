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
         * dictionary housePointsPair | Dictionary containing all houses with the points of the answer to go to that house
         * int points | Number of points
         */
        new Answer(1, 1, "Gryffindor", new Dictionary<string, int> { {"Gryffindor", 5}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", -2} }),
        new Answer(2, 1, "Hufflepuff", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 5}, {"Ravenclaw", 0}, {"Slytherin", -2} }),
        new Answer(3, 1, "Ravenclaw", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 5}, {"Slytherin", 3} }),
        new Answer(4, 1, "Slytherin", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 5} }),

        new Answer(5, 2, "Apple's", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(6, 2, "Banana's", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(7, 2, "Kiwi's", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(8, 2, "Grapes", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 1} }),

        new Answer(9, 3, "Hagrid", new Dictionary<string, int> { {"Gryffindor", 5}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(10, 3, "Snape", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 5}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(11, 3, "Dumbledore", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 5}, {"Slytherin", 0} }),
        new Answer(12, 3, "Voldemort", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 5} }),
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