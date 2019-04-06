using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ElearningApp.Data.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(11)]
        public string MaticNumber { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }

        public Student()
        {
            Enrolments = new Collection<Enrolment>();
        }
    }
}
