using System;
using System.Linq;
using System.Threading.Tasks;
using HSE.DAL.DbContext;
using HSE.DAL.Repositories.Abstract;
using HSE.DAL.Settings;
using HSE.DAL.ViewModels;
using HSE.Domain.Entities;
using System.DirectoryServices;

namespace HSE.DAL.Repositories.Concrete
{
    public class AuthenticateRepository : BaseRepository<Authenticate>, IAuthenticateRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        public AuthenticateRepository(HseDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Authenticate> Authenticate(LoginViewModel model, string remoteIpAddress)
        {
            var user = GetOracleUser(model);
            
            if (user != null)
            {
                bool isUserNull = ActiveDirectoryLogin(model);
                if (isUserNull == false)
                {
                    user = null;
                }
            }

           
            return Task.FromResult(user);
        }

        #region helperMethods

        private Authenticate GetOracleUser(LoginDomainModel model)
        {
            Authenticate user = null;
            
            if (_context.Set<Employee>().Any(e =>
                e.EmailAddress.ToLower() == model.Username.ToLower() && e.CurrentEmployeeFlag.Equals('Y')))
            {
                user = _context.Set<Employee>()
                    .Where(e => e.EmailAddress.ToLower() == model.Username.ToLower()
                                && e.CurrentEmployeeFlag.Equals('Y')).Select(e => new Authenticate
                                {
                                    Username = model.Username,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Fincode = e.NationalIdentifier,
                                    FatherName = e.Patronymic,
                                    UserOrgId = e.OrganizationId.ToString(),
                                    Position = e.JobName,
                                    PhoneNumber = string.IsNullOrEmpty(e.MobilePhone) ? "" : e.MobilePhone
                                }).First();
            }
            return user;
        }

        private bool ActiveDirectoryLogin(LoginDomainModel model)
        {
            string username = model.Username.Split("@")[0];
            string path = model.Username.Contains("@adyexpress") ? AppSettings.PathAdyExpress : AppSettings.Path;

            using var entry = new DirectoryEntry(path, username, model.Password);
            var searcher = new DirectorySearcher(entry)
            {
                Filter = "(objectclass=user)"
            };
            try
            {
                SearchResult ent = searcher.FindOne();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
        #endregion
    }
}
