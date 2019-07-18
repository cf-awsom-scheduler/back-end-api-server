///-------------------------------------------------------------------------------------------------
// file:	Models\AwsomApiContext.cs
//
// summary:	Implements the awsom API context class
///-------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


///-------------------------------------------------------------------------------------------------
// namespace: awsomAPI.Models
//
// summary:	.
///-------------------------------------------------------------------------------------------------

namespace awsomAPI.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An awsom API context. </summary>
    ///
    /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class AwsomApiContext : DbContext
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="options">  Options for controlling the operation. </param>
        ///-------------------------------------------------------------------------------------------------

        public AwsomApiContext(DbContextOptions<AwsomApiContext> options) : base(options) { }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the users. </summary>
        ///
        /// <value> The users. </value>
        ///-------------------------------------------------------------------------------------------------

        public DbSet<User> Users { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the trial requests. </summary>
        ///
        /// <value> The trial requests. </value>
        ///-------------------------------------------------------------------------------------------------

        public DbSet<TrialRequest> TrialRequests { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the teacher selections. </summary>
        ///
        /// <value> The teacher selections. </value>
        ///-------------------------------------------------------------------------------------------------

        public DbSet<StudentTeacherSelectedRelation> TeacherSelections { get; set; }
    }

}