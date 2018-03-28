using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Homework
{
    public class Answer
    {
        private int answer_id;
        private int question_id;
        private string answer;
        private int points;

        public Answer(int answer_id, int question_id, string answer, int points)
        {
            this.answer_id = answer_id;
            this.question_id = question_id;
            this.answer = answer;
            this.points = points;
        }

        public Answer(int question_id, string answer, int points)
        {
            this.question_id = question_id;
            this.answer = answer;
            this.points = points;
        }

        public Answer()
        {

        }

        // Getters
        public int GetAnswerId()
        {
            return this.answer_id;
        }
        public int GetQuestionId()
        {
            return this.question_id;
        }
        public string GetAnswer()
        {
            return this.answer;
        }
        public int GetPoints()
        {
            return this.points;
        }

        // Insert answer into DB
        public void InsertAnswer()
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO answers (question_id, answer, points) VALUES (@0, @1, @2)", this.question_id, this.answer, this.points);
        }
    }
}