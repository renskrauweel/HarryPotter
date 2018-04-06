using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Data class. This class holds all the questions and answers for the sorting hat
/// </summary>
public class Data
{
    /// <summary>
    /// Return questions
    /// </summary>
    private static List<Question> questions = new List<Question>
    {
        /*
         * Parameter order:
         * int question_id | Unique, Auto increment
         * string question
         */
        new Question(1, "1. What animal do you associate yourself with the most?"),
        new Question(2, "2. You've just heard that a girl has been lost in the Dark Woods for over 2 hours. There is also a mythical sword hidden in the Dark Woods. " +
            "What will you do?"),
        new Question(3, "3. What would you do on your first day of Hogwarts?"),
        new Question(4, "4. Who of these people do you trust the most?"),
        new Question(5, "5. There are 4 relics in front of you which one would you pick?"),
        new Question(6, "6. What is the first thing you do when you're in a Wizard's Duel?"),
        new Question(7, "7. You see that Frank is getting bullied by Devin, because Frank's parents are not wizards. What do you do?"),
        new Question(8, "8. You're competing in the Triwizard Tournament. In the first stage you need to obtain an egg of one of these dragons, which one would it be?"),
        new Question(9, "9. Which one of these clases do you like the most?"),
        new Question(10, "10. You got homework that needs to be done by tomorrow, but also you have a Quidditch match tomorrow. What do you do?"),
        new Question(11, "11. Which of these sports do you like the most"),
        new Question(12, "12. There are 4 potions in front of you, which one of these would you take?"),

    };

    /// <summary>
    /// Return answers
    /// </summary>
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

