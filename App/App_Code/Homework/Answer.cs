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
        private int homework_id;

        public Answer(int answer_id, int question_id, string answer, int points, int homework_id)
        {
            this.answer_id = answer_id;
            this.question_id = question_id;
            this.answer = answer;
            this.points = points;
            this.homework_id = homework_id;
        }

        public Answer(int question_id, string answer, int points, int homework_id)
        {
            this.question_id = question_id;
            this.answer = answer;
            this.points = points;
            this.homework_id = homework_id;
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
        public int GetHomeworkId()
        {
            return this.homework_id;
        }

        // Insert answer into DB
        public void InsertAnswer()
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO answers (question_id, answer, points, homework_id) VALUES (@0, @1, @2, @3)", this.question_id, this.answer, this.points, this.homework_id);

            db.Dispose();
        }
    }
}