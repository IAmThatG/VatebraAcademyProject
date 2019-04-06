using System;
namespace ElearningApp.Data.Entities
{
    public class Enrolment : BaseEntity
    {
        public long CourseId { get; set; }
        public long StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
