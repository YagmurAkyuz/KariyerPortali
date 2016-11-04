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
    public interface ICountryService
    {
        IEnumerable<Country> Search(string search);
        IEnumerable<Country> GetCountries();
        Country GetCountry(int id);
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(Country country);
        void SaveCountry();
    }
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICountryService Members
        public IEnumerable<Country> Search(string search)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = GetCountries();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.CountryId.ToString().Contains(sSearch) || c.CountryName.Contains(sSearch));
                }
            }
            return query;

        }
        public IEnumerable<Country> GetCountries()
        {
            var countries = countryRepository.GetAll();
            return countries;
        }
        public Country GetCountry(int id)
        {
            var country = countryRepository.GetById(id);
            return country;
        }
        public void CreateCountry(Country country)
        {
            countryRepository.Add(country);
        }
        public void UpdateCountry(Country country)
        {
            countryRepository.Update(country);
        }
        public void DeleteCountry(Country country)
        {
            countryRepository.Delete(country);
        }
        public void SaveCountry()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
