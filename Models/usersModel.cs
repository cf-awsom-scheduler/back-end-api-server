using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models {
  [Table("Users")]
  public class User {        
    [Key, Required]
    public long Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    //Morgana - Change this to enum with teacher (or user) and admin as the options
    //Default should be user
    public string Role { get; set; }
  }
}