        new Answer(9, 3, "You try to make friends by talking to your fellow classmates.", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", -1}, {"Slytherin", 1} }),
        new Answer(10, 3, "You're curious about the lessons, so you start by going to the library.", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(11, 3, "You explore the castle and look for secrets it hides.", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", -1}, {"Slytherin", 1} }),
        new Answer(12, 3, "Stay in your common room and only make friends with the people of your house", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", -1}, {"Ravenclaw", 1}, {"Slytherin", 3} }),

        new Answer(13, 4, "Pomona Sprout", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(14, 4, "Minerva McGonagall", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", -1} }),
        new Answer(15, 4, "Severus Snape", new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),
        new Answer(16, 4, "Filius Flitwick", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 1} }),
        
        new Answer(17, 5, "A Wand that will make you the most powerful wizzard ever.", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", 2} }),
        new Answer(18, 5, "A book that grants you all the wisdom.", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 4}, {"Slytherin", -1} }),
        new Answer(19, 5, "A broomstick that will make you the fastest in the air.", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", 2} }),
        new Answer(20, 5, "A flask with water that makes you immortal", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 1}, {"Ravenclaw", 0}, {"Slytherin", 3} }),

        new Answer(21, 6, "You wait for your opponent to cast a spell first, but you're prepared to use Protego so get a shield that will deflect the opponents spell", 
            new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(22, 6, "you use Stupefy to stun your opponent.", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 1} }),
        new Answer(23, 6, "You use Everte Statum to throw your opponent backwards.",
            new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", -1}, {"Ravenclaw", 0}, {"Slytherin", 3} }),
        new Answer(24, 6, "You use Expelliarmus to disarm your opponent", new Dictionary<string, int> { {"Gryffindor", 0}, { "Hufflepuff", 3} , {"Ravenclaw", 2}, {"Slytherin", -1} }),

        new Answer(25, 7, "You don't want to get involved, so you ignore it and walk away.", 
            new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 1 } }),
        new Answer(26, 7, "Well Frank is a mudblood. So you ask Frank to get out of Hogwarts, because his blood isn't pure.", 
            new Dictionary<string, int> { {"Gryffindor", -1}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),
        new Answer(27, 7, "Stand up for Frank so you push Devin to the ground and tell him to leave Frank alone.",
            new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", -1}, {"Slytherin", 0} }),
        new Answer(28, 7, "You ask someone to get a teacher in case it escalates. Then you ask Devin to stop bullying Frank.", 
            new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", -1} }),

        new Answer(29, 8, "A Common Welsh Green, It prefers to prey mainly on sheep and other small mammals and to avoid human contact altogether", 
            new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 1}, {"Slytherin", 3} }),
        new Answer(30, 8, "A Chinese Fireball, The Fireball is aggressive but, unlike other dragons, it is more tolerant of its own kind, and will sometimes consent to share its territory ",
            new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 0} }),
        new Answer(31, 8, "A Hungarian Horntail, being one of the most vicious and aggressive breeds of dragon. This breed is especially aggressive when protecting their young.",
            new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 1} }),
        new Answer(32, 8, "A Swedish Short-Snout, It preferred to live in wild, uninhabited areas. Since it rarely came into contact with humans, the Short-Snout has least deaths.", 
            new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 0} }),

        new Answer(33, 9, "Astronomy", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 0}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(34, 9, "Charms", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", 1}, {"Slytherin", 0} }),
        new Answer(35, 9, "Dark Arts", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", -1}, {"Ravenclaw", 0}, {"Slytherin", 3} }),
        new Answer(36, 9, "Herbology", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", -1} }),

        new Answer(37, 10, "You do the homework you need to do now.", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 2}, {"Ravenclaw", 2}, {"Slytherin", 0} }),
        new Answer(38, 10, "You go to the training of Quidditch now, so you are ready for the match tomorrow.", new Dictionary<string, int> { {"Gryffindor", 2}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 2} }),

        new Answer(39, 11, "Quidditch", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 3}, {"Ravenclaw", 0}, {"Slytherin", 1} }),
        new Answer(40, 11, "The Triwizard Tournament", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 1}, {"Ravenclaw", -1}, {"Slytherin", 1} }),
        new Answer(41, 11, "Wizard's Chess", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 0} }),
        new Answer(42, 11, "Wizard's Duelling", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", 0}, {"Ravenclaw", -1}, {"Slytherin", 3} }),

        new Answer(43, 12, "Polyjuice potion (Shapeshifting potion)", new Dictionary<string, int> { {"Gryffindor", 3}, {"Hufflepuff", -1}, {"Ravenclaw", 0}, {"Slytherin", 1} }),
        new Answer(44, 12, "Invisibility potion", new Dictionary<string, int> { {"Gryffindor", 1}, {"Hufflepuff", 0}, {"Ravenclaw", 0}, {"Slytherin", 3} }),
        new Answer(45, 12, "Love potion", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 3}, {"Ravenclaw", 1}, {"Slytherin", 0} }),
        new Answer(46, 12, "Felix Felicis potion (Liquid Luck potion)", new Dictionary<string, int> { {"Gryffindor", 0}, {"Hufflepuff", 1}, {"Ravenclaw", 3}, {"Slytherin", 0} }),

    };

    /// <summary>
    /// Get all questions
    /// </summary>
    /// <returns>List<Question> questions</returns>
    public static List<Question> GetQuestions()
    {
        return Data.questions;
    }

    /// <summary>
    /// Get question's answers by question_id
    /// </summary>
    /// <param name="question_id"></param>
    /// <returns>List<Answer> answers</returns>
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

    /// <summary>
    /// Get single answer by answer_id
    /// </summary>
    /// <param name="answerId"></param>
    /// <returns>Answer answer</returns>
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

    /// <summary>
    /// Return list of highest house ids with same values
    /// </summary>
    /// <param name="points"></param>
    /// <returns>List<int> house ids</returns>
    public static List<int> GetHighestHouseIdsWithSameValue(int[] points)
    {
        int highestnumber = 0;
        int numberOfOccurances = 0;
        List<int> houseIds = new List<int>();

        // Set highest number
        foreach (int item in points)
        {
            if (item > highestnumber)
            {
                highestnumber = item;
            }
        }

        // Check if number appears multiple times
        int position = 0;
        foreach (int item in points)
        {
            position++;
            if (item == highestnumber)
            {
                numberOfOccurances++;
                houseIds.Add(position);
            }
        }

        return houseIds;
    }
}