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

        public Homework(int homework_id, string homework_description, int class_id, DateTime deadline)
        {
            this.homework_id = homework_id;
            this.homework_description = homework_description;
            this.class_id = class_id;
            this.deadline = deadline;
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

        // Fetch the highest homework_id from DB
        public static int GetMaxHomeworkId()
        {
            var db = Database.Open("HarryPotter");

            var row = db.QueryValue("SELECT MAX(homework_id) FROM homework");
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
        }
    }
}