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
    public class InstructionFormRepository:BaseRepository<InstructionForm>,IInstructionFormRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public InstructionFormRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<InstructionForm> Add(InstructionForm entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<InstructionForm> GetInstructionFormData(int id)
        {
            var result = await _context.Set<InstructionForm>().Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<ActiveFormsViewModel>> GetActiveForms(int userId,int userRoleId, string organizationIds,DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var activeFormsViewModels = new List<ActiveFormsViewModel>();

            await using var con = new SqlConnection(AppSettings.ConnectionString);
            con.Open();
            await using var cmd = new SqlCommand("SP_GET_ACTIVE_FORMS", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@page", jqueryDataTablesParameters.Start);
            cmd.Parameters.AddWithValue("@number", jqueryDataTablesParameters.Length);
            cmd.Parameters.AddWithValue("@formId", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("formId"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorUserId", userId);
            cmd.Parameters.AddWithValue("@instructionDate", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructionDate"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorOrganizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorOrganizationFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorPosition", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorPosition"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorTypeName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorTypeName"))?.Search.Value ?? DBNull.Value);

            if (jqueryDataTablesParameters.SortOrder == null)
            {
                cmd.Parameters.AddWithValue("@sortedColumn", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedColumn", jqueryDataTablesParameters.SortOrder.Split(' ')[0]);
            }
            if (jqueryDataTablesParameters.Order == null)
            {
                cmd.Parameters.AddWithValue("@sortedType", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedType", jqueryDataTablesParameters.Order[0].Dir.ToString());
            }
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);

            var reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    activeFormsViewModels.Add(new ActiveFormsViewModel
                    {
                        FormId = int.Parse(reader["ID"].ToString() ?? string.Empty),
                        InstructionDate = Convert.ToDateTime(reader["INSTRUCTION_DATE"]).ToString("dd/MM/yyyy"),
                        InstructorFullName = reader["INSTRUCTOR_FULL_NAME"].ToString(),
                        InstructorOrganizationFullName = reader["INSTRUCTOR_ORGANIZATION_FULL_NAME"].ToString(),
                        InstructorPosition = reader["INSTRUCTOR_POSITION"].ToString(),
                        InstructorTypeName = reader["INSTRUCTION_TYPE_NAME"].ToString(),
                        InstructionShortContent = reader["INSTRUCTOR_SHORT_CONTENT"].ToString(),
                        InstructionStatus = "Prosesdə"
                    });
                }
            }

            return activeFormsViewModels;
        }

        public async Task<int> GetActiveFormsTotalCount(int userId,int userRoleId,string organizationIds)
        {
            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_ACTIVE_FORMS_TOTAL_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@instructorUserId", userId);
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);
            var recordsTotalCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);

            return recordsTotalCount;
        }

        public async Task<int> GetActiveFormsFilteredCount(int instructorUserId,int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_ACTIVE_FORMS_FILTER_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@formId", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("formId"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@instructionDate", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructionDate"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorOrganizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorOrganizationFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorPosition", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorPosition"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorTypeName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorTypeName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);

            int filteredCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);
            return filteredCount;
        }

        public async Task<List<AllFormsForHistoryViewModel>> GetAllFormsForHistory(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            var allFormsForHistoryViewModels = new List<AllFormsForHistoryViewModel>();

            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_ALL_FORMS_FOR_HISTORY", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@page", jqueryDataTablesParameters.Start);
            cmd.Parameters.AddWithValue("@number", jqueryDataTablesParameters.Length);
            cmd.Parameters.AddWithValue("@formId", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("formId"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@instructionDate", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructionDate"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorOrganizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorOrganizationFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorPosition", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorPosition"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorTypeName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorTypeName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isActive", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("isActive"))?.Search.Value ?? DBNull.Value);

            if (jqueryDataTablesParameters.SortOrder == null)
            {
                cmd.Parameters.AddWithValue("@sortedColumn", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedColumn", jqueryDataTablesParameters.SortOrder.Split(' ')[0]);
            }
            if (jqueryDataTablesParameters.Order == null)
            {
                cmd.Parameters.AddWithValue("@sortedType", DBNull.Value);
            }
            else
            {
                string a = jqueryDataTablesParameters.Order[0].Dir.ToString();
                cmd.Parameters.AddWithValue("@sortedType", jqueryDataTablesParameters.Order[0].Dir.ToString());
            }
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);

            var reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    allFormsForHistoryViewModels.Add(new AllFormsForHistoryViewModel
                    {
                        FormId = int.Parse(reader["ID"].ToString() ?? string.Empty),
                        InstructionDate = Convert.ToDateTime(reader["INSTRUCTION_DATE"]).ToString("dd/MM/yyyy"),
                        InstructorFullName = reader["INSTRUCTOR_FULL_NAME"].ToString(),
                        InstructorOrganizationFullName = reader["INSTRUCTOR_ORGANIZATION_FULL_NAME"].ToString(),
                        InstructorPosition = reader["INSTRUCTOR_POSITION"].ToString(),
                        InstructorTypeName = reader["INSTRUCTION_TYPE_NAME"].ToString(),
                        InstructionShortContent = reader["INSTRUCTOR_SHORT_CONTENT"].ToString(),
                        IsActive = reader["IS_ACTIVE"].ToString()
                    });
                }
            }

            return allFormsForHistoryViewModels;
        }

        public async Task<int> GetAllFormsForHistoryTotalCount(int instructorUserId, int userRoleId, string organizationIds)
        {
            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_ALL_FORMS_FOR_HISTORY_TOTAL_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);
            var recordsTotalCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);

            return recordsTotalCount;
        }

        public async Task<int> GetAllFormsForHistoryFilteredCount(int instructorUserId, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_ALL_FORMS_FOR_HISTORY_FILTER_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@formId", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("formId"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@instructionDate", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructionDate"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorOrganizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorOrganizationFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorPosition", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorPosition"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorTypeName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorTypeName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isActive", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("isActive"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);

            int filteredCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString()?? string.Empty);
            return filteredCount;
        }

        public async Task<List<FormsReportViewModel>> GetFormsReport(int instructorUserId, string dateRange, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            DateTime startDateTime = DateTime.MinValue;
            DateTime endDateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(dateRange))
            {
                startDateTime = DateTime.ParseExact(dateRange.Split('-')[0].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                endDateTime = DateTime.ParseExact(dateRange.Split('-')[1].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            var formsReportViewModels = new List<FormsReportViewModel>();

            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_FORMS_REPORT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@page", jqueryDataTablesParameters.Start);
            cmd.Parameters.AddWithValue("@number", jqueryDataTablesParameters.Length);
            cmd.Parameters.AddWithValue("@startDate", startDateTime);
            cmd.Parameters.AddWithValue("@endDate", endDateTime);
            cmd.Parameters.AddWithValue("@formId", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("formId"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@instructionDate", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructionDate"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorOrganizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorOrganizationFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorPosition", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorPosition"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorTypeName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorTypeName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isActive", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("isActive"))?.Search.Value ?? DBNull.Value);

            if (jqueryDataTablesParameters.SortOrder == null)
            {
                cmd.Parameters.AddWithValue("@sortedColumn", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedColumn", jqueryDataTablesParameters.SortOrder.Split(' ')[0]);
            }
            if (jqueryDataTablesParameters.Order == null)
            {
                cmd.Parameters.AddWithValue("@sortedType", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@sortedType", jqueryDataTablesParameters.Order[0].Dir.ToString());
            }
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);

            var reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    formsReportViewModels.Add(new FormsReportViewModel
                    {
                        FormId = int.Parse(reader["ID"].ToString() ?? string.Empty),
                        InstructionDate = Convert.ToDateTime(reader["INSTRUCTION_DATE"]).ToString("dd/MM/yyyy"),
                        InstructorFullName = reader["INSTRUCTOR_FULL_NAME"].ToString(),
                        InstructorOrganizationFullName = reader["INSTRUCTOR_ORGANIZATION_FULL_NAME"].ToString(),
                        InstructorPosition = reader["INSTRUCTOR_POSITION"].ToString(),
                        InstructorTypeName = reader["INSTRUCTION_TYPE_NAME"].ToString(),
                        InstructionShortContent = reader["INSTRUCTOR_SHORT_CONTENT"].ToString(),
                        IsActive = reader["IS_ACTIVE"].ToString()
                    });
                }
            }
            return formsReportViewModels;
        }

        public async Task<int> GetFormsReportTotalCount(int instructorUserId, string dateRange, int userRoleId, string organizationIds)
        {
            DateTime startDateTime = DateTime.MinValue;
            DateTime endDateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(dateRange))
            {
                startDateTime = DateTime.ParseExact(dateRange.Split('-')[0].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                endDateTime = DateTime.ParseExact(dateRange.Split('-')[1].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_FORMS_REPORT_TOTAL_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@startDate", startDateTime);
            cmd.Parameters.AddWithValue("@endDate", endDateTime);
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);
            var recordsTotalCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);

            return recordsTotalCount;
        }

        public async Task<int> GetFormsReportFilteredCount(int instructorUserId, string dateRange, int userRoleId, string organizationIds, DataTableParamsModel.JqueryDataTablesParameters jqueryDataTablesParameters)
        {
            DateTime startDateTime = DateTime.MinValue;
            DateTime endDateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(dateRange))
            {
                startDateTime = DateTime.ParseExact(dateRange.Split('-')[0].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                endDateTime = DateTime.ParseExact(dateRange.Split('-')[1].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            await using var con = new SqlConnection(AppSettings.ConnectionString);
            await con.OpenAsync();
            await using var cmd = new SqlCommand("SP_GET_FORMS_REPORT_FILTER_COUNT", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = 0
            };
            cmd.Parameters.AddWithValue("@formId", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("formId"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@startDate", startDateTime);
            cmd.Parameters.AddWithValue("@endDate", endDateTime);
            cmd.Parameters.AddWithValue("@instructorUserId", instructorUserId);
            cmd.Parameters.AddWithValue("@instructionDate", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructionDate"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorOrganizationFullName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorOrganizationFullName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorPosition", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorPosition"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@instructorTypeName", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("instructorTypeName"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@isActive", (object)jqueryDataTablesParameters.Columns.FirstOrDefault(c => c.Data.Equals("isActive"))?.Search.Value ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@permitionTypeId", userRoleId);
            cmd.Parameters.AddWithValue("@child_orgs", organizationIds);

            int filteredCount = int.Parse((await cmd.ExecuteScalarAsync())?.ToString() ?? string.Empty);
            return filteredCount;
        }

        public async Task<InstructionForm> UpdateIsActiveByInstructionFormId(int instructionFormId)
        {
            var result = await _context.Set<InstructionForm>().Where(x => x.Id == instructionFormId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
