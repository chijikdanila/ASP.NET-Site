using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHIZHIK.Entities;

namespace WEB_953502_CHIZHIK.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.BookGroups.Any())
            {
                context.BookGroups.AddRange(
                new List<BookGroup>
                {
                    new BookGroup {GroupName="Роман"},
                    new BookGroup {GroupName="Фэнтези"},
                    new BookGroup {GroupName="Детектив"},
                    new BookGroup {GroupName="Приключения"},
                    new BookGroup {GroupName="Ужасы"}
                });
                await context.SaveChangesAsync();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                new List<Book>
                {
                    new Book {BookName="Три мушкетера", Author="Александр Дюма", Price = 12, BookGroupId= 4, Image="Images/Три-мушкетера.jpg" },
                    new Book {BookName="Приключения Шерлока Холмса", Author="Артур Конан Дойл", Price = 20, BookGroupId= 3, Image="Images/Шерлок-Холмс.jpg" },
                    new Book {BookName="Оно", Author="Стивен Кинг", Price = 15, BookGroupId= 5, Image="Images/Оно.jpg" },
                    new Book {BookName="Ведьмак: Час Презрения", Author="Анджей Сапковский", Price = 12, BookGroupId= 2, Image="Images/Ведьмак.jpg" },
                    new Book {BookName="Мастер и Маргарита", Author="Михаил Булкагов", Price = 10, BookGroupId= 1, Image="Images/Мастер-и-Маргарита.jpg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
