using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A trial request. </summary>
    /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [Table("TrialRequests")]
    public class TrialRequest
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        ///-------------------------------------------------------------------------------------------------

        [Key, Required]
        public long Id { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the parent. </summary>
        /// <value> The name of the parent. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string ParentName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the name of the student. </summary>
        /// <value> The name of the student. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string StudentName { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the student birth date. </summary>
        /// <value> The student birth date. </value>
        ///-------------------------------------------------------------------------------------------------

        public string StudentBirthDate { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the email. </summary>
        /// <value> The email. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string Email { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the phone. </summary>
        /// <value> The phone. </value>
        ///-------------------------------------------------------------------------------------------------

        public string Phone { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the address. </summary>
        /// <value> The address. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string Address { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the city. </summary>
        /// <value> The city. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string City { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the zip code. </summary>
        /// <value> The zip code. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string ZipCode { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the region. </summary>
        /// <value> The region. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string Region { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the instrument. </summary>
        /// <value> The instrument. </value>
        ///-------------------------------------------------------------------------------------------------

        [Required]
        public string Instrument { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the has instrument. </summary>
        /// <value> The has instrument. </value>
        ///-------------------------------------------------------------------------------------------------

        public string HasInstrument { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the availability. </summary>
        /// <value> The availability. </value>
        ///-------------------------------------------------------------------------------------------------

        public string Availability { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the experience. </summary>
        /// <value> The experience. </value>
        ///-------------------------------------------------------------------------------------------------

        public string Experience { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the notes. </summary>
        /// <value> The notes. </value>
        ///-------------------------------------------------------------------------------------------------

        public string Notes { get; set; }
    }
}