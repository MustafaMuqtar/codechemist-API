using codechemist.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using codechemist.Data.Entities;

namespace codechemist.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Technology> Technologys { get; set; }
    }
}
