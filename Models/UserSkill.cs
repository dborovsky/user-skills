using System;
using System.Collections.Generic;

namespace user_skills.Models
{
    public class UserSkill
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; } 

        public DateTime CreatedAt { get; set; }
    }
}