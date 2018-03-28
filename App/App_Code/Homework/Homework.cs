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

        public Homework(int homework_id, string homework_description, int class_id)
        {
            this.homework_id = homework_id;
            this.homework_description = homework_description;
            this.class_id = class_id;
        }

        public static int GetMaxHomeworkId()
        {
            var db = Database.Open("HarryPotter");

            var row = db.QueryValue("SELECT MAX(homework_id) FROM homework");
            if (row.GetType() == typeof(DBNull))
            {
                return 0;
            }
            row = Convert.ToInt32(row);
            return row;
        }

        // Insert homework into DB
        public static void InsertHomework(string homework_description, int class_id)
        {
            var db = Database.Open("HarryPotter");

            var row = db.Execute("INSERT INTO homework (homework_description, class_id) VALUES (@0, @1)", homework_description, class_id);
        }
    }
}