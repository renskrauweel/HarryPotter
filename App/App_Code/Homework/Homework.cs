using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace Homework
{
    /// <summary>
    /// Homework class in Homework namespace
    /// </summary>
    public class Homework
    {
        private int homework_id;
        private string homework_description;
        private int class_id;
        private DateTime deadline;
        private List<Question> questions = new List<Question>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="homework_id"></param>
        /// <param name="homework_description"></param>
        /// <param name="class_id"></param>
        /// <param name="deadline"></param>
        public Homework(int homework_id, string homework_description, int class_id, DateTime deadline)
        {
            this.homework_id = homework_id;
            this.homework_description = homework_description;
            this.class_id = class_id;
            this.deadline = deadline;

            // Fetch questions from DB
            AddQuestions();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Homework()
        {
            // Fetch questions from DB
            AddQuestions();
        }

        // Getters
        /// <summary>
        /// Return homework_id
        /// </summary>
        /// <returns>int homework_id</returns>
        public int GetHomeworkId()
        {
            return this.homework_id;
        }
        /// <summary>
        /// Return homework_description
        /// </summary>
        /// <returns>string homework_description</returns>
        public string GetHomeworkDescription()
        {
            return this.homework_description;
        }
        /// <summary>
        /// Return class_id
        /// </summary>
        /// <returns>int class_id</returns>
        public int GetClassId()
        {
            return this.class_id;
        }
        /// <summary>
        /// Return deadline
        /// </summary>
        /// <returns>Datetime deadline</returns>
        public DateTime GetDeadline()
        {
            return this.deadline;
        }
        public List<Question> GetQuestions()
        {
            return this.questions;
        }

        /// <summary>
        /// Add questions to homework
        /// </summary>
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

        /// <summary>
        /// Fetch the highest homework_id from DB
        /// </summary>
        /// <returns>int homework_id</returns>
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

        /// <summary>
        /// Insert homework into DB
        /// </summary>
        /// <param name="homework_description"></param>
        /// <param name="class_id"></param>
        /// <param name="deadline"></param>
        public static void InsertHomework(string homework_description, int class_id, DateTime deadline)
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO homework (homework_description, class_id, deadline) VALUES (@0, @1, @2)", homework_description, class_id, deadline);
            db.Dispose();
        }

        /// <summary>
        /// Fetch the homework from DB
        /// </summary>
        /// <param name="homeworkId"></param>
        /// <returns>Homework homework</returns>
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

        /// <summary>
        /// Set homework result
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="result"></param>
        public void SetResult(int user_id, int result)
        {
            var db = Database.Open("HarryPotter");
            var row = db.Execute("INSERT INTO homework_results (homework_id, user_id, results) VALUES (@0, @1, @2)", this.homework_id, user_id, result);
            db.Dispose();
        }

        /// <summary>
        /// Return if user finished homework
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns>bool homework is done</returns>
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

        /// <summary>
        /// Fetch result from homework
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns>int results</returns>
        public int GetResult(int user_id)
        {
            var db = Database.Open("HarryPotter");
            var row = db.QueryValue("SELECT results FROM homework_results WHERE user_id = @0 AND homework_id = @1", user_id, this.homework_id);
            db.Dispose();

            return (int)row;
        }
    }
}