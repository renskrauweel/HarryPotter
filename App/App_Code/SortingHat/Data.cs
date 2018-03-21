using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Data
{
    private List<Question> questions = new List<Question>
    {
        new Question(1, "Which house do you prefer?"),
        new Question(2, "What's your favorite fruit?"),
    };

    private List<Answer> answers = new List<Answer>
    {
        new Answer(1, "Gryffindor", "Gryffindor", 5),
        new Answer(1, "Hufflepuff", "Hufflepuff", 5),
        new Answer(1, "Ravenclaw", "Ravenclaw", 5),
        new Answer(1, "Slytherin", "Slytherin", 5),

        new Answer(2, "Apples", "Gryffindor", 5),
        new Answer(2, "Banana's", "Hufflepuff", 3),
        new Answer(2, "Kiwi's", "Ravenclaw", -2),
        new Answer(2, "Grapes", "Slytherin", 1),
    };

    // Get all questions
    public List<Question> GetQuestions()
    {
        return this.questions;
    }

    // Get question's answers by question_id
    public List<Answer> GetAnswers(int question_id)
    {
        List<Answer> answers = new List<Answer>();
        foreach (Answer answer in this.answers)
        {
            if (answer.GetQuestionId() == question_id)
            {
                answers.Add(answer);
            }
        }

        return answers;
    }
}