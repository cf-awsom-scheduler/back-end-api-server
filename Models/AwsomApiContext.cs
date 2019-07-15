using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace awsomAPI.Models {
  public class AwsomApiContext : DbContext {
    public AwsomApiContext(DbContextOptions<AwsomApiContext> options) : base(options) {}
    public DbSet<User> Users { get; set; }
  }

}