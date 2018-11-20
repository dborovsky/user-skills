using System;
using System.Collections.Generic;
using System.Data;

namespace user_skills.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserSkill> UserSkills { get; set; }

        public Skill()
        {
            UserSkills = new List<UserSkill>();
        }
    }
}