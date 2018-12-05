using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using user_skills.Models;


namespace user_skills
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = PrepairDB();
            Console.WriteLine("Комманды: list - вывод всех пользователей");
            Console.WriteLine("Комманды: first - вывод первого пользователя");
            Console.WriteLine("Введите комманду:");
            string command = Console.ReadLine();    
                
            switch(command)
            {
                case "list":
                    DisplayUsers(users);
                    break;
                case "first":
                    DisplayFirstUser(users);
                    break;
                default:
                    Console.WriteLine("Неверная комманда");
                    break; 
            }    
            
            Console.Read();    
        }

        static List<User> PrepairDB()
        {
            var db = new UserSkillContext();
            
            User u1 = new User { FullName = "Ivan Ivanov", UserId = 1};
            User u2 = new User { FullName = "Wladimir Putin", UserId = 2};
            db.Users.AddRange(new List<User> {u1, u2});
            
            Skill s1 = new Skill { Name = "Java", Id = 1};
            Skill s2 = new Skill { Name = "C++", Id = 2};
            db.Skills.AddRange(new List<Skill> {s1, s2});
            db.SaveChanges();

            u1.UserSkills.Add(new UserSkill { SkillId = s1.Id, CreatedAt = DateTime.Now });
            u1.UserSkills.Add(new UserSkill { SkillId = s2.Id, CreatedAt = DateTime.Now });
            u2.UserSkills.Add(new UserSkill { SkillId = s2.Id, CreatedAt = DateTime.Now });
            db.SaveChanges();

            var users = db.Users.ToList();
            
            return users;
        }

        static void DisplayUsers(List<User> users )
        {
            // выводим всех юзеров
                foreach (var user in users)
                {
                    Console.WriteLine($"\n Пользователь: {user.FullName}");
                    var skills = user.UserSkills.Select(u => new {u.Skill, u.CreatedAt}).ToList();
                    // выводим все скиллы конкретного юзера
                    foreach(var skill in skills)
                    {
                        Console.WriteLine("Скилл: {0}, Дата добавления: {1:U}", skill.Skill.Name, skill.CreatedAt);
                    }
                }
        }

        static void DisplayFirstUser(List<User> users)
        {
            var user = users.First();
            Console.WriteLine($"\n Пользователь: {user.FullName}");
        }
    }
}