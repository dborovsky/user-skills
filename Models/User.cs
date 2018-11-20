using System.Collections.Generic;

namespace user_skills.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }

        public List<UserSkill> UserSkills { get; set; }

        public User()
        {
            UserSkills = new List<UserSkill>();
        }
    }
}