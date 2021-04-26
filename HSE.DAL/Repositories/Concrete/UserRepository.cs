using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.DAL.Settings;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HSE.DAL.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public UserRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserInfoByUserId(int userId)
        {
            var result = await _context.Set<User>().Where(x => x.Id == userId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> GetUserIdByFincode(string fincode)
        {
            var result = await _context.Set<User>().Where(x => x.Fincode == fincode).FirstOrDefaultAsync();
            return result.Id;
        }

        public async Task<List<WorkerInformationViewModel>> GetWorkerInformations(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            List<WorkerInformationViewModel> workerInformationViewModels = new List<WorkerInformationViewModel>();

            await using SqlConnection con = new SqlConnection(AppSettings.ConnectionString);
            con.Open();
            await using SqlCommand cmd = new SqlCommand("SP_GET_WORKER_INFORMATIONS", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@page", jqueryDataTablesParameters.Start);
            cmd.Parameters.AddWithValue("@number", jqueryDataTablesParameters.Length);
            cmd.Parameters.AddWithValue("@firstName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("firstName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@lastName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("lastName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@patronymicName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("patronymicName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@jobName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("jobName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@organizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("organizationFullName"))?.Search.Value ?? DBNull.Value);

            if (jqueryDataTablesParameters.SortOrder == null)
            {
                cmd.Parameters.AddWithValue("@sortedColumn", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedColumn", jqueryDataTablesParameters.SortOrder);
            }
            if (jqueryDataTablesParameters.Order == null)
            {
                cmd.Parameters.AddWithValue("@sortedType", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedType", jqueryDataTablesParameters.Order[0].Dir.ToString());
            }

            var reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    workerInformationViewModels.Add(new WorkerInformationViewModel
                    {
                        UserId = int.Parse(reader["ID"].ToString() ?? string.Empty),
                        FirstName = reader["FIRST_NAME"].ToString(),
                        LastName = reader["LAST_NAME"].ToString(),
                        PatronymicName = reader["PATRONYMIC"].ToString(),
                        JobName = reader["JOB_NAME"].ToString(),
                        OrganizationFullName = reader["ORGANIZATION_FULL_NAME"].ToString(),
                    });
                }
            }

            return workerInformationViewModels;
        }

        public async Task<int> GetWorkerInformationsTotalCount()
        {
            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_WORKER_INFORMATIONS_TOTAL_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            var recordsTotalCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);

            return recordsTotalCount;
        }

        public async Task<int> GetWorkerInformationsFilteredCount(DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {


            await using SqlConnection con = new SqlConnection(AppSettings.ConnectionString);
            con.Open();
            await using SqlCommand cmd = new SqlCommand("SP_GET_WORKER_INFORMATIONS_FILTER_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@firstName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("FirstName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@lastName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("LastName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@patronymicName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("PatronymicName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@jobName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("JobName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@organizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("OrganizationFullName"))?.Search.Value ?? DBNull.Value);

            int filteredCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);
            return filteredCount;
        }

        public async Task<bool> CheckFincodeAndEmpUserId(string fincode,int employeeUserId)
        {
            var result = await _context.Set<User>().AnyAsync(x => x.Fincode == fincode & x.Id == employeeUserId);
            return result;
        }
    }
}
