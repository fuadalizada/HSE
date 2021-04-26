﻿using System.Threading.Tasks;
using HSE.Business.DTOs;

namespace HSE.Business.Services.Abstract
{
    public interface IEmployeeService:IBaseService<EmployeeDto>
    {
        Task<int> GetOrganizationIdByFincode(string fincode);
    }
}
