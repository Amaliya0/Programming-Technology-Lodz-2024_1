﻿namespace PTProject.Presentation.Models
{
    public class ProcessState
    {
        public int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int GoodId { get; set; }
        public string Description { get; set; }
    }
}