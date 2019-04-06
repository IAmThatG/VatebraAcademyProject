using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ElearningApp.Data.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string CourseTitle { get; set; }

        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; }

        public string CourseDescription { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }

        public Course()
        {
            Enrolments = new Collection<Enrolment>();
        }
    }
}
