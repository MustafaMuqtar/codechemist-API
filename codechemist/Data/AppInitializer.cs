using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using codechemist.Data.Entities;
using codechemist.Models;

namespace codechemist.Data
{
    public class AppInitializer
    {



        public static async Task SeedUserManager(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
            {
                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();



                if (!_userManager.Users.Any())
                {
                    var user = new User
                    {
                        UserName = "mustafa",
                        Email = "mustafa@gmail.com"
                    };

                    await _userManager.CreateAsync(user, "mustafa123");
                    await _userManager.AddToRoleAsync(user, "Member");

                    var admin = new User
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com"
                    };

                    await _userManager.CreateAsync(admin, "mustafa123");
                    await _userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
                }
            }
        }



        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();


                await _dbContext.Database.EnsureCreatedAsync();
                if (!await _dbContext.Technologys.AnyAsync())
                {
                    await _dbContext.Technologys.AddRangeAsync(new List<Technology>()

                    {
                        new Technology
                        {
                            Title = "Javascript Syntax",
                            Image= "https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/800px-Unofficial_JavaScript_logo_2.svg.png"
                        },
                              new Technology
                        {
                            Title = "C# Syntax",
                            Image= "https://seeklogo.com/images/C/c-sharp-c-logo-02F17714BA-seeklogo.com.png"
                        }
                    });





                    await _dbContext.SaveChangesAsync();
                }


                if (!await _dbContext.Lessons.AnyAsync())
                {
                    await _dbContext.Lessons.AddRangeAsync(new List<Lesson>()

                    {
                        new Lesson
                        {
                            Title = "Lektion 1",
                            TechnologyId=1
                        },

                    });





                    await _dbContext.SaveChangesAsync();
                }

                if (!await _dbContext.Subjects.AnyAsync())
                {
                    await _dbContext.Subjects.AddRangeAsync(new List<Subject>()

                    {
                        new Subject
                        {
                            Title = "Hur man skapar ett Javascript project",
                            Content= "https://drive.google.com/file/d/1gma4xeP2_fUYex_GZ_1iPz-ZhbEkSV4k/view?usp=sharing",
                            LessonId=4
                        },

                    });

                    await _dbContext.SaveChangesAsync();
                }




            }
        }




    }
}


