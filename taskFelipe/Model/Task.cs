﻿namespace taskFelipe.Model
{
    public class Task
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public bool? completed_at { get; set; }

        public bool? created_at { get; set; }

        public bool? updated_at { get; set; }   

    }
}
