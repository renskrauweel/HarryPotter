using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}