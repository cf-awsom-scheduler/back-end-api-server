using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A role model. </summary>
    /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public static class Role
    {
        public const string Admin = "admin";
        public const string User = "user";
    }
}