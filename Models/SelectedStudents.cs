using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models
{
    public class StudentTeacherSelectedRelation
    {
        [Key, Required]
        public long Id { get; set; }
        public string TrialRequestId { get; set; }
        public string TeacherId { get; set; }
    }
}