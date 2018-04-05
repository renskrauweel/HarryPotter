using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Homework
{
    /// <summary>
    /// Answer class in Homework namespace
    /// </summary>
    public class Answer
    {
        private int answer_id;
        private int question_id;
        private string answer;
        private int points;
        private int homework_id;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="answer_id"></param>
        /// <param name="question_id"></param>
        /// <param name="answer"></param>
        /// <param name="points"></param>
        /// <param name="homework_id"></param>
        public Answer(int answer_id, int question_id, string answer, int points, int homework_id)
        {
            this.answer_id = answer_id;
            this.question_id = question_id;
            this.answer = answer;
            this.points = points;
            this.homework_id = homework_id;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="question_id"></param>
        /// <param name="answer"></param>
        /// <param name="points"></param>
        /// <param name="homework_id"></param>
        public Answer(int question_id, string answer, int points, int homework_id)
        {
            this.question_id = question_id;
            this.answer = answer;
            this.points = points;
            this.homework_id = homework_id;
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
        /// <returns>int anwer_id</returns>
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
        /// Return points
        /// </summary>
        /// <returns>int points</returns>
        public int GetPoints()
        {
            return this.points;
        }
        /// <summary>
        /// Return homework_id
        /// </summary>
        /// <returns>int homework_id</returns>
        public int GetHomeworkId()
        {
            return this.homework_id;
        }

        /// <summary>
        /// Insert answer into DB
        /// </summary>
        public void InsertAnswer()
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO answers (question_id, answer, points, homework_id) VALUES (@0, @1, @2, @3)", this.question_id, this.answer, this.points, this.homework_id);

            db.Dispose();
        }

        /// <summary>
        /// Fetch all answers of homework
        /// </summary>
        /// <param name="homeworkId"></param>
        /// <returns>List<Answer> answers</returns>
        public static List<Answer> GetAnswers(int homeworkId)
        {
            var db = Database.Open("HarryPotter");
            var rows = db.Query("SELECT * FROM answers WHERE homework_id = @0", homeworkId);
            db.Dispose();

            List<Answer> answers = new List<Answer>();
            foreach (var row in rows)
            {
                int answerId = (int)row["answer_id"];
                int questionId = (int)row["question_id"];
                int points = (int)row["points"];
                answers.Add(new Answer(answerId, questionId, row["answer"], points, homeworkId));
            }

            return answers;
        }

        /// <summary>
        /// Fetch answer points
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns>int answer_id</returns>
        public static int GetAnswerPoints(int answerId)
        {
            var db = Database.Open("HarryPotter");
            var row = db.QueryValue("SELECT points FROM answers WHERE answer_id = @0", answerId);
            db.Dispose();

            return (int)row;
        }
    }
}