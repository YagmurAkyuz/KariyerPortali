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
    public interface IResumeService
    {
        IEnumerable<Resume> GetResumes();
        Resume GetResume(int id);
        void CreateResume(Resume resume);
        void SaveResume();
    }
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository resumeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ResumeService(IResumeRepository resumeRepository, IUnitOfWork unitOfWork)
        {
            this.resumeRepository = resumeRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IResumeService Members
        public IEnumerable<Resume> GetResumes()
        {
            var cvs = resumeRepository.GetAll();
            return cvs;
        }

        public Resume GetResume(int id)
        {
            var cv = resumeRepository.GetById(id);
            return cv;
        }

        public void CreateResume(Resume resume)
        {
            resumeRepository.Add(resume);
        }
        public void UpdateResume(Resume resume)
        {
            resumeRepository.Update(resume);
        }
        public void DeleteResume(Resume resume)
        {
            resumeRepository.Delete(resume);
        }

        public void SaveResume()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
    
}
