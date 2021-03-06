﻿using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface ISkillService
    {
        IEnumerable<Skill> GetSkills();
        Skill GetSkill(int id);
        void CreateSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(Skill skill);
        void SaveSkill();
    }
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepository;
        private readonly IUnitOfWork unitOfWork;
        public SkillService(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISkillService Members
        public IEnumerable<Skill> GetSkills()
        {
            var skills = skillRepository.GetAll();
            return skills;
        }
        public Skill GetSkill(int id)
        {
            var skill = skillRepository.GetById(id);
            return skill;
        }
        public void CreateSkill(Skill skill)
        {
            skillRepository.Add(skill);
        }
        public void UpdateSkill(Skill skill)
        {
            skillRepository.Update(skill);
        }
        public void DeleteSkill(Skill skill)
        {
            skillRepository.Delete(skill);
        }
        public void SaveSkill()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
