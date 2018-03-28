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

        public Question(int question_id, string question, int homework_id)
        {
            this.question_id = question_id;
            this.question = question;
            this.homework_id = homework_id;
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

        // Insert question into DB
        public void InsertQuestion()
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO questions (question, homework_id) VALUES (@0, @1)", this.question, this.homework_id);
        }
    }
}