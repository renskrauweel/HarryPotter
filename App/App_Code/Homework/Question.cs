using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Homework
{
    public class Question
    {
        private int question_id;
        private string question;
        private int homework_id;
        private List<Answer> answers = new List<Answer>();

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
        public int GetQuestionId()
        {
            return this.question_id;
        }
        public string GetQuestion()
        {
            return this.question;
        }
        public int GetHomeworkId()
        {
            return this.homework_id;
        }
        public List<Answer> GetAnswers()
        {
            return this.answers;
        }

        // Insert question into DB
        public void InsertQuestion()
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO questions (question, homework_id) VALUES (@0, @1)", this.question, this.homework_id);

            db.Dispose();
        }

        // Fetch highest question_id from DB
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