using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Homework
{
    public class Homework
    {
        private int homework_id;
        private string homework_description;
        private int class_id;
        private DateTime deadline;
        private List<Question> questions = new List<Question>();

        public Homework(int homework_id, string homework_description, int class_id, DateTime deadline)
        {
            this.homework_id = homework_id;
            this.homework_description = homework_description;
            this.class_id = class_id;
            this.deadline = deadline;

            // Fetch questions from DB
            AddQuestions();
        }
        public Homework()
        {
            // Fetch questions from DB
            AddQuestions();
        }

        // Getters
        public int GetHomeworkId()
        {
            return this.homework_id;
        }
        public string GetHomeworkDescription()
        {
            return this.homework_description;
        }
        public int GetClassId()
        {
            return this.class_id;
        }
        public DateTime GetDeadline()
        {
            return this.deadline;
        }
        public List<Question> GetQuestions()
        {
            return this.questions;
        }

        // Add questions to homework
        private void AddQuestions()
        {
            var db = Database.Open("HarryPotter");
            var rows = db.Query("SELECT * FROM questions WHERE homework_id = @0", this.homework_id);
            db.Dispose();

            foreach (var row in rows)
            {
                int questionId = (int)row["question_id"];
                int homeworkId = (int)row["homework_id"];
                this.questions.Add(new Question(questionId, row["question"], homeworkId));
            }
        }

        // Fetch the highest homework_id from DB
        public static int GetMaxHomeworkId()
        {
            var db = Database.Open("HarryPotter");

            var row = db.QueryValue("SELECT MAX(homework_id) FROM homework");
            db.Dispose();
            if (row.GetType() == typeof(DBNull))
                return 0;
            row = Convert.ToInt32(row);
            return row;
        }

        // Insert homework into DB
        public static void InsertHomework(string homework_description, int class_id, DateTime deadline)
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO homework (homework_description, class_id, deadline) VALUES (@0, @1, @2)", homework_description, class_id, deadline);
            db.Dispose();
        }

        // Fetch the homework from DB
        public static Homework GetHomework(int homeworkId)
        {
            var db = Database.Open("HarryPotter");
            var row = db.QuerySingle("SELECT * FROM homework WHERE homework_id = @0", homeworkId);
            db.Dispose();

            Homework homework = new Homework();
            if (row != null)
            {
                int classId = (int)row["class_id"];
                DateTime deadline = (DateTime)row["deadline"];
                homework = new Homework(homeworkId, row["homework_description"], classId, deadline);
            }

            return homework;
        }

        // Set homework result
        public void SetResult(int user_id, int result)
        {
            var db = Database.Open("HarryPotter");
            var row = db.Execute("INSERT INTO homework_results (homework_id, user_id, results) VALUES (@0, @1, @2)", this.homework_id, user_id, result);
            db.Dispose();
        }

        // Return if user finished homework
        public bool HomeworkDone(int user_id)
        {
            var db = Database.Open("HarryPotter");
            var row = db.QueryValue("SELECT COUNT(*) FROM homework_results WHERE user_id = @0 AND homework_id = @1", user_id, this.homework_id);
            db.Dispose();

            if ((int)row > 0)
            {
                return true;
            }
            return false;
        }

        // Fetch result from homework
        public int GetResult(int user_id)
        {
            var db = Database.Open("HarryPotter");
            var row = db.QueryValue("SELECT results FROM homework_results WHERE user_id = @0 AND homework_id = @1", user_id, this.homework_id);
            db.Dispose();

            return (int)row;
        }
    }
}