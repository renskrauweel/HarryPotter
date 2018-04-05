using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Homework
{
    /// <summary>
    /// Question class in Homework namespace
    /// </summary>
    public class Question
    {
        private int question_id;
        private string question;
        private int homework_id;
        private List<Answer> answers = new List<Answer>();

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="question_id"></param>
        /// <param name="question"></param>
        /// <param name="homework_id"></param>
        public Question(int question_id, string question, int homework_id)
        {
            this.question_id = question_id;
            this.question = question;
            this.homework_id = homework_id;

            // Fetch answers from DB
            var db = Database.Open("HarryPotter");
            var rows = db.Query("SELECT * FROM answers WHERE question_id = @0 AND homework_id = @1", this.question_id, this.homework_id);
            db.Dispose();

            foreach (var row in rows)
            {
                int answerId = (int)row["answer_id"];
                int questionId = (int)row["question_id"];
                int points = (int)row["points"];
                int homeworkId = (int)row["homework_id"];
                this.answers.Add(new Answer(answerId, questionId, row["answer"], points, homeworkId));
            }
        }

        // Getters
        /// <summary>
        /// Return question_id
        /// </summary>
        /// <returns>int question_id</returns>
        public int GetQuestionId()
        {
            return this.question_id;
        }
        /// <summary>
        /// Return question
        /// </summary>
        /// <returns>string question</returns>
        public string GetQuestion()
        {
            return this.question;
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
        /// Return answers
        /// </summary>
        /// <returns>List<Answer> answers</returns>
        public List<Answer> GetAnswers()
        {
            return this.answers;
        }

        /// <summary>
        /// Insert question into DB
        /// </summary>
        public void InsertQuestion()
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO questions (question, homework_id) VALUES (@0, @1)", this.question, this.homework_id);

            db.Dispose();
        }

        /// <summary>
        /// Fetch highest question_id from DB
        /// </summary>
        /// <returns>int question_id</returns>
        public static int GetMaxQuestionId()
        {
            var db = Database.Open("HarryPotter");
            var row = db.QueryValue("SELECT MAX(question_id) FROM questions");
            db.Dispose();

            if (row.GetType() == typeof(DBNull))
                return 0;
            row = Convert.ToInt32(row);
            return row;
        }
    }
}