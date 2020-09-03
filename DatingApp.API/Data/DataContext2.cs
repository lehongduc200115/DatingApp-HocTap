using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DatingApp.API.Data
{
    public class DataContext2 : DbContext
    {
        public DataContext2(DbContextOptions options) : base(options)
        {}

        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos { get; set; }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        //     optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;Database=CustomerDB; Trusted_Connection=True;");
        //     optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        // }

        // public override int SaveChanges()
        // {
        //     var test = ChangeTracker.Entries();
        //     return base.SaveChanges();
        // }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Customer>()
        //         .HasOne(cus => cus.Groups)
        //         .WithMany(g => g.Customers)
        //         .HasForeignKey(FK => FK.GroupID);
        // }

    }
}