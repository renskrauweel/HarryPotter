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
        new Question(1, "1. What animal do you associate yourself with the most?"),
        new Question(2, "2. A Student went into the Dark Woods, because there is a tale about a mystical sword being there. You just heared that she has been gone now for the past 2 hours. " +
            "What will you do?"),
        new Question(3, "3. What would you do on your first day of Hogwarts?"),
        new Question(4, "4. Who of these people do you trust the most?"),
        new Question(5, "5. There are 4 relics in front of you which one would you pick?"),
        new Question(6, "6. At the Duelling club you have been challenged a Wizard's duel. You accept the challenge. You bow and start the duel, but what is the first thing you do?"),
        new Question(7, "7. You see that Frank is getting bullied by Devin. Frank is really insecure and has really big ears. What do you do?"),
        new Question(8, "8. Which of these sports do you like the most"),
        new Question(9, "9. Which one of these clases do you like the most?"),
        new Question(10, "10."),
        new Question(11, "11."),
        new Question(12, "12. You got homework that needs to be done by tomorrow, but also you have a Quidditch match tomorrow. What do you do?"),

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
        new Answer(7, 2, "You will go in on your own eventhough people call you mad for doing it. You mainly want to find the lost girl, but hopefully you will find the mystical sword as " +
            "well as the girl.",new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", -2}, {"Slytherin", -1} }),
        new Answer(8, 2, "There is no way you will go in the Dark Forest. You will get the teachers as quick as you can and tell them what is happening.",
            new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 2}, {"Ravenclaw", 4}, {"Slytherin", -1} }),

        new Answer(9, 3, "You try to make friends by talking to your fellow classmates.", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 3}, {"Ravenclaw", -1}, {"Slytherin", 1} }),
        new Answer(10, 3, "You're curious about the lessons, so you start reading your books already.", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", -1} }),
        new Answer(11, 3, "You explore the castle and look for secrets it hides.", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", -1}, {"Slytherin", 1} }),
        new Answer(12, 3, "You want to be the funny guy, so you try to prank someone", new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),

        new Answer(13, 4, "Pomona Sprout", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(14, 4, "Minerva McGonagall", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", -1} }),
        new Answer(15, 4, "Severus Snape", new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),
        new Answer(16, 4, "Filius Flitwick", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 1} }),
        
        new Answer(17, 5, "A Want that will make you the most powerful wizzard ever.", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", 2} }),
        new Answer(18, 5, "A book that grants you all the wisdom.", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 4}, {"Slytherin", -1} }),
        new Answer(19, 5, "A broomstick that will make you the fastest in the air.", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", 2} }),
        new Answer(20, 5, "A flask with water that makes you immortal", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", 3} }),

        new Answer(21, 6, "You wait for your opponent to cast a spell first, but you're prepared to use Protego so get a shield that will deflect the opponents spell", 
            new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(22, 6, "you use Stupefy to stun your opponent.", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 1} }),
        new Answer(23, 6, "You use Everte Statum to thows your opponent backwards.",
            new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", -1}, {"Ravenclaw", 0}, {"Slytherin", 3} }),
        new Answer(24, 6, "You use Expelliarmus to disarm your opponent", new Dictionary<string, int> { {"Gryffindor", 0}, { "Hufflepuff", 3} , {"Ravenclaw", 2}, {"Slytherin", -1} }),

        new Answer(25, 7, "You don't want to get involved, so you ignore it and walk away.", 
            new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 1 } }),
        new Answer(26, 7, "Screw Frank he is always annoying in class, so you join Devin and say to Frank: Hey Franky, go flap your ears, hopefully you'll fly away.", 
            new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),
        new Answer(27, 7, "Stand up for Frank and you push Devin on the ground and tell him to leave Frank alone and get of here.",
            new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", -1}, {"Slytherin", 0} }),
        new Answer(28, 7, "You ask some someone to get a teacher in case it escalates. Then you ask Devin to stop bullying Frank.", 
            new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", -1} }),

        new Answer(29, 8, "Quidditch", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 1} }),
        new Answer(30, 8, "The Triwizard Tournament", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", -1}, {"Slytherin", 1} }),
        new Answer(31, 8, "Wizard's Chess", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(32, 8, "Wizard's Duelling", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", -1}, {"Slytherin", 3} }),

        new Answer(33, 9, "Astronomy", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(34, 9, "Charms", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 1}, {"Slytherin", 0} }),
        new Answer(35, 9, "Dark Arts", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", -1}, {"Ravenclaw", 0}, {"Slytherin", 3} }),
        new Answer(36, 9, "Herbology", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", -1} }),

        new Answer(37, 10, "You do the homework you need to do now.", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 2}, {"Ravenclaw", 2}, {"Slytherin", 0} }),
        new Answer(38, 10, "You go to the training of Quidditch now, so you are ready for the match tomorrow.", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 2} }),

        new Answer(39, 11, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(40, 11, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(41, 11, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(42, 11, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),

        new Answer(43, 12, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(44, 12, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(45, 12, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(46, 12, "", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 0} }),


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