using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ElearningApp.Data.Entities;

namespace ELearnngApp.Domain.ApiResponseModels
{
    public class StudentResponse
    {
        public long Id;
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MaticNumber { get; set; }

        public ICollection<EnrolmentResponse> Enrolments { get; set; }

        public StudentResponse()
        {
            Enrolments = new Collection<EnrolmentResponse>();
        }
    }
}
