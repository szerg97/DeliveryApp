﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company> GetCompany(string companyId);
    }
}
