using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models
{
    [Table("TrialRequests")]

    public class TrialRequest
    {
        [Key, Required]
        public long Id { get; set; }
        [Required]
        public string ParentName { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string StudentBirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Instrument { get; set; }
        public string HasInstrument { get; set; }
        public string Availability { get; set; }
        public string Experience { get; set; }
        public string Notes { get; set; }
    }
}