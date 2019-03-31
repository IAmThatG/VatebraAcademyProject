using System;
namespace ElearningApp.Data.Entities
{
    public class Course : BaseEntity
    {
        public string CourseTitle { get; set; }

        public string CourseCode { get; set; }

        public string CourseDescription { get; set; }
    }
}
