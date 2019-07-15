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
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    //Morgana - Change this to enum with teacher (or user) and admin as the options
    //Default should be user
    public string Role { get; set; }
    public string Password { get; set; }
    [Required]
    public string Region { get; set; }
    public List<string> InstrumentsTaught { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int Zip { get; set; }
  }
}