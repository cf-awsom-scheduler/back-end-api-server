using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A student teacher selected relation. </summary>
    /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class StudentTeacherSelectedRelation
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        ///-------------------------------------------------------------------------------------------------

        [Key, Required]
        public long Id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the trial request. </summary>
        /// <value> The identifier of the trial request. </value>
        ///-------------------------------------------------------------------------------------------------

        public string TrialRequestId { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier of the teacher. </summary>
        /// <value> The identifier of the teacher. </value>
        ///-------------------------------------------------------------------------------------------------

        public string TeacherId { get; set; }
    }
